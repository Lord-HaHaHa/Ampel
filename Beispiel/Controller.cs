using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Beispiel
{
    class Controller
    {
        public List<Ampel> ampels = new List<Ampel>();
        private bool running;

        public Controller(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
            Running = false;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(dispatcherTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e) {
            if (running)
            {
                foreach (Ampel ampel in ampels)
                {
                    ampel.ToggleNext();
                }
            }
        }

        public MainWindow MainWindow { get; }

        void AmpelClosed(object sender, EventArgs a)
        {
            ampels.Remove((Ampel)sender);
            MainWindow.txtActiveAmpels.Text = "Es sind " + ampels.Count().ToString() + " Ampeln aktiv";
        }

        public Ampel registerAmpel(int Top, int Left)
        {
            Ampel ampel = new Ampel(ampels.Count + 1, Top, Left);
            ampel.OnClose += AmpelClosed;
            ampels.Add(ampel);
            return ampel;
        }

        public bool Running { get => running; set => running = value; }

        internal void toggleAuto()
        {
            Running = !Running;
        }
    }
}
