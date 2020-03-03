namespace NumberEditor
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnResourcePathLoad = new DarkUI.Controls.DarkButton();
            this.textBoxFolderPath = new DarkUI.Controls.DarkTextBox();
            this.propertySetting = new System.Windows.Forms.PropertyGrid();
            this.comboBoxBg = new DarkUI.Controls.DarkComboBox();
            this.label2 = new DarkUI.Controls.DarkLabel();
            this.panelMain = new DarkUI.Docking.DarkDockPanel();
            this.btnClear = new DarkUI.Controls.DarkButton();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.btnNew = new DarkUI.Controls.DarkButton();
            this.tableLayoutPanelMenu = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutMenu = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolTip_tools = new System.Windows.Forms.ToolTip(this.components);
            this.imageboxMain = new Emgu.CV.UI.ImageBox();
            this.radioPencil = new System.Windows.Forms.RadioButton();
            this.radioMagnifier = new System.Windows.Forms.RadioButton();
            this.radioFill = new System.Windows.Forms.RadioButton();
            this.radioHand = new System.Windows.Forms.RadioButton();
            this.radioEraser = new System.Windows.Forms.RadioButton();
            this.radioSelection = new System.Windows.Forms.RadioButton();
            this.radioHandBack = new System.Windows.Forms.RadioButton();
            this.radioResizeBack = new System.Windows.Forms.RadioButton();
            this.radioFillBack = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanelMenu.SuspendLayout();
            this.tableLayoutMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageboxMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnResourcePathLoad
            // 
            this.btnResourcePathLoad.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanelMenu.SetColumnSpan(this.btnResourcePathLoad, 2);
            this.btnResourcePathLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResourcePathLoad.Location = new System.Drawing.Point(287, 67);
            this.btnResourcePathLoad.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.btnResourcePathLoad.Name = "btnResourcePathLoad";
            this.btnResourcePathLoad.Padding = new System.Windows.Forms.Padding(5);
            this.btnResourcePathLoad.Size = new System.Drawing.Size(75, 23);
            this.btnResourcePathLoad.TabIndex = 2;
            this.btnResourcePathLoad.Text = "资源";
            this.btnResourcePathLoad.Click += new System.EventHandler(this.btnResourcePathLoad_Click);
            // 
            // textBoxFolderPath
            // 
            this.textBoxFolderPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.textBoxFolderPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanelMenu.SetColumnSpan(this.textBoxFolderPath, 5);
            this.textBoxFolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFolderPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.textBoxFolderPath.Location = new System.Drawing.Point(18, 65);
            this.textBoxFolderPath.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.textBoxFolderPath.Name = "textBoxFolderPath";
            this.textBoxFolderPath.Size = new System.Drawing.Size(214, 22);
            this.textBoxFolderPath.TabIndex = 1;
            // 
            // propertySetting
            // 
            this.propertySetting.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.propertySetting.CategoryForeColor = System.Drawing.Color.Gainsboro;
            this.tableLayoutPanelMenu.SetColumnSpan(this.propertySetting, 7);
            this.propertySetting.CommandsActiveLinkColor = System.Drawing.Color.DarkGray;
            this.propertySetting.CommandsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.propertySetting.CommandsDisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.propertySetting.CommandsForeColor = System.Drawing.Color.Gainsboro;
            this.propertySetting.CommandsLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.propertySetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertySetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.propertySetting.HelpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.propertySetting.HelpForeColor = System.Drawing.Color.Gainsboro;
            this.propertySetting.HelpVisible = false;
            this.propertySetting.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.propertySetting.Location = new System.Drawing.Point(18, 148);
            this.propertySetting.Name = "propertySetting";
            this.propertySetting.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propertySetting.Size = new System.Drawing.Size(344, 606);
            this.propertySetting.TabIndex = 3;
            this.propertySetting.TabStop = false;
            this.propertySetting.ToolbarVisible = false;
            this.propertySetting.ViewBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(68)))), ((int)(((byte)(70)))));
            this.propertySetting.ViewForeColor = System.Drawing.Color.Gainsboro;
            this.propertySetting.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGridSetting_PropertyValueChanged);
            // 
            // comboBoxBg
            // 
            this.tableLayoutPanelMenu.SetColumnSpan(this.comboBoxBg, 5);
            this.comboBoxBg.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxBg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxBg.FormattingEnabled = true;
            this.comboBoxBg.Location = new System.Drawing.Point(18, 98);
            this.comboBoxBg.Name = "comboBoxBg";
            this.comboBoxBg.Size = new System.Drawing.Size(214, 23);
            this.comboBoxBg.TabIndex = 1;
            this.comboBoxBg.SelectedIndexChanged += new System.EventHandler(this.comboBoxBg_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelMenu.SetColumnSpan(this.label2, 2);
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label2.Location = new System.Drawing.Point(300, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(12, 3, 3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "背景";
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1416, 828);
            this.panelMain.TabIndex = 7;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanelMenu.SetColumnSpan(this.btnClear, 2);
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(287, 25);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Padding = new System.Windows.Forms.Padding(5);
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "清洁";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanelMenu.SetColumnSpan(this.btnSave, 3);
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(152, 25);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5);
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanelMenu.SetColumnSpan(this.btnNew, 2);
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(18, 25);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Padding = new System.Windows.Forms.Padding(5);
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "新建";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // tableLayoutPanelMenu
            // 
            this.tableLayoutPanelMenu.ColumnCount = 9;
            this.tableLayoutPanelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanelMenu.Controls.Add(this.btnNew, 1, 1);
            this.tableLayoutPanelMenu.Controls.Add(this.btnSave, 3, 1);
            this.tableLayoutPanelMenu.Controls.Add(this.btnClear, 6, 1);
            this.tableLayoutPanelMenu.Controls.Add(this.textBoxFolderPath, 1, 2);
            this.tableLayoutPanelMenu.Controls.Add(this.btnResourcePathLoad, 6, 2);
            this.tableLayoutPanelMenu.Controls.Add(this.label2, 6, 3);
            this.tableLayoutPanelMenu.Controls.Add(this.comboBoxBg, 1, 3);
            this.tableLayoutPanelMenu.Controls.Add(this.propertySetting, 1, 5);
            this.tableLayoutPanelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMenu.Location = new System.Drawing.Point(3, 53);
            this.tableLayoutPanelMenu.Name = "tableLayoutPanelMenu";
            this.tableLayoutPanelMenu.RowCount = 7;
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanelMenu.Size = new System.Drawing.Size(380, 772);
            this.tableLayoutPanelMenu.TabIndex = 13;
            // 
            // tableLayoutMenu
            // 
            this.tableLayoutMenu.ColumnCount = 2;
            this.tableLayoutMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMenu.Controls.Add(this.tableLayoutPanelMenu, 0, 1);
            this.tableLayoutMenu.Controls.Add(this.imageboxMain, 1, 1);
            this.tableLayoutMenu.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMenu.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMenu.Name = "tableLayoutMenu";
            this.tableLayoutMenu.RowCount = 2;
            this.tableLayoutMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutMenu.Size = new System.Drawing.Size(1416, 828);
            this.tableLayoutMenu.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 12;
            this.tableLayoutMenu.SetColumnSpan(this.tableLayoutPanel1, 2);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.radioPencil, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioMagnifier, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioFill, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioHand, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioEraser, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioSelection, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioHandBack, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioResizeBack, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioFillBack, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(18, 3);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(18, 3, 3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1395, 44);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // imageboxMain
            // 
            this.imageboxMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.imageboxMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageboxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageboxMain.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageboxMain.Location = new System.Drawing.Point(391, 65);
            this.imageboxMain.Margin = new System.Windows.Forms.Padding(5, 15, 15, 15);
            this.imageboxMain.Name = "imageboxMain";
            this.imageboxMain.Size = new System.Drawing.Size(1010, 748);
            this.imageboxMain.TabIndex = 2;
            this.imageboxMain.TabStop = false;
            // 
            // radioPencil
            // 
            this.radioPencil.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioPencil.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioPencil.BackgroundImage = global::NumberEditor.Properties.Resources.pencil;
            this.radioPencil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radioPencil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioPencil.Location = new System.Drawing.Point(3, 3);
            this.radioPencil.Name = "radioPencil";
            this.radioPencil.Size = new System.Drawing.Size(36, 38);
            this.radioPencil.TabIndex = 11;
            this.toolTip_tools.SetToolTip(this.radioPencil, "绘画");
            this.radioPencil.UseVisualStyleBackColor = true;
            this.radioPencil.CheckedChanged += new System.EventHandler(this.radioPencil_CheckedChanged);
            // 
            // radioMagnifier
            // 
            this.radioMagnifier.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioMagnifier.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioMagnifier.BackgroundImage = global::NumberEditor.Properties.Resources.magnifier;
            this.radioMagnifier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radioMagnifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioMagnifier.Location = new System.Drawing.Point(297, 3);
            this.radioMagnifier.Name = "radioMagnifier";
            this.radioMagnifier.Size = new System.Drawing.Size(36, 38);
            this.radioMagnifier.TabIndex = 10;
            this.toolTip_tools.SetToolTip(this.radioMagnifier, "放大镜");
            this.radioMagnifier.UseVisualStyleBackColor = true;
            this.radioMagnifier.CheckedChanged += new System.EventHandler(this.radioMagnifier_CheckedChanged);
            // 
            // radioFill
            // 
            this.radioFill.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioFill.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioFill.BackgroundImage = global::NumberEditor.Properties.Resources.fill;
            this.radioFill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radioFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioFill.Location = new System.Drawing.Point(45, 3);
            this.radioFill.Name = "radioFill";
            this.radioFill.Size = new System.Drawing.Size(36, 38);
            this.radioFill.TabIndex = 11;
            this.toolTip_tools.SetToolTip(this.radioFill, "填充");
            this.radioFill.UseVisualStyleBackColor = true;
            this.radioFill.CheckedChanged += new System.EventHandler(this.radioFill_CheckedChanged);
            // 
            // radioHand
            // 
            this.radioHand.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioHand.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioHand.BackgroundImage = global::NumberEditor.Properties.Resources.hand;
            this.radioHand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radioHand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioHand.Location = new System.Drawing.Point(213, 3);
            this.radioHand.Name = "radioHand";
            this.radioHand.Size = new System.Drawing.Size(36, 38);
            this.radioHand.TabIndex = 11;
            this.toolTip_tools.SetToolTip(this.radioHand, "移动画面");
            this.radioHand.UseVisualStyleBackColor = true;
            this.radioHand.CheckedChanged += new System.EventHandler(this.radioHand_CheckedChanged);
            // 
            // radioEraser
            // 
            this.radioEraser.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioEraser.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioEraser.BackgroundImage = global::NumberEditor.Properties.Resources.erase;
            this.radioEraser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radioEraser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioEraser.Location = new System.Drawing.Point(129, 3);
            this.radioEraser.Name = "radioEraser";
            this.radioEraser.Size = new System.Drawing.Size(36, 38);
            this.radioEraser.TabIndex = 12;
            this.radioEraser.TabStop = true;
            this.toolTip_tools.SetToolTip(this.radioEraser, "橡皮");
            this.radioEraser.UseVisualStyleBackColor = true;
            this.radioEraser.CheckedChanged += new System.EventHandler(this.radioButtonErase_CheckedChanged);
            // 
            // radioSelection
            // 
            this.radioSelection.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioSelection.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioSelection.BackgroundImage = global::NumberEditor.Properties.Resources.selection;
            this.radioSelection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radioSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioSelection.Location = new System.Drawing.Point(171, 3);
            this.radioSelection.Name = "radioSelection";
            this.radioSelection.Size = new System.Drawing.Size(36, 38);
            this.radioSelection.TabIndex = 11;
            this.toolTip_tools.SetToolTip(this.radioSelection, "选择");
            this.radioSelection.UseVisualStyleBackColor = true;
            this.radioSelection.CheckedChanged += new System.EventHandler(this.radioSelection_CheckedChanged);
            // 
            // radioHandBack
            // 
            this.radioHandBack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioHandBack.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioHandBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioHandBack.BackgroundImage")));
            this.radioHandBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radioHandBack.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioHandBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioHandBack.Location = new System.Drawing.Point(255, 3);
            this.radioHandBack.Name = "radioHandBack";
            this.radioHandBack.Size = new System.Drawing.Size(36, 38);
            this.radioHandBack.TabIndex = 13;
            this.radioHandBack.TabStop = true;
            this.toolTip_tools.SetToolTip(this.radioHandBack, "移动背景");
            this.radioHandBack.UseVisualStyleBackColor = true;
            this.radioHandBack.CheckedChanged += new System.EventHandler(this.radioHandBack_CheckedChanged);
            // 
            // radioResizeBack
            // 
            this.radioResizeBack.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioResizeBack.BackgroundImage = global::NumberEditor.Properties.Resources.resize_back;
            this.radioResizeBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radioResizeBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioResizeBack.Location = new System.Drawing.Point(339, 3);
            this.radioResizeBack.Name = "radioResizeBack";
            this.radioResizeBack.Size = new System.Drawing.Size(36, 38);
            this.radioResizeBack.TabIndex = 14;
            this.radioResizeBack.TabStop = true;
            this.toolTip_tools.SetToolTip(this.radioResizeBack, "背景大小调整");
            this.radioResizeBack.UseVisualStyleBackColor = true;
            this.radioResizeBack.CheckedChanged += new System.EventHandler(this.radioResizeBack_CheckedChanged);
            // 
            // radioFillBack
            // 
            this.radioFillBack.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioFillBack.BackgroundImage = global::NumberEditor.Properties.Resources.fill_back;
            this.radioFillBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radioFillBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioFillBack.Location = new System.Drawing.Point(87, 3);
            this.radioFillBack.Name = "radioFillBack";
            this.radioFillBack.Size = new System.Drawing.Size(36, 38);
            this.radioFillBack.TabIndex = 15;
            this.radioFillBack.TabStop = true;
            this.toolTip_tools.SetToolTip(this.radioFillBack, "背景填充");
            this.radioFillBack.UseVisualStyleBackColor = true;
            this.radioFillBack.CheckedChanged += new System.EventHandler(this.radioFillBack_CheckedChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 828);
            this.Controls.Add(this.tableLayoutMenu);
            this.Controls.Add(this.panelMain);
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "车牌生成工具";
            this.tableLayoutPanelMenu.ResumeLayout(false);
            this.tableLayoutPanelMenu.PerformLayout();
            this.tableLayoutMenu.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageboxMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DarkUI.Controls.DarkButton btnResourcePathLoad;
        private DarkUI.Controls.DarkTextBox textBoxFolderPath;
        private DarkUI.Docking.DarkDockPanel panelMain;
        private DarkUI.Controls.DarkComboBox comboBoxBg;
        private DarkUI.Controls.DarkLabel label2;
        private Emgu.CV.UI.ImageBox imageboxMain;
        private DarkUI.Controls.DarkButton btnClear;
        private DarkUI.Controls.DarkButton btnSave;
        private DarkUI.Controls.DarkButton btnNew;
        private System.Windows.Forms.PropertyGrid propertySetting;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMenu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMenu;
        private System.Windows.Forms.ToolTip toolTip_tools;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton radioPencil;
        private System.Windows.Forms.RadioButton radioMagnifier;
        private System.Windows.Forms.RadioButton radioFill;
        private System.Windows.Forms.RadioButton radioHand;
        private System.Windows.Forms.RadioButton radioEraser;
        private System.Windows.Forms.RadioButton radioSelection;
        private System.Windows.Forms.RadioButton radioHandBack;
        private System.Windows.Forms.RadioButton radioResizeBack;
        private System.Windows.Forms.RadioButton radioFillBack;
    }
}

