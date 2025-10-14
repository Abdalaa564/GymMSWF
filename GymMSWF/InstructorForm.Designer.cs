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
            searchTextBox = new Guna.UI2.WinForms.Guna2TextBox();
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
            flowLayoutPanel1.Location = new Point(0, 103);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(958, 542);
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
            AddInstructorBTN.Location = new Point(770, 12);
            AddInstructorBTN.Name = "AddInstructorBTN";
            AddInstructorBTN.ShadowDecoration.CustomizableEdges = customizableEdges8;
            AddInstructorBTN.Size = new Size(183, 56);
            AddInstructorBTN.TabIndex = 2;
            AddInstructorBTN.Text = "+ Add Instructor";
            AddInstructorBTN.Click += AddInstructorBTN_Click;
            // 
            // searchTextBox
            // 
            searchTextBox.BackColor = Color.FromArgb(39, 41, 54);
            searchTextBox.BorderColor = Color.FromArgb(39, 41, 54);
            searchTextBox.CustomizableEdges = customizableEdges9;
            searchTextBox.DefaultText = "";
            searchTextBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            searchTextBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            searchTextBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            searchTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            searchTextBox.FillColor = Color.FromArgb(39, 41, 54);
            searchTextBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            searchTextBox.Font = new Font("Segoe UI", 9F);
            searchTextBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            searchTextBox.Location = new Point(45, 4);
            searchTextBox.Margin = new Padding(3, 4, 3, 4);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.PlaceholderText = "";
            searchTextBox.SelectedText = "";
            searchTextBox.ShadowDecoration.CustomizableEdges = customizableEdges10;
            searchTextBox.Size = new Size(250, 35);
            searchTextBox.TabIndex = 3;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.FromArgb(74, 79, 99);
            guna2Panel1.Controls.Add(searchIconButton);
            guna2Panel1.Controls.Add(searchTextBox);
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
            searchIconButton.Click += searchIconButton_Click;
            // 
            // InstructorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(49, 52, 67);
            ClientSize = new Size(958, 645);
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
        private Guna.UI2.WinForms.Guna2TextBox searchTextBox;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private FontAwesome.Sharp.IconButton searchIconButton;
    }
}