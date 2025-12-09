using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectRecord.Common.Services;

public abstract class ReactiveObject : ObservableObject
{
    public Control? BindingControl { get; set; }
}