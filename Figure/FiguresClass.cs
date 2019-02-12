using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Figures
{
    public abstract class FiguresClass
    {
        public int Width;
        public int Height;
        public int[] Color;
        public int Position;
    }

    public class Rectangles : FiguresClass
    {
        //
    }

    public class Cubes : FiguresClass
    {
        public int XLocation;
        public int YLocation;
        public string Name;
        public int Speed;
    }
}
