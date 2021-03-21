using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace Figures
{
    public class MyRectangle : SimpleFigure
    {
        public override Point Draw(Canvas canva)
        {
            Figure = new Rectangle()
            {
                Height = Math.Abs(PrevPos.Y - NewPos.Y),
                Width = Math.Abs(PrevPos.X - NewPos.X),
                StrokeThickness = Thickness,
                Stroke = BorderColor,
                Fill = FillColor,
                IsHitTestVisible = false
            };          
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

        public MyRectangle(double thickness, Brush fill, Brush border) : base(thickness, fill, border)
        {

        }
    }
}
