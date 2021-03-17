using CryptoMonitor.Domain.Models;
using CryptoMonitor.Domain.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace CryptoMonitor.WPF.ViewModels 
{

    public class CryptoInfoViewModel : ViewModelBase
    {
        private readonly ICryptoInfoService _cryptoInfoService;
        private static CryptoInfoViewModel cryptoInfoViewModel;

        private CryptoInfo _BTC;
        public CryptoInfo BTC
        {
            get
            {
                return _BTC;
            }
            set
            {
                _BTC = value;
                OnPropertyChange(nameof(BTC));
            }
        }
        private CryptoInfo _ETH;
        public CryptoInfo ETH
        {
            get
            {
                return _ETH;
            }
            set
            {
                _ETH = value;
                OnPropertyChange(nameof(ETH));
            }
        }
        private CryptoInfo _BNB;
        public CryptoInfo BNB
        {
            get
            {
                return _BNB;
            }
            set
            {
                _BNB = value;
                OnPropertyChange(nameof(BNB));
            }
        }
        private CryptoInfo _USDT;
        public CryptoInfo USDT
        {
            get
            {
                return _USDT;
            }
            set
            {
                _USDT = value;
                OnPropertyChange(nameof(USDT));
            }
        }
        private CryptoInfo _ADA;
        public CryptoInfo ADA
        {
            get
            {
                return _ADA;
            }
            set
            {
                _ADA = value;
                OnPropertyChange(nameof(ADA));
            }
        }
        private CryptoInfo _DOT;
        public CryptoInfo DOT
        {
            get
            {
                return _DOT;
            }
            set
            {
                _DOT = value;
                OnPropertyChange(nameof(DOT));
            }
        }
        private CryptoInfo _XRP;
        public CryptoInfo XRP
        {
            get
            {
                return _XRP;
            }
            set
            {
                _XRP = value;
                OnPropertyChange(nameof(XRP));
            }
        }
        private CryptoInfo _UNI;
        public CryptoInfo UNI
        {
            get
            {
                return _UNI;
            }
            set
            {
                _UNI = value;
                OnPropertyChange(nameof(UNI));
            }
        }
        private CryptoInfo _LTC;
        public CryptoInfo LTC
        {
            get
            {
                return _LTC;
            }
            set
            {
                _LTC = value;
                OnPropertyChange(nameof(LTC));
            }
        }
        private CryptoInfo _LINK;
        public CryptoInfo LINK
        {
            get
            {
                return _LINK;
            }
            set
            {
                _LINK = value;
                OnPropertyChange(nameof(LINK));
            }
        }

        public CryptoInfoViewModel(ICryptoInfoService cryptoInfoService)
        {
            _cryptoInfoService = cryptoInfoService;
        }

        public static CryptoInfoViewModel LoadCryptoInfoViewModel(ICryptoInfoService cryptoInfoService)
        {
            if(cryptoInfoViewModel == null)
            {
                cryptoInfoViewModel = new CryptoInfoViewModel(cryptoInfoService);
                cryptoInfoViewModel.LoadCryptoInfoService();
            }
            return cryptoInfoViewModel;
        }



        private void LoadCryptoInfoService()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Tick += new EventHandler(GetInfo);
            dispatcherTimer.Start();
       
        }
        private void GetInfo(object sender, EventArgs e)
        {
            _cryptoInfoService.GetCryptoInfo(CryptoType.BTC).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    BTC = task.Result;
                }
            });
            _cryptoInfoService.GetCryptoInfo(CryptoType.ETH).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    ETH = task.Result;
                }
            });
            _cryptoInfoService.GetCryptoInfo(CryptoType.BNB).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    BNB = task.Result;
                }
                _cryptoInfoService.GetCryptoInfo(CryptoType.USDT).ContinueWith(task =>
                {
                    if (task.Exception == null)
                    {
                        USDT = task.Result;
                    }
                });

            });
            _cryptoInfoService.GetCryptoInfo(CryptoType.ADA).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    ADA = task.Result;
                }
            });
            _cryptoInfoService.GetCryptoInfo(CryptoType.DOT).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    DOT = task.Result;
                }
            });
            _cryptoInfoService.GetCryptoInfo(CryptoType.XRP).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    XRP = task.Result;
                }
            });
            _cryptoInfoService.GetCryptoInfo(CryptoType.UNI).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    UNI = task.Result;
                }
            });
            _cryptoInfoService.GetCryptoInfo(CryptoType.LTC).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    LTC = task.Result;
                }
            });
            _cryptoInfoService.GetCryptoInfo(CryptoType.LINK).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    LINK = task.Result;
                }
            });
        }

    }
}

