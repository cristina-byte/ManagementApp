using Application.Commands.ChatCommands;
using Application.Queries.ChatQueries;
using AutoMapper;
using Domain.Entities;
using ManagementTool.API.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
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

        [HttpDelete]
        [Route("{chatId}")]
        public async Task<IActionResult> Delete(int chatId)
        {

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Chat chat)
        {
            return Ok();
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
            var chatDto = _mapper.Map<GetChatDto>(chat);
            return Ok(chatDto);
        }
    }
}
