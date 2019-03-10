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
        private const int NumberOfCubes = 3;

        private static int _score = 0;
        private static int _cubeStartPosition;
        private static int _playerStartPosition;
        private static bool _pause;

        public static List<Cube> Cubes = new List<Cube>();
        public Player Player;

        List<Cube> GetModelFromCubeUI() // file?
        {
            List<Cube> cubes = new List<Cube>();
            for (int j = 0; j < Cubes.Count; j++)
            {
                cubes.Add(new Cube()
                {
                    XLocation = Cubes[j].XLocation,
                    FigureColor = CubeColorReturn(),
                    Height = CubeHeight,
                    Width = CubeWidth,
                    Position = Cubes[j].FigurePb.Top,
                    Speed = Cubes[j].Speed,
                    Score = _score
                });
            }
            return cubes;
        }

        public void SetModelToCubeUI(List<Cube> dtoCubes) // for?
        {
            for (int j = 0; j < NumberOfCubes; j++)
            {                
                Cubes[j].XLocation = dtoCubes[j].XLocation;             
                Cubes[j].Speed = dtoCubes[j].Speed;
                Cubes[j].Position = dtoCubes[j].Position;
                Cubes[j].FigureColor = dtoCubes[j].FigureColor;
                Cubes[j].Width = dtoCubes[j].Width;
                Cubes[j].Height = dtoCubes[j].Height;
                Cubes[j].CreatingFigure();
            }
            _score = dtoCubes[0].Score;
            points_label.Text = _score.ToString();
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
            _pause = false;

            Player = new Player(PlayerWidth, PlayerHeight, PlayerColorReturn(), _playerStartPosition);
            player.Top = Player.Position;
            if (Cubes.Count < NumberOfCubes)
            {
                for (var i = 0; i < NumberOfCubes; i++)
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
            if (!_pause)
            {
                player.Left = Cursor.Position.X - player.Width / 2; //The movement of the player

                for (var i = 0; i < NumberOfCubes; i++)
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
                        Cubes.Insert(i,
                            new Cube(CubeWidth, CubeHeight, CubeColorReturn(), _cubeStartPosition, speed,
                                xCubeLocation));
                        Controls.Add(Cubes[i].CreatingFigure());
                    }
                }
            }
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { Close(); }

            if (e.KeyCode == Keys.F5) //5 different files, this is some problem, hehe
            {
                _pause = true;
                Cursor.Show();
                var sfd = new SaveFileDialog();
                var result = sfd.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                        var dto = GetModelFromCubeUI();
                        //var fileName = sfd.FileName + i;
                        XmlSerz.WriteToFile(sfd.FileName, dto);
                _pause = false;
                Cursor.Hide();
                }
                else
                {
                    _pause = false;
                    Cursor.Hide();
                }
            }

            if (e.KeyCode == Keys.F9) //need to read 5 files, this is some problem, not hehe
            {
                _pause = true;
                Cursor.Show();
                var ofd = new OpenFileDialog();
                var result = ofd.ShowDialog(this);                   
                if (result == DialogResult.OK)
                {
                   // var fileName = ofd.FileName + i;
                    var dto = XmlSerz.LoadFromFileCube(ofd.FileName);
                    SetModelToCubeUI(dto);
                    _pause = false;
                    Cursor.Hide();
                }
                else
                {
                    _pause = false;
                    Cursor.Hide();
                }
            } 
        }
    }
}