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
    public partial class NewFileDialog : Form
    {
        public uint ResultSize
        {
            get => (uint)numericUpDown1.Value;
        }

        public bool ResultAutoSize
        {
            get => checkBox1.Checked;
        }

        public NewFileDialog()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        public delegate void NewFileDialogOK();
        public event NewFileDialogOK OK;

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            OK?.Invoke();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = !((CheckBox)sender).Checked;
        }
    }
}
