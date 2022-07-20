using System;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace AlpacaDesktop
{
    public partial class Form1 : Form
    {
        private bool isDraggable = false;
        private Point point = new Point(0, 0);
        PictureBox newPic = new PictureBox();
        Form newForm = new Form();
        string color = "Pink";

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer secondaryTimer;
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
            TopMost = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initTimer();
        }
        private void initTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(displayRandomNumber);
            timer.Interval = 3000; 
            timer.Start();
        }

        private void initTimerOneSecond()
        {
            secondaryTimer = new System.Windows.Forms.Timer();
            secondaryTimer.Tick += new EventHandler(rightMovement);
            secondaryTimer.Interval = 300; 
            secondaryTimer.Start();
        }

        private void rightMovement(object sender, EventArgs e)
        {

            if (this.Left > 0)
            {
                this.Left -= 10;
            }
            else
            {
                displayRandomNumber(sender, e);
            }
        }

        private void initTimerLeftMovement()
        {
            secondaryTimer = new System.Windows.Forms.Timer();
            secondaryTimer.Tick += new EventHandler(leftMovement);
            secondaryTimer.Interval = 300; 
            secondaryTimer.Start();
        }

        private void leftMovement(object sender, EventArgs e)
        {

            double screenWidth = Screen.PrimaryScreen.Bounds.Width;

            if (this.Left + 200 < screenWidth)
            {
                this.Left += 10;
            }
            else
            {
                displayRandomNumber(sender, e);
            }
        }


        private void initTimerShortJumpMovement()
        {
            secondaryTimer = new System.Windows.Forms.Timer();
            secondaryTimer.Tick += new EventHandler(shortJumpMovement);
            secondaryTimer.Interval = 300; 
            secondaryTimer.Start();
        }

        private void shortJumpMovement(object sender, EventArgs e)
        {
            this.Top -= 10;
            this.Top += 10;
        }

        private void initTimerShortQueueJumpMovement()
        {
            secondaryTimer = new System.Windows.Forms.Timer();
            secondaryTimer.Tick += new EventHandler(shortQueueJumpMovement);
            secondaryTimer.Interval = 300; 
            secondaryTimer.Start();
        }

        private void shortQueueJumpMovement(object sender, EventArgs e)
        {
            this.Top -= 10;
            this.Top += 10;
        }

        private void displayRandomNumber(object sender, EventArgs e)
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 2);
            if (secondaryTimer != null)
            {
                secondaryTimer.Stop();
            }

            // TO - DO: A LA HORA DE HACER EL REFACTOR AQUÍ, HACER QUE PRIMERO SE ELIJA EL LADO (SWITCH 2) Y DE ÁHÍ LA ANIMACIÓN CON SU COLOR

            switch(randomNumber)
            {
                case 1: //base
                    MessageBox.Show("You're here");
                    pictureBox2.Image = Image.FromFile("C:/Users/Zegar/source/repos/Desktop-Alpaca/Properties/Animations/"+color+"/base.gif");
                    break;
                case 2: //base left
                    pictureBox2.Image = Image.FromFile("C:/Users/Zegar/source/repos/Desktop-Alpaca/Properties/Animations/"+color+"baseLeft.gif");
                    break;
                case 3: //rightMovement
                    pictureBox2.Image = Image.FromFile("C:/Users/Zegar/source/repos/Desktop-Alpaca/Properties/Animations/"+color+"rightMovement.gif");
                    initTimerOneSecond();
                    break;
                case 4: //leftMovement
                    pictureBox2.Image = Image.FromFile("C:/Users/Zegar/source/repos/Desktop-Alpaca/Properties/Animations/"+color+"leftMovement.gif");
                    initTimerLeftMovement();
                    break;
                case 5: //short jump
                    pictureBox2.Image = Image.FromFile("C:/Users/Zegar/source/repos/Desktop-Alpaca/Properties/Animations/"+color+"shortJumpAnimation.gif");
                    initTimerShortJumpMovement();
                    break;
                case 6: //short jump left
                    pictureBox2.Image = Image.FromFile("C:/Users/Zegar/source/repos/Desktop-Alpaca/Properties/Animations/"+color+"shortJumpAnimationLeft.gif");
                    initTimerShortJumpMovement();
                    break;
                case 7: //short queue jump & poop
                    pictureBox2.Image = Image.FromFile("C:/Users/Zegar/source/repos/Desktop-Alpaca/Properties/Animations/"+color+"shortJumpQueueAnimation.gif");
                    
                    newForm.BackColor = Color.LimeGreen;
                    newForm.TransparencyKey = Color.LimeGreen;
                    newForm.TopMost = true;
                    newForm.Location = new Point(this.DesktopLocation.X + 25 , this.DesktopLocation.Y + 15);
                    newForm.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                    newForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

                    newPic.Height = 60; 
                    newPic.Width = 100; 
                    newPic.Image = Image.FromFile("C:/Users/Zegar/Downloads/caca.png");
                    newPic.Location = new Point(100, 100);
                    newForm.Controls.Add(newPic);

                    newForm.Show();

                    initTimerShortQueueJumpMovement();
                    break;
                case 8: //short queue jump left
                    pictureBox2.Image = Image.FromFile("C:/Users/Zegar/source/repos/Desktop-Alpaca/Properties/Animations/"+color+"shortJumpQueueAnimationLeft.gif");
                    initTimerShortQueueJumpMovement();
                    break;

            }
        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("CEPILLADO DE LA ALPACA") ;
        }

        private void newForm_MouseClick(object sender, EventArgs e)
        {
            newForm.Hide();
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // TO - DO: Añadir animación para que la alpaca cambie de color (se le cae un bote de pintura). 
                color = "Blue";
            }
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            isDraggable = false;
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            isDraggable = true;
            point = new Point(e.X, e.Y);
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            double screenWidth = Screen.PrimaryScreen.Bounds.Width;
            double screenHeight = Screen.PrimaryScreen.Bounds.Height;

            if (isDraggable)
            {
                Point pointToScreen = PointToScreen(e.Location);

                if (pointToScreen.X - this.point.X > Convert.ToInt32(screenWidth)-130) // right
                {
                    Location = new Point(Convert.ToInt32(screenWidth)-130, pointToScreen.Y - this.point.Y);                
                }

                else if (pointToScreen.X - this.point.X <= 0) // left
                {
                    Location = new Point(0, pointToScreen.Y - this.point.Y);                
                }

                else if(pointToScreen.Y - this.point.Y <= 0) // top
                {
                    Location = new Point(pointToScreen.X - this.point.X, 0);                
                }

                else if(pointToScreen.Y - this.point.Y >= Convert.ToInt32(screenHeight)-160) // bottom
                {
                    Location = new Point(pointToScreen.X - this.point.X, Convert.ToInt32(screenHeight)-160);                
                }

                else // anywhere
                {
                    Location = new Point(pointToScreen.X - this.point.X, pointToScreen.Y - this.point.Y);
                }
            }
        }
    }
}
