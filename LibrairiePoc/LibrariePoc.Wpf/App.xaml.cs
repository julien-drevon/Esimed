using LibrairiePoc.Infra;
using LibrairiePoc.Infra.Ports.Controller;
using LibrairiePoc.Infra.Ports.Controller;
using LibrairiePoc.UsesCase.Ports.Gateway;
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
            services.AddTransient<IBookGateway, BookRepositoryEF>();
            services.AddTransient<BookRepositoryEF>();
            services.AddTransient<GettingBookApplicationController<MainWindowViewModel>>(container => new GettingBookApplicationController<MainWindowViewModel>(new ViewModelBookPResenter(), container.GetService<IBookGateway>()));
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainWindowViewModel>(c => c.GetRequiredService<GettingBookApplicationController<MainWindowViewModel>>().GetBooks(1, 10));
            serviceProvider = services.BuildServiceProvider();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

    }
}
