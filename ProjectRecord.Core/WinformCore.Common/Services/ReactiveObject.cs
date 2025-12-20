using CommunityToolkit.Mvvm.ComponentModel;

namespace WinformCore.Common.Services;

public abstract class ReactiveObject : ObservableObject
{
    public Control? BindingControl { get; set; }
}