using System;
using System.Windows;
using System.Windows.Threading;
using WpfApp1.ViewModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mvm { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            mvm = new(this);
            DataContext = mvm;
        }
    }
}
