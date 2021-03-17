using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Figures
{
    class MyLine : AbstractFigure
    {
        Line line;

        public MyLine(double thickness, Brush fill, Brush border) : base(thickness, fill, border)
        {
        }

        //public override AbstractFigure GetNew()
        //{
        //    return new ClassLine(AreaToDraw)
        //    {
        //        FigureArea = new Canvas()
        //    };
        //}

        public override Point Draw(Canvas canva)
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
            return NullPos;
        }
    }
}
