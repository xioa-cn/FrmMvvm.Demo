using LottieSharp.WPF;
using ProjectRecord.Common.Attribute;
using ProjectRecord.Common.Extensions;
using ProjectRecord.Common.Services;
using ProjectRecord.Startup.ViewModels;
using System.Windows;
using System.Windows.Forms.Integration;
using HorizontalAlignment = System.Windows.HorizontalAlignment;
using System.ComponentModel;
using ProjectRecord.Models.Models.Login;

namespace ProjectRecord.Startup;

[AutoFrmView(nameof(LoginFrm), registerType: typeof(Form))]
public partial class LoginFrm : ViewModelFrm, IViewModelFrm<LoginViewModel>
{
    public LoginFrm(LoginViewModel login) : base(true, closeApplication: false)
    {
        ViewModel = login;
        this.OnceLoaded(OnceLoaded);
        InitializeComponent();
    }

    public override void FrmBinding()
    {
        this.SetBinding()
            .BindingProperty(button2, btn => btn.Text, vm => vm.LoginBtnText)
            .CommandBinding(button2, vm => vm.LoginCommand,
                () => new LoginUser() { Account = this.Account.Text, Password = this.Password.Text })
            .BindingProperty(titleBar, "Text", vm => vm.Title)
            .BindingProperty(rememberPassword, cb => cb.Checked, vm => vm.RememberInfo);

        base.FrmBinding();
    }


    private void OnceLoaded(object? sender, EventArgs e)
    {
        LottieAnimationView lottieAnimationView = new LottieAnimationView();
        lottieAnimationView.AutoPlay = true;
        lottieAnimationView.RepeatCount = -1;
        lottieAnimationView.FileName = "Resources/loginbg.json";
        lottieAnimationView.HorizontalAlignment = HorizontalAlignment.Center;
        lottieAnimationView.VerticalAlignment = VerticalAlignment.Center;
        ElementHost host = new ElementHost()
        {
            Width = 310,
            Height = 300,
            Child = lottieAnimationView,
            Dock = DockStyle.Fill
        };

        panel2.Controls.Add(host);
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public LoginViewModel ViewModel { get; set; }
}