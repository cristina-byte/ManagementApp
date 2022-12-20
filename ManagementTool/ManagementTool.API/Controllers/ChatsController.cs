using Application.Queries.ChatQueries;
using AutoMapper;
using Domain.Entities;
using ManagementTool.API.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementTool.API.Controllers
{
    [Route("api/users/{id}/[controller]")]
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
        public async Task<IActionResult> GetAllPrivate(int id)
        {
            var chats = await _mediator.Send(new GetChatsQuery { UserId = id });
            //var chatsDto = _mapper.Map<List<ChatDto>>(chats);
            return Ok(chats);
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

        [HttpGet]
        [Route("{chatId}/messages")]
        public async Task<IActionResult> GetMessages(int chatId)  //this can be a private or a group chat for a team
        {
            var messages = await _mediator.Send(new GetMessagesQuery { ChatId = chatId });
            var messagesDto = _mapper.Map<List<MessageDto>>(messages);

            return Ok(messagesDto);
        }
    }
}
