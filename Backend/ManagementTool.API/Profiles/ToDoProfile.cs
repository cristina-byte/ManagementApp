using AutoMapper;
using Domain.TeamEntities;
using ManagementTool.API.Dto.TeamDtos;
using Task = Domain.TeamEntities.Task;

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
