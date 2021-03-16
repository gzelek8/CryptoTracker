using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.Models;
using CryptoTracker.ApplicationServices.API.Domain.Wallet.Add;
using CryptoTracker.ApplicationServices.API.Domain.Wallet.Delete;
using CryptoTracker.ApplicationServices.API.Domain.Wallet.Put;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Profiles
{
    public class WalletsProfile : Profile
    {
        public WalletsProfile()
        {
            this.CreateMap<DeleteWalletRequest, DataAccess.Entities.Wallet>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

            this.CreateMap<PutWalletRequest, DataAccess.Entities.Wallet>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId));

            this.CreateMap<AddWalletRequest, DataAccess.Entities.Wallet>()
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId));

            this.CreateMap<DataAccess.Entities.Wallet, Wallet>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId));
        }
    }
}
