using PlannerClosedXML.ViewModel;
using System.Windows;

namespace PlannerClosedXML
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    }
}