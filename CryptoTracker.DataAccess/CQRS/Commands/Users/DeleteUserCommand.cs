using CryptoTracker.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess.CQRS.Commands.Users
{
    public class DeleteUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(CryptoStorageContext context)
        {
            context.Users.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;

        }
    }
}
