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

        NewFileDialog newFileDialog = new NewFileDialog();
        PolygonEditorApplication app;

        private void drawingSurface1_Click(object sender, EventArgs e)
        {

        }

        private void StarMapEditor_Load(object sender, EventArgs e)
        {
            
            dsStarMap.Resized += DrawingSurface1_Resized;

            app = new PolygonEditorApplication(dsStarMap);
            app.Run();

            importDialog.FileOk += OnFileImport;
            newFileDialog.OK += NewFileOK;
        }



        private void OnFileImport(object sender, CancelEventArgs e)
        {
            OpenFileDialog diag = (OpenFileDialog)sender;

            if (diag.FileName.EndsWith(".ac"))
            {
                var result = BinaryFormats.ReadDotAC(diag.FileName);
                app.Vertices.Clear();
                app.Vertices.AddRange(result);
                app.UpdateGrid(256, 256);
                app.IsActive = true;
            }


        }

        private void DrawingSurface1_Resized(SFML.System.Vector2i size)
        {
            Console.WriteLine(size);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Polygon Editor for Andromeda2D\n\n(C) Jonathan \"Vorlias\" Holmes 2017", "About StarMap", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importDialog.ShowDialog();
        }

        private void importDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void NewFileOK()
        {
            app.Vertices.Clear();
            app.UpdateGrid(newFileDialog.ResultSize, newFileDialog.ResultSize);
            app.IsActive = true;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //app.Vertices.Clear();
            //app.UpdateGrid(64, 64);
            //app.IsActive = true;

            newFileDialog.ShowDialog();
            
        }
    }
}
