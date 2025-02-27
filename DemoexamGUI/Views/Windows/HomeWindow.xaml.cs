using DemoexamGUI.AppData;
using DemoexamGUI.Views.Pages;
using System.Windows;

namespace DemoexamGUI.Views.Windows
{
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();

            HomeObjects.frameHome = frame;
            frame.Navigate(new HomePage());
        }
    }
}