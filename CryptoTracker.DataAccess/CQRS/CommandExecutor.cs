using CryptoTracker.DataAccess.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly CryptoStorageContext context;
        public CommandExecutor(CryptoStorageContext context)
        {
            this.context = context;
        }
        public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
        {
            return command.Execute(context);
        }
    }
}
