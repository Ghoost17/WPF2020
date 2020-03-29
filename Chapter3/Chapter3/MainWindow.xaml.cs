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
using System.Windows.Shapes;

namespace Chapter3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            ToggleBoldAndItalic();
            
        }
         void RunOnMouseDown(object sender, MouseButtonEventArgs args)
            {
                Run run = sender as Run;

                if (args.ChangedButton == MouseButton.Left)
                    run.FontStyle = run.FontStyle == FontStyles.Italic ?
                        FontStyles.Normal : FontStyles.Italic;

                if (args.ChangedButton == MouseButton.Right)
                    run.FontWeight = run.FontWeight == FontWeights.Bold ?
                        FontWeights.Normal : FontWeights.Bold;

            }
        public void ToggleBoldAndItalic()
        {
            Title = " Toggle and bold & Italic";
            TextBlock text = new TextBlock();
            text.FontSize = 32;
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Center;
            Content = text;

            string strQ = "Yes or no? I don't know.";
            string[] strW = strQ.Split();

            foreach(string str in strW)
            {
                Run run = new Run(str);
                run.MouseDown += RunOnMouseDown;
                text.Inlines.Add(run);
                text.Inlines.Add(" ");
            }


        }
        
    }
}
