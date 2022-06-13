using LibrairiePoc.Infra;
using LibrairiePoc.Infra.Ports.Gateway;
using LibrairiePoc.Infra.Ports.Controller;
using LibrairiePoc.UsesCase.Ports.Controller;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LibrariePoc.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public App()
        {
            var services = new ServiceCollection();
            services.AddDbContext<DbContext, BooksContext>(c => c.UseInMemoryDatabase("bookContextTests"));
            services.AddTransient<IBookStorage, BookRepositoryEF>();
            services.AddTransient<BookRepositoryEF>();
            services.AddTransient<GettingBookGateway<MainWindowViewModel>>(container => new GettingBookGateway<MainWindowViewModel>(new ViewModelBookPResenter(), container.GetService<IBookStorage>()));
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainWindowViewModel>(c => c.GetRequiredService<GettingBookGateway<MainWindowViewModel>>().GetBooks(1, 10));
            serviceProvider = services.BuildServiceProvider();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

    }
}
