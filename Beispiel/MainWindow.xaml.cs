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
        private Ampel Ampel;


        // Ampel-Controler 
        private Controller controller;

        public MainWindow()
        {
            InitializeComponent();
            //Ampel wird erzeugt, Komposition
            controller = new Controller(this);
            Ampel = controller.registerAmpel(0,100);
            
            //Registrieren von mehreren Ampeln
            Ampel = controller.registerAmpel(300,0);
            Ampel = controller.registerAmpel(600,100);
            Ampel = controller.registerAmpel(300,300);

            txtActiveAmpels.Text = "Es sind " + controller.ampels.Count().ToString() + " Ampeln aktiv";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            while (controller.ampels.Count() > 0)
            {
                Ampel ampel = controller.ampels[controller.ampels.Count() - 1];
                ampel.CloseWindow();
            }
        }

        private void btnOn_Click(object sender, RoutedEventArgs e)
        {
            foreach (Ampel ampel in controller.ampels)
            {                               
                ampel.SetOn();
            }
        }

        private void btnToggle_Click(object sender, RoutedEventArgs e)
        {
            foreach (Ampel ampel in controller.ampels) { 
                ampel.ToggleNext(); 
            }
        }

        private void btnOff_Click(object sender, RoutedEventArgs e)
        {
            foreach (Ampel ampel in controller.ampels)
            {
                ampel.SetOff();
            }
        }

        private void btnAuto_Click(object sender, RoutedEventArgs e)
        {
            controller.toggleAuto();
        }
    }
}
