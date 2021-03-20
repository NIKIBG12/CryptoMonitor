using CryptoMonitor.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.WPF.Widgets
{
        public class CryptoWidget : ObservableObject
        {
            private string _name;
            public string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;
                    OnPropertyChange(nameof(Name));
                }
            }
            private double _price;
            public double Price
            {
                get
                {
                    return _price;
                }
                set
                {
                    _price = value;
                    OnPropertyChange(nameof(Price));
                }
            }


        private double _change;

        public double Change
        {
            get
            {
                return _change;
            }
            set
            {
                _change = value;
                OnPropertyChange(nameof(Change));
            }
        }

        private string _color;

        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                OnPropertyChange(nameof(Color));
            }
        }

        public CryptoWidget(string name)
        {
            this.Name = name;
            this.Price = 0.0;
            this.Change = 0.0;
            this.Color = "#faff78";
        }
        }
}
