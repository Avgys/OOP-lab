using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Figures
{

    interface ISerializable {
        public string Serialize();
    }


    //{"Thickness":22,"BorderColor":{"ColorContext":null,"A":255,"R":0,"G":0,"B":0,"ScA":1,"ScR":0,"ScG":0,"ScB":0},"FillColor":{ "ColorContext":null,"A":255,"R":255,"G":255,"B":255,"ScA":1,"ScR":1,"ScG":1,"ScB":1},"PrevPos":{ "X":259.08000000000004,"Y":113},"NewPos":{ "X":611.08,"Y":212}}

    public class AbstractFigure 
    {
        //public Canvas FigureArea;        
        [JsonPropertyName("Thickness")]
        public double Thickness { get; set; }
        [JsonPropertyName("FillColor")]
        public Color FillColor { get; set; }
        [JsonPropertyName("BorderColor")]
        public Color BorderColor { get; set; }
        [JsonPropertyName("PrevPos")]
        public Point PrevPos { get; set; }
        [JsonPropertyName("NewPos")]
        public Point NewPos { get; set; }

        static protected Point NullPos;

        public virtual Point Draw(Canvas canva)
        {
            return NullPos;
        }

        public virtual void Remove(Canvas canva)
        {
        }

        public virtual void Add(Canvas canva)
        {
        }

        public virtual AbstractFigure GetCopy()
        {           
            return this;
        }

        public AbstractFigure(double thickness, Color fillColor, Color borderColor,  Point prevPos, Point newPos)
        {
            NullPos.X = -1;
            NullPos.Y = -1;

            this.Thickness = thickness;
            this.FillColor = fillColor;
            this.BorderColor = borderColor;
            this.PrevPos = prevPos;
            this.NewPos = newPos;
        }

        public AbstractFigure()
        {

        }
    }

    public class SimpleFigure : AbstractFigure
    {
        [JsonIgnore]
        public Shape Figure;
        public SimpleFigure(double thickness, Color fill, Color border, Point prevPos, Point newPos) : base(thickness, fill, border, prevPos, newPos)
        {
            PrevPos = prevPos;
            NewPos = newPos;
        }

        public SimpleFigure()
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

    //public class CombinedFigure : AbstractFigure //Not in use currently
    //{
    //    protected List<SimpleFigure> FigureArr;
    //    public CombinedFigure(double thickness, Color fill, Color border, Point prevPos, Point newPos) : base(thickness, fill, border)
    //    {
    //       FigureArr = new List<SimpleFigure>();
    //    }

    //    public void RemoveFigure(SimpleFigure fig)
    //    {
    //        FigureArr.Remove(fig);
    //    }

    //    public void RemoveLastFigure()
    //    {            
    //        FigureArr.Remove(FigureArr.Last());
    //    }

    //    public void AddFigure(SimpleFigure fig)
    //    {
    //        FigureArr.Add(fig);
    //    }

    //    public override void Remove(Canvas canva)
    //    {
    //        for (int i = 0; i < FigureArr.Count;i++)
    //        canva.Children.Remove(FigureArr[i].Figure);
    //    }

    //    public override void Add(Canvas canva)
    //    {
    //        for (int i = FigureArr.Count - 1; i >= 0; i--)
    //        {
    //            if (canva.Children.Contains(FigureArr[i].Figure))
    //            break;
    //            canva.Children.Add(FigureArr[i].Figure);
    //        }
    //    }
    //}

    public class PointsFigure : AbstractFigure
    {
        [JsonPropertyName("PointArray")][JsonInclude]
        public List<Point> PointArray { get; set; }
        [JsonIgnore]
        protected Shape Figure;

        public PointsFigure()
        {
            
        }

        public PointsFigure(double thickness, Color fill, Color border, Point prevPos, Point newPos) : base(thickness, fill, border, prevPos, newPos)
        {
            PointArray = new List<Point>
            {
                prevPos,
                newPos
            };
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
