using System.ComponentModel;

namespace NavigationModules.Views;

partial class MainFrm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
        titleBar = new AntdUI.PageHeader();
        colorTheme = new AntdUI.ColorPicker();
        btn_mode = new AntdUI.Button();
        panel1 = new AntdUI.Panel();
        splitter1 = new AntdUI.Splitter();
        panel2 = new AntdUI.Panel();
        headerMenu = new AntdUI.Menu();
        titleBar.SuspendLayout();
        panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitter1).BeginInit();
        splitter1.SuspendLayout();
        panel2.SuspendLayout();
        SuspendLayout();
        // 
        // titleBar
        // 
        titleBar.BackColor = System.Drawing.Color.Transparent;
        titleBar.Controls.Add(colorTheme);
        titleBar.Controls.Add(btn_mode);
        titleBar.DividerColor = System.Drawing.Color.FromArgb(((int)((byte)251)), ((int)((byte)251)), ((int)((byte)251)));
        titleBar.DividerMargin = 1;
        titleBar.DividerShow = true;
        titleBar.Dock = System.Windows.Forms.DockStyle.Top;
        titleBar.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
        titleBar.ForeColor = System.Drawing.Color.DarkRed;
        titleBar.Icon = ((System.Drawing.Image)resources.GetObject("titleBar.Icon"));
        titleBar.Location = new System.Drawing.Point(0, 0);
        titleBar.Name = "titleBar";
        titleBar.ShowButton = true;
        titleBar.ShowIcon = true;
        titleBar.Size = new System.Drawing.Size(800, 40);
        titleBar.TabIndex = 0;
        titleBar.Text = "Winform.Core";
        // 
        // colorTheme
        // 
        colorTheme.Dock = System.Windows.Forms.DockStyle.Right;
        colorTheme.Location = new System.Drawing.Point(534, 0);
        colorTheme.Name = "colorTheme";
        colorTheme.Padding = new System.Windows.Forms.Padding(5);
        colorTheme.Size = new System.Drawing.Size(40, 40);
        colorTheme.TabIndex = 8;
        colorTheme.Value = System.Drawing.Color.FromArgb(((int)((byte)22)), ((int)((byte)119)), ((int)((byte)255)));
        colorTheme.Visible = false;
        // 
        // btn_mode
        // 
        btn_mode.Dock = System.Windows.Forms.DockStyle.Right;
        btn_mode.Ghost = true;
        btn_mode.IconSvg = "SunOutlined";
        btn_mode.Location = new System.Drawing.Point(574, 0);
        btn_mode.Name = "btn_mode";
        btn_mode.Radius = 0;
        btn_mode.Size = new System.Drawing.Size(46, 40);
        btn_mode.TabIndex = 6;
        btn_mode.ToggleIconSvg = "MoonOutlined";
        btn_mode.Visible = false;
        btn_mode.WaveSize = 0;
        btn_mode.Click += btn_mode_Click;
        // 
        // panel1
        // 
        panel1.Back = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)255)), ((int)((byte)22)), ((int)((byte)22)));
        panel1.BackColor = System.Drawing.Color.Transparent;
        panel1.Controls.Add(splitter1);
        panel1.Controls.Add(panel2);
        panel1.Dock = System.Windows.Forms.DockStyle.Fill;
        panel1.Location = new System.Drawing.Point(0, 40);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(800, 410);
        panel1.TabIndex = 1;
        panel1.Text = "panel1";
        // 
        // splitter1
        // 
        splitter1.BackColor = System.Drawing.Color.Transparent;
        splitter1.Cursor = System.Windows.Forms.Cursors.Default;
        splitter1.Dock = System.Windows.Forms.DockStyle.Fill;
        splitter1.Location = new System.Drawing.Point(0, 30);
        splitter1.Name = "splitter1";
        splitter1.Size = new System.Drawing.Size(800, 380);
        splitter1.SplitterDistance = 200;
        splitter1.SplitterWidth = 10;
        splitter1.TabIndex = 1;
        splitter1.Text = "splitter1";
        // 
        // panel2
        // 
        panel2.Back = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)22)), ((int)((byte)119)), ((int)((byte)255)));
        panel2.Controls.Add(headerMenu);
        panel2.Dock = System.Windows.Forms.DockStyle.Top;
        panel2.Location = new System.Drawing.Point(0, 0);
        panel2.Name = "panel2";
        panel2.Size = new System.Drawing.Size(800, 30);
        panel2.TabIndex = 0;
        panel2.Text = "panel2";
        // 
        // headerMenu
        // 
        headerMenu.BackColor = System.Drawing.Color.Transparent;
        headerMenu.Dock = System.Windows.Forms.DockStyle.Fill;
        headerMenu.Location = new System.Drawing.Point(0, 0);
        headerMenu.Mode = AntdUI.TMenuMode.Horizontal;
        headerMenu.Name = "headerMenu";
        headerMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        headerMenu.Size = new System.Drawing.Size(800, 30);
        headerMenu.TabIndex = 0;
        headerMenu.Text = "menu1";
        // 
        // MainFrm
        // 
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
        BackColor = System.Drawing.Color.White;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(panel1);
        Controls.Add(titleBar);
        Dark = true;
        ForeColor = System.Drawing.Color.Black;
        Mode = AntdUI.TAMode.Dark;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "MainFrm";
        titleBar.ResumeLayout(false);
        panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitter1).EndInit();
        splitter1.ResumeLayout(false);
        panel2.ResumeLayout(false);
        ResumeLayout(false);
    }

    private AntdUI.ColorPicker colorTheme;

    private AntdUI.Button btn_mode;

    private AntdUI.Menu headerMenu;


    private AntdUI.Splitter splitter1;

    private AntdUI.Panel panel2;

    private AntdUI.Panel panel1;

    #endregion
    
    private AntdUI.PageHeader titleBar;
}