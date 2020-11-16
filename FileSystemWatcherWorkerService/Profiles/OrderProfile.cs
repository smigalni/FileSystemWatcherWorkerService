using AutoMapper;
using FileSystemWatcherWorkerService.DtoModels;
using FileSystemWatcherWorkerService.Models;

namespace FileSystemWatcherWorkerService.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
               .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
               ;

            CreateMap<OrderDto, Order>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
              .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
              ;
        }
    }
}
