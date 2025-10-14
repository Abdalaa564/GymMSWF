namespace GymMSWF
{
    partial class Packages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Packages));
            TopBarPanel = new Panel();
            panel1 = new Panel();
            SearchPackage = new FontAwesome.Sharp.IconButton();
            txtSearch = new TextBox();
            AddPackage = new Button();
            MainPanel = new Panel();
            flowPackages = new FlowLayoutPanel();
            TopBarPanel.SuspendLayout();
            panel1.SuspendLayout();
            MainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // TopBarPanel
            // 
            TopBarPanel.BackColor = Color.FromArgb(49, 52, 67);
            TopBarPanel.Controls.Add(panel1);
            TopBarPanel.Controls.Add(AddPackage);
            TopBarPanel.Dock = DockStyle.Top;
            TopBarPanel.Location = new Point(0, 0);
            TopBarPanel.Name = "TopBarPanel";
            TopBarPanel.Size = new Size(1178, 69);
            TopBarPanel.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(74, 79, 99);
            panel1.Controls.Add(SearchPackage);
            panel1.Controls.Add(txtSearch);
            panel1.Location = new Point(18, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(354, 47);
            panel1.TabIndex = 2;
            // 
            // SearchPackage
            // 
            SearchPackage.Cursor = Cursors.Hand;
            SearchPackage.FlatAppearance.BorderSize = 0;
            SearchPackage.FlatStyle = FlatStyle.Flat;
            SearchPackage.Font = new Font("Segoe UI", 4.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SearchPackage.IconChar = FontAwesome.Sharp.IconChar.Search;
            SearchPackage.IconColor = Color.FromArgb(210, 212, 217);
            SearchPackage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SearchPackage.IconSize = 30;
            SearchPackage.Location = new Point(22, 7);
            SearchPackage.Name = "SearchPackage";
            SearchPackage.Size = new Size(43, 30);
            SearchPackage.TabIndex = 2;
            SearchPackage.UseVisualStyleBackColor = true;
            SearchPackage.Click += SearchPackage_Click;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(39, 41, 54);
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.ForeColor = Color.White;
            txtSearch.Location = new Point(71, 7);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(271, 34);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // AddPackage
            // 
            AddPackage.BackColor = Color.FromArgb(74, 169, 81);
            AddPackage.FlatAppearance.BorderSize = 0;
            AddPackage.FlatStyle = FlatStyle.Flat;
            AddPackage.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddPackage.ForeColor = Color.White;
            AddPackage.Location = new Point(868, 10);
            AddPackage.Name = "AddPackage";
            AddPackage.Size = new Size(166, 47);
            AddPackage.TabIndex = 1;
            AddPackage.Text = "+  Add Package";
            AddPackage.UseVisualStyleBackColor = false;
            AddPackage.Click += AddPackage_Click;
            // 
            // MainPanel
            // 
            MainPanel.BackColor = Color.FromArgb(49, 52, 67);
            MainPanel.Controls.Add(flowPackages);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 69);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1178, 0);
            MainPanel.TabIndex = 1;
            // 
            // flowPackages
            // 
            flowPackages.AutoScroll = true;
            flowPackages.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowPackages.Dock = DockStyle.Fill;
            flowPackages.Location = new Point(0, 0);
            flowPackages.Margin = new Padding(10);
            flowPackages.Name = "flowPackages";
            flowPackages.Size = new Size(1178, 0);
            flowPackages.TabIndex = 1;
            // 
            // Packages
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1178, 0);
            Controls.Add(MainPanel);
            Controls.Add(TopBarPanel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(1200, 0);
            MinimumSize = new Size(1200, 0);
            Name = "Packages";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Packages";
            Load += Packages_Load;
            TopBarPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            MainPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel TopBarPanel;
        private Panel MainPanel;
        private TextBox txtSearch;
        private Button AddPackage;
        private FontAwesome.Sharp.IconButton SearchPackage;
        private Panel panel1;
        private FlowLayoutPanel flowPackages;
    }
}