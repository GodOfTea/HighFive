using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using Figure;
using Game;

namespace SaveAndLoadForm
{
    public partial class SavesForm : Form
    {
        public SavesForm()
        {
            InitializeComponent();
        }

        //general
        public PictureBox FigurePb;
        public int Width;
        public int Height;
        public int[] FigureColor;
        public int Position;

        //cube
        public int Speed;
        public int XLocation;

        public void SaveSystem()
        {
            var xmlCube = new XmlSerializer(typeof(Cube));
            var xmlPlayer = new XmlSerializer(typeof(Player));

            var player = new Player();
            List<Cube> cubes = new List<Cube>();

            //player settings
            player.FigurePb = FigurePb;
            player.Width = Width;
            player.Height = Height;
            player.FigureColor = FigureColor;
            player.Position = Position;

            //cubes settings
            var Cubes = MainForm.Cubes;
            for (int i = 0; i < Cubes.Count; i++)
            {
                cubes[i].FigurePb = Cubes[i].FigurePb;
                cubes[i].Width = Cubes[i].Width;
                cubes[i].Height = Cubes[i].Height;
                cubes[i].FigureColor = Cubes[i].FigureColor;
                cubes[i].Position = Cubes[i].Position;
                cubes[i].Speed = Cubes[i].Speed;
                cubes[i].XLocation = Cubes[i].XLocation;
            }

            using (var playerStream = new FileStream("PlayerSave.xml", FileMode.Create, FileAccess.Write))
            {
                xmlPlayer.Serialize(playerStream, player);
            }

            using (var cubesStream = new FileStream("CubesSave.xml", FileMode.Create, FileAccess.Write))
            {
                xmlCube.Serialize(cubesStream, player);
            }

        }

        public void LoadSystem()
        {

        }

        private void save_button_Click(object sender, EventArgs e)
        {
            SaveSystem();
        }

        private void load_button_Click(object sender, EventArgs e)
        {

        }
    }
}
