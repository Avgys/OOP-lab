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
                   
            if (PrevPos.Y < NewPos.Y)
                Canvas.SetTop(Figure, PrevPos.Y);
            else
                Canvas.SetTop(Figure, PrevPos.Y - Figure.Height);
            if (PrevPos.X < NewPos.X)
                Canvas.SetLeft(Figure, PrevPos.X);
            else
                Canvas.SetLeft(Figure, PrevPos.X - Figure.Width);
            Add(canva);
            return NullPos;
        }

        public MyRectangle(double thickness, Brush fill, Brush border, Point prevPos, Point newPos) : base(thickness, fill, border, prevPos, newPos)
        {
            Figure = new Rectangle()
            {
                Height = Math.Abs(prevPos.Y - newPos.Y),
                Width = Math.Abs(prevPos.X - newPos.X),
                StrokeThickness = thickness,
                Stroke = border,
                Fill = fill,
                IsHitTestVisible = false
            };
        }
    }
}
