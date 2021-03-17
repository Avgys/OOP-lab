using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Figures
{
    class MyPolygon : AbstractFigure
    {
        Polygon polygon;
        private PointCollection pointCollection;
        
        public MyPolygon(double thickness, Brush fill, Brush border) : base(thickness, fill, border)
        {

        }

        //public override AbstractFigure GetNew()
        //{
        //    Canvas buff = FigureArea;
        //    PointCollection buffCollection = pointCollection;
        //    if (buff == null)
        //    {
        //        return new ClassPolygon(AreaToDraw)
        //        {
        //            FigureArea = new Canvas(),
        //            pointCollection = new PointCollection()
        //        };
        //    }
        //    else
        //    {                
        //        return this;
        //    }
        //}

        public override Point Draw(Canvas canva)
        {
            if (pointCollection.Count < 1)
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
                pointCollection.Add(PrevPos);
            }
            pointCollection.Add(NewPos);
            return NewPos;
        }
    }
}
