﻿using CryptoMonitor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.Domain.Services
{
    public interface ICryptoInfoService
    {
        Task<CryptoInfo> GetCryptoInfo(CryptoType cryptoType);
    }
}
