using System;
using System.Windows;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        [STAThread]
        public static void Main()
        {
            var app = new Application();
            app.Run(new MainWindow());
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
    }
}
