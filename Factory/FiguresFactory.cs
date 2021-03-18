using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Factory
{
    using Figures;
    public abstract class FiguresFactory
    {
       public abstract AbstractFigure GetFigure(double thickness, Brush fill, Brush border);
    }

    public class LineFactory : FiguresFactory
    {
        public override AbstractFigure GetFigure(double thickness, Brush fill, Brush border)
        {
            return new MyLine(thickness, fill, border);
        }
    }

    public class EllipseFactory : FiguresFactory
    {
        public override AbstractFigure GetFigure(double thickness, Brush fill, Brush border)
        {
            return new MyEllipse(thickness, fill, border);
        }
    }

    public class RectangleFactory : FiguresFactory
    {
        public override AbstractFigure GetFigure(double thickness, Brush fill, Brush border)
        {
            return new MyRectangle(thickness, fill, border);
        }
    }

    public class BrokenLineFactory : FiguresFactory
    {
        public override AbstractFigure GetFigure(double thickness, Brush fill, Brush border)
        {            
            return new MyBrokenLine(thickness, fill, border);
        }
    }

    public class PolygonFactory : FiguresFactory
    {
        public override AbstractFigure GetFigure(double thickness, Brush fill, Brush border)
        {
            return new MyPolygon(thickness, fill, border);
        }
    }
}
