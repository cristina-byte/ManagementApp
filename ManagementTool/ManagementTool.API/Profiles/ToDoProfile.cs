using AutoMapper;
using Domain.Entities.TeamEntities;
using ManagementTool.API.Dto.TeamDtos;
using Task = Domain.Entities.TeamEntities.Task;

namespace ManagementTool.API.Profiles
{
    public class ToDoProfile:Profile
    {
        public ToDoProfile()
        {
            CreateMap<ToDo, ToDoListDto>();
            CreateMap<Task, TaskDto>();
        }

    }
}
