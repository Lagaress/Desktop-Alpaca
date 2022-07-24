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
        private string side = "Left", color = "Pink";
        private double screenWidth = Screen.PrimaryScreen.Bounds.Width;
        private double screenHeight = Screen.PrimaryScreen.Bounds.Height;
        private bool isDraggable = false;
        private Point point = new Point(0, 0);
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer secondaryTimer;
        
        Random random = new Random();
        PictureBox newPic = new PictureBox();
        Form newForm = new Form();

        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
            TopMost = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainTimer();
        }
        private void mainTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(displayRandomAnimation);
            timer.Interval = 2000; 
            timer.Start();
        }

        private void animationTimer()
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
                displayRandomAnimation(sender, e);
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


            if (this.Left + 200 < screenWidth)
            {
                this.Left += 10;
            }
            else
            {
                displayRandomAnimation(sender, e);
            }
        }


        private void shortJumpTimer()
        {
            secondaryTimer = new System.Windows.Forms.Timer();
            secondaryTimer.Tick += new EventHandler(shortJump);
            secondaryTimer.Interval = 300; 
            secondaryTimer.Start();
        }

        private void shortJump(object sender, EventArgs e)
        {
            this.Top -= 10;
            this.Top += 10;
        }

        private void shortQueueJumpTimer()
        {
            secondaryTimer = new System.Windows.Forms.Timer();
            secondaryTimer.Tick += new EventHandler(shortQueueJump);
            secondaryTimer.Interval = 300; 
            secondaryTimer.Start();
        }

        private void shortQueueJump(object sender, EventArgs e)
        {
            this.Top -= 10;
            this.Top += 10;
        }

        private void displayRandomAnimation(object sender, EventArgs e)
        {
            stopAnimationTimer();
            generateRandomSide();
            generateRandomAnimation();
            
        }

        private void generateRandomSide()
        {
            int randomNumber = random.Next(1, 3);
            switch (randomNumber) 
            {
                case 1: 
                    side = "Left";
                    break; 
                case 2: 
                    side = "Right";
                    break;
            }
        }

        private void stopAnimationTimer()
        {
            if (secondaryTimer != null)
            {
                secondaryTimer.Stop();
            }
        }

        private void generateRandomAnimation()
        {
            int randomNumber = random.Next(1, 6);

            switch(randomNumber)
            {
                case 1: //base
                    pictureBox2.Image = Image.FromFile("C:/Users/Zegar/source/repos/Desktop-Alpaca/Properties/Animations/"+side+"/"+color+"/base.gif");
                    break;
                case 2: //movement
                    pictureBox2.Image = Image.FromFile("C:/Users/Zegar/source/repos/Desktop-Alpaca/Properties/Animations/"+side+"/"+color+"/movement.gif");
                    chooseMovementDependingSide();
                    break;
                case 3: //short jump
                    pictureBox2.Image = Image.FromFile("C:/Users/Zegar/source/repos/Desktop-Alpaca/Properties/Animations/"+side+"/"+color+"/shortJump.gif");
                    shortJumpTimer();
                    break;
                case 4: //short queue jump
                    pictureBox2.Image = Image.FromFile("C:/Users/Zegar/source/repos/Desktop-Alpaca/Properties/Animations/"+side+"/"+color+"/shortJumpQueue.gif");
                    shortQueueJumpTimer();
                    break;
                case 5: //poop
                    pictureBox2.Image = Image.FromFile("C:/Users/Zegar/source/repos/Desktop-Alpaca/Properties/Animations/"+side+"/"+color+"/pedo.gif");
                    generatePop();
                    break;
            }
        }

        private void chooseMovementDependingSide()
        {
            if (side == "Left")
            {
                animationTimer();
            }
            else
            {
                initTimerLeftMovement();
            }
        }

        private void generatePop()
        {
            createPopForm();
            createPopPictureBox();
            newForm.Show();
        }

        private void createPopForm()
        {
            newForm.BackColor = Color.LimeGreen;
            newForm.TransparencyKey = Color.LimeGreen;
            newForm.TopMost = true;
            setLocationDependingSide();
            newForm.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            newForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void setLocationDependingSide()
        {
            if (side == "Left")
            {
                newForm.Location = new Point(this.DesktopLocation.X + 25 , this.DesktopLocation.Y - 43);
            }
            else
            {
                newForm.Location = new Point(this.DesktopLocation.X - 175 , this.DesktopLocation.Y - 43);
            }
        }

        private void createPopPictureBox()
        {
            newPic.Height = 100; 
            newPic.Width = 100; 
            newPic.Image = Image.FromFile("C:/Users/Zegar/source/repos/Desktop-Alpaca/Properties/Animations/poop.gif");
            newPic.Location = new Point(100, 100);
            newForm.Controls.Add(newPic);
        }




        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile("C:/Users/Zegar/source/repos/Desktop-Alpaca/Properties/Animations/"+side+"/"+color+"/cepillado.gif");
        }

        private void newForm_MouseClick(object sender, EventArgs e)
        {
            newForm.Hide();
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                color = "Blue";
                pictureBox2.Image = Image.FromFile("C:/Users/Zegar/source/repos/Desktop-Alpaca/Properties/Animations/"+side+"/"+color+"/transformation.gif");
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
            if (isDraggable)
            {
                setLocationDependingCursor(e);
            }
        }

        private void setLocationDependingCursor(MouseEventArgs e)
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
