using CryptoMonitor.WPF.State.Navigators;
using System;
using System.Windows.Input;

namespace CryptoMonitor.WPF.Commands
{
    public class RenavigateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly IReNavigator _renavigator;

        public RenavigateCommand(IReNavigator renavigator)
        {
            _renavigator = renavigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _renavigator.Renavigate();
        }
    }
}
