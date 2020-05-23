using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Chapter16
{
    public class ImagedTreeViewItem : TreeViewItem
    {
        TextBlock text;
        Image img;
        ImageSource srcSelected, srcUnselected;
        // Конструктор создаеет стак панель с текстом и картинками. 
        public ImagedTreeViewItem()
        {
            StackPanel stack = new StackPanel();
            stack.Orientation = Orientation .Horizontal;
            Header = stack;
            img = new Image();
            img.VerticalAlignment =  VerticalAlignment.Center;
            img.Margin = new Thickness(0, 0, 2, 0);
            stack.Children.Add(img);
            text = new TextBlock();
            text.VerticalAlignment =  VerticalAlignment.Center;
            stack.Children.Add(text);
        }
        // откртые св-ва текста и картинок.      
        public string Text
        {
            set { text.Text = value; }
            get { return text.Text; }
        }
        public ImageSource SelectedImage
        {
            set
            {
                srcSelected = value;
                if (IsSelected)
                    img.Source = srcSelected;
            }
            get { return srcSelected; }
        }
        public ImageSource UnselectedImage
        {
            set
            {
                srcUnselected = value;
                if (!IsSelected)
                    img.Source = srcUnselected;
            }
            get { return srcUnselected; }
        }    
        // переопределение событий для задания изображения.  
        protected override void OnSelected (RoutedEventArgs args)
        {
            base.OnSelected(args);
            img.Source = srcSelected;
        }
        protected override void OnUnselected (RoutedEventArgs args)
        {
            base.OnUnselected(args);
            img.Source = srcUnselected;
        }
    }
} 