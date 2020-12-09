using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Timers;

namespace Beispiel
{
    public class Ampel
    {
        // Die Ampel hat einen View (Komposition)
        private AmpelView Window;

        // Zustände der Ampel als enum
        private enum Zustand { red, yellow, redyellow, green, off };
        // Attribut von dem Typ Zustand
        private Zustand AStatus;
        // Timer
        private Timer Timer;
        public Ampel()
        {
            // Die Ampel erzeugt ihren View selbst 
            Window = new AmpelView();

            // und zeigt den View an
            Window.Show();
            // Zustandsvariable setzen
            this.AStatus = Zustand.off;

            // Zustandsvariable auf Wert prüfen
            if(this.AStatus == Zustand.off)
            { }

            UpdateAll(); // Window Updaten
        }
        public void ToggleNext()
        {
            switch (AStatus)
            {
                case Zustand.off:
                    AStatus = Zustand.red;
                    break;
                case Zustand.red:
                    AStatus = Zustand.redyellow;
                    break;
                case Zustand.redyellow:
                    AStatus = Zustand.green;
                    break;
                case Zustand.green:
                    AStatus = Zustand.yellow;
                    break;
                case Zustand.yellow:
                    AStatus = Zustand.red;
                    break;
            }
            UpdateAll();
        }

        public void UpdateWindow()
        {
            
            switch (AStatus)
            {
                case Zustand.off:
                    Window.Red.Fill = Brushes.White;
                    Window.Yellow.Fill = Brushes.White;
                    Window.Green.Fill = Brushes.White;
                    break;
                case Zustand.red:
                    Window.Red.Fill = Brushes.Red;
                    Window.Yellow.Fill = Brushes.White;
                    Window.Green.Fill = Brushes.White;
                    break;
                case Zustand.redyellow:
                    Window.Red.Fill = Brushes.Red;
                    Window.Yellow.Fill = Brushes.Yellow;
                    Window.Green.Fill = Brushes.White;
                    break;
                case Zustand.green:
                    Window.Red.Fill = Brushes.White;
                    Window.Yellow.Fill = Brushes.White;
                    Window.Green.Fill = Brushes.Green;
                    break;
                case Zustand.yellow:
                    Window.Red.Fill = Brushes.White;
                    Window.Yellow.Fill = Brushes.Yellow;
                    Window.Green.Fill = Brushes.White;
                    break;
            }
        }

        void UpdateAll()
        {
            UpdateWindow();
        }

        public void ToggleToRed()
        {
            while (AStatus != Zustand.red)
                GoToRed();
        }
        private void GoToRed()
        {
            Timer = new System.Timers.Timer(500);
            // Set attributes for timer
            Timer.Elapsed += OnTimedEvent;
            Timer.AutoReset = false;
            Timer.Enabled = true;
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            ToggleNext();
        }
        public void SetOff()
        {
            ToggleToRed();
            AStatus = Zustand.off;
            UpdateAll();
        }

        public void SetOn()
        {
            AStatus = Zustand.red;
            UpdateAll();
        }
        public string GetStatus()
        {
            var acct = AStatus;
            return acct.ToString();
        }

        public void CloseWindow()
        {
            Window.Close();
        }

    }
}
