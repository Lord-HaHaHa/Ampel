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

namespace Beispiel
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Das Control-Fenster hat eine Ampel
        private Ampel myAmpel;
        public MainWindow()
        {
            InitializeComponent();

            //Ampel wird erzeugt, Komposition
            myAmpel = new Ampel();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            myAmpel.CloseWindow();
        }

        private void btnOn_Click(object sender, RoutedEventArgs e)
        {
            myAmpel.SetOn();
        }

        private void btnToggle_Click(object sender, RoutedEventArgs e)
        {
            myAmpel.ToggleNext();
        }

        private void btnOff_Click(object sender, RoutedEventArgs e)
        {
            myAmpel.SetOff();
        }
    }
}
