using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.Cryptocurrency.Add;
using CryptoTracker.ApplicationServices.API.Domain.Cryptocurrency.Delete;
using CryptoTracker.ApplicationServices.API.Domain.Cryptocurrency.Put;
using CryptoTracker.ApplicationServices.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Profiles
{
    public class CryptocurrenciesProfile : Profile
    {
        public CryptocurrenciesProfile()
        {
            this.CreateMap<DeleteCryptocurrencyRequest, DataAccess.Entities.Cryptocurrency>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.CryptocurrencyId));

            this.CreateMap<PutCryptocurrencyRequest, DataAccess.Entities.Cryptocurrency>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.CryptocurrencyId))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Rank, y => y.MapFrom(z => z.Rank))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price));


            this.CreateMap<AddCryptocurrencyRequest, DataAccess.Entities.Cryptocurrency>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Rank, y => y.MapFrom(z => z.Rank))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price));

            this.CreateMap<DataAccess.Entities.Cryptocurrency, Cryptocurrency>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Rank, y => y.MapFrom(z => z.Rank))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price));
        }
    }
}
