using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.Models;
using CryptoTracker.ApplicationServices.API.Domain.User.Add;
using CryptoTracker.ApplicationServices.API.Domain.User.Delete;
using CryptoTracker.ApplicationServices.API.Domain.User.Put;
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

            this.CreateMap<PutUserRequest, DataAccess.Entities.User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Nick, y => y.MapFrom(z => z.Nick));

            this.CreateMap<AddUserRequest, DataAccess.Entities.User>()
                .ForMember(x => x.Nick, y => y.MapFrom(z => z.Nick));

            this.CreateMap<DataAccess.Entities.User, User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Nick, y => y.MapFrom(z => z.Nick));
        }
    }
}
