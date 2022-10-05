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

namespace WpfCanvas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point p1;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        bool captured = false;
        double x_shape, x_canvas, y_shape, y_canvas;
        UIElement source = null;

        private void MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            source = (UIElement)sender;
            Mouse.Capture(source);
            captured = true;
            x_shape = Canvas.GetLeft(source);
            //x_canvas = e.GetPosition(Canvas.X);
            y_shape = Canvas.GetTop(source);
            //y_canvas = e.GetPosition(Canvas.Y);
        }
        

        private void MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            captured = false;
        }
        
        private void MouseMove(object sender, MouseEventArgs e)
        {
            if (captured == true)
            {
                p1 = e.GetPosition((UIElement)sender);
                //p1 = e.GetPosition((IInputElement)sender);
                int mouseX = (int)p1.X;
                int mouseY = (int)p1.Y;

                c1.SetValue(Canvas.TopProperty, (double)mouseY);
                c1.SetValue(Canvas.LeftProperty, (double)mouseX);
            }

        }
        


        
        private void Canvas_Drop(object sender, DragEventArgs e)
        {
        //    // If an element in the panel has already handled the drop,
        //    // the panel should not also handle it.
        //    //if (e.Handled == false)
        //    //{
        //        Canvas _panel = (Canvas)sender;
        //        UIElement _element = (UIElement)e.Data.GetData("Object");

        //        //if (_panel != null && _element != null)
        //        //{
        //            // Get the panel that the element currently belongs to,
        //            // then remove it from that panel and add it the Children of
        //            // the panel that its been dropped on.
        //         //   Panel _parent = (Panel)VisualTreeHelper.GetParent(_element);

        //           // if (_parent != null)
        //           // {
        //                if (e.KeyStates == DragDropKeyStates.ControlKey &&
        //                    e.AllowedEffects.HasFlag(DragDropEffects.Copy))
        //                {
        //                    CanvasCircle _circle = new CanvasCircle((CanvasCircle)_element);
        //                    _panel.Children.Add(_circle);
        //                    // set the value to return to the DoDragDrop call
        //                    e.Effects = DragDropEffects.Copy;
        //                }
        //                else if (e.AllowedEffects.HasFlag(DragDropEffects.Move))
        //                {
        //                    //_parent.Children.Remove(_element);
        //                    _panel.Children.Add(_element);
        //                    // set the value to return to the DoDragDrop call
        //                    e.Effects = DragDropEffects.Move;
        //                }
        //          //  }
        //       // }
        //    //}
        }

    }
}
