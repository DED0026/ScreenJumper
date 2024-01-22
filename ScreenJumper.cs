using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ScreenJumper
{
    public partial class ScreenJumper : Form
    {
        Size Screenbounds;
        Point meow; // = new Point(40,0);
        private Random rnd = new Random();

        public ScreenJumper() => InitializeComponent();
        private void Form1_Load(object sender, EventArgs e)
        {
            //assign the available screen space
            Screenbounds = Screen.PrimaryScreen.Bounds.Size - Size;

            //randomize speed
            meow = new Point(rnd.Next(0, Screenbounds.Width / 40), rnd.Next(0, Screenbounds.Height / 40));

            //start the mover
            UpdatePos.Start();
        }

        void randomize()
        {
            //randomize color in 100-255 range
            BackColor = Color.FromArgb(rnd.Next(100, 255), rnd.Next(100, 255), rnd.Next(100, 255));
        }

        private void UpdatePos_Tick(object sender, EventArgs e)
        {
            Location = new Point(Location.X + meow.X, Location.Y + meow.Y);
            if (!Enumerable.Range(0, Screenbounds.Height).Contains(Location.Y))
            {
                meow = new Point(meow.X, -meow.Y);
                randomize();
            }
            if (!Enumerable.Range(0, Screenbounds.Width).Contains(Location.X))
            {
                meow = new Point(-meow.X, meow.Y);
                randomize();
            }
        }
    }
}
