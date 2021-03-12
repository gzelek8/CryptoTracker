using CryptoTracker.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess.CQRS.Queries.Users
{
    class GetUsersQuery : QueryBase<List<User>>
    {
        public string Nick { get; set; }
        public override async Task<List<User>> Execute(CryptoStorageContext context)
        {
            if (!string.IsNullOrEmpty(Nick))
            {
                return await context.Users.Where(x => x.Nick.Contains(this.Nick)).ToListAsync();
            }
            else
            {
                return await context.Users.ToListAsync();
            }        
        }
    }
}
