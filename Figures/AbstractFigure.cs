using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Figures
{
    public class AbstractFigure 
    {
        //public Canvas FigureArea;
        public Point PrevPos;
        public Point NewPos;
        public double Thickness;
        public Brush BorderColor;
        public Brush FillColor;
        static protected Point NullPos;

        public virtual Point Draw(Canvas canva)
        {
            return NullPos;
        }

        public virtual void Remove(Canvas canva)
        {
        }

        public AbstractFigure(double thickness, Brush fill, Brush border)
        {
            NullPos.X = -1;
            NullPos.Y = -1;
            Thickness = thickness;
            FillColor = fill;
            BorderColor = border;
        }
    }

    public class SimpleFigure : AbstractFigure
    {
        public Shape Figure;
        public SimpleFigure(double thickness, Brush fill, Brush border) : base(thickness, fill, border)
        {
        }
        public override void Remove(Canvas canva)
        {
            canva.Children.Remove(Figure);
        }
    }

    public class ComplexFigure : AbstractFigure
    {
        public List<Shape> Figure;
        public ComplexFigure(double thickness, Brush fill, Brush border) : base(thickness, fill, border)
        {
        }
    }

}
