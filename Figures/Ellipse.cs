using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Figures
{
    class MyEllipse : SimpleFigure
    {
        public override Point Draw(Canvas canva)
        {
            Figure = new Ellipse()
            {
                Width = Math.Abs(PrevPos.X - NewPos.X),
                Height = Math.Abs(PrevPos.Y - NewPos.Y),                
                StrokeThickness = Thickness,
                Stroke = BorderColor,
                Fill = FillColor,
                IsHitTestVisible = false
            };
            //Figure.IsHitTestVisible
            if (PrevPos.Y < NewPos.Y)
                Canvas.SetTop(Figure, PrevPos.Y);
            else
                Canvas.SetTop(Figure, PrevPos.Y - Figure.Height);
            if (PrevPos.X < NewPos.X)
                Canvas.SetLeft(Figure, PrevPos.X);
            else
                Canvas.SetLeft(Figure, PrevPos.X - Figure.Width);
            
            canva.Children.Add(Figure);
            return NullPos;
        }

        public MyEllipse(double thickness, Brush fill, Brush border) : base(thickness, fill, border)
        {
        }
    }
}
