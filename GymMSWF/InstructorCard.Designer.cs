namespace GymMSWF
{
    partial class InstructorCard
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            insImage = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            insName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            insPhone = new Guna.UI2.WinForms.Guna2HtmlLabel();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            deleteInsIconButton = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)insImage).BeginInit();
            SuspendLayout();
            // 
            // insImage
            // 
            insImage.Anchor = AnchorStyles.None;
            insImage.ImageRotate = 0F;
            insImage.Location = new Point(31, 25);
            insImage.Name = "insImage";
            insImage.ShadowDecoration.CustomizableEdges = customizableEdges1;
            insImage.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            insImage.Size = new Size(153, 147);
            insImage.TabIndex = 0;
            insImage.TabStop = false;
            // 
            // insName
            // 
            insName.Anchor = AnchorStyles.None;
            insName.BackColor = Color.Transparent;
            insName.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            insName.ForeColor = Color.White;
            insName.Location = new Point(47, 178);
            insName.Name = "insName";
            insName.Size = new Size(137, 21);
            insName.TabIndex = 3;
            insName.Text = "guna2HtmlLabel1";
            insName.TextAlignment = ContentAlignment.TopCenter;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.ForeColor = Color.White;
            guna2HtmlLabel2.Location = new Point(53, 222);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(121, 22);
            guna2HtmlLabel2.TabIndex = 4;
            guna2HtmlLabel2.Text = "guna2HtmlLabel2";
            guna2HtmlLabel2.TextAlignment = ContentAlignment.BottomCenter;
            // 
            // insPhone
            // 
            insPhone.BackColor = Color.Transparent;
            insPhone.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            insPhone.ForeColor = Color.White;
            insPhone.Location = new Point(53, 250);
            insPhone.Name = "insPhone";
            insPhone.Size = new Size(125, 21);
            insPhone.TabIndex = 5;
            insPhone.Text = "guna2HtmlLabel3";
            insPhone.TextAlignment = ContentAlignment.BottomCenter;
            // 
            // iconButton2
            // 
            iconButton2.BackColor = Color.Transparent;
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.ForeColor = Color.Transparent;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.Refresh;
            iconButton2.IconColor = Color.FromArgb(2, 172, 195);
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 25;
            iconButton2.Location = new Point(190, 0);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(31, 30);
            iconButton2.TabIndex = 7;
            iconButton2.UseVisualStyleBackColor = false;
            iconButton2.Click += iconButton2_Click;
            // 
            // deleteInsIconButton
            // 
            deleteInsIconButton.FlatAppearance.BorderSize = 0;
            deleteInsIconButton.FlatStyle = FlatStyle.Flat;
            deleteInsIconButton.ForeColor = Color.Transparent;
            deleteInsIconButton.IconChar = FontAwesome.Sharp.IconChar.Trash;
            deleteInsIconButton.IconColor = Color.FromArgb(2, 172, 195);
            deleteInsIconButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            deleteInsIconButton.IconSize = 25;
            deleteInsIconButton.Location = new Point(0, 0);
            deleteInsIconButton.Name = "deleteInsIconButton";
            deleteInsIconButton.Size = new Size(31, 30);
            deleteInsIconButton.TabIndex = 8;
            deleteInsIconButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(63, 65, 76);
            label1.Location = new Point(6, 204);
            label1.Name = "label1";
            label1.Size = new Size(200, 2);
            label1.TabIndex = 9;
            // 
            // InstructorCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 41, 54);
            Controls.Add(label1);
            Controls.Add(deleteInsIconButton);
            Controls.Add(iconButton2);
            Controls.Add(insPhone);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(insName);
            Controls.Add(insImage);
            Name = "InstructorCard";
            Size = new Size(213, 285);
            ((System.ComponentModel.ISupportInitialize)insImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox insImage;
        private Guna.UI2.WinForms.Guna2HtmlLabel insName;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel insPhone;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton deleteInsIconButton;
        private Label label1;
    }
}
