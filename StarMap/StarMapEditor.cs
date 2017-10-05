using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarMap
{
    public partial class StarMapEditor : Form
    {
        public StarMapEditor()
        {
            InitializeComponent();
        }

        private void drawingSurface1_Click(object sender, EventArgs e)
        {

        }

        private void StarMapEditor_Load(object sender, EventArgs e)
        {
            dsStarMap.Resized += this.DrawingSurface1_Resized;
        }

        private void DrawingSurface1_Resized(SFML.System.Vector2i size)
        {
            Console.WriteLine(size);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Polygon Editor for Andromeda2D\n\n(C) Jonathan \"Vorlias\" Holmes 2017", "About StarMap", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
