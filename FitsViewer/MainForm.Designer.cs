namespace FitsViewer
{
    partial class MainForm
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
            this.panelNavi = new System.Windows.Forms.Panel();
            this.buttonHeader = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.panelPicture = new System.Windows.Forms.Panel();
            this.textBoxHeader = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.panelNavi.SuspendLayout();
            this.panelPicture.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panelNavi
            // 
            this.panelNavi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelNavi.Controls.Add(this.buttonHeader);
            this.panelNavi.Controls.Add(this.buttonPrev);
            this.panelNavi.Controls.Add(this.buttonNext);
            this.panelNavi.Controls.Add(this.buttonOpen);
            this.panelNavi.Location = new System.Drawing.Point(12, 617);
            this.panelNavi.Name = "panelNavi";
            this.panelNavi.Size = new System.Drawing.Size(972, 58);
            this.panelNavi.TabIndex = 1;
            // 
            // buttonHeader
            // 
            this.buttonHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonHeader.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHeader.Image = global::FitsViewer.Properties.Resources.img_head;
            this.buttonHeader.Location = new System.Drawing.Point(552, 0);
            this.buttonHeader.Name = "buttonHeader";
            this.buttonHeader.Size = new System.Drawing.Size(86, 58);
            this.buttonHeader.TabIndex = 2;
            this.buttonHeader.TabStop = false;
            this.buttonHeader.UseVisualStyleBackColor = true;
            this.buttonHeader.Click += new System.EventHandler(this.buttonHeader_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(232)))));
            this.buttonNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonNext.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonNext.Image = global::FitsViewer.Properties.Resources.next;
            this.buttonNext.Location = new System.Drawing.Point(467, 0);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(79, 58);
            this.buttonNext.TabIndex = 1;
            this.buttonNext.TabStop = false;
            this.buttonNext.UseVisualStyleBackColor = false;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // panelPicture
            // 
            this.panelPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPicture.Controls.Add(this.textBoxHeader);
            this.panelPicture.Controls.Add(this.pictureBox);
            this.panelPicture.Location = new System.Drawing.Point(12, 12);
            this.panelPicture.Name = "panelPicture";
            this.panelPicture.Size = new System.Drawing.Size(972, 599);
            this.panelPicture.TabIndex = 2;
            // 
            // textBoxHeader
            // 
            this.textBoxHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxHeader.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxHeader.Location = new System.Drawing.Point(0, 0);
            this.textBoxHeader.Multiline = true;
            this.textBoxHeader.Name = "textBoxHeader";
            this.textBoxHeader.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxHeader.Size = new System.Drawing.Size(972, 599);
            this.textBoxHeader.TabIndex = 1;
            this.textBoxHeader.Visible = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Multiselect = true;
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.White;
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 678);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(996, 25);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(63, 20);
            this.toolStripStatusLabel.Text = "Nothing";
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(972, 599);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // buttonPrev
            // 
            this.buttonPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonPrev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(232)))));
            this.buttonPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPrev.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonPrev.Image = global::FitsViewer.Properties.Resources.prev;
            this.buttonPrev.Location = new System.Drawing.Point(382, 0);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(79, 58);
            this.buttonPrev.TabIndex = 0;
            this.buttonPrev.TabStop = false;
            this.buttonPrev.UseVisualStyleBackColor = false;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOpen.FlatAppearance.BorderSize = 3;
            this.buttonOpen.Image = global::FitsViewer.Properties.Resources.openFile1;
            this.buttonOpen.Location = new System.Drawing.Point(301, 0);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonOpen.Size = new System.Drawing.Size(75, 58);
            this.buttonOpen.TabIndex = 0;
            this.buttonOpen.TabStop = false;
            this.buttonOpen.UseMnemonic = false;
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(996, 703);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panelPicture);
            this.Controls.Add(this.panelNavi);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "MainForm";
            this.Text = "FITS Viewer";
            this.panelNavi.ResumeLayout(false);
            this.panelPicture.ResumeLayout(false);
            this.panelPicture.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelNavi;
        private System.Windows.Forms.Panel panelPicture;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Button buttonHeader;
        private System.Windows.Forms.TextBox textBoxHeader;

    }
}

