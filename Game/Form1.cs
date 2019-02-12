using System;
using System.Drawing;
using System.Windows.Forms;
using Figures;

namespace Game
{
    public partial class mainForm : Form
    {
        Random rnd = new Random();
        Rectangles Player = new Rectangles();
        Cubes Cube = new Cubes();
        PictureBox PlayerPB = new PictureBox();

        static public int NumberOfSCubes = 6;
        static public int Score = 0;

        public int[] CubeSpeed = new int[NumberOfSCubes];
        public PictureBox[] Cubes = new PictureBox[NumberOfSCubes];

        public PictureBox CreatingFigure (string figure, int order)
        {
            PictureBox figureCopy = new PictureBox();
            switch (figure)
            {
                case "player":
                    Player.Width = 300;
                    Player.Height = 50;
                    Player.Color = new int[3];
                    Player.Color[0] = 0;
                    Player.Color[1] = 0;
                    Player.Color[2] = 192;
                    Player.Position = playground.Bottom - (playground.Bottom / 5);
                    break;
                case "cube":
                    int randomValue = rnd.Next(playground.Left, playground.Right - 50);
                    Cube.Width = 50;
                    Cube.Height = 50;
                    Cube.Color = new int[3];
                    Cube.Color[0] = rnd.Next(150, 255);
                    Cube.Color[1] = rnd.Next(150, 255);
                    Cube.Color[2] = rnd.Next(150, 255);
                    Cube.Position = playground.Top - 30;
                    Cube.XLocation = randomValue;
                    Cube.YLocation = 0;
                    Cube.Name = "ccccube";
                    Cube.Speed = rnd.Next(4, 10);
                    figureCopy = CreatingCubs(order, figureCopy);
                    break;
                default:
                    break;
            }
            return figureCopy;
        }

        public PictureBox CreatingCubs (int order, PictureBox cubeCopy)
        {
            int randomValue = rnd.Next(playground.Left, playground.Right - 50);
            cubeCopy.Location = new Point(Cube.XLocation, Cube.YLocation);
            cubeCopy.Width = Cube.Width;
            cubeCopy.Height = Cube.Height;
            cubeCopy.Name = Cube.Name;
            CubeSpeed[order] = Cube.Speed;
            cubeCopy.BackColor = Color.FromArgb(Cube.Color[0], Cube.Color[1], Cube.Color[2]);
            Controls.Add(cubeCopy);
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

            PlayerPB = CreatingFigure("player", -1);

            player.Top = Player.Position; //player pos
            cube.Top = Cube.Position; //cube start pos

            for (int i = 0; i < NumberOfSCubes; i++)
            {
                Cubes[i] = CreatingFigure("cube", i);
            }
        }

        private void timer_Tick(object sender, EventArgs e) //Update
        {
            player.Left = Cursor.Position.X - (player.Width / 2); //The movement of the player


            for (int i = 0; i < NumberOfSCubes; i++)
            {
                Cubes[i].Top += CubeSpeed[i]; //Movement of cubes

                if (Cubes[i].Bottom >= player.Top && Cubes[i].Bottom <= player.Bottom && Cubes[i].Left >= player.Left && Cubes[i].Right <= player.Right)
                {
                    Cubes[i].Dispose();
                    Cubes[i] = CreatingFigure("cube", i);
                    Score += 1;
                    points_label.Text = Score.ToString();
                }
                if (Cubes[i].Bottom >= playground.Bottom)
                {
                    Cubes[i].Dispose();
                    Cubes[i] = CreatingFigure("cube", i);
                }
            }
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { Close(); }
        }
    }
}