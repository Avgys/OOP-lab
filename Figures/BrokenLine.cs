using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Figures
{
    class MyBrokenLine : PointsFigure
    {
        Line line;
        public override Point Draw(Canvas canva)
        {
            if (NewPos.X > 0 && NewPos.Y > 0)
            {
                line = new Line()
                {
                    X1 = PrevPos.X,
                    X2 = NewPos.X,
                    Y1 = PrevPos.Y,
                    Y2 = NewPos.Y,
                    StrokeStartLineCap = PenLineCap.Round,
                    StrokeEndLineCap = PenLineCap.Round,
                    StrokeThickness = Thickness,
                    Stroke = BorderColor,
                    Fill = FillColor
                };
                canva.Children.Add(line);
            }
            return NewPos;
        }

        public override void Remove(Canvas canva)
        {
            //canva.Children.Remove(this.fig)
        }

        public MyBrokenLine(double thickness, Brush fill, Brush border) : base(thickness, fill, border)
        {
        }
    }
}
