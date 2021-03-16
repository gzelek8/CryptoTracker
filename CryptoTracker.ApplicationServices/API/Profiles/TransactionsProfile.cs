using AutoMapper;
using CryptoTracker.ApplicationServices.API.Domain.Models;
using CryptoTracker.ApplicationServices.API.Domain.Transaction.Add;
using CryptoTracker.ApplicationServices.API.Domain.Transaction.Delete;
using CryptoTracker.ApplicationServices.API.Domain.Transaction.Put;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Profiles
{
    public class TransactionsProfile : Profile
    {
        public TransactionsProfile()
        {
            this.CreateMap<DeleteTransactionRequest, DataAccess.Entities.Transaction>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

            this.CreateMap<PutTransactionRequest, DataAccess.Entities.Transaction>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.CryptocurrencyId, y => y.MapFrom(z => z.CryptocurrencyId))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
                .ForMember(x => x.Date, y => y.MapFrom(z => z.Date))
                .ForMember(x => x.CryptoAmout, y => y.MapFrom(z => z.CryptoAmout));


            this.CreateMap<AddTransactionRequest, DataAccess.Entities.Transaction>()
                .ForMember(x => x.CryptocurrencyId, y => y.MapFrom(z => z.CryptocurrencyId))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
                .ForMember(x => x.Date, y => y.MapFrom(z => z.Date))
                .ForMember(x => x.CryptoAmout, y => y.MapFrom(z => z.CryptoAmout));

            this.CreateMap<DataAccess.Entities.Transaction, Transaction>()
                .ForMember(x => x.Id , y => y.MapFrom(z => z.Id))
                .ForMember(x => x.CryptoAmout, y => y.MapFrom(z => z.CryptoAmout))
                .ForMember(x => x.CryptocurrencyId, y => y.MapFrom(z => z.CryptocurrencyId))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
                .ForMember(x => x.Date, y => y.MapFrom(z => z.Date));
        }
    }
}
