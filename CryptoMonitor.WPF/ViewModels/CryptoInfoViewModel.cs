using CryptoMonitor.Domain.Models;
using CryptoMonitor.Domain.Services;
using CryptoMonitor.EntityFramework;
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
        private readonly IDataService<CryptoCurrency> _cryptoCurrencyService;
        //List<CryptoInfo> Labels = new List<CryptoInfo>();

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

        public CryptoInfoViewModel(ICryptoInfoService cryptoInfoService, IDataService<CryptoCurrency> cryptoCurrencyService)
        {
            _cryptoInfoService = cryptoInfoService;
            _cryptoCurrencyService = cryptoCurrencyService;
            //Labels.Add(BTC);
            //Labels.Add(ETH);
            //Labels.Add(BNB);
            //Labels.Add(USDT);
            //Labels.Add(ADA);
            //Labels.Add(DOT);
            //Labels.Add(XRP);
            //Labels.Add(UNI);
            //Labels.Add(LTC);
            //Labels.Add(LINK);
        }
        public static CryptoInfoViewModel LoadCryptoInfoViewModel(ICryptoInfoService cryptoInfoService, IDataService<CryptoCurrency> cryptoCurrencyService)
        {
            if (cryptoInfoViewModel == null)
            {
                cryptoInfoViewModel = new CryptoInfoViewModel(cryptoInfoService, cryptoCurrencyService);
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
            //List<CryptoCurrency> cryptoCurrencies = null;
            //_cryptoCurrencyService.GetAll().ContinueWith(task =>
            //{
            //    if (task.Exception == null)
            //    {
            //        cryptoCurrencies = (List<CryptoCurrency>)task.Result;
            //    }
            //});
            //if (cryptoCurrencies != null)
            //{
            //    foreach (var crypto in cryptoCurrencies)
            //    {

            //        _cryptoInfoService.GetCryptoInfo((CryptoType)crypto.Id - 1).ContinueWith(task =>
            //        {
            //            double currentPrice = crypto.CurrentPrice;
            //            if (task.Exception == null)
            //            {
            //                switch (crypto.Id)
            //                {
            //                    case 1:
            //                        BTC = task.Result;
            //                        break;
            //                    default:
            //                        break;
            //                }
            //                currentPrice = task.Result.Ticker.Price;

            //            }
            //            crypto.CurrentPrice = currentPrice;
            //            _cryptoCurrencyService.Update(crypto.Id, crypto);
            //        });
            //    }
            //}

            CryptoCurrency crypto = null;
            _cryptoCurrencyService.Get(1).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    crypto = task.Result;
                }
            });
            _cryptoInfoService.GetCryptoInfo(CryptoType.BTC).ContinueWith(task =>
             {
                 if (crypto != null)
                 {
                     double currentPrice = crypto.CurrentPrice;
                     if (task.Exception == null)
                     {
                         BTC = task.Result;
                         currentPrice = task.Result.Ticker.Price;

                     }
                     crypto.CurrentPrice = currentPrice;
                     _cryptoCurrencyService.Update(1, crypto);

                 }

             });

            CryptoCurrency crypto2 = null;
            _cryptoCurrencyService.Get(2).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    crypto2 = task.Result;
                }
            });
            _cryptoInfoService.GetCryptoInfo(CryptoType.ETH).ContinueWith(task =>
            {
                if (crypto2 != null)
                {
                    double currentPrice = crypto2.CurrentPrice;
                    if (task.Exception == null)
                    {
                        ETH = task.Result;
                        currentPrice = task.Result.Ticker.Price;

                    }
                    crypto2.CurrentPrice = currentPrice;
                    _cryptoCurrencyService.Update(2, crypto2);

                }
            });

            CryptoCurrency crypto3 = null;
            _cryptoCurrencyService.Get(3).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    crypto3 = task.Result;
                }
            });
            _cryptoInfoService.GetCryptoInfo(CryptoType.BNB).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    if (crypto3 != null)
                    {
                        double currentPrice = crypto3.CurrentPrice;
                        if (task.Exception == null)
                        {
                            BNB = task.Result;
                            currentPrice = task.Result.Ticker.Price;

                        }
                        crypto3.CurrentPrice = currentPrice;
                        _cryptoCurrencyService.Update(3, crypto3);

                    }
                }
            });

            CryptoCurrency crypto4 = null;
            _cryptoCurrencyService.Get(4).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    crypto4 = task.Result;
                }
            });
            _cryptoInfoService.GetCryptoInfo(CryptoType.USDT).ContinueWith(task =>
            {
                if (crypto4 != null)
                {
                    double currentPrice = crypto4.CurrentPrice;
                    if (task.Exception == null)
                    {
                        USDT = task.Result;
                        currentPrice = task.Result.Ticker.Price;

                    }
                    crypto4.CurrentPrice = currentPrice;
                    _cryptoCurrencyService.Update(4, crypto4);

                }
            });

            CryptoCurrency crypto5 = null;
            _cryptoCurrencyService.Get(5).ContinueWith(task =>
                {
                    if (task.Exception == null)
                    {
                        crypto5 = task.Result;
                    }
                });
            _cryptoInfoService.GetCryptoInfo(CryptoType.ADA).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    if (crypto5 != null)
                    {
                        double currentPrice = crypto5.CurrentPrice;
                        if (task.Exception == null)
                        {
                            ADA = task.Result;
                            currentPrice = task.Result.Ticker.Price;

                        }
                        crypto5.CurrentPrice = currentPrice;
                        _cryptoCurrencyService.Update(5, crypto5);

                    }
                }
            });

            CryptoCurrency crypto6 = null;
            _cryptoCurrencyService.Get(6).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    crypto6 = task.Result;
                }
            });
            _cryptoInfoService.GetCryptoInfo(CryptoType.DOT).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    if (crypto6 != null)
                    {
                        double currentPrice = crypto6.CurrentPrice;
                        if (task.Exception == null)
                        {
                            DOT = task.Result;
                            currentPrice = task.Result.Ticker.Price;

                        }
                        crypto6.CurrentPrice = currentPrice;
                        _cryptoCurrencyService.Update(6, crypto6);

                    }
                }
            });

            CryptoCurrency crypto7 = null;
            _cryptoCurrencyService.Get(7).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    crypto7 = task.Result;
                }
            });
            _cryptoInfoService.GetCryptoInfo(CryptoType.XRP).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    if (crypto7 != null)
                    {
                        double currentPrice = crypto7.CurrentPrice;
                        if (task.Exception == null)
                        {
                            XRP = task.Result;
                            currentPrice = task.Result.Ticker.Price;

                        }
                        crypto7.CurrentPrice = currentPrice;
                        _cryptoCurrencyService.Update(7, crypto7);

                    }
                }
            });

            CryptoCurrency crypto8 = null;
            _cryptoCurrencyService.Get(8).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    crypto8 = task.Result;
                }
            });
            _cryptoInfoService.GetCryptoInfo(CryptoType.UNI).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    if (crypto8 != null)
                    {
                        double currentPrice = crypto8.CurrentPrice;
                        if (task.Exception == null)
                        {
                            UNI = task.Result;
                            currentPrice = task.Result.Ticker.Price;

                        }
                        crypto8.CurrentPrice = currentPrice;
                        _cryptoCurrencyService.Update(8, crypto8);

                    }
                }
            });

            CryptoCurrency crypto9 = null;
            _cryptoCurrencyService.Get(9).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    crypto9 = task.Result;
                }
            });
            _cryptoInfoService.GetCryptoInfo(CryptoType.LTC).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    if (crypto9 != null)
                    {
                        double currentPrice = crypto9.CurrentPrice;
                        if (task.Exception == null)
                        {
                            LTC = task.Result;
                            currentPrice = task.Result.Ticker.Price;

                        }
                        crypto9.CurrentPrice = currentPrice;
                        _cryptoCurrencyService.Update(9, crypto9);

                    }
                }
            });

            CryptoCurrency crypto10 = null;
            _cryptoCurrencyService.Get(10).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    crypto10 = task.Result;
                }
            });
            _cryptoInfoService.GetCryptoInfo(CryptoType.LINK).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    if (crypto10 != null)
                    {
                        double currentPrice = crypto10.CurrentPrice;
                        if (task.Exception == null)
                        {
                            LINK = task.Result;
                            currentPrice = task.Result.Ticker.Price;

                        }
                        crypto10.CurrentPrice = currentPrice;
                        _cryptoCurrencyService.Update(10, crypto10);

                    }
                }
            });
        }
    }
}

