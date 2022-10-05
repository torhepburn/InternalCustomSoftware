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

namespace wpfDRAG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //UIElement source = null;
        Point p1;
        //UIElement source = null;
        Ellipse c1;
        string flag = "n";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            //source = (UIElement)sender;
            //Mouse.Capture(source);
            
            //Ellipse c1 = new Ellipse { Width = 100, Height = 100, Fill = Brushes.Blue };
            //Canvas.SetLeft(c1, e.GetPosition((UIElement)sender).X);
            //Canvas.SetTop(c1, e.GetPosition((UIElement)sender).Y);
            //Ellipse c1 = new Ellipse { Width = 100, Height = 100, Fill = Brushes.Blue };
            //Ellipse c2 = new Ellipse { Width = 100, Height = 100, Fill = Brushes.Red };

            if (flag == "y")
            {
                c1 = new Ellipse { Width = 50, Height = 30, Fill = Brushes.Blue };
                
                cvs.Children.Insert(0, c1);
                
                //p1 = e.GetPosition((UIElement)sender);
                p1 = e.GetPosition((IInputElement)sender);
                int mouseX = (int)p1.X;
                int mouseY = (int)p1.Y;

                c1.SetValue(Canvas.TopProperty, (double)mouseY);
                c1.SetValue(Canvas.LeftProperty, (double)mouseX);
            }

        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            
            c1 = new Ellipse { Width = 50, Height = 30, Fill = Brushes.Blue };
            //Ellipse c2 = new Ellipse { Width = 100, Height = 100, Fill = Brushes.Red };
            cvs.Children.Insert(0, c1);
            p1 = e.GetPosition((IInputElement)sender);
            int mouseX = (int)p1.X;
            int mouseY = (int)p1.Y;

            c1.SetValue(Canvas.TopProperty, (double)mouseY);
            c1.SetValue(Canvas.LeftProperty, (double)mouseX);
            //c1.SetValue(Canvas.TopProperty, (double)100);
            //c1.SetValue(Canvas.LeftProperty, (double)100);
            

            if (flag == "y")
            {
                flag = "n";
            }
            else
            {
                flag = "y";

            }
            
            //Ellipse c2 = new Ellipse { Width = 100, Height = 100, Fill = Brushes.Red };

            //p1 = e.GetPosition((UIElement)sender);
            ////p1 = e.GetPosition((IInputElement)sender);
            //int mouseX = (int)p1.X;
            //int mouseY = (int)p1.Y;

            //c2.SetValue(Canvas.TopProperty, (double)mouseY);
            //c2.SetValue(Canvas.LeftProperty, (double)mouseX);
            
            //Canvas.SetLeft(c2, e.GetPosition((UIElement)sender).X);
            //Canvas.SetTop(c2, e.GetPosition((UIElement)sender).Y);
            //c2.SetValue(Canvas.TopProperty,(double))
        }
        
    }
}
