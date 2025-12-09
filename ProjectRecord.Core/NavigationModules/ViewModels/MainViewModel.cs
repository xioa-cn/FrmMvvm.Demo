using ProjectRecord.Common.Attribute;
using ProjectRecord.Common.Services;
using ProjectRecord.Models.Configs;

namespace NavigationModules.ViewModels;

[AutoFrmVm(typeof(MainViewModel))]
public partial class MainViewModel : ReactiveObject
{
    public string Title { get; set; }

    public MainViewModel(AppSettings appSetting)
    {
        this.Title = appSetting.AppName;
    }
}