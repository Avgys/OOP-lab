using System.Collections.Generic;
using System.Windows.Controls;


namespace DrawNamespace
{
    using Figures;

    public class RedoUndoClass
    {
        private int CurrStep;
        public List<AbstractFigure> FigureList { get; set; }
        Canvas Canva;

        public void AddToFigureList(AbstractFigure figure)
        {
            if (CurrStep + 1 < FigureList.Count)
            {
                FigureList.RemoveRange(CurrStep + 1, FigureList.Count -(CurrStep + 1));                
            }
            if (!FigureList.Contains(figure))
            {
                FigureList.Add(figure);
                CurrStep++;
            }
        }

        public void Backward()
        {            
            if (FigureList.Count >= 1 && CurrStep >= 0)
            {
                FigureList[CurrStep].Remove(Canva);
                CurrStep--;
            }
        }

        public void Forward()
        {
            if (FigureList.Count > CurrStep + 1) { 
                ++CurrStep;
                FigureList[CurrStep].Add(Canva);
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
