using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Figures
{
    class MyBrokenLine : CombinedFigure
    {
        private int Count;
        public override Point Draw(Canvas canva)
        {            
                //FigureArr[Count].PrevPos = PrevPos;
                //FigureArr[Count].NewPos = NewPos;                
            Add(canva);            
            return NewPos;
        }

        public override void Remove(Canvas canva)
        {
            //canva.Children.Remove(this.fig)
        }

        public MyBrokenLine(double thickness, Brush fill, Brush border, Point prevPos, Point newPos) : base(thickness, fill, border, prevPos, newPos)
        {
            Count = 0;
        }
    }
}
