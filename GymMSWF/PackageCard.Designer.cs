namespace GymMSWF
{
    partial class PackageCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            lblName = new Label();
            lblPrice = new Label();
            lblSessions = new Label();
            lblDescription = new Label();
            DeletePackage = new FontAwesome.Sharp.IconButton();
            EditPackage = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(400, 216);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblName.AutoSize = true;
            lblName.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.White;
            lblName.ImageAlign = ContentAlignment.MiddleLeft;
            lblName.Location = new Point(70, 242);
            lblName.Name = "lblName";
            lblName.Size = new Size(67, 26);
            lblName.TabIndex = 1;
            lblName.Text = "label1";
            lblName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPrice
            // 
            lblPrice.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Times New Roman", 10.8F);
            lblPrice.ForeColor = Color.White;
            lblPrice.ImageAlign = ContentAlignment.MiddleLeft;
            lblPrice.Location = new Point(70, 294);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(51, 20);
            lblPrice.TabIndex = 2;
            lblPrice.Text = "label1";
            lblPrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSessions
            // 
            lblSessions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblSessions.AutoSize = true;
            lblSessions.Font = new Font("Times New Roman", 10.8F);
            lblSessions.ForeColor = Color.White;
            lblSessions.ImageAlign = ContentAlignment.MiddleLeft;
            lblSessions.Location = new Point(70, 331);
            lblSessions.Name = "lblSessions";
            lblSessions.Size = new Size(51, 20);
            lblSessions.TabIndex = 3;
            lblSessions.Text = "label1";
            lblSessions.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDescription
            // 
            lblDescription.Font = new Font("Times New Roman", 10.8F);
            lblDescription.ForeColor = Color.White;
            lblDescription.ImageAlign = ContentAlignment.MiddleLeft;
            lblDescription.Location = new Point(70, 366);
            lblDescription.MaximumSize = new Size(0, 230);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(263, 92);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "label1";
            // 
            // DeletePackage
            // 
            DeletePackage.FlatAppearance.BorderSize = 0;
            DeletePackage.FlatStyle = FlatStyle.Flat;
            DeletePackage.IconChar = FontAwesome.Sharp.IconChar.Trash;
            DeletePackage.IconColor = Color.FromArgb(4, 165, 188);
            DeletePackage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            DeletePackage.IconSize = 25;
            DeletePackage.Location = new Point(363, 435);
            DeletePackage.Name = "DeletePackage";
            DeletePackage.Size = new Size(37, 45);
            DeletePackage.TabIndex = 5;
            DeletePackage.UseVisualStyleBackColor = true;
            DeletePackage.Click += DeletePackage_Click;
            // 
            // EditPackage
            // 
            EditPackage.FlatAppearance.BorderSize = 0;
            EditPackage.FlatStyle = FlatStyle.Flat;
            EditPackage.IconChar = FontAwesome.Sharp.IconChar.Edit;
            EditPackage.IconColor = Color.FromArgb(4, 165, 188);
            EditPackage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            EditPackage.IconSize = 25;
            EditPackage.Location = new Point(3, 435);
            EditPackage.Name = "EditPackage";
            EditPackage.Size = new Size(37, 45);
            EditPackage.TabIndex = 6;
            EditPackage.UseVisualStyleBackColor = true;
            EditPackage.Click += EditPackage_Click;
            // 
            // PackageCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 41, 54);
            Controls.Add(EditPackage);
            Controls.Add(DeletePackage);
            Controls.Add(lblDescription);
            Controls.Add(lblSessions);
            Controls.Add(lblPrice);
            Controls.Add(lblName);
            Controls.Add(pictureBox1);
            Name = "PackageCard";
            Size = new Size(400, 500);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblName;
        private Label lblPrice;
        private Label lblSessions;
        private Label lblDescription;
        private FontAwesome.Sharp.IconButton DeletePackage;
        private FontAwesome.Sharp.IconButton EditPackage;
    }
}
