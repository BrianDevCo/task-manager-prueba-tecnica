using AutoMapper;
using TaskManager.Core.DTOs;
using TaskManager.Core.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskManager.Core.Mappings;

public class TaskMappingProfile : Profile
{
    public TaskMappingProfile()
    {
        CreateMap<Task, TaskDto>();
        CreateMap<CreateTaskDto, Task>();
        CreateMap<UpdateTaskDto, Task>();
    }
}