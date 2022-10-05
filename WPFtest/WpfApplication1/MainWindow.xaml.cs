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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            WpfApplication1.AccessFrontEndsDataSet accessFrontEndsDataSet = ((WpfApplication1.AccessFrontEndsDataSet)(this.FindResource("accessFrontEndsDataSet")));
            // Load data into the table ZygoCannonMappings. You can modify this code as needed.
            WpfApplication1.AccessFrontEndsDataSetTableAdapters.ZygoCannonMappingsTableAdapter accessFrontEndsDataSetZygoCannonMappingsTableAdapter = new WpfApplication1.AccessFrontEndsDataSetTableAdapters.ZygoCannonMappingsTableAdapter();
            accessFrontEndsDataSetZygoCannonMappingsTableAdapter.Fill(accessFrontEndsDataSet.ZygoCannonMappings);
            System.Windows.Data.CollectionViewSource zygoCannonMappingsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("zygoCannonMappingsViewSource")));
            zygoCannonMappingsViewSource.View.MoveCurrentToFirst();
        }
    }
}
