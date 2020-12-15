using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Timers;
using System.Diagnostics;

namespace Beispiel
{
    public class Ampel
    {
        // Die Ampel hat einen View (Komposition)
        private AmpelView Window;
        // Zustände der Ampel als enum
        private enum Zustand { red1, red2, red3, red4, red5, yellow, redyellow, green, off };
        // Attribut von dem Typ Zustand
        private Zustand AStatus;

        private int index;

        public Ampel(int index, int top, int left)
        {
            // Die Ampel erzeugt ihren View selbst 
            Window = new AmpelView(this);
            Window.Top = top;
            Window.Left = left;
            // und zeigt den View an
            Window.Show();
            // Zustandsvariable setzen
            AStatus = Zustand.off;

            this.index = index;

            UpdateAll(); // Window Updaten
        }

        public event EventHandler OnClose;

        protected void onClose(EventArgs e) { OnClose?.Invoke(this, e); }

        ~Ampel()
        {

        }
        public void ToggleNext()
        {
            switch (AStatus)
            {
                case Zustand.off:
                    if (index % 2 == 0)
                    {
                        AStatus = Zustand.green;
                    }
                    else
                    {
                        AStatus = Zustand.red3;
                    }
                    break;
                case Zustand.red1:
                    AStatus = Zustand.red2;
                    break;
                case Zustand.red2:
                    AStatus = Zustand.red3;
                    break;
                case Zustand.red3:
                    AStatus = Zustand.red4;
                    break;
                case Zustand.red4:
                    AStatus = Zustand.red5;
                    break;
                case Zustand.red5:
                    AStatus = Zustand.redyellow;
                    break;
                case Zustand.redyellow:
                    AStatus = Zustand.green;
                    break;
                case Zustand.green:
                    AStatus = Zustand.yellow;
                    break;
                case Zustand.yellow:
                    AStatus = Zustand.red1;
                    break;
            }
            UpdateAll();
        }

        public void UpdateColors()
        {
            switch (AStatus)
            {
                case Zustand.off:
                    Window.Red.Fill = Brushes.White;
                    Window.Yellow.Fill = Brushes.White;
                    Window.Green.Fill = Brushes.White;
                    break;
                case Zustand.red1:
                case Zustand.red2:
                case Zustand.red3:
                case Zustand.red4:
                case Zustand.red5:
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
            UpdateColors();
            Window.index.Text = index.ToString();
        }

        public void SetOff()
        {
            AStatus = Zustand.off;
            UpdateAll();
        }

        public void SetOn()
        {
            ToggleNext();
        }
        public string GetStatus()
        {
            var acct = AStatus;
            return acct.ToString();
        }

        public void Close()
        {
            onClose(new EventArgs());
        }

        public void CloseWindow()
        {
            onClose(new EventArgs());
            Window.Close();
        }

    }
}
