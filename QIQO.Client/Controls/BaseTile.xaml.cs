using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QIQO.Client.Controls
{
    /// <summary>
    /// Interaction logic for BaseTile.xaml
    /// </summary>
    public partial class BaseTile : UserControl
    {
        public BaseTile()
        {
            InitializeComponent();
        }


        public string TileLabel
        {
            get { return (string)GetValue(TileLabelProperty); }
            set { SetValue(TileLabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TileLabel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TileLabelProperty =
            DependencyProperty.Register("TileLabel", typeof(string), typeof(BaseTile), new PropertyMetadata("Tile Label"));



        public string TileValue
        {
            get { return (string)GetValue(TileValueProperty); }
            set { SetValue(TileValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TileValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TileValueProperty =
            DependencyProperty.Register("TileValue", typeof(string), typeof(BaseTile), new PropertyMetadata("0"));


    }
}
