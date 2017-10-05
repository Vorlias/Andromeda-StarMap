namespace StarMap
{
    partial class ResizeDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResizeDialog));
            this.numSizeX = new System.Windows.Forms.NumericUpDown();
            this.numSizeY = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numSizeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSizeY)).BeginInit();
            this.SuspendLayout();
            // 
            // numSizeX
            // 
            this.numSizeX.Location = new System.Drawing.Point(12, 12);
            this.numSizeX.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numSizeX.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numSizeX.Name = "numSizeX";
            this.numSizeX.Size = new System.Drawing.Size(120, 20);
            this.numSizeX.TabIndex = 0;
            this.numSizeX.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // numSizeY
            // 
            this.numSizeY.Location = new System.Drawing.Point(150, 12);
            this.numSizeY.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numSizeY.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numSizeY.Name = "numSizeY";
            this.numSizeY.Size = new System.Drawing.Size(120, 20);
            this.numSizeY.TabIndex = 1;
            this.numSizeY.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "x";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(195, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Resize";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ResizeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 69);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numSizeY);
            this.Controls.Add(this.numSizeX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResizeDialog";
            this.Text = "Resize";
            ((System.ComponentModel.ISupportInitialize)(this.numSizeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSizeY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numSizeX;
        private System.Windows.Forms.NumericUpDown numSizeY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}