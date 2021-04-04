using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Figures
{
    class MyLine : SimpleFigure
    {
        public MyLine(double thickness, Brush fill, Brush border, Point prevPos, Point newPos) : base(thickness, fill, border, prevPos, newPos)
        {
            Figure = new Line()
            {
                X1 = PrevPos.X,
                X2 = NewPos.X,
                Y1 = PrevPos.Y,
                Y2 = NewPos.Y,
                StrokeStartLineCap = PenLineCap.Round,
                StrokeEndLineCap = PenLineCap.Round,
                StrokeThickness = Thickness,
                Stroke = BorderColor,
                Fill = FillColor,
                IsHitTestVisible = false
            };
        }

        public override AbstractFigure GetCopy()
        {
            return new MyLine(Thickness, FillColor, BorderColor, PrevPos, NewPos);
        }

        public override Point Draw(Canvas canva)
        {            
            Add(canva);
            return NullPos;
        }        
    }
}
