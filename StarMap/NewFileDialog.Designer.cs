namespace StarMap
{
    partial class NewFileDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewFileDialog));
            this.btnCreate = new System.Windows.Forms.Button();
            this.numScaleX = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numScaleY = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numScaleX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScaleY)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(114, 69);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // numScaleX
            // 
            this.numScaleX.Location = new System.Drawing.Point(7, 23);
            this.numScaleX.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numScaleX.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numScaleX.Name = "numScaleX";
            this.numScaleX.Size = new System.Drawing.Size(79, 20);
            this.numScaleX.TabIndex = 4;
            this.numScaleX.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numScaleX.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Polygon Rectangle";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(108, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(77, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Auto Sized";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // numScaleY
            // 
            this.numScaleY.Location = new System.Drawing.Point(110, 23);
            this.numScaleY.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numScaleY.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numScaleY.Name = "numScaleY";
            this.numScaleY.Size = new System.Drawing.Size(79, 20);
            this.numScaleY.TabIndex = 7;
            this.numScaleY.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "x";
            // 
            // NewFileDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 95);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numScaleY);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numScaleX);
            this.Controls.Add(this.btnCreate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewFileDialog";
            this.Text = "Create";
            ((System.ComponentModel.ISupportInitialize)(this.numScaleX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScaleY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.NumericUpDown numScaleX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown numScaleY;
        private System.Windows.Forms.Label label2;
    }
}