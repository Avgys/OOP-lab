using Figures;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Threading;
using System.Globalization;
using System.IO;
using Microsoft.Win32;

namespace Paint_OOP_lab
{
    using DrawNamespace;
    using Factory;
    public partial class MainWindow : Window
    {
        Paint paint;
        public MainWindow()
        {
            InitializeComponent();
            paint = new Paint(Canva);
        }

        private void Canva_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (paint.PrevPos.X >= 0 && paint.PrevPos.Y >= 0)
            {
                Color LineBrush;
                if (SelectedLineColor.SelectedColor == null)
                {
                    LineBrush = Color.FromRgb(0, 0, 0); 
                }
                else
                    LineBrush = (Color)SelectedLineColor.SelectedColor;
                Color FillBrush;
                if (SelectedFillColor.SelectedColor == null)
                {
                    FillBrush = Color.FromRgb(255, 255, 255);
                }
                else
                    FillBrush =  (Color)SelectedFillColor.SelectedColor;
                paint.DrawCurrentFigure(double.Parse(StrokeWidth.Text, CultureInfo.InvariantCulture), FillBrush, LineBrush, e.GetPosition(Canva));
                
            }
            else 
            {
                paint.SetPrevPos(e.GetPosition(Canva));
            }
        }


        private void Canva_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {            
        }

        private void Canva_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint.PrevPos.X >= 0 && paint.PrevPos.Y >= 0)
            {
                Color LineBrush;
                if (SelectedLineColor.SelectedColor == null)
                {
                    LineBrush = Color.FromRgb(0, 0, 0);
                }
                else
                    LineBrush = (Color)SelectedLineColor.SelectedColor;
                Color FillBrush;
                if (SelectedFillColor.SelectedColor == null)
                {
                    FillBrush = Color.FromRgb(255, 255, 255);
                }
                else
                    FillBrush = (Color)SelectedFillColor.SelectedColor;

                paint.Prerender(double.Parse(StrokeWidth.Text, CultureInfo.InvariantCulture), FillBrush, LineBrush, e.GetPosition(Canva));
            }
        }

        private void Canva_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            paint.ClearPos();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Escape))
            {
                paint.ClearPos();
            }
        }

        private void Canva_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            paint.ClearPos();
            paint.rewind.Backward();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            paint.ClearPos();
            paint.rewind.RemoveAll();
        }

        private void Re_Undo_Click(object sender, RoutedEventArgs e)
        {
            paint.rewind.Forward();
        }

        private void Polygon_Click(object sender, RoutedEventArgs e)
        {
            paint.SetFactory(new PolygonFactory());
        }

        private void Rectangle_Click(object sender, RoutedEventArgs e)
        {
            paint.SetFactory(new RectangleFactory());
        }

        private void Ellipes_Click(object sender, RoutedEventArgs e)
        {
            paint.SetFactory(new EllipseFactory());
        }

        private void Line_Click(object sender, RoutedEventArgs e)
        {
            paint.SetFactory(new LineFactory());
        }

        private void BrokenLine_Click(object sender, RoutedEventArgs e)
        {
            paint.SetFactory(new BrokenLineFactory());
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Program.Close();
        }

        private void ClearAllButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            paint.rewind.ReturnAll();
        }

        private void Canva_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
        }             

        private void Deserialize_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "json (*.json)|*.json";
            if (openFileDialog.ShowDialog() == true)
            {
                string str = System.IO.File.ReadAllText(openFileDialog.FileName);
                paint.Deserialize(str);
            }
        }

        private void Serialize_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "json (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == true)
            {
                FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate);
                string str = paint.Serialize();
                System.IO.File.WriteAllText(saveFileDialog.FileName, str);
            }
        }
    }
}
