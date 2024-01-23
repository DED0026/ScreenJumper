using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenJumper
{
    public partial class ScreenJumper : Form
    {
        Size Screenbounds;
        Point Velocity;
        private Random rnd = new Random();

        public ScreenJumper() => InitializeComponent();
        private void Form1_Load(object sender, EventArgs e)
        {
            //assign the available screen space
            Screenbounds = Screen.PrimaryScreen.WorkingArea.Size - Size;

            //randomize speed
            Velocity = new Point(rnd.Next(0, Screenbounds.Width / 40), rnd.Next(0, Screenbounds.Height / 40));

            //start the mover
            UpdatePos.Start();
        }

        void randomize()
        {
            //randomize color in 100-255 range
            BackColor = Color.FromArgb(rnd.Next(50, 255), rnd.Next(50, 255), rnd.Next(50, 255));
        }

        private void UpdatePos_Tick(object sender, EventArgs e)
        {
            Location = new Point(Location.X + Velocity.X, Location.Y + Velocity.Y);

            if (!(Location.Y > 0 && Location.Y < Screenbounds.Height))
            {
                Velocity = new Point(Velocity.X, -Velocity.Y);
                randomize();
            }

            if (!(Location.X > 0 && Location.X < Screenbounds.Width))
            {
                Velocity = new Point(-Velocity.X, Velocity.Y);
                randomize();
            }
        }
    }
}
