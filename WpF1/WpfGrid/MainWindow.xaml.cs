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

namespace WpfGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isDraginProgress;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void s_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
            
            //_isDraginProgress = true;
            sq1.CaptureMouse();
            DragDrop.DoDragDrop(sq1, sq1.Fill.ToString(), DragDropEffects.Move);
        }

        private void s_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //var mousePos = (UIElement)e.Source;

            //int c = Grid.GetColumn(mousePos);
            //int r = Grid.GetRow(mousePos);

            //Grid.SetRow(sq1, r);
            //Grid.SetColumn(sq1, c);
            
            //_isDraginProgress = false;
            //sq1.ReleaseMouseCapture();
        }

        private void s_MouseMove(object sender, MouseEventArgs e)
        {
            //if (!_isDraginProgress) return;

            //get the position of the mouse relative to the canvas
            //var mousePos = (UIElement)e.Source;

            //int c = Grid.GetColumn(mousePos);
            //int r = Grid.GetRow(mousePos);

            //Grid.SetRow(sq1, 3);
            //Grid.SetColumn(sq1, 3);
            

            //Grid.SetRow(sq1,r);
            //Grid.SetColumn(sq1, c);
            
            //center the square on the mouse
            //double left = mousePos.X - (sq1.ActualWidth / 2);
            //double top = mousePos.Y - (sq1.ActualHeight / 2);

            //Grid.SetRow(sq1, );
            //Canvas.SetTop(sq1, top);

        }

        private void grd_Drop(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;

        }

        private void grd_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;

        }
    }
}
