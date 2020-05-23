using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace Chapter16
{
    public class DirectoryTreeViewItem : ImagedTreeViewItem
    {
        DirectoryInfo dir;
        // конструктор получает объект directoryinfo. 
        public DirectoryTreeViewItem(DirectoryInfo  dir)
        {
            this.dir = dir;
            Text = dir.Name;
            SelectedImage =   new BitmapImage(new Uri("C:/Users/7777/source/repos/Chapter16/Chapter16/OPENFOLD.BMP"));
            UnselectedImage = new BitmapImage(new Uri("C:/Users/7777/source/repos/Chapter16/Chapter16/CLSDFOLD.BMP"));
        }
        // открытое свойство для получения этого объекта.    
        public DirectoryInfo DirectoryInfo
        {
            get { return dir; }
        }
        // открытый метод для заполнения узлов. 
        public void Populate()
        {
            DirectoryInfo[] dirs;
            try {dirs = dir.GetDirectories();}
            catch   { return;}
            foreach (DirectoryInfo dirChild in dirs)
                Items.Add(new  DirectoryTreeViewItem(dirChild));
        }
        // переобределение события для заполнения вложеенных узлов     
        protected override void OnExpanded (RoutedEventArgs args)
        {
            base.OnExpanded(args);
            foreach (object obj in Items)
            {
                DirectoryTreeViewItem item = obj  as DirectoryTreeViewItem;
                item.Populate();
            }
        }
    }
} 
