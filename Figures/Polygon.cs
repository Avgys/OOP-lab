using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

using Factory;
namespace Figures
{
    class MyPolygon : PointsFigure
    {
        //private PointCollection pointCollection;
        public MyPolygon(double thickness, Brush fill, Brush border, Point prevPos, Point newPos) : base(thickness, fill, border, prevPos, newPos)
        {
            Figure = new Polygon()
            {                
                StrokeStartLineCap = PenLineCap.Round,
                StrokeEndLineCap = PenLineCap.Round,
                StrokeThickness = Thickness,
                Stroke = BorderColor,
                Fill = FillColor,
                IsHitTestVisible = false

            };
            (Figure as Polygon).Points.Add(prevPos);
            (Figure as Polygon).Points.Add(newPos);
        }       

        public override Point Draw(Canvas canva)
        {
            Add(canva);
            return NewPos;
        }

        public override void AddPoint(Point pos)
        {
            (Figure as Polygon).Points.Add(pos);
            PointArray.Add(pos);
        }

        public override void RemovePoint(Point pos)
        {
            (Figure as Polygon).Points.Remove(pos);
            PointArray.Remove(pos);
        }

        public override AbstractFigure GetCopy()
        {

            var temp = new MyPolygon(Thickness, FillColor, BorderColor, this.PointArray[0], this.PointArray[1]);
            var Factory = new PolygonFactory();
            for (int i =2; i < this.PointArray.Count; i++)
            {
                temp = Factory.GetFigure(Thickness, FillColor, BorderColor, PrevPos, this.PointArray[i], temp) as MyPolygon;
            }
            return temp;
        }
    }
}
