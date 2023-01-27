using Application.Commands.ChatCommands;
using Application.Queries.ChatQueries;
using AutoMapper;
using ManagementTool.API.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace ManagementTool.API.Controllers
{
    [Route("api/Users/{userId}/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ChatsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPrivate(int userId)
        {
            var chats = await _mediator.Send(new GetChatsQuery { UserId = userId });
            var chatsDto = _mapper.Map<List<ChatDto>>(chats);
            return Ok(chatsDto);
        }

        [HttpPost]
        [Route("{chatId}")]
        public async Task<IActionResult> AddMessage(int chatId, [FromBody]string message, int userId)
        {
            var chat = await _mediator.Send(new SendMessageCommand
            {
                ChatId = chatId,
                Content = message,
                SenderId = userId
            });

            var chatDto = _mapper.Map<GetChatDto>(chat);
            return Ok(chatDto);
        }

        [HttpGet]
        [Route("{chatId}")]
        public async Task<IActionResult> GetById(int chatId)
        {
            var chat = await _mediator.Send(new GetChatQuery { Id = chatId });
            if (chat == null)
                return NotFound();
            var chatDto = _mapper.Map<GetChatDto>(chat);
            return Ok(chatDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] int receiverId,int userId)
        {
                var createdChat = await _mediator.Send(new CreatePrivateChatCommand
                {
                    SenderId = userId,
                    ReceiverId = receiverId
                });

                var createdChatDto = _mapper.Map<GetChatDto>(createdChat);

                return CreatedAtAction(nameof(GetById), new { chatId = createdChatDto.Id }, createdChatDto);
        }
    }
}
