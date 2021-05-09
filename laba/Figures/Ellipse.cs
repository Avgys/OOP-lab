using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Figures
{
    class MyEllipse : SimpleFigure
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

        public override AbstractFigure GetCopy()
        {
            return new MyEllipse(Thickness, FillColor, BorderColor, PrevPos, NewPos);
        }

        public MyEllipse()
        {

        }

        public MyEllipse(double thickness, Color fill, Color border, Point prevPos, Point newPos) : base(thickness, fill, border, prevPos, newPos)
        {
            Figure = new Ellipse()
            {
                Width = Math.Abs(PrevPos.X - NewPos.X),
                Height = Math.Abs(PrevPos.Y - NewPos.Y),
                StrokeThickness = Thickness,
                Stroke = new SolidColorBrush(BorderColor),
                Fill = new SolidColorBrush(FillColor),
                IsHitTestVisible = false
            };
        }
    }
}
