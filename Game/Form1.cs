using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class mainForm : Form
    {
        Random rnd = new Random();
        static public int NumberOfSCubes = 5;
        public int Score = 0;

        public int[] CubeSpeed = new int[NumberOfSCubes];
        public PictureBox[] Cubes = new PictureBox[NumberOfSCubes];

        //The boundaries of the cubes
        public void CollisionCheck(PictureBox[] Cubes)
        {
            for (int i = 0; i < NumberOfSCubes-1; i++)
            {
                for (int j = 1; j < NumberOfSCubes; j++)
                {
                    if ((Cubes[i].Location.X >= Cubes[j].Location.X && Cubes[i].Location.X <= Cubes[j].Location.X+50) ||
                        (Cubes[i].Location.X+50 >= Cubes[j].Location.X && Cubes[i].Location.X+50 <= Cubes[j].Location.X + 50))
                    {
                        Cubes[i].Dispose();
                        Cubes[i] = CreatingCubs(i);
                    }
                }
            }
        }

        public PictureBox CreatingCubs (int order)
        {
            int randomValue = rnd.Next(playground.Left, playground.Right - 50);
            PictureBox cubeCopy = new PictureBox();
            cubeCopy.BackColor = cube.BackColor;
            cubeCopy.Location = new Point(randomValue, 0);
            cubeCopy.Width = 50;
            cubeCopy.Height = 50;
            Controls.Add(cubeCopy);
            cubeCopy.Name = "cube" + order;
            CubeSpeed[order] = rnd.Next(4, 10);
            cubeCopy.BackColor = Color.FromArgb(rnd.Next(150, 255), rnd.Next(150, 255), rnd.Next(150, 255));
            cubeCopy.BringToFront();
            return cubeCopy;
        }

        public mainForm()
        {
            InitializeComponent();
            Cursor.Hide();

            //FullScreen
            FormBorderStyle = FormBorderStyle.None; 
            TopMost = true;
            Bounds = Screen.PrimaryScreen.Bounds;

            player.Top = playground.Bottom - (playground.Bottom / 5); //player pos
            cube.Top = playground.Top - 30; //cube start pos

            for (int i = 0; i < NumberOfSCubes; i++)
            {
                Cubes[i] = CreatingCubs(i);
            }
            CollisionCheck(Cubes);
        }

        private void timer_Tick(object sender, EventArgs e) //Update
        {
            player.Left = Cursor.Position.X - (player.Width / 2); //The movement of the player

            //CollisionCheck(Cubes);

            for (int i = 0; i < NumberOfSCubes; i++)
            {
                Cubes[i].Top += CubeSpeed[i]; //Movement of cubes
                

                if (Cubes[i].Bottom >= player.Top && Cubes[i].Bottom <= player.Bottom && Cubes[i].Left >= player.Left && Cubes[i].Right <= player.Right)
                {
                    Cubes[i].Dispose();
                    Cubes[i] = CreatingCubs(i);
                    Score += 1;
                    points_label.Text = Score.ToString();
                }
                if (Cubes[i].Bottom >= playground.Bottom)
                {
                    Cubes[i].Dispose();
                    Cubes[i] = CreatingCubs(i);
                }
            }
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { Close(); }
        }
    }
}