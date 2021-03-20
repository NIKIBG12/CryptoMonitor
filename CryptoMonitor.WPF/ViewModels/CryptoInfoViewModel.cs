using CryptoMonitor.Domain.Models;
using CryptoMonitor.Domain.Services;
using CryptoMonitor.EntityFramework;
using CryptoMonitor.WPF.Models;
using CryptoMonitor.WPF.Widgets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace CryptoMonitor.WPF.ViewModels
{

    public class CryptoInfoViewModel : ViewModelBase
    {
        private readonly ICryptoInfoService _cryptoInfoService;
        private static CryptoInfoViewModel cryptoInfoViewModel;
        private readonly IDataService<CryptoCurrency> _cryptoCurrencyService;
        private Timer timer;
        List<CryptoWidget> Labels = new List<CryptoWidget>();


        private CryptoWidget _BTC;
        public CryptoWidget BTC
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
        private CryptoWidget _ETH;
        public CryptoWidget ETH
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
        private CryptoWidget _BNB;
        public CryptoWidget BNB
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
        private CryptoWidget _USDT;
        public CryptoWidget USDT
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
        private CryptoWidget _ADA;
        public CryptoWidget ADA
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
        private CryptoWidget _DOT;
        public CryptoWidget DOT
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
        private CryptoWidget _XRP;
        public CryptoWidget XRP
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
        private CryptoWidget _UNI;
        public CryptoWidget UNI
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
        private CryptoWidget _LTC;
        public CryptoWidget LTC
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
        private CryptoWidget _LINK;
        public CryptoWidget LINK
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
            BTC = new CryptoWidget("BTC");
            ETH = new CryptoWidget("ETH");
            BNB = new CryptoWidget("BNB");
            USDT = new CryptoWidget("USDT");
            ADA = new CryptoWidget("ADA");
            DOT = new CryptoWidget("DOT");
            XRP = new CryptoWidget("XRP");
            UNI = new CryptoWidget("UNI");
            LTC = new CryptoWidget("LTC");
            LINK = new CryptoWidget("LINK");
            Labels.Add(BTC);
            Labels.Add(ETH);
            Labels.Add(BNB);
            Labels.Add(USDT);
            Labels.Add(ADA);
            Labels.Add(DOT);
            Labels.Add(XRP);
            Labels.Add(UNI);
            Labels.Add(LTC);
            Labels.Add(LINK);
            timer = new(new TimerCallback(GetInfo), null, 0, 5000);
        }
        public static CryptoInfoViewModel LoadCryptoInfoViewModel(ICryptoInfoService cryptoInfoService, IDataService<CryptoCurrency> cryptoCurrencyService)
        {
            if (cryptoInfoViewModel == null)
            {
                cryptoInfoViewModel = new CryptoInfoViewModel(cryptoInfoService, cryptoCurrencyService);
            }
            return cryptoInfoViewModel;
        }

        private async void GetInfo(object state)
        {
            List<CryptoCurrency> cryptoCurrencies = (List<CryptoCurrency>)await _cryptoCurrencyService.GetAll();
            List<CryptoWidget> widgets = new();

            foreach (var crypto in cryptoCurrencies)
            {

                CryptoInfo info = await _cryptoInfoService.GetCryptoInfo((CryptoType)crypto.Id - 1);
                CryptoWidget widget = new(info.Ticker.Base);
                widget.Name = info.Ticker.Base;
                widget.Price = info.Ticker.Price;
                widget.Change = Math.Round((info.Ticker.Price - crypto.CurrentPrice), 2);
                if(widget.Change > 0)
                {
                    widget.Color = "Green";
                }
                else if(widget.Change < 0)
                {
                    widget.Color = "Red";
                }
                else
                {
                    widget.Color = "#faff78";
                }

                widgets.Add(widget);
                crypto.CurrentPrice = info.Ticker.Price;
                await _cryptoCurrencyService.Update(crypto.Id, crypto);

            }

            Dispatcher.CurrentDispatcher.Invoke(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    var widget = Labels[i];
                    var update = widgets[i];
                    widget.Name = update.Name;
                    widget.Price = update.Price;
                    widget.Change = update.Change;
                    widget.Color = update.Color;
                }
            });


        }
    }
    }

