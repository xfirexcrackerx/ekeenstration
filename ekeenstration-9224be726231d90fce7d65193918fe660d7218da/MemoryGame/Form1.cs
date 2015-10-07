﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace MemoryGame
{
    public partial class GameWindow : Form
    {
        private void Form1_Click(object sender, System.EventArgs e)
        {
            this.BackColor = System.Drawing.Color.DarkBlue;
        }
        Random Location = new Random();
        int score = 0;
        List<Point> points = new List<Point>();
        int zero = 0;
        bool again = false;
        PictureBox PendingImage1;
        PictureBox PendingImage2;
        System.Media.SoundPlayer card1 = new System.Media.SoundPlayer("card1audio.wav");
        System.Media.SoundPlayer card2 = new System.Media.SoundPlayer("card2audio.wav");
        System.Media.SoundPlayer card3 = new System.Media.SoundPlayer("card3audio.wav");
        System.Media.SoundPlayer card4 = new System.Media.SoundPlayer("card4audio.wav");
        System.Media.SoundPlayer card5 = new System.Media.SoundPlayer("card5audio.wav");
        System.Media.SoundPlayer card6 = new System.Media.SoundPlayer("card6audio.wav");
        System.Media.SoundPlayer card7 = new System.Media.SoundPlayer("card7audio.wav");
        System.Media.SoundPlayer card8 = new System.Media.SoundPlayer("card8audio.wav");
        System.Media.SoundPlayer card9 = new System.Media.SoundPlayer("card9audio.wav");
        System.Media.SoundPlayer card10 = new System.Media.SoundPlayer("card10audio.wav");
        System.Media.SoundPlayer card11 = new System.Media.SoundPlayer("card11audio.wav");
        System.Media.SoundPlayer card12 = new System.Media.SoundPlayer("card12audio.wav");

        public GameWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "5";
            foreach(PictureBox picture in CardsHolder.Controls)
            {
                picture.Enabled = true;
                points.Add(picture.Location);
            }
            foreach (PictureBox picture in CardsHolder.Controls)
            {
                int next = Location.Next(points.Count);
                Point p = points[next];
                picture.Location = p;
                points.Remove(p);
            }
            timer1.Start();
            timer2.Start();
            Card1.Image = Properties.Resources.Card1;
            Card2.Image = Properties.Resources.Card2;
            Card3.Image = Properties.Resources.Card3;
            Card4.Image = Properties.Resources.Card4;
            Card5.Image = Properties.Resources.Card5;
            Card6.Image = Properties.Resources.Card6;
            Card7.Image = Properties.Resources.Card7;
            Card8.Image = Properties.Resources.Card8;
            Card9.Image = Properties.Resources.Card9;
            Card10.Image = Properties.Resources.Card10;
            Card11.Image = Properties.Resources.Card11;
            Card12.Image = Properties.Resources.Card12;
            DupCard1.Image = Properties.Resources.Card1;
            DupCard2.Image = Properties.Resources.Card2;
            DupCard3.Image = Properties.Resources.Card3;
            DupCard4.Image = Properties.Resources.Card4;
            DupCard5.Image = Properties.Resources.Card5;
            DupCard6.Image = Properties.Resources.Card6;
            DupCard7.Image = Properties.Resources.Card7;
            DupCard8.Image = Properties.Resources.Card8;
            DupCard9.Image = Properties.Resources.Card9;
            DupCard10.Image = Properties.Resources.Card10;
            DupCard11.Image = Properties.Resources.Card11;
            DupCard12.Image = Properties.Resources.Card12;
            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            foreach (PictureBox picture in CardsHolder.Controls)
            {
                picture.Cursor = Cursors.Hand;
                picture.Image = Properties.Resources.cover1;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int timer = Convert.ToInt32(label1.Text);
            timer = timer-1;
            label1.Text = Convert.ToString(timer);
            if (timer==0)
            {
                timer2.Stop();
                label1.Visible = false;
            }
        }

        #region Cards
        // Below we start defining the methods for the different cards 
        private void Card1_Click(object sender, EventArgs e)
        {
            Card1.Image = Properties.Resources.Card1;
            if (PendingImage1==null)
            {
                PendingImage1 = Card1;
            }
            else if (PendingImage1!=null&&PendingImage2==null)
            {
                PendingImage2 = Card1;
            }
            if (PendingImage1!=null&&PendingImage2!=null)
            {
                if (PendingImage1.Tag==PendingImage2.Tag)
                {
                    card1.Play();
                    PendingImage2 = null;
                    PendingImage1 = null;
                    Card1.Enabled = false;
                    DupCard1.Enabled = false;
                ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    zero = Convert.ToInt32(ScoreCounter.Text);
                    if (zero > 0)
                    {
                        ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5);   
                    }
      
                    timer3.Start();
                }
        
            }
        }

        private void DupCard1_Click(object sender, EventArgs e)
        {
            DupCard1.Image = Properties.Resources.Card1;
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard1;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard1;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    card1.Play();
                    PendingImage2 = null;
                    PendingImage1 = null;
                    Card1.Enabled = false;
                    DupCard1.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    timer3.Start();
                    zero = Convert.ToInt32(ScoreCounter.Text);
                    if (zero > 0)
                    {
                        ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5);
                    }
                }

            }
        }

        private void Card2_Click(object sender, EventArgs e)
        {
            Card2.Image = Properties.Resources.Card2;
            if (PendingImage1 == null)
            {
                PendingImage1 = Card2;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card2;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    card2.Play();
                    PendingImage2 = null;
                    PendingImage1 = null;
                    Card2.Enabled = false;
                    DupCard2.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    timer3.Start();
                    zero = Convert.ToInt32(ScoreCounter.Text);
                    if (zero > 0)
                    {
                        ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5);
                    }
                }

            }
        }

        private void DupCard2_Click(object sender, EventArgs e)
        {
            DupCard2.Image = Properties.Resources.Card2;
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard2;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard2;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    card2.Play();
                    PendingImage2 = null;
                    PendingImage1 = null;
                    Card2.Enabled = false;
                    DupCard2.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    timer3.Start();
                    zero = Convert.ToInt32(ScoreCounter.Text);
                    if (zero > 0)
                    {
                        ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5);
                    }
                }

            }
        }

        private void Card3_Click(object sender, EventArgs e)
        {
            Card3.Image = Properties.Resources.Card3;
            if (PendingImage1 == null)
            {
                PendingImage1 = Card3;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card3;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    card3.Play();
                    PendingImage2 = null;
                    PendingImage1 = null;
                    Card3.Enabled = false;
                    DupCard3.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    timer3.Start();
                    zero = Convert.ToInt32(ScoreCounter.Text);
                    if (zero > 0)
                    {
                        ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5);
                    }
                }

            }
        }

        private void DupCard3_Click(object sender, EventArgs e)
        {
            DupCard3.Image = Properties.Resources.Card3;
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard3;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard3;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    card3.Play();
                    PendingImage2 = null;
                    PendingImage1 = null;
                    Card3.Enabled = false;
                    DupCard3.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    timer3.Start();
                    zero = Convert.ToInt32(ScoreCounter.Text);
                    if (zero > 0)
                    {
                        ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5);
                    }
                }

            }
        }

        private void Card4_Click(object sender, EventArgs e)
        {
            Card4.Image = Properties.Resources.Card4;
            if (PendingImage1 == null)
            {
                PendingImage1 = Card4;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card4;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    card4.Play();
                    PendingImage2 = null;
                    PendingImage1 = null;
                    Card4.Enabled = false;
                    DupCard4.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    timer3.Start();
                    zero = Convert.ToInt32(ScoreCounter.Text);
                    if (zero > 0)
                    {
                        ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5);
                    }
                }

            }
        }

        private void DupCard4_Click(object sender, EventArgs e)
        {
            DupCard4.Image = Properties.Resources.Card4;
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard4;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard4;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    card4.Play();
                    PendingImage2 = null;
                    PendingImage1 = null;
                    Card4.Enabled = false;
                    DupCard4.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    timer3.Start();
                    zero = Convert.ToInt32(ScoreCounter.Text);
                    if (zero > 0)
                    {
                        ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5);
                    }
                }

            }
        }

        private void Card5_Click(object sender, EventArgs e)
        {
            Card5.Image = Properties.Resources.Card5;
            if (PendingImage1 == null)
            {
                PendingImage1 = Card5;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card5;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    card5.Play();
                    PendingImage2 = null;
                    PendingImage1 = null;
                    Card5.Enabled = false;
                    DupCard5.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    timer3.Start();
                    zero = Convert.ToInt32(ScoreCounter.Text);
                    if (zero > 0)
                    {
                        ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5);
                    }
                }

            }
        }

        private void DupCard5_Click(object sender, EventArgs e)
        {
            DupCard5.Image = Properties.Resources.Card5;
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard5;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard5;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    card5.Play();
                    PendingImage2 = null;
                    PendingImage1 = null;
                    Card5.Enabled = false;
                    DupCard5.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    timer3.Start();
                    zero = Convert.ToInt32(ScoreCounter.Text);
                    if (zero > 0)
                    {
                        ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5);
                    }
                }

            }
        }

        private void Card6_Click(object sender, EventArgs e)
        {
            Card6.Image = Properties.Resources.Card6;
            if (PendingImage1 == null)
            {
                PendingImage1 = Card6;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card6;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    card6.Play();
                    PendingImage2 = null;
                    PendingImage1 = null;
                    Card6.Enabled = false;
                    DupCard6.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    timer3.Start();
                    zero = Convert.ToInt32(ScoreCounter.Text);
                    if (zero > 0)
                    {
                        ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5);
                    }
                }

            }
        }

        private void DupCard6_Click(object sender, EventArgs e)
        {
            DupCard6.Image = Properties.Resources.Card6;
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard6;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard6;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    card6.Play();
                    PendingImage2 = null;
                    PendingImage1 = null;
                    Card6.Enabled = false;
                    DupCard6.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    timer3.Start();
                    zero = Convert.ToInt32(ScoreCounter.Text);
                    if (zero > 0)
                    {
                        ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5);
                    }
                }

            }
        }

        private void Card7_Click(object sender, EventArgs e)
        {
            Card7.Image = Properties.Resources.Card7;
            if (PendingImage1 == null)
            {
                PendingImage1 = Card7;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card7;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    card7.Play();
                    PendingImage2 = null;
                    PendingImage1 = null;
                    Card7.Enabled = false;
                    DupCard7.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    timer3.Start();
                    zero = Convert.ToInt32(ScoreCounter.Text);
                    if (zero > 0)
                    {
                        ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5);
                    }
                }

            }
        }

        private void DupCard7_Click(object sender, EventArgs e)
        {
            DupCard7.Image = Properties.Resources.Card7;
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard7;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard7;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    card7.Play();
                    PendingImage2 = null;
                    PendingImage1 = null;
                    Card7.Enabled = false;
                    DupCard7.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    timer3.Start();
                    zero = Convert.ToInt32(ScoreCounter.Text);
                    if (zero > 0)
                    {
                        ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5);
                    }
                }

            }
        }

        private void Card8_Click(object sender, EventArgs e)
        {
            Card8.Image = Properties.Resources.Card8;
            if (PendingImage1 == null)
            {
                PendingImage1 = Card8;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card8;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    card8.Play();
                    PendingImage2 = null;
                    PendingImage1 = null;
                    Card8.Enabled = false;
                    DupCard8.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    timer3.Start();
                    zero = Convert.ToInt32(ScoreCounter.Text);
                    if (zero > 0)
                    {
                        ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5);
                    }
                }

            }
        }

        private void DupCard8_Click(object sender, EventArgs e)
        {
            DupCard8.Image = Properties.Resources.Card8;
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard8;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard8;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    card8.Play();
                    PendingImage2 = null;
                    PendingImage1 = null;
                    Card8.Enabled = false;
                    DupCard8.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    timer3.Start();
                    zero = Convert.ToInt32(ScoreCounter.Text);
                    if (zero > 0)
                    {
                        ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5);
                    }
                }

            }
        }

        private void Card9_Click(object sender, EventArgs e)
        {
            Card9.Image = Properties.Resources.Card9;
            if (PendingImage1 == null)
            {
                PendingImage1 = Card9;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card9;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    card9.Play();
                    PendingImage2 = null;
                    PendingImage1 = null;
                    Card9.Enabled = false;
                    DupCard9.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    timer3.Start();
                    zero = Convert.ToInt32(ScoreCounter.Text);
                    if (zero > 0)
                    {
                        ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5);
                    }
                }

            }
        }

        private void DupCard9_Click(object sender, EventArgs e)
        {
            DupCard9.Image = Properties.Resources.Card9;
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard9;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard9;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    card9.Play();
                    PendingImage2 = null;
                    PendingImage1 = null;
                    Card9.Enabled = false;
                    DupCard9.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    timer3.Start();
                    zero = Convert.ToInt32(ScoreCounter.Text);
                    if (zero > 0)
                    {
                        ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5);
                    }
                }

            }
        }

        private void Card10_Click(object sender, EventArgs e)
        {
            Card10.Image = Properties.Resources.Card10;
            if (PendingImage1 == null)
            {
                PendingImage1 = Card10;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card10;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    card10.Play();
                    PendingImage2 = null;
                    PendingImage1 = null;
                    Card10.Enabled = false;
                    DupCard10.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    timer3.Start();
                    zero = Convert.ToInt32(ScoreCounter.Text);
                    if (zero > 0)
                    {
                        ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5);
                    }
                }

            }
        }

        private void DupCard10_Click(object sender, EventArgs e)
        {
            DupCard10.Image = Properties.Resources.Card10;
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard10;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard10;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    card10.Play();
                    PendingImage2 = null;
                    PendingImage1 = null;
                    Card10.Enabled = false;
                    DupCard10.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    timer3.Start();
                    zero = Convert.ToInt32(ScoreCounter.Text);
                    if (zero > 0)
                    {
                        ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5);
                    }
                }

            }
        }

        private void Card11_Click(object sender, EventArgs e)
        {
            Card11.Image = Properties.Resources.Card11;
            if (PendingImage1 == null)
            {
                PendingImage1 = Card11;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card11;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    card11.Play();
                    PendingImage2 = null;
                    PendingImage1 = null;
                    Card11.Enabled = false;
                    DupCard11.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    timer3.Start();
                    zero = Convert.ToInt32(ScoreCounter.Text);
                    if (zero > 0)
                    {
                        ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5);
                    }
                }

            }
        }

        private void DupCard11_Click(object sender, EventArgs e)
        {
            DupCard11.Image = Properties.Resources.Card11;
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard11;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard11;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    card11.Play();
                    PendingImage2 = null;
                    PendingImage1 = null;
                    Card11.Enabled = false;
                    DupCard11.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    timer3.Start();
                    zero = Convert.ToInt32(ScoreCounter.Text);
                    if (zero > 0)
                    {
                        ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5);
                    }
                }

            }
        }

        private void Card12_Click(object sender, EventArgs e)
        {
            Card12.Image = Properties.Resources.Card12;
            if (PendingImage1 == null)
            {
                PendingImage1 = Card12;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card12;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    card12.Play();
                    PendingImage2 = null;
                    PendingImage1 = null;
                    Card12.Enabled = false;
                    DupCard12.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    timer3.Start();
                    zero = Convert.ToInt32(ScoreCounter.Text);
                    if (zero > 0)
                    {
                        ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5);
                    }
                }

            }
        }

        private void DupCard12_Click(object sender, EventArgs e)
        {
            DupCard12.Image = Properties.Resources.Card12;
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard12;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard12;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    card12.Play();
                    PendingImage2 = null;
                    PendingImage1 = null;
                    Card12.Enabled = false;
                    DupCard12.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    timer3.Start();
                    zero = Convert.ToInt32(ScoreCounter.Text);
                    if (zero > 0)
                    {
                        ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5);
                    }
                }

            }
        }
#endregion
        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Stop();   
            PendingImage1.Image = Properties.Resources.cover1;
            PendingImage2.Image = Properties.Resources.cover1;
            PendingImage1 = null;
            PendingImage2 = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
            ScoreCounter.Text = "0";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
        