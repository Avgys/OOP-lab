using Figures;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DrawNamespace
{
    using Factory;
    public class Paint
    {
        Canvas Canva;

        public Point PrevPos;
        public Point ImPos;

        AbstractFigure ImFigure;
        AbstractFigure ChosenFigure;
        public FiguresFactory CurrentFactory;
        public RedoUndoClass rewind;

        public void SetPrevPos(Point pos)
        {
            PrevPos = pos;
        }
        public void ClearPos()
        {
            PrevPos.X = -1;
            PrevPos.Y = -1;
            ChosenFigure = null;
            if (ImFigure != null)
            {
                ImFigure.Remove(Canva);
                ImFigure = null;
            }
        }

        public void SetFactory(FiguresFactory factory)
        {
            CurrentFactory = factory;
        }

        public void DrawCurrentFigure(double thickness, Brush fill, Brush border, Point pos)
        {
            if (PrevPos.X >= 0 && PrevPos.Y >= 0)
            {
                if (ImFigure != null)
                {
                    ImFigure.Remove(Canva);
                    ImFigure = null;
                }
                ChosenFigure = CurrentFactory.GetFigure(thickness, fill, border, PrevPos, pos, ChosenFigure);
                ChosenFigure.NewPos = pos;
                PrevPos = ChosenFigure.Draw(Canva);
                rewind.AddToFigureList(ChosenFigure);
            }
        }

        public void Prerender(double thickness, Brush fill, Brush border, Point pos)
        {
            if (PrevPos.X >= 0 && PrevPos.Y >= 0)
            {
                if (ImFigure != null)
                {
                    ImFigure.Remove(Canva);
                    if (ChosenFigure != null)
                    {
                        ImFigure = ChosenFigure.GetCopy(); // Копирую уже нарисованную часть фигуры,
                        if (ChosenFigure.Equals(ImFigure)) // чтобы получить фигуру дорисанную на одну точку больше для предпросмотра
                        {
                            MessageBox.Show("Not Copy");
                        }
                    }
                    else
                    {
                        ImFigure = null;
                    }
                }
                ImFigure = CurrentFactory.GetFigure(thickness, fill, border, PrevPos, pos, ImFigure);                 
                ImFigure.Draw(Canva);
            }
        }

       

        public Paint(Canvas canvaToDraw)
        {
            CurrentFactory = new LineFactory();
            Canva = canvaToDraw;
            PrevPos = new Point() { X = -1, Y = -1 };
            rewind = new RedoUndoClass(Canva);
        }
    }
}
