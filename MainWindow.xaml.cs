using Figures;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Threading;
//using System

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
            paint.SetPrevPos(e.GetPosition(Canva));
        }


        private void Canva_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //paint.SetNewPos(e.GetPosition(Canva));
            SolidColorBrush LineBrush;
            //if (SelectedLineColor.SelectedColor == null)
            //{
            LineBrush = Brushes.Black;
            //}
            //else
            //    LineBrush = new SolidColorBrush((Color)SelectedLineColor.SelectedColor);
            SolidColorBrush FillBrush;
            //if (SelectedFillColor.SelectedColor == null)
            //{
            FillBrush = Brushes.White;
            //}
            //else
            //    FillBrush = new SolidColorBrush((Color)SelectedFillColor.SelectedColor);
            paint.DrawCurrentFigure(Convert.ToDouble(StrokeWidth.Text), FillBrush, LineBrush, e.GetPosition(Canva));
            paint.SetPrevPos(new Point() { X = -1, Y = -1 });
        }

        private void Canva_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint.PrevPos.X >= 0 && paint.PrevPos.Y >= 0)
            {
                SolidColorBrush LineBrush;
                //if (SelectedLineColor.SelectedColor == null)
                //{
                LineBrush = Brushes.Black;
                //}
                //else
                //    LineBrush = new SolidColorBrush((Color)SelectedLineColor.SelectedColor);
                SolidColorBrush FillBrush;
                //if (SelectedFillColor.SelectedColor == null)
                //{
                FillBrush = Brushes.White;
                //}
                //else
                //    FillBrush = new SolidColorBrush((Color)SelectedFillColor.SelectedColor);
                paint.Prerender(Convert.ToDouble(StrokeWidth.Text), FillBrush, LineBrush, e.GetPosition(Canva));
            }
        }

        private void Canva_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
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
            paint.rewind.Backward();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
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
    }
}
