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

        public virtual AbstractFigure GetCopy()
        {
            //canva.Children.Remove(this)
            return null;
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
        public SimpleFigure(double thickness, Brush fill, Brush border, Point prevPos, Point newPos) : base(thickness, fill, border)
        {
            PrevPos = prevPos;
            NewPos = newPos;
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
        protected List<SimpleFigure> FigureArr;
        public CombinedFigure(double thickness, Brush fill, Brush border, Point prevPos, Point newPos) : base(thickness, fill, border)
        {
           FigureArr = new List<SimpleFigure>();
        }

        public void RemoveFigure(SimpleFigure fig)
        {
            FigureArr.Remove(fig);
        }

        public void RemoveLastFigure()
        {            
            FigureArr.Remove(FigureArr.Last());
        }

        public void AddFigure(SimpleFigure fig)
        {
            FigureArr.Add(fig);
        }

        public override void Remove(Canvas canva)
        {
            for (int i = 0; i < FigureArr.Count;i++)
            canva.Children.Remove(FigureArr[i].Figure);
        }

        public override void Add(Canvas canva)
        {
            for (int i = FigureArr.Count - 1; i >= 0; i--)
            {
                if (canva.Children.Contains(FigureArr[i].Figure))
                break;
                canva.Children.Add(FigureArr[i].Figure);
            }
        }
    }

    public class PointsFigure : AbstractFigure{
        public List<Point> PointArray;
        public Shape Figure;
        public PointsFigure(double thickness, Brush fill, Brush border, Point prevPos, Point newPos) : base(thickness, fill, border) {
            PointArray = new List<Point>();
            PointArray.Add(prevPos);
            PointArray.Add(newPos);
        }

        public override void Remove(Canvas canva)
        {
            canva.Children.Remove(Figure);
        }

        public override void Add(Canvas canva)
        {
            if (!canva.Children.Contains(Figure))
                canva.Children.Add(Figure);
        }

        public virtual void AddPoint(Point pos)
        {
            PointArray.Add(pos);
        }

        public virtual void RemovePoint(Point pos)
        {
            PointArray.Remove(pos);
        }
    }
}
