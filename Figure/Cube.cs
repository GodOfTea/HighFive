using System;
using System.Drawing;
using System.Windows.Forms;

namespace Figure
{
    [Serializable]
    public class Cube : Figure, IDisposable
    {
        public int Speed;
        public int XLocation;
        private int _score;

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public Cube()
        {  }

        public Cube(int cubeWidth, int cubeHeight, int[] cubeColor, int startPosition, int speed, int xLoc)
        {
            FigurePb = new PictureBox();
            Width = cubeWidth;
            Height = cubeHeight;
            FigureColor = new[] { cubeColor[0], cubeColor[1], cubeColor[2] };
            Position = startPosition;
            Speed = speed;
            XLocation = xLoc;
            FigurePb.Location = new Point(XLocation, 0);
        }

        public void Move()
        {
            FigurePb.Top += Speed;
        }

        public void Dispose()
        {
            FigurePb.Dispose();
        }

    }
}