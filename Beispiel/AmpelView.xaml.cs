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
using System.Windows.Shapes;

namespace Beispiel
{
    /// <summary>
    /// Interaktionslogik für AmpelView.xaml
    /// </summary>
    public partial class AmpelView : Window
    {
        private Ampel _ampel;
        public AmpelView(Ampel ampel)
        {
            _ampel = ampel;
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _ampel.Close();
        }
    }
}
