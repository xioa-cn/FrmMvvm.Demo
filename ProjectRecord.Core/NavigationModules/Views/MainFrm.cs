using NavigationModules.ViewModels;
using ProjectRecord.Common.Services;
using System.ComponentModel;
using ProjectRecord.Common.Attribute;
using ProjectRecord.Common.Extensions;
using MenuItem = AntdUI.MenuItem;

namespace NavigationModules.Views;

[AutoFrmView(nameof(MainFrm), registerType: typeof(Form))]
public partial class MainFrm : ViewModelFrm, IViewModelFrm<MainViewModel>
{
    public MainFrm(MainViewModel mainViewModel) : base(false, closeApplication: true)
    {
        this.ViewModel = mainViewModel;
        InitializeComponent();
        colorTheme.ValueChanged += ColorTheme_ValueChanged;
        this.headerMenu.Items.Add(new MenuItem()
        {
            Text = "TEXST",
        });
    }

    public override void FrmBinding()
    {
        this.SetBinding()
            .BindingProperty(titleBar, pg => pg.Text, vm => vm.Title);
        base.FrmBinding();
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public MainViewModel ViewModel { get; set; }

    bool setcolor = false;

    private void btn_mode_Click(object sender, EventArgs e)
    {
        if (setcolor)
        {
            var color = AntdUI.Style.Db.Primary;
            AntdUI.Config.IsDark = !AntdUI.Config.IsDark;
            Dark = AntdUI.Config.IsDark;
            AntdUI.Style.SetPrimary(color);
        }
        else
        {
            AntdUI.Config.IsDark = !AntdUI.Config.IsDark;
            Dark = AntdUI.Config.IsDark;
        }

        btn_mode.Toggle = Dark;
        OnSizeChanged(e);
    }
    
    private void ColorTheme_ValueChanged(object sender, AntdUI.ColorEventArgs e)
    {
        setcolor = true;
        AntdUI.Style.SetPrimary(e.Value);
        Refresh();
    }
}