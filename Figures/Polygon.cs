using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Figures
{
    class MyPolygon : PointsFigure
    {
        Polygon polygon;
        private PointCollection pointCollection;

        public MyPolygon(double thickness, Brush fill, Brush border, Point prevPos, Point newPos) : base(thickness, fill, border, prevPos, newPos)
        {
        }       

        public override Point Draw(Canvas canva)
        {
            if (this.PointArray.Count < 1)
            {
                polygon = new Polygon()
                {
                    Points = pointCollection,
                    StrokeStartLineCap = PenLineCap.Round,
                    StrokeEndLineCap = PenLineCap.Round,
                    StrokeThickness = Thickness,
                    Stroke = BorderColor,
                    Fill = FillColor
                };
                canva.Children.Add(polygon);
                polygon.Points.Add(PrevPos);
            }
            polygon.Points.Add(NewPos);
            return NewPos;
        }
    }
}
