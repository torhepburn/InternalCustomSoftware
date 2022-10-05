using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfSquare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isDraginProgress;
        private Line l1;

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 3; i <= 5; i++)
            {
                Line l = new Line();
                //("l"+ i.ToString).Stroke = System.Windows.Media.Brushes.Black;
                //("l" + i.ToString).X1 = (100 * i);
                //("l" + i.ToString).Y1 = 10;
                //("l" + i.ToString).X2 = (100 * i);
                //("l" + i.ToString).Y2 = 400;
                //("l" + i.ToString).StrokeThickness = 2;
                //cvs.Children.Add("l" + i.ToString);
            }
        }

        private void s_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isDraginProgress = true;
            sq1.CaptureMouse();
            DragDrop.DoDragDrop(sq1, sq1.Fill.ToString(), DragDropEffects.Move);
        }

        private void s_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isDraginProgress = false;
            sq1.ReleaseMouseCapture();
        }

        private void s_MouseMove (object sender, MouseEventArgs e)
        {
            if (!_isDraginProgress) return;

            //get the position of the mouse relative to the canvas
            var mousePos = e.GetPosition(cvs);

            //center the square on the mouse
            double left = mousePos.X - (sq1.ActualWidth / 2);
            double top = mousePos.Y - (sq1.ActualHeight / 2);

            Canvas.SetLeft(sq1, left);
            Canvas.SetTop(sq1, top);

        }

        private void R42_Drop (object sender, DragEventArgs e)
        {
            //BrushConverter converter = new BrushConverter();
            //Brush newFill = (Brush)converter.ConvertFromString("Blue");
            R42.Fill = sq1.Fill; 
        }

    }
}
