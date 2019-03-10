using System;
using System.Windows.Forms;

namespace Figure
{
    [Serializable]
    public class Player : Figure
    {
        public Player()
        {        }

        public Player (int playerWidth, int playerHeight, int[] playerColor, int startPosition)
        {
            FigurePb = new PictureBox();
            Width = playerWidth;
            Height = playerHeight;
            FigureColor = new[] { playerColor[0], playerColor[1], playerColor[2] };
            Position = startPosition;
        }
    }
}