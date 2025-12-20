using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using WinformCore.Common.Attribute;
using WinformCore.Common.Extensions;
using WinformCore.Common.Services;
using WinformCore.Models.Configs;
using WinformCore.Models.Models.Login;

namespace WinformCore.Startup.ViewModels;

[AutoFrmVm(typeof(LoginViewModel))]
public partial class LoginViewModel : ReactiveObject
{
    [ObservableProperty] public string _loginBtnText = "登  录";

    [ObservableProperty] private bool _rememberInfo = true;

    private readonly Form _mainFrm;

    public LoginViewModel(AppSettings appSettings, [FromKeyedServices("MainFrm")] Form mainFrm)
    {
        _mainFrm = mainFrm;
        Title = appSettings.AppName;
        Task.Factory.StartNew(Comm, TaskCreationOptions.LongRunning);
    }

    public string Title { get; set; }

    [RelayCommand]
    private void Login(LoginUser user)
    {
        this.BindingControl?.SwitchWindow(_mainFrm, FormSwitchExtensions.AnimationType.SlideLeft,
            closeFrmAction: frm => frm.Visible = false);
    }

    private async Task Comm()
    {
        var r = new Random();
        while (true)
        {
            await Task.Delay(500);
        }
    }
}