using Figures;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace DrawNamespace
{
    using Factory;
    public class Paint
    {
        //private List<AbstractFigure> FigureList;
        Canvas Canva;

        public Point PrevPos;
        //public Point NewPos;
        public Point ImPos;

        SimpleFigure ImFigure;
        AbstractFigure ChosenFigure;
        public FiguresFactory CurrentFactory;
        public RedoUndoClass rewind;

        public void SetPrevPos(Point pos)
        {
            PrevPos = pos;
        }

        //public void SetNewPos(Point pos)
        //{
        //    NewPos = pos;
        //}        

        public void ClearPos()
        {
            PrevPos.X = -1;
            PrevPos.Y = -1;
            //NewPos.X = -1;
            //NewPos.Y = -1;
            //ChosenFigure = CurrentFactory.GetFigure();
            ChosenFigure = null;
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
                    Canva.Children.Remove(ImFigure.Figure);
                }
                ChosenFigure = CurrentFactory.GetFigure(thickness, fill, border);
                //ChosenFigure.NewPos = NewPos;
                ChosenFigure.PrevPos = PrevPos;
                ChosenFigure.NewPos = pos;
                ChosenFigure.Draw(Canva);
                //if (!Canva.Children.Contains(ChosenFigure.FigureArea))
                //{
                    //Canva.Children.Add(ChosenFigure.FigureArea);
                    rewind.AddToFigureList(ChosenFigure);
                //}
            }
        }

        public void Prerender(double thickness, Brush fill, Brush border, Point pos)
        {
            if (PrevPos.X >= 0 && PrevPos.Y >= 0)
            {
                if (ImFigure != null)
                {
                    Canva.Children.Remove(ImFigure.Figure);
                }
                ImFigure = CurrentFactory.GetFigure(thickness, fill, border) as SimpleFigure;
                ImFigure.NewPos = pos;
                ImFigure.PrevPos = PrevPos;
                ImFigure.Draw(Canva);
            }
        }

        public Paint(Canvas canvaToDraw)
        {
            CurrentFactory = new LineFactory();
            Canva = canvaToDraw;
            //NewPos = new Point() { X = -1, Y = -1 };
            PrevPos = new Point() { X = -1, Y = -1 };
            rewind = new RedoUndoClass(Canva);
        }
        //~Paint();
    }
}
