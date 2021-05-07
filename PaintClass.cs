﻿using Figures;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Text.Json;

namespace DrawNamespace
{
    using Factory;
    using System.Collections.Generic;

    public class Paint
    {
        Canvas Canva;

        public Point PrevPos;
        public Point ImPos;

        AbstractFigure ImFigure;
        AbstractFigure ChosenFigure;
        public FiguresFactory CurrentFactory;
        public RedoUndoClass rewind;
        //public Serializer 

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

        string json;

        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public string Deserialize()
        {

            rewind.RemoveAll();
            string[] arr = json.Split("/n");
            for(int i = 0; i < arr.Length; i++)
            {
                var fig = JsonSerializer.Deserialize<MyLine>(arr[i]);
                rewind.AddToFigureList(fig);
            }

            //rewind.FigureList = JsonSerializer.Deserialize<List<AbstractFigure>>(json);            
            return json;
        }

        public string Serialize()
        { 
            json = "";
            
            string[] arr = new string[rewind.FigureList.Count];

            for (int i = 0; i < rewind.FigureList.Count; i++)
            {
                arr[i] = rewind.FigureList[i].GetType().ToString();
            }
            json += JsonSerializer.Serialize(arr);
            json += "\n";

            for (int i = 0; i < rewind.FigureList.Count; i++)
            {
                json += JsonSerializer.Serialize(rewind.FigureList[i], rewind.FigureList[i].GetType());
                json += "\n";
            }

            //json += JsonSerializer.Serialize(rewind.FigureList, rewind.FigureList.GetType());

            //json = JsonSerializer.Serialize(rewind.FigureList[0], rewind.FigureList[0].GetType());

            rewind.RemoveAll();
            
            string[] jsonRows = json.Split("\n");

            string[] arrTypes = JsonSerializer.Deserialize(jsonRows[0], jsonRows.GetType()) as string[];

            System.Type myType;            

            var FigureList = new List<AbstractFigure>();

            for (int i = 0; i < arrTypes.Length; i++)
            {
                myType = System.Type.GetType(arrTypes[i], false, true);
                AbstractFigure nfig = JsonSerializer.Deserialize(jsonRows[i+1], myType) as AbstractFigure;
                //FigureList[i] = (FigureList[i] as myType ).GetCopy();
                FigureList.Add(nfig.GetCopy());
            }

            rewind.FigureList = FigureList;
            rewind.ReturnAll();

            //AbstractFigure nfig = JsonSerializer.Deserialize(json, type) as AbstractFigure;

            //nfig.Draw(Canva);
            //rewind.AddToFigureList(nfig);
            return json;
        }

        public void DrawCurrentFigure(double thickness, Color fill, Color border, Point pos)
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

        public void Prerender(double thickness, Color fill, Color border, Point pos)
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
