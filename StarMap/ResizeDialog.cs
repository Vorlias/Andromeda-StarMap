using SFML.System;
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
    public partial class ResizeDialog : Form
    {
        public Vector2u ResultSize
        {
            get => new Vector2u((uint)numSizeX.Value, (uint)numSizeY.Value);
            set
            {
                numSizeX.Value = value.X < 16 ? 16 : value.X;
                numSizeY.Value = value.Y < 16 ? 16 : value.Y;
            }
        }

        public ResizeDialog()
        {
            InitializeComponent();
        }

        public delegate void ResizeDialogOK();
        public event ResizeDialogOK OK;

        private void button1_Click(object sender, EventArgs e)
        {
            OK?.Invoke();
            Close();
        }
    }
}
