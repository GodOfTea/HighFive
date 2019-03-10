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

namespace Game
{
    public partial class SavesForm : Form
    {
        public SavesForm()
        {
            InitializeComponent();
        }

        public void SaveSystem()
        {
            XmlSerializer writerSerializer = new XmlSerializer(typeof(List<Cube>));
            FileStream sw = new FileStream();
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            
        }

        private void load_button_Click(object sender, EventArgs e)
        {

        }
    }
}
