using CommunityToolkit.Mvvm.ComponentModel;
using LibrairiePoc.Infra.Ports.Gateway;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibrariePoc.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow(MainWindowViewModel model)
        {
            this.Model = model;
            InitializeComponent();
            DataContext = Model;

        }

        public MainWindowViewModel Model { get; set; }
    }

    public class MainWindowViewModel
    {
        public ObservableCollection<BookViewModel> Books { get; set; } = new ObservableCollection<BookViewModel>();
    }

    public class BookViewModel
    {
        public string Author { get; set; }

        public string Title { get; set; }
    }
}
