using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Figure;

namespace Game
{
    public partial class MainForm : Form
    {
        private static readonly Random Rnd = new Random();

        const int PlayerWidth = 300;
        const int PlayerHeight = 50;
        const int CubeWidth = 50;
        const int CubeHeight = 50;
        private const int NumberOfSCubes = 3;

        private static int _score = 0;
        private static int _cubeStartPosition;
        private static int _playerStartPosition;

        public static List<Cube> Cubes = new List<Cube>();
        public Player Player;

        Cube GetModelFromCubeUI( int i ) // file?
        {
            return new Cube()
            {
                FigureColor = CubeColorReturn(),
                Height = CubeHeight,
                Width = CubeWidth,
                Position = Cubes[i].FigurePb.Top,
                Speed = Cubes[i].Speed,
                Score = _score
            };
        }

        public void SetModelToCubeUI(Cube dtoCube, int i) // for?
        {
            _score = dtoCube.Score;
                Cubes[i].Speed = dtoCube.Speed;
                Cubes[i].Position = dtoCube.FigurePb.Top;
                Cubes[i].FigureColor = dtoCube.FigureColor;
                Cubes[i].Width = dtoCube.Width;
                Cubes[i].Height = dtoCube.Height;
        }

        private static int[] PlayerColorReturn()
        {
            int[] playerColor = { 0, 0, 192 };
            return playerColor;
        }

        private static int[] CubeColorReturn()
        {
            int[] cubeColor = { Rnd.Next(150, 255), Rnd.Next(150, 255), Rnd.Next(150, 255) };
            return cubeColor;
        }

       
        public MainForm()
        {
            InitializeComponent();
            Cursor.Hide();
            //FullScreen
            //FormBorderStyle = FormBorderStyle.None; 
            //TopMost = true;
            //Bounds = Screen.PrimaryScreen.Bounds;

            _playerStartPosition = playground.Bottom - playground.Bottom / 5;
            _cubeStartPosition = playground.Top - CubeHeight;

            Player = new Player(PlayerWidth, PlayerHeight, PlayerColorReturn(), _playerStartPosition);
            player.Top = Player.Position;
            for (var i = 0; i < NumberOfSCubes; i++)
            {
                if (Cubes[i] == null)
                {
                    var speed = Rnd.Next(4, 12);
                    var xCubeLocation = Rnd.Next(playground.Left, playground.Right - CubeWidth);
                    Cubes.Add(new Cube(CubeWidth, CubeHeight, CubeColorReturn(), _cubeStartPosition, speed,
                        xCubeLocation));
                    Controls.Add(Cubes[i].CreatingFigure());
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e) //Update
        {

            player.Left = Cursor.Position.X - player.Width / 2; //The movement of the player

            for (var i = 0; i < NumberOfSCubes; i++)
            {
                var collisionPlayer = Cubes[i].CollisionCheck(player);
                var collisionPlayground = Cubes[i].CollisionCheck(playground);
                Cubes[i].Move(); //Movement of cubes

                if (collisionPlayer)
                {
                    _score += 1;
                    points_label.Text = _score.ToString();
                }

                if (!collisionPlayground || collisionPlayer)
                {
                    var speed = Rnd.Next(4, 12);
                    var xCubeLocation = Rnd.Next(playground.Left, playground.Right - CubeWidth);
                    Cubes[i].Dispose();
                    Cubes.RemoveAt(i);
                    Cubes.Insert(i, new Cube(CubeWidth, CubeHeight, CubeColorReturn(), _cubeStartPosition, speed, xCubeLocation));
                    Controls.Add(Cubes[i].CreatingFigure());
                }
            }
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { Close(); }

            if (e.KeyCode == Keys.F5) //5 different files, this is some problem, hehe
            {
                var sfd = new SaveFileDialog()
                {
                    Filter = "Cubes|*.cube"
                };
                for (int i = 0; i < Cubes.Count; i++)
                {
                    var result = sfd.ShowDialog(this);
                    if (result == DialogResult.OK)
                    {
                        var dto = GetModelFromCubeUI(i);
                        XmlSerz.WriteToFile(sfd.FileName, dto);
                    }
                }
                
            }

            if (e.KeyCode == Keys.F9) //need to read 5 files, this is some problem, not hehe
            {
                var ofd = new OpenFileDialog()
                {
                    Filter = "Cubes|*.cube"
                };
                for (int i = 0; i < Cubes.Count; i++)
                {
                    var result = ofd.ShowDialog(this);
                    if (result == DialogResult.OK)
                    {
                        var dto = XmlSerz.LoadFromFileCube(ofd.FileName);
                        SetModelToCubeUI(dto, i);
                    }
                }             
            } 
        }

    }
}