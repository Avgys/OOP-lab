using System.Collections.Generic;
using System.Windows.Controls;


namespace DrawNamespace
{
    using Figures;

    public class RedoUndoClass
    {
        private int CurrStep;
        private List<AbstractFigure> FigureList;
        Canvas Canva;

        public void AddToFigureList(AbstractFigure figure)
        {
            if (CurrStep + 1 < FigureList.Count)
            {
                FigureList.RemoveRange(CurrStep + 1, FigureList.Count -(CurrStep + 1));                
            }
                FigureList.Add(figure);
                CurrStep++;
        }

        public void Backward()
        {            
            if (FigureList.Count >= 1 && CurrStep >= 0)
            {
                if (FigureList[CurrStep] is SimpleFigure)
                {
                    SimpleFigure figure = FigureList[CurrStep] as SimpleFigure;
                    //Canva.Children.Remove(figure.Figure);
                    figure.Remove(Canva);
                    CurrStep--;
                }
            }
        }

        public void Forward()
        {
            if (FigureList.Count > CurrStep + 1) { 
                ++CurrStep;
                if (FigureList[CurrStep] is SimpleFigure) {
                    SimpleFigure figure = FigureList[CurrStep] as SimpleFigure;
                    //Canva.Children.Add(figure.Figure);
                    figure.Add(Canva);
                }
            }
        }

        public void ReturnAll()
        {
            while (FigureList.Count > CurrStep + 1)
            {
                Forward();
            }
        }

        public void RemoveAll()
        {
            while (FigureList.Count >= 1 && CurrStep >= 0)
            {
                Backward();
            }
        }

        public RedoUndoClass(Canvas AreaToDraw)
        {
            CurrStep = -1;
            FigureList = new List<AbstractFigure>();
            Canva = AreaToDraw;
        }
    }
}
