using System;
using System.Drawing;
using System.Windows.Forms;
using Figures;

namespace Game
{
    public partial class mainForm : Form
    {
        static Random rnd = new Random();

        static public int NumberOfSCubes = 6;
        static public int Score = 0;

        public Cube[] Cubes = new Cube[NumberOfSCubes];
        public Player Player;

        public mainForm()
        {
            InitializeComponent();
            Cursor.Hide();
            //FullScreen
            FormBorderStyle = FormBorderStyle.None; 
            TopMost = true;
            Bounds = Screen.PrimaryScreen.Bounds;

            Player = new Player(300, 50, playerColorsReturn(), playground.Bottom - (playground.Bottom / 5));
            for (int i = 0; i < NumberOfSCubes; i++)
            {
                Cubes[i] = new Cube(50, 50, cubeColorsReturn(), playground.Top - 30);
                Cubes[i].Speed = Cubes[i].Acceleration(rnd.Next(4, 12));
                Cubes[i].FigurePB.Location = new Point(Cubes[i].Spawn(rnd.Next(playground.Left, playground.Right - Cubes[i].Width)), 0);
                Controls.Add(Cubes[i].CreatingFigure(Cubes[i].FigurePB));
            }

            Player.CreatingFigure(player);
        }

        static int[] playerColorsReturn()
        {
            int[] playerColors = { 0, 0, 192 };
            return playerColors;
        }

        static int[] cubeColorsReturn()
        {
            int[] cubeColors = { rnd.Next(150, 255), rnd.Next(150, 255), rnd.Next(150, 255) };
            return cubeColors;
        }

        private void timer_Tick(object sender, EventArgs e) //Update
        {
            player.Left = Player.Move(Cursor.Position.X - Player.Width / 2); //The movement of the player


            for (int i = 0; i < NumberOfSCubes; i++)
            {
                Cubes[i].FigurePB.Top += Cubes[i].Move(Cubes[i].Speed); //Movement of cubes

                if (Cubes[i].FigurePB.Bottom >= player.Top && Cubes[i].FigurePB.Bottom <= player.Bottom && Cubes[i].FigurePB.Left >= player.Left && Cubes[i].FigurePB.Right <= player.Right)
                {
                    Cubes[i].Destroy(Cubes[i].FigurePB);
                    Cubes[i].Speed = Cubes[i].Acceleration(rnd.Next(4, 12));
                    Cubes[i].FigurePB.Location = new Point(Cubes[i].Spawn(rnd.Next(playground.Left, playground.Right - Cubes[i].Width)), 0);
                    Controls.Add(Cubes[i].CreatingFigure(Cubes[i].FigurePB));
                    Score += 1;
                    points_label.Text = Score.ToString();
                }
                if (Cubes[i].FigurePB.Bottom >= playground.Bottom)
                {
                    Cubes[i].Destroy(Cubes[i].FigurePB);
                    Cubes[i].Speed = Cubes[i].Acceleration(rnd.Next(4, 12));
                    Cubes[i].FigurePB.Location = new Point(Cubes[i].Spawn(rnd.Next(playground.Left, playground.Right - Cubes[i].Width)), 0);
                    Controls.Add(Cubes[i].CreatingFigure(Cubes[i].FigurePB));
                }
            }
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { Close(); }
        }
    }
}