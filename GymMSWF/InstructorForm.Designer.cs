namespace GymMSWF
{
    partial class InstructorForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            flowLayoutPanel1 = new FlowLayoutPanel();
            AddInstructorBTN = new Guna.UI2.WinForms.Guna2Button();
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            searchIconButton = new FontAwesome.Sharp.IconButton();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.FromArgb(49, 52, 67);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(0, 101);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(987, 411);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // AddInstructorBTN
            // 
            AddInstructorBTN.CustomizableEdges = customizableEdges7;
            AddInstructorBTN.DisabledState.BorderColor = Color.DarkGray;
            AddInstructorBTN.DisabledState.CustomBorderColor = Color.DarkGray;
            AddInstructorBTN.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            AddInstructorBTN.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            AddInstructorBTN.FillColor = Color.FromArgb(74, 169, 81);
            AddInstructorBTN.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddInstructorBTN.ForeColor = Color.White;
            AddInstructorBTN.Location = new Point(804, 12);
            AddInstructorBTN.Name = "AddInstructorBTN";
            AddInstructorBTN.ShadowDecoration.CustomizableEdges = customizableEdges8;
            AddInstructorBTN.Size = new Size(183, 56);
            AddInstructorBTN.TabIndex = 2;
            AddInstructorBTN.Text = "+ Add Instructor";
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.BackColor = Color.FromArgb(39, 41, 54);
            guna2TextBox1.BorderColor = Color.FromArgb(39, 41, 54);
            guna2TextBox1.CustomizableEdges = customizableEdges9;
            guna2TextBox1.DefaultText = "";
            guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.FillColor = Color.FromArgb(39, 41, 54);
            guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Font = new Font("Segoe UI", 9F);
            guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Location = new Point(45, 4);
            guna2TextBox1.Margin = new Padding(3, 4, 3, 4);
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PlaceholderText = "";
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2TextBox1.Size = new Size(250, 35);
            guna2TextBox1.TabIndex = 3;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.FromArgb(74, 79, 99);
            guna2Panel1.Controls.Add(searchIconButton);
            guna2Panel1.Controls.Add(guna2TextBox1);
            guna2Panel1.CustomizableEdges = customizableEdges11;
            guna2Panel1.Location = new Point(12, 12);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2Panel1.Size = new Size(298, 45);
            guna2Panel1.TabIndex = 4;
            // 
            // searchIconButton
            // 
            searchIconButton.FlatAppearance.BorderSize = 0;
            searchIconButton.FlatStyle = FlatStyle.Flat;
            searchIconButton.IconChar = FontAwesome.Sharp.IconChar.Search;
            searchIconButton.IconColor = Color.Black;
            searchIconButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            searchIconButton.IconSize = 30;
            searchIconButton.Location = new Point(0, 4);
            searchIconButton.Name = "searchIconButton";
            searchIconButton.Size = new Size(53, 35);
            searchIconButton.TabIndex = 5;
            searchIconButton.UseVisualStyleBackColor = true;
            // 
            // InstructorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(49, 52, 67);
            ClientSize = new Size(987, 512);
            Controls.Add(guna2Panel1);
            Controls.Add(AddInstructorBTN);
            Controls.Add(flowLayoutPanel1);
            Name = "InstructorForm";
            Text = "InstructorForm";
            Load += InstructorForm_Load;
            guna2Panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Button AddInstructorBTN;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private FontAwesome.Sharp.IconButton searchIconButton;
    }
}