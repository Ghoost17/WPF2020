using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Chapter_6
{
    class SplitNine : Window
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application app = new Application();
            app.Run(new SplitNine());
        }
        public SplitNine()
        {
            Title = "Split Nine";
            Grid grid = new Grid();
            Content = grid;
            for(int i = 0; i < 3; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.RowDefinitions.Add(new RowDefinition());
            }
            for (int x = 1; x < 4; x++)
                for (int y = 1; y < 4; y++)
                {
                    Button btn = new Button();
                    btn.Content = "Row " + y + "\nColumn " + x;
                    grid.Children.Add(btn);
                    Grid.SetRow(btn, y-1);
                    Grid.SetColumn(btn, x-1);
                }
            GridSplitter split = new GridSplitter();
            split.Width = 6;
            grid.Children.Add(split);
            
            Grid.SetRow(split, 1);
            Grid.SetColumn(split, 1);
        }

    }
}
