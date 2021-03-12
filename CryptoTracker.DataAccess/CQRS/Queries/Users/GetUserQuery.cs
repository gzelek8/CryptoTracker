using CryptoTracker.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess.CQRS.Queries.Users
{
    class GetUserQuery : QueryBase<User>
    {
        public int Id { get; set; }
        public override async Task<User> Execute(CryptoStorageContext context)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Id == this.Id);
        }
    }
}
