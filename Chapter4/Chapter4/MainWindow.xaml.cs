using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Controls.Primitives;


namespace Chapter4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Title = "Bind the button";
            BindTheButton();
        }
        public void BindTheButton()
        {
            ToggleButton btn = new ToggleButton();
            btn.Content = "TO _Tompost";
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.SetBinding(ToggleButton.IsCheckedProperty, "Topmost");
            btn.DataContext = this;
            Content = btn;

            ToolTip tip = new ToolTip();
            tip.Content = "toggle the button on to make " + "the window topmost on the destop";
            btn.ToolTip = tip;

        }

    }
}
