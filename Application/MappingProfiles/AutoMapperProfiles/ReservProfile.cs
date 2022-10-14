using Application.DTO.Request.ReservControllerRequest;
using Application.DTO.Response.ReservControllerResponse;
using AutoMapper;
using Domain.Entities;

namespace Application.MappingProfiles.AutoMapperProfiles
{
    public class ReservProfile:Profile
    {
        public ReservProfile()
        {
            CreateMap<NewReservReqModel, Reserv>().AfterMap((newR, r) => r.Id = Guid.NewGuid());
            CreateMap<Reserv, UserReservsResModel>().ForMember(id => id.Id, opt=>opt.MapFrom(id=>id.Id));
        }
    }
}
