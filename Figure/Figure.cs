using System.Drawing;
using System.Windows.Forms;

namespace Figures
{
    public abstract class Figure
    {
        public PictureBox FigurePB;
        public int Width;
        public int Height;
        public int[] figureColor; //just "Color" is occupied by the built-in method
        public int Position;

        public int Move (int speed)
        {
            return speed;
        }

        public PictureBox CreatingFigure (PictureBox figure)
        {
            figure.Width = Width;
            figure.Height = Height;
            figure.BackColor = Color.FromArgb( figureColor[0], figureColor[1], figureColor[2]);
            figure.Top = Position;
            return figure;
        }
    }

    public class Player : Figure
    {
        public Player (int playerWidth, int playerHeight, int[] playerColor, int playerPosition)
        {
            Width = playerWidth;
            Height = playerHeight;
            figureColor = new int[] { playerColor[0], playerColor[1], playerColor[2] };
            Position = playerPosition;
        }
    }

    public class Cube : Figure
    {
        public int XLocation;
        public int Speed;

        public Cube(int cubeWidth, int cubeHeight, int[] cubeColor, int cubePosition)
        {
            FigurePB = new PictureBox();
            Width = cubeWidth;
            Height = cubeHeight;
            figureColor = new int[] { cubeColor[0], cubeColor[1], cubeColor[2] };
            Position = cubePosition;
        }

        public int Spawn (int randomXLocation)
        {
            XLocation = randomXLocation;
            return XLocation;
        }

        public int Acceleration(int randomSpeed)
        {
            return randomSpeed;
        }

        public void Destroy(PictureBox cube)
        {
            cube.Dispose();
            FigurePB = new PictureBox();
        }
    }
}
