using System;
using System.Drawing;
using System.Windows.Forms;
using Figures;
using System.Collections.Generic;

namespace Game
{
    public partial class mainForm : Form
    {
        static Random rnd = new Random();

        static public int NumberOfSCubes = 3;
        static public int Score = 0;

        public static List<Cube> Cubes = new List<Cube>();
        public Player Player;

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

        public mainForm()
        {
            InitializeComponent();
            Cursor.Hide();
            //FullScreen
            //FormBorderStyle = FormBorderStyle.None; 
            //TopMost = true;
            //Bounds = Screen.PrimaryScreen.Bounds;

            Player = new Player(300, 50, playerColorsReturn(), playground);
            player.Top = Player.Position;
            for (int i = 0; i < NumberOfSCubes; i++)
            {
                Cubes.Add(new Cube(50, 50, cubeColorsReturn(), playground, rnd.Next(4, 12), rnd.Next(playground.Left, playground.Right - 50)));
                Controls.Add(Cubes[i].CreatingFigure());
            }
        }

        private void timer_Tick(object sender, EventArgs e) //Update
        {

            player.Left = Cursor.Position.X - player.Width / 2; //The movement of the player

            for (int i = 0; i < NumberOfSCubes; i++)
            {
                Cubes[i].Move(); //Movement of cubes

                if (Cubes[i].CollisionCheckWithPlayer(Cubes[i], player))
                {
                    Cubes[i].Dispose();
                    Cubes.RemoveAt(i);
                    Cubes.Insert(i, (new Cube(50, 50, cubeColorsReturn(), playground, rnd.Next(4, 12), rnd.Next(playground.Left, playground.Right - 50))));
                    Controls.Add(Cubes[i].CreatingFigure());
                    Score += 1;
                    points_label.Text = Score.ToString();
                }

                if (Cubes[i].CollisionCheckWithPlayground(Cubes[i], playground))
                {
                    Cubes[i].Dispose();
                    Cubes.RemoveAt(i);
                    Cubes.Insert(i, (new Cube(50, 50, cubeColorsReturn(), playground, rnd.Next(4, 12), rnd.Next(playground.Left, playground.Right - 50))));
                    Controls.Add(Cubes[i].CreatingFigure());
                }
            }
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { Close(); }
        }
    }
}