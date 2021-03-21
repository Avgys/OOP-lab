using Figures;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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

        public AbstractFigure ImFigure;
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
                    ImFigure.Remove(Canva);
                    ImFigure = null;
                }
                ChosenFigure = CurrentFactory.GetFigure(thickness, fill, border, ChosenFigure);
                //ChosenFigure.NewPos = NewPos;
                ChosenFigure.PrevPos = PrevPos;
                ChosenFigure.NewPos = pos;
                PrevPos = ChosenFigure.Draw(Canva);
                rewind.AddToFigureList(ChosenFigure);
                
                //if (ImFigure != null)
                //{
                //    //Canva.Children.Remove(ImFigure);
                //    ImFigure.Remove(Canva);
                //    ChosenFigure = ImFigure;
                //      PrevPos = ChosenFigure.Draw(Canva);
                //    rewind.AddToFigureList(ChosenFigure);
                //    ImFigure = null;
                //}
            }
        }

        public void Prerender(double thickness, Brush fill, Brush border, Point pos)
        {
            if (PrevPos.X >= 0 && PrevPos.Y >= 0)
            {
                if (ImFigure != null)
                {
                    //Canva.Children.Remove(ImFigure.Figure);
                    ImFigure.Remove(Canva);
                }
                ImFigure = CurrentFactory.GetFigure(thickness, fill, border, ImFigure) as SimpleFigure;

                //ImFigure.NewPos = new Point { X = pos.X -1, Y = pos.Y -1 };
                ImFigure.NewPos = pos;
                ImFigure.PrevPos = PrevPos;
                //ImFigure.Figure.IsHitTestVisible = false;
                ImFigure.Draw(Canva);
                //Canva.Focus();
                //Canva.MouseLeftButtonDown += ;
                //MouseButtonEventArgs
                //(ImFigure as SimpleFigure).Figure.MouseLeftButtonUp += ;
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
