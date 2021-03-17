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
                Canva.Children.Remove(FigureList[CurrStep--].);
            }
        }

        public void Forward()
        {
            if (FigureList.Count > CurrStep+1)
            {
                Canva.Children.Add(FigureList[++CurrStep].FigureArea);
            }
        }

        public void RemoveAll()
        {
            while (FigureList.Count >= 1 && CurrStep >= 0)
            {
                Canva.Children.Remove(FigureList[CurrStep--].FigureArea);
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
