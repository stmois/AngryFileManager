namespace AngryFileManager
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.catalogsView = new System.Windows.Forms.TreeView();
            this.iconList = new System.Windows.Forms.ImageList(this.components);
            this.backButton = new System.Windows.Forms.Button();
            this.goButton = new System.Windows.Forms.Button();
            this.detailsView = new System.Windows.Forms.ListView();
            this.DetailsName = new System.Windows.Forms.ColumnHeader();
            this.DetailsSize = new System.Windows.Forms.ColumnHeader();
            this.DetailsType = new System.Windows.Forms.ColumnHeader();
            this.DetailsDate = new System.Windows.Forms.ColumnHeader();
            this.navigationTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // catalogsView
            // 
            this.catalogsView.AllowDrop = true;
            this.catalogsView.ImageIndex = 0;
            this.catalogsView.ImageList = this.iconList;
            this.catalogsView.Location = new System.Drawing.Point(12, 88);
            this.catalogsView.Name = "catalogsView";
            this.catalogsView.SelectedImageIndex = 0;
            this.catalogsView.Size = new System.Drawing.Size(243, 512);
            this.catalogsView.TabIndex = 0;
            this.catalogsView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // iconList
            // 
            this.iconList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.iconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconList.ImageStream")));
            this.iconList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconList.Images.SetKeyName(0, "icons8-folder-16.png");
            this.iconList.Images.SetKeyName(1, "icons8-file-16.png");
            this.iconList.Images.SetKeyName(2, "icons8-ssd-16.png");
            // 
            // backButton
            // 
            this.backButton.Image = ((System.Drawing.Image)(resources.GetObject("backButton.Image")));
            this.backButton.Location = new System.Drawing.Point(524, 27);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(41, 23);
            this.backButton.TabIndex = 1;
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // goButton
            // 
            this.goButton.Image = ((System.Drawing.Image)(resources.GetObject("goButton.Image")));
            this.goButton.Location = new System.Drawing.Point(477, 27);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(41, 23);
            this.goButton.TabIndex = 2;
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // detailsView
            // 
            this.detailsView.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.detailsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DetailsName,
            this.DetailsSize,
            this.DetailsType,
            this.DetailsDate});
            this.detailsView.FullRowSelect = true;
            this.detailsView.LargeImageList = this.iconList;
            this.detailsView.Location = new System.Drawing.Point(261, 88);
            this.detailsView.Name = "detailsView";
            this.detailsView.Size = new System.Drawing.Size(659, 511);
            this.detailsView.SmallImageList = this.iconList;
            this.detailsView.TabIndex = 3;
            this.detailsView.UseCompatibleStateImageBehavior = false;
            this.detailsView.View = System.Windows.Forms.View.Details;
            this.detailsView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            this.detailsView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // DetailsName
            // 
            this.DetailsName.Text = "Имя";
            this.DetailsName.Width = 300;
            // 
            // DetailsSize
            // 
            this.DetailsSize.Text = "Размер";
            this.DetailsSize.Width = 100;
            // 
            // DetailsType
            // 
            this.DetailsType.Text = "Тип";
            this.DetailsType.Width = 100;
            // 
            // DetailsDate
            // 
            this.DetailsDate.Text = "Дата изменения";
            this.DetailsDate.Width = 135;
            // 
            // navigationTextBox
            // 
            this.navigationTextBox.Location = new System.Drawing.Point(12, 27);
            this.navigationTextBox.Name = "navigationTextBox";
            this.navigationTextBox.Size = new System.Drawing.Size(459, 23);
            this.navigationTextBox.TabIndex = 4;
            this.navigationTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.filePathTextBox_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Каталоги:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Навигация:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(261, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Содержимое:";
            // 
            // MainForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 606);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.navigationTextBox);
            this.Controls.Add(this.detailsView);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.catalogsView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Angry File Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TreeView catalogsView;
        private Button backButton;
        private Button goButton;
        private ListView detailsView;
        private TextBox navigationTextBox;
        private Label label1;
        private Label fileNameLabel;
        private Label label3;
        private Label fileTypeLabel;
        private ImageList iconList;
        private Label label2;
        private Label label4;
        private Label label5;
        private ColumnHeader DetailsName;
        private ColumnHeader DetailsSize;
        private ColumnHeader DetailsType;
        private ColumnHeader DetailsDate;
    }
}