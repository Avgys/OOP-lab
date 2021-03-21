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
            //canva.Children.Remove(this)
        }

        public virtual void Add(Canvas canva)
        {
            //canva.Children.Remove(this)
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

        public override void Add(Canvas canva)
        {
            canva.Children.Add(Figure);
        }
    }

    public class CombinedFigure : AbstractFigure
    {
        public List<SimpleFigure> Figure;
        public CombinedFigure(double thickness, Brush fill, Brush border) : base(thickness, fill, border)
        {
        }
        public override void Remove(Canvas canva)
        {
            for (int i = 0; i < Figure.Count;i++)
            canva.Children.Remove(Figure[i].Figure);
        }
    }

    public class PointsFigure : AbstractFigure{
        public List<Point> PointArray;
        public PointsFigure(double thickness, Brush fill, Brush border) : base(thickness, fill, border)
        {
        }
    }

}
