namespace ProjectRecord.Startup;

partial class LoginFrm
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginFrm));
        titleBar = new AntdUI.PageHeader();
        panel1 = new AntdUI.Panel();
        gridPanel1 = new AntdUI.GridPanel();
        button2 = new AntdUI.Button();
        rememberPassword = new AntdUI.Checkbox();
        Password = new AntdUI.Input();
        Account = new AntdUI.Input();
        label1 = new AntdUI.Label();
        panel2 = new AntdUI.Panel();
        wel = new AntdUI.Label();
        panel1.SuspendLayout();
        gridPanel1.SuspendLayout();
        panel2.SuspendLayout();
        SuspendLayout();
        // 
        // titleBar
        // 
        titleBar.BackColor = System.Drawing.Color.Transparent;
        titleBar.DividerColor = System.Drawing.Color.FromArgb(((int)((byte)251)), ((int)((byte)251)), ((int)((byte)251)));
        titleBar.DividerMargin = 1;
        titleBar.DividerShow = true;
        titleBar.Dock = System.Windows.Forms.DockStyle.Top;
        titleBar.Font = new System.Drawing.Font("Mistral", 12F, System.Drawing.FontStyle.Bold);
        titleBar.ForeColor = System.Drawing.Color.DarkRed;
        titleBar.Location = new System.Drawing.Point(0, 0);
        titleBar.MaximizeBox = false;
        titleBar.MinimizeBox = false;
        titleBar.Name = "titleBar";
        titleBar.ShowButton = true;
        titleBar.Size = new System.Drawing.Size(650, 40);
        titleBar.TabIndex = 0;
        titleBar.Text = "Winform.Core";
        // 
        // panel1
        // 
        panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
        panel1.Back = System.Drawing.Color.FromArgb(((int)((byte)145)), ((int)((byte)208)), ((int)((byte)209)), ((int)((byte)218)));
        panel1.BackColor = System.Drawing.Color.Transparent;
        panel1.BorderColor = System.Drawing.Color.FromArgb(((int)((byte)49)), ((int)((byte)22)), ((int)((byte)119)), ((int)((byte)255)));
        panel1.BorderWidth = 10F;
        panel1.Controls.Add(gridPanel1);
        panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
        panel1.Location = new System.Drawing.Point(339, 48);
        panel1.Margin = new System.Windows.Forms.Padding(5);
        panel1.Name = "panel1";
        panel1.padding = new System.Windows.Forms.Padding(20);
        panel1.Radius = 10;
        panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        panel1.Size = new System.Drawing.Size(311, 300);
        panel1.TabIndex = 1;
        panel1.Text = "panel1";
        // 
        // gridPanel1
        // 
        gridPanel1.Controls.Add(button2);
        gridPanel1.Controls.Add(rememberPassword);
        gridPanel1.Controls.Add(Password);
        gridPanel1.Controls.Add(Account);
        gridPanel1.Controls.Add(label1);
        gridPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        gridPanel1.HandCursor = System.Windows.Forms.Cursors.Arrow;
        gridPanel1.Location = new System.Drawing.Point(13, 13);
        gridPanel1.Name = "gridPanel1";
        gridPanel1.Padding = new System.Windows.Forms.Padding(10);
        gridPanel1.Size = new System.Drawing.Size(285, 274);
        gridPanel1.Span = "100%;100%;100%;100%;100%;-25% 20% 20% \r\n10% 20% 0%\r\n\r\n\r\n\r\n";
        gridPanel1.TabIndex = 0;
        gridPanel1.Text = "gridPanel1";
        // 
        // button2
        // 
        button2.BackExtend = "135, #6253E1, #04BEFE";
        button2.IconSvg = "";
        button2.Location = new System.Drawing.Point(13, 203);
        button2.Name = "button2";
        button2.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
        button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        button2.Shape = AntdUI.TShape.Round;
        button2.Size = new System.Drawing.Size(259, 45);
        button2.TabIndex = 6;
        button2.Text = "登  录";
        button2.TextCenterHasIcon = true;
        button2.Type = AntdUI.TTypeMini.Primary;
        // 
        // rememberPassword
        // 
        rememberPassword.Dock = System.Windows.Forms.DockStyle.Left;
        rememberPassword.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 8F);
        rememberPassword.Location = new System.Drawing.Point(13, 178);
        rememberPassword.Name = "rememberPassword";
        rememberPassword.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
        rememberPassword.Size = new System.Drawing.Size(259, 19);
        rememberPassword.TabIndex = 4;
        rememberPassword.Text = "记住密码";
        // 
        // Password
        // 
        Password.BackExtend = "-20deg, #e9defa, #fbfcdb";
        Password.BorderWidth = 0F;
        Password.Dock = System.Windows.Forms.DockStyle.Fill;
        Password.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)19)), ((int)((byte)100)), ((int)((byte)212)));
        Password.Location = new System.Drawing.Point(13, 127);
        Password.Name = "Password";
        Password.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
        Password.PasswordChar = '*';
        Password.PlaceholderColorExtend = "120deg, #f093fb, #f5576c";
        Password.PlaceholderText = "密码";
        Password.Size = new System.Drawing.Size(259, 45);
        Password.TabIndex = 3;
        // 
        // Account
        // 
        Account.BackExtend = "-20deg, #e9defa, #fbfcdb";
        Account.BorderWidth = 0F;
        Account.Dock = System.Windows.Forms.DockStyle.Fill;
        Account.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)19)), ((int)((byte)100)), ((int)((byte)212)));
        Account.Location = new System.Drawing.Point(13, 77);
        Account.Name = "Account";
        Account.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
        Account.PlaceholderColorExtend = "120deg, #f093fb, #f5576c";
        Account.PlaceholderText = "账户";
        Account.Size = new System.Drawing.Size(259, 45);
        Account.TabIndex = 2;
        // 
        // label1
        // 
        label1.Dock = System.Windows.Forms.DockStyle.Bottom;
        label1.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 15F, System.Drawing.FontStyle.Bold);
        label1.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)22)), ((int)((byte)119)), ((int)((byte)255)));
        label1.Location = new System.Drawing.Point(13, 13);
        label1.Name = "label1";
        label1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
        label1.Size = new System.Drawing.Size(259, 58);
        label1.TabIndex = 0;
        label1.Text = "账户登录";
        label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
        // 
        // panel2
        // 
        panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
        panel2.Back = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)22)), ((int)((byte)119)), ((int)((byte)255)));
        panel2.BackColor = System.Drawing.Color.Transparent;
        panel2.Controls.Add(wel);
        panel2.Location = new System.Drawing.Point(30, 53);
        panel2.Margin = new System.Windows.Forms.Padding(10);
        panel2.Name = "panel2";
        panel2.padding = new System.Windows.Forms.Padding(10);
        panel2.Padding = new System.Windows.Forms.Padding(10);
        panel2.Size = new System.Drawing.Size(310, 300);
        panel2.TabIndex = 2;
        panel2.Text = "panel2";
        // 
        // wel
        // 
        wel.Dock = System.Windows.Forms.DockStyle.Bottom;
        wel.Font = new System.Drawing.Font("Edwardian Script ITC", 12F, System.Drawing.FontStyle.Bold);
        wel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)7)), ((int)((byte)206)), ((int)((byte)224)));
        wel.Highlight = false;
        wel.Location = new System.Drawing.Point(10, 260);
        wel.Name = "wel";
        wel.PrefixColor = System.Drawing.Color.FromArgb(((int)((byte)19)), ((int)((byte)94)), ((int)((byte)200)));
        wel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        wel.Size = new System.Drawing.Size(290, 30);
        wel.TabIndex = 0;
        wel.Text = "登录界面";
        wel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
        // 
        // LoginFrm
        // 
        BackColor = System.Drawing.Color.White;
        BackgroundImage = ((System.Drawing.Image)resources.GetObject("$this.BackgroundImage"));
        BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        ClientSize = new System.Drawing.Size(650, 360);
        Controls.Add(panel2);
        Controls.Add(panel1);
        Controls.Add(titleBar);
        Dark = true;
        Font = new System.Drawing.Font("Microsoft YaHei UI Light", 12F);
        ForeColor = System.Drawing.Color.Black;
        MaximizeBox = false;
        MaximumSize = new System.Drawing.Size(650, 360);
        MinimizeBox = false;
        MinimumSize = new System.Drawing.Size(650, 360);
        Mode = AntdUI.TAMode.Dark;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "AntdUI";
        panel1.ResumeLayout(false);
        gridPanel1.ResumeLayout(false);
        panel2.ResumeLayout(false);
        ResumeLayout(false);
    }

    private AntdUI.Button button2;

  

    private AntdUI.Checkbox rememberPassword;

    private AntdUI.Input Password;

    private AntdUI.Input Account;

    private AntdUI.Label label1;

    private AntdUI.GridPanel gridPanel1;

    private AntdUI.Label wel;

    private AntdUI.Panel panel2;

    private AntdUI.Panel panel1;

    #endregion

        private AntdUI.PageHeader titleBar;
}