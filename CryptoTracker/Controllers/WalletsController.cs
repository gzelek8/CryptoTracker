using CryptoTracker.DataAccess;
using CryptoTracker.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalletsController : ControllerBase
    {
        private readonly IRepository<Wallet> walletRepository;

        public WalletsController(IRepository<Wallet> walletRepository)
        {
            this.walletRepository = walletRepository;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Wallet> GetAllWallets() => this.walletRepository.GetAll();
        [HttpGet]
        [Route("{walletId}")]
        public Wallet GetWalletById(int walletId) => this.walletRepository.GetById(walletId);
    }
}
