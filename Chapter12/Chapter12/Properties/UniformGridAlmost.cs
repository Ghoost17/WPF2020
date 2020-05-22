using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;
using System;

namespace Chapter12
{
    class UniformGridAlmost : Panel
    {
        // Открыте статические свойства для чтения.  
        public static readonly DependencyProperty  ColumnsProperty;
        // Static constructor to create dependency  property.    
        static UniformGridAlmost()
        {
            ColumnsProperty = DependencyProperty.Register("Columns", typeof(int), typeof (UniformGridAlmost),
                new FrameworkPropertyMetadata(1,FrameworkPropertyMetadataOptions.AffectsMeasure));
        }
        // Свойство columns.  
        public int Columns
        {
            set { SetValue(ColumnsProperty, value); }
            get { return (int)GetValue (ColumnsProperty); }
        }
        // Свойство rows только для чтения.
        public int Rows
        {
            get { return (InternalChildren.Count +  Columns - 1) / Columns; }
        }
        //пеереопределение MeasureOverride .    
        protected override Size MeasureOverride (Size sizeAvailable)
        {
            // Вычисление размера дочернего элемента.   
            Size sizeChild = new Size (sizeAvailable.Width / Columns, sizeAvailable.Height / Rows);
            // переменные максимальных размеров.   
            double maxwidth = 0;
            double maxheight = 0;
            foreach (UIElement child in  InternalChildren)
            {
                // вызов Measure для каждого дочернего элемента ... 
                child.Measure(sizeChild);
                // провенрить свойство DesiredSize .  
                maxwidth = Math.Max(maxwidth,  child.DesiredSize.Width);
                maxheight = Math.Max(maxheight,  child.DesiredSize.Height);
            }
            // Считам размер решетки.     
            return new Size(Columns * maxwidth,  Rows * maxheight);
        }
        // переопределяем ArrangeOverride, размещающий элементы.   
        protected override Size ArrangeOverride (Size sizeFinal)
        {
            //вычисление размера дочерних элементов    
            Size sizeChild = new Size(sizeFinal .Width / Columns,    
                sizeFinal .Height / Rows);
            for (int index = 0; index <  InternalChildren.Count; index++)
            {
                int row = index / Columns;
                int col = index % Columns;
                // Вычисленние прямоугоника для каждого элемента    
                Rect rectChild =  new Rect(new Point(col *  sizeChild.Width,row *  sizeChild.Height),sizeChild);
                // вызов arrange  для этого объекта     
                InternalChildren[index].Arrange (rectChild);
            }             return sizeFinal;
        }
    }
} 


