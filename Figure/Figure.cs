using System;
using System.Drawing;
using System.Windows.Forms;

namespace Figure
{
    [Serializable]
    public abstract class Figure
    {
        private PictureBox _figurePb;
        public PictureBox FigurePb
        {
            get { return _figurePb; }
            protected set { _figurePb = value; }
        }
        public int Width;
        public int Height;
        public int[] FigureColor; //just "Color" is occupied by the built-in method
        public int Position;

        public Figure()
        {        }

        public PictureBox CreatingFigure ()
        {
            FigurePb.Width = Width;
            FigurePb.Height = Height;
            FigurePb.BackColor = Color.FromArgb( FigureColor[0], FigureColor[1], FigureColor[2]);
            FigurePb.Top = Position;
            return FigurePb;
        }

        public bool CollisionCheck (PictureBox unit)
        {
            return FigurePb.Bottom >= unit.Top && FigurePb.Bottom <= unit.Bottom && FigurePb.Left >= unit.Left && FigurePb.Right <= unit.Right;
        }
    }

    
}