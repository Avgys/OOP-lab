using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Trapeze
{
    using Figures;
    using Factory;

    public class StarFactory : FiguresFactory
    {
        public override AbstractFigure GetFigure(double thickness, Color fill, Color border, Point prevPos, Point newPos, AbstractFigure figure)
        {
            return new MyStar(thickness, fill, border, prevPos, newPos);
        }
    }

    public class MyStar : PointsFigure
    {
        public override Point Draw(Canvas canva)
        {
            //    if (PrevPos.Y < NewPos.Y)
            //        Canvas.SetTop(Figure, PrevPos.Y);
            //    else
            //        Canvas.SetTop(Figure, PrevPos.Y - Figure.Height);
            //    if (PrevPos.X < NewPos.X)
            //        Canvas.SetLeft(Figure, PrevPos.X);
            //    else
            //        Canvas.SetLeft(Figure, PrevPos.X - Figure.Width);
            Add(canva);
            return NullPos;
        }

        public override AbstractFigure GetCopy()
        {
            return new MyStar(Thickness, FillColor, BorderColor, PrevPos, NewPos);
        }

        public MyStar()
        {
        }

        public MyStar(double thickness, Color fill, Color border, Point prevPos, Point newPos) : base(thickness, fill, border, prevPos, newPos)
        {
            Figure = new Polygon()
            {
                StrokeStartLineCap = PenLineCap.Round,
                StrokeEndLineCap = PenLineCap.Round,
                StrokeThickness = Thickness,
                Stroke = new SolidColorBrush(BorderColor),
                Fill = new SolidColorBrush(FillColor),
                IsHitTestVisible = false
            };

            Point p1 = new Point(), p2 = new Point(); ;
            if (NewPos.X > PrevPos.X)
            {
                p2.X = NewPos.X;
                p1.X = PrevPos.X;
            }
            else
            {
                p2.X = PrevPos.X;
                p1.X = NewPos.X;
            }

            if (NewPos.Y > PrevPos.Y)
            {
                p2.Y = NewPos.Y;
                p1.Y = PrevPos.Y;
            }
            else
            {
                p2.Y = PrevPos.Y;
                p1.Y = NewPos.Y;
            }
            double wParam = (p2.X - p1.X) /8;
            double hParam = (p2.Y - p1.Y) /8;
            (Figure as Polygon).Points.Add(new Point() { X = (p2.X + p1.X) / 2, Y = p1.Y });
            (Figure as Polygon).Points.Add(new Point() { X = (p2.X + p1.X) / 2 + wParam, Y = (p1.Y + p2.Y) / 2 - hParam});
            (Figure as Polygon).Points.Add(new Point() { X = p2.X, Y = (p1.Y+p2.Y) / 2 });
            (Figure as Polygon).Points.Add(new Point() { X = (p2.X + p1.X) / 2 + wParam, Y = (p1.Y + p2.Y) / 2 + hParam });
            (Figure as Polygon).Points.Add(new Point() { X = (p2.X + p1.X) / 2, Y = p2.Y });
            (Figure as Polygon).Points.Add(new Point() { X = (p2.X + p1.X) / 2 - wParam, Y = (p1.Y + p2.Y) / 2 + hParam });
            (Figure as Polygon).Points.Add(new Point() { X = p1.X, Y = (p1.Y + p2.Y) / 2 });
            (Figure as Polygon).Points.Add(new Point() { X = (p2.X + p1.X) / 2 - wParam, Y = (p1.Y + p2.Y) / 2 - hParam });
        }
    }
}
