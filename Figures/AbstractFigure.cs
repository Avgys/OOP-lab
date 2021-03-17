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
    public class AbstractFigure : Object
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

        //public virtual AbstractFigure GetNew()
        //{

        //    FigureArea = new Canvas();
        //    return new AbstractFigure(AreaToDraw);
        //}

        public AbstractFigure(double thickness, Brush fill, Brush border)
        {
            NullPos.X = -1;
            NullPos.Y = -1;
            //FigureArea.Width = Zone.Width;
            //FigureArea.Height = Zone.Height;
        }
    }
}
