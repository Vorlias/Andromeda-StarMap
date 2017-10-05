using SFML.System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        string fileName = "";

        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
                saveFileDialog.FileName = fileName;
            }
        }

        NewFileDialog newFileDialog = new NewFileDialog();
        ResizeDialog resizeDialog = new ResizeDialog();
        PolygonEditorApplication app;

        const string AC_FORMAT_FILTER = "PolygonCollider V1|*.ac";
        const string SMC_FORMAT_FILTER = "Star Map Collider|*.smc";
        const string PNG_FILE_FILTER = "PNG File|*.png";
        const string SM_FILTER = "Star Map File|*.smc;*.sm";
        const string RAW_FORMAT_FILTER = "Star Map Project|*.sm";

        readonly string OPEN_FILTER = $"{SM_FILTER}";
        readonly string SAVE_FILTER = $"{SMC_FORMAT_FILTER}|{RAW_FORMAT_FILTER}|{AC_FORMAT_FILTER}";
        readonly string IMPORT_FILTER = $"{PNG_FILE_FILTER}|{AC_FORMAT_FILTER}";


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
            resizeDialog.OK += ResizeOK;
            
            saveFileDialog.FileOk += SaveFileOK;

            importDialog.Filter = IMPORT_FILTER;
            saveFileDialog.Filter = SAVE_FILTER;
            openFileDialog.Filter = OPEN_FILTER;
        }

        private void ResizeOK()
        {
            app.AutoSize = false;
            app.EditorSize = resizeDialog.ResultSize;
            app.UpdateGrid(app.EditorSize.X, app.EditorSize.Y);
        }

        private void SaveFileOK(object sender, CancelEventArgs e)
        {
            var saveDialog = (SaveFileDialog)sender;
            if (saveDialog.FileName.EndsWith(BinaryFormats.EXTENSION_STARMAP_COLLIDER))
            {
                BinaryFormats.WriteDotSMC(saveDialog.FileName, app.EditorSize, app.Vertices, app.AutoSize);
            }
            else if (saveDialog.FileName.EndsWith(BinaryFormats.EXTENSION_POLYEDIT_COLLIDER))
            {
                BinaryFormats.WriteDotAC(saveDialog.FileName, app.Vertices);
            }
        }

        private void OnFileImport(object sender, CancelEventArgs e)
        {
            OpenFileDialog diag = (OpenFileDialog)sender;

            if (diag.FileName.EndsWith(".ac"))
            {
                var result = BinaryFormats.ReadDotAC(diag.FileName);
                app.Vertices.Clear();
                app.Vertices.AddRange(result);
                app.AutoSize = true;
                app.UpdateGrid(64, 64);
                app.EditorSize = new Vector2u(64, 64);
                app.IsActive = true;

                FileName = new FileInfo( diag.FileName ).Name.Replace(".ac", "");
            }
            else if (diag.FileName.EndsWith(".png"))
            {
                app.TextureFile = diag.FileName;
                app.IsActive = true;

                if (app.BackgroundTexture.Size.X > 256 || app.BackgroundTexture.Size.Y > 256)
                {
                    MessageBox.Show("Image is too large (256x256 limit)", "Uh oh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    app.IsActive = false;
                    return;
                }

                if (MessageBox.Show("Resize collider to image size?", "Resize", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var size = app.BackgroundTexture.Size;
                    app.AutoSize = false;
                    app.UpdateGrid(size.X, size.Y);
                    app.EditorSize = size;
                }
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
            app.IsActive = false;

            app.Vertices.Clear();
            if (newFileDialog.ResultAutoSize)
            {
                app.AutoSize = true;
                app.UpdateGrid(256, 256);
                app.EditorSize = new Vector2u(256, 256);
                app.UpdateGrid(256, 256);
            }
            else
            {
                app.EditorSize = newFileDialog.ResultSize;
                app.UpdateGrid(newFileDialog.ResultSize.X, newFileDialog.ResultSize.Y);
            }
            
            app.IsActive = true;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //app.Vertices.Clear();
            //app.UpdateGrid(64, 64);
            //app.IsActive = true;

            newFileDialog.ShowDialog();
            
        }

        private void statusTick_Tick(object sender, EventArgs e)
        {
            txtStatus.Text = $"{app.EditorSize.X}x{app.EditorSize.Y} | AutoSize: {app.AutoSize} | Vertices: { app.Vertices.Count} ";

            if (fileName != "")
                Text = "Star Map - " + fileName;
            else
                Text = "Star Map";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            var openDialog = (OpenFileDialog)sender;
            if (openDialog.FileName.EndsWith(BinaryFormats.EXTENSION_STARMAP_COLLIDER))
            {
                BinaryFormats.ReadDotSMC(openDialog.FileName, out Vector2i[] vertices, out bool autoSize, out Vector2u size);

                app.Vertices.Clear();
                app.Vertices.AddRange(vertices);
                app.AutoSize = autoSize;

                if (autoSize)
                    app.UpdateGrid(64, 64);
                else
                    app.UpdateGrid(size.X, size.Y);

                app.IsActive = true;
            }
            else
                Console.WriteLine("wat");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void changeSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resizeDialog.ResultSize = app.EditorSize;
            resizeDialog.ShowDialog();
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
