using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Figures
{
    class MyLine : SimpleFigure
    {
        public MyLine()
        {

        }

        public MyLine(double Thickness, Color FillColor, Color BorderColor, Point PrevPos, Point NewPos) : base(Thickness, FillColor, BorderColor, PrevPos, NewPos)
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
                Stroke = new SolidColorBrush(BorderColor),
                Fill = new SolidColorBrush(FillColor),
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
