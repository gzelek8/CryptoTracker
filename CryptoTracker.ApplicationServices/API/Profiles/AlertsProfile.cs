using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.Alert.Add;
using CryptoTracker.ApplicationServices.API.Domain.Alert.Delete;
using CryptoTracker.ApplicationServices.API.Domain.Alert.Put;
using CryptoTracker.ApplicationServices.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Profiles
{
    class AlertsProfile : Profile
    {
        public AlertsProfile()
        {
            this.CreateMap<DeleteAlertRequest, DataAccess.Entities.Alert>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.AlertId));

            this.CreateMap<PutAlertRequest, DataAccess.Entities.Alert>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.AlertId))
                .ForMember(x => x.PriceAlert, y => y.MapFrom(z => z.PriceAlert))
                .ForMember(x => x.CryptocurrencyId, y => y.MapFrom(z => z.CryptocurrencyId));


            this.CreateMap<AddAlertRequest, DataAccess.Entities.Alert>()
                .ForMember(x => x.PriceAlert, y => y.MapFrom(z => z.PriceAlert))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
                .ForMember(x => x.CryptocurrencyId, y => y.MapFrom(z => z.CryptocurrencyId));

            this.CreateMap<DataAccess.Entities.Alert, Alert>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.PriceAlert, y => y.MapFrom(z => z.PriceAlert))
                .ForMember(x => x.CryptocurrencyId, y => y.MapFrom(z => z.CryptocurrencyId))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId));
      
        }
    }
}
