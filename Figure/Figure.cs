using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System;

namespace Figures
{
    public abstract class Figure
    {
        protected PictureBox FigurePB;
        public int Width;
        public int Height;
        public int[] figureColor; //just "Color" is occupied by the built-in method
        public int Position;

        public PictureBox CreatingFigure ()
        {
            FigurePB.Width = Width;
            FigurePB.Height = Height;
            FigurePB.BackColor = Color.FromArgb( figureColor[0], figureColor[1], figureColor[2]);
            FigurePB.Top = Position;
            return FigurePB;
        }

        public bool CollisionCheckWithPlayer (Cube cube, PictureBox player)
        {
            if (cube.FigurePB.Bottom >= player.Top && cube.FigurePB.Bottom <= player.Bottom && cube.FigurePB.Left >= player.Left && cube.FigurePB.Right <= player.Right)
            { return true; }
            else
            { return false; }
        }

        public bool CollisionCheckWithPlayground(Cube cube, PictureBox playground)
        {
            if (cube.FigurePB.Bottom >= playground.Bottom)
            { return true; }
            else
            { return false; }
        }
    }

    public class Player : Figure
    {
        public Player (int playerWidth, int playerHeight, int[] playerColor, PictureBox playground)
        {
            FigurePB = new PictureBox();
            Width = playerWidth;
            Height = playerHeight;
            figureColor = new int[] { playerColor[0], playerColor[1], playerColor[2] };
            Position = playground.Bottom - (playground.Bottom / 5);
        }
    }

    public class Cube : Figure, IDisposable
    {
        public int Speed;
        public int XLocation;

        public Cube(int cubeWidth, int cubeHeight, int[] cubeColor, PictureBox playground, int speed, int xLoc)
        {
            FigurePB = new PictureBox();
            Width = cubeWidth;
            Height = cubeHeight;
            figureColor = new int[] { cubeColor[0], cubeColor[1], cubeColor[2] };
            Position = playground.Top - 30;
            Speed = speed;
            XLocation = xLoc;
            FigurePB.Location = new Point(XLocation, 0);
        }

        public void Move()
        {
            FigurePB.Top += Speed;
        }

        public void Dispose()
        {
            FigurePB.Dispose();
        }

    }
}