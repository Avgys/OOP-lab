using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Figures
{
    class MyBrokenLine : AbstractFigure
    {
        Line line;

        //public override AbstractFigure GetNew()
        //{
        //    Canvas buff = FigureArea;
        //    if (buff == null)
        //    {
        //        return new ClassBrokenLine(AreaToDraw)
        //        {
        //            FigureArea = new Canvas()
        //        };
        //    }
        //    else
        //        return new ClassBrokenLine(AreaToDraw)
        //        {
        //            FigureArea = buff
        //        };
        //}

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
        public MyBrokenLine(double thickness, Brush fill, Brush border) : base(thickness, fill, border)
        {
        }
    }
}
