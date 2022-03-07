using LibrairiePoc.Infra;
using LibrairiePoc.Infra.Ports.Primary;
using LibrairiePoc.Infra.Ports.Secondary;
using LibrairiePoc.UsesCase.Ports.Secondary;
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
            services.AddTransient<IBookRepository, BookRepositoryEF>();
            services.AddTransient<BookRepositoryEF>();
            services.AddTransient<GettingBookAdapter<MainWindowViewModel>>(container => new GettingBookAdapter<MainWindowViewModel>(new ViewModelBookPResenter(), container.GetService<IBookRepository>()));
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainWindowViewModel>(c => c.GetRequiredService<GettingBookAdapter<MainWindowViewModel>>().GetBooks(1, 10));
            serviceProvider = services.BuildServiceProvider();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

    }
}
