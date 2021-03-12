using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            this.CreateMap<DeleteUserRequest, DataAccess.Entities.User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.UserId));

            this.CreateMap<PutUserByIdRequest, DataAccess.Entities.User>()
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Position, y => y.MapFrom(z => z.Position))
                .ForMember(x => x.Workplace, y => y.MapFrom(z => z.Workplace));

            this.CreateMap<AddUserRequest, DataAccess.Entities.User>()
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Position, y => y.MapFrom(z => z.Position))
                .ForMember(x => x.Workplace, y => y.MapFrom(z => z.Workplace));

            this.CreateMap<DataAccess.Entities.User, User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Position, y => y.MapFrom(z => z.Position))
                .ForMember(x => x.Workplace, y => y.MapFrom(z => z.Workplace));
        }
    }
}
