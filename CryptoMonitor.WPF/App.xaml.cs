using CryptoMonitor.Domain.Models;
using CryptoMonitor.Domain.Services;
using CryptoMonitor.EntityFramework;
using CryptoMonitor.EntityFramework.Services;
using CryptoMonitor.WPF.State;
using CryptoMonitor.WPF.State.Navigators;
using CryptoMonitor.WPF.ViewModels;
using CryptoMonitor.WPF.ViewModels.Factories;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoMonitor.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void  OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();
            //IAccountService accountService = new AccountDataService(new EntityFramework.CryptoDbContextFactory());
            //ICryptoPriceService cryptoPriceService = new CryptoPriceService();
            //IInvestService investService = new InvestService(cryptoPriceService, accountService);

            //Account investor = await accountService.Get(1);
            //await investService.Invest(investor, "BTC", 1);

            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();
            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<CryptoDbContextFactory>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IAccountService, AccountDataService>();
            services.AddSingleton<ICryptoInfoService, CryptoInfoService>();
            services.AddSingleton<ICryptoCurrencyService, CryptoCurrencyService>();
            services.AddSingleton<ICryptoPriceService, CryptoPriceService>();
            services.AddSingleton<IInvestService, InvestService>();

            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            services.AddSingleton<ICryptoMonitorViewModelAbstract, CryptoMonitorViewModelAbstract>();
            services.AddSingleton<InvestViewModel>();

            services.AddSingleton<ProfileViewModel>();
            services.AddSingleton<HomeViewModel>(services => new HomeViewModel(CryptoInfoViewModel
                   .LoadCryptoInfoViewModel(services.GetRequiredService<ICryptoInfoService>(), services.GetRequiredService<ICryptoCurrencyService>())));

            services.AddSingleton<CreateViewModel<HomeViewModel>>(services =>
           {
               return () => services.GetRequiredService<HomeViewModel>();
           });

            services.AddSingleton<CreateViewModel<ProfileViewModel>>(services =>
            {
                return () => new ProfileViewModel();
            });

            services.AddSingleton<ViewModelRenavigator<HomeViewModel>>();
            services.AddSingleton<ViewModelRenavigator<RegisterViewModel>>();
            services.AddSingleton<ViewModelRenavigator<LoginViewModel>>();
            services.AddSingleton<ViewModelRenavigator<InvestViewModel>>();
            services.AddSingleton<CreateViewModel<RegisterViewModel>>(services => 
            {
                return () => new RegisterViewModel(services.GetRequiredService<IAuthenticator>(), services.GetRequiredService<ViewModelRenavigator<LoginViewModel>>(), services.GetRequiredService<ViewModelRenavigator<LoginViewModel>>()); 
            });

            services.AddSingleton<CreateViewModel<LoginViewModel>>(services =>
            {
                return () => new LoginViewModel
                (services.GetRequiredService<IAuthenticator>(), services.GetRequiredService<ViewModelRenavigator<HomeViewModel>>(), services.GetRequiredService<ViewModelRenavigator<RegisterViewModel>>());
            });

            services.AddSingleton<CreateViewModel<InvestViewModel>>(services =>
            {
                return () => services.GetRequiredService<InvestViewModel>();
            });

            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<IAccountStore, AccountStore>();
            services.AddScoped<MainViewModel>();
            services.AddScoped<InvestViewModel>();

            services.AddScoped<MainWindow>(a => new MainWindow(a.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}
