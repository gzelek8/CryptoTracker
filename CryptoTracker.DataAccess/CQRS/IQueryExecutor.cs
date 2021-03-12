using CryptoTracker.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess.CQRS
{
    public interface IQuerryExecutor
    {
        Task<TResult> Execute<TResult>(QueryBase<TResult> query);

    }
}
