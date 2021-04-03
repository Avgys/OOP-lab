using System.Windows;
using System.Windows.Media;

namespace Factory
{
    using Figures;
    public abstract class FiguresFactory
    {
        public abstract AbstractFigure GetFigure(double thickness, Brush fill, Brush border, Point prevPos, Point newPos, AbstractFigure figure);
    }

    public class LineFactory : FiguresFactory
    {
        public override SimpleFigure GetFigure(double thickness, Brush fill, Brush border, Point prevPos, Point newPos, AbstractFigure figure)
        {
            return new MyLine(thickness, fill, border, prevPos, newPos);
        }
    }

    public class EllipseFactory : FiguresFactory
    {
        public override SimpleFigure GetFigure(double thickness, Brush fill, Brush border, Point prevPos, Point newPos, AbstractFigure figure)
        {
            return new MyEllipse(thickness, fill, border, prevPos, newPos);
        }
    }

    public class RectangleFactory : FiguresFactory
    {
        public override AbstractFigure GetFigure(double thickness, Brush fill, Brush border, Point prevPos, Point newPos, AbstractFigure figure)
        {
            return new MyRectangle(thickness, fill, border, prevPos, newPos);
        }
    }

    public class BrokenLineFactory : FiguresFactory
    {
        public override AbstractFigure GetFigure(double thickness, Brush fill, Brush border, Point prevPos, Point newPos, AbstractFigure figure)
        {
            if (figure == null)
            {
                var temp = new MyBrokenLine(thickness, fill, border, prevPos, newPos);
                temp.AddFigure(new MyLine(thickness, fill, border, prevPos, newPos));
                return temp;
            }
            else
            { 
                (figure as CombinedFigure).AddFigure(new MyLine(thickness, fill, border, prevPos, newPos));
                return figure;
            }
        }
    }

    public class PolygonFactory : FiguresFactory
    {
        public override AbstractFigure GetFigure(double thickness, Brush fill, Brush border, Point prevPos, Point newPos, AbstractFigure figure)
        {
            if (figure == null)
            {
                return new MyPolygon(thickness, fill, border, prevPos, newPos);
            }
            else
            {
                return figure;
            }
        }
    }
}
