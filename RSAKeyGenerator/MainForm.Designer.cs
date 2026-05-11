namespace KeyGenerator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblDestination = new Label();
            txtDestination = new TextBox();
            btnBrowse = new Button();
            fbdDestination = new FolderBrowserDialog();
            lblPrivate = new Label();
            txtPrivate = new TextBox();
            txtPublic = new TextBox();
            btnGenerate = new Button();
            lblPublic = new Label();
            SuspendLayout();
            // 
            // lblDestination
            // 
            lblDestination.AutoSize = true;
            lblDestination.Location = new Point(23, 34);
            lblDestination.Name = "lblDestination";
            lblDestination.Size = new Size(67, 15);
            lblDestination.TabIndex = 0;
            lblDestination.Text = "Destination";
            // 
            // txtDestination
            // 
            txtDestination.Location = new Point(105, 30);
            txtDestination.Name = "txtDestination";
            txtDestination.Size = new Size(371, 23);
            txtDestination.TabIndex = 1;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(475, 30);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(75, 23);
            btnBrowse.TabIndex = 2;
            btnBrowse.Text = "browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // lblPrivate
            // 
            lblPrivate.AutoSize = true;
            lblPrivate.Location = new Point(23, 69);
            lblPrivate.Name = "lblPrivate";
            lblPrivate.Size = new Size(99, 15);
            lblPrivate.TabIndex = 3;
            lblPrivate.Text = "Private Key Name";
            // 
            // txtPrivate
            // 
            txtPrivate.Location = new Point(128, 66);
            txtPrivate.MaxLength = 255;
            txtPrivate.Name = "txtPrivate";
            txtPrivate.Size = new Size(148, 23);
            txtPrivate.TabIndex = 4;
            txtPrivate.Text = "private.pem";
            // 
            // txtPublic
            // 
            txtPublic.Location = new Point(402, 66);
            txtPublic.MaxLength = 255;
            txtPublic.Name = "txtPublic";
            txtPublic.Size = new Size(148, 23);
            txtPublic.TabIndex = 5;
            txtPublic.Text = "public.pem";
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(23, 108);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(109, 38);
            btnGenerate.TabIndex = 6;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // lblPublic
            // 
            lblPublic.AutoSize = true;
            lblPublic.Location = new Point(297, 69);
            lblPublic.Name = "lblPublic";
            lblPublic.Size = new Size(96, 15);
            lblPublic.TabIndex = 7;
            lblPublic.Text = "Public Key Name";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(602, 158);
            Controls.Add(lblPublic);
            Controls.Add(btnGenerate);
            Controls.Add(txtPublic);
            Controls.Add(txtPrivate);
            Controls.Add(lblPrivate);
            Controls.Add(btnBrowse);
            Controls.Add(txtDestination);
            Controls.Add(lblDestination);
            Name = "MainForm";
            Text = "RSA Key Generator";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDestination;
        private TextBox txtDestination;
        private Button btnBrowse;
        private FolderBrowserDialog fbdDestination;
        private Label lblPrivate;
        private TextBox txtPrivate;
        private TextBox txtPublic;
        private Button btnGenerate;
        private Label lblPublic;
    }
}
