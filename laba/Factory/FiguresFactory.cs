using System.Windows;
using System.Windows.Media;

namespace Factory
{
    using Figures;
    public abstract class FiguresFactory
    {
        public abstract AbstractFigure GetFigure(double thickness, Color fill, Color border, Point prevPos, Point newPos, AbstractFigure figure);
    }

    public class LineFactory : FiguresFactory
    {
        public override AbstractFigure GetFigure(double thickness, Color fill, Color border, Point prevPos, Point newPos, AbstractFigure figure)
        {
            return new MyLine(thickness, fill, border, prevPos, newPos);
        }
    }

    public class EllipseFactory : FiguresFactory
    {
        public override AbstractFigure GetFigure(double thickness, Color fill, Color border, Point prevPos, Point newPos, AbstractFigure figure)
        {
            return new MyEllipse(thickness, fill, border, prevPos, newPos);
        }
    }

    public class RectangleFactory : FiguresFactory
    {
        public override AbstractFigure GetFigure(double thickness, Color fill, Color border, Point prevPos, Point newPos, AbstractFigure figure)
        {
            return new MyRectangle(thickness, fill, border, prevPos, newPos);
        }
    }

    public class BrokenLineFactory : FiguresFactory
    {
        public override AbstractFigure GetFigure(double thickness, Color fill, Color border, Point prevPos, Point newPos, AbstractFigure figure)
        {
            try
            {
                if (figure == null || !(figure is MyBrokenLine))
                {
                    var temp = new MyBrokenLine(thickness, fill, border, prevPos, newPos);
                    temp.AddFigure(new MyLine(thickness, fill, border, prevPos, newPos));
                    return temp;
                }
                else
                {                    
                    (figure as MyBrokenLine).AddFigure(new MyLine(thickness, fill, border, prevPos, newPos));
                    return figure;                    
                }
            }
            catch
            {
                MessageBox.Show("BrokenLineFactory Error");
                return null;
            }            
        }
    }

    public class PolygonFactory : FiguresFactory
    {
        public override AbstractFigure GetFigure(double thickness, Color fill, Color border, Point prevPos, Point newPos, AbstractFigure figure)
        {
            try
            {
                if (figure == null || !(figure is MyPolygon))
                {
                    var temp = new MyPolygon(thickness, fill, border, prevPos, newPos);
                    return temp;
                }
                else
                {
                    (figure as MyPolygon).AddPoint(newPos);
                    return figure;
                }
            }
            catch
            {
                MessageBox.Show("PolygonFactory Error");
                return null;
            }
        }
    }
}
