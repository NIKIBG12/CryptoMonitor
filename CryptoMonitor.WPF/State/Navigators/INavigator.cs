﻿using CryptoMonitor.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoMonitor.WPF.State.Navigators
{
    public enum ViewType
    {
        Home,
        Profile
    }
    public interface INavigator
    {
       
        ViewModelBase CurrentViewModel { get; set; }

        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
