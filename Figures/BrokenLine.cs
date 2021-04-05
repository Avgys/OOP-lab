using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using Factory;

namespace Figures
{
    class MyBrokenLine : PointsFigure
    {
        List<SimpleFigure> FigureArr;
        public override Point Draw(Canvas canva)
        {
            PointArray.Add(FigureArr[^1].NewPos);
            Add(canva);
            return FigureArr[^1].NewPos;
        }

        public void AddFigure(SimpleFigure fig)
        {
            FigureArr.Add(fig);
        }

        public void RemoveFigure(SimpleFigure fig)
        {
            FigureArr.Remove(fig);
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

        public override void Remove(Canvas canva)
        {
            for (int i = 0; i < FigureArr.Count; i++)
                canva.Children.Remove(FigureArr[i].Figure);
        }

        public override AbstractFigure GetCopy()
        {
            var temp = new MyBrokenLine(Thickness, FillColor, BorderColor, PrevPos, NewPos);
            var Factory = new BrokenLineFactory();
            for (int i = 0; i < this.FigureArr.Count; i++)
            {
                temp = Factory.GetFigure(Thickness, FillColor, BorderColor, FigureArr[i].PrevPos, FigureArr[i].NewPos, temp) as MyBrokenLine;
            }
            return temp;
        }

        public MyBrokenLine(double thickness, Brush fill, Brush border, Point prevPos, Point newPos) : base(thickness, fill, border, prevPos, newPos)
        {
            FigureArr = new List<SimpleFigure>();
        }
    }
}
