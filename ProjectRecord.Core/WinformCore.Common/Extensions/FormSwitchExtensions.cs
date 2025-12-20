using System.Runtime.InteropServices;

namespace WinformCore.Common.Extensions;

public static class FormSwitchExtensions
{
    #region Windows API 动画相关（核心）

    // 导入 Windows 动画 API
    [DllImport("user32.dll")]
    private static extern bool AnimateWindow(IntPtr hWnd, int dwTime, int dwFlags);

    private const int AW_HOR_POSITIVE = 0x00000001; // 从左到右滑动
    private const int AW_HOR_NEGATIVE = 0x00000002; // 从右到左滑动
    private const int AW_VER_POSITIVE = 0x00000004; // 从上到下滑动
    private const int AW_VER_NEGATIVE = 0x00000008; // 从下到上滑动
    private const int AW_CENTER = 0x00000010; // 中心展开/收缩
    private const int AW_HIDE = 0x00010000; // 隐藏窗体（配合其他动画）
    private const int AW_ACTIVATE = 0x00020000; // 激活窗体（配合其他动画）
    private const int AW_BLEND = 0x00080000; // 淡入/淡出（最常用）

    #endregion

    /// <summary>
    /// 带动画切换窗体：关闭原窗体 → 打开新窗体（支持淡入/滑动等动画）
    /// </summary>
    /// <param name="form">要关闭的原窗体</param>
    /// <param name="switchFrm">要打开的新窗体</param>
    /// <param name="animationType">动画类型（默认淡入淡出）</param>
    /// <param name="animationTime">动画时长（毫秒，默认300）</param>
    /// <param name="closeFrmAction"></param>
    public static void SwitchWindow(this Control form, Form switchFrm,
        AnimationType animationType = AnimationType.Fade,
        int animationTime = 300, Action<Control>? closeFrmAction = null)
    {
        if (form == null) throw new ArgumentNullException(nameof(form));
        if (switchFrm == null) throw new ArgumentNullException(nameof(switchFrm));

        if (!form.IsDisposed && form.Visible)
        {
            ApplyCloseAnimation(form, animationType, animationTime);

            if (closeFrmAction is not null)
            {
                closeFrmAction(form);
            }
            else
            {
                form.TryCloseFrm();
            }
        }

        ApplyOpenAnimation(switchFrm, animationType, animationTime);
        switchFrm.Show();
    }

    private static void ApplyCloseAnimation(Control control, AnimationType animationType, int time)
    {
        Form? form;

        if (control is Form frm)
        {
            form = frm;
        }
        else
        {
            form = control.FindForm();
        }

        if (form is null)
        {
            throw new Exception();
        }

        int animationFlags = GetAnimationFlags(animationType, isClose: true);
        AnimateWindow(form.Handle, time, animationFlags);
    }

    private static void ApplyOpenAnimation(Form form, AnimationType animationType, int time)
    {
        int animationFlags = GetAnimationFlags(animationType, isClose: false);
        AnimateWindow(form.Handle, time, animationFlags);
    }

    private static int GetAnimationFlags(AnimationType type, bool isClose)
    {
        return type switch
        {
            // 淡入/淡出（最通用，无方向问题）
            AnimationType.Fade => isClose ? (AW_BLEND | AW_HIDE) : (AW_BLEND | AW_ACTIVATE),
            // 从右到左滑动
            AnimationType.SlideLeft => isClose ? (AW_HOR_NEGATIVE | AW_HIDE) : (AW_HOR_NEGATIVE | AW_ACTIVATE),
            // 从左到右滑动
            AnimationType.SlideRight => isClose ? (AW_HOR_POSITIVE | AW_HIDE) : (AW_HOR_POSITIVE | AW_ACTIVATE),
            // 从下到上滑动
            AnimationType.SlideUp => isClose ? (AW_VER_NEGATIVE | AW_HIDE) : (AW_VER_NEGATIVE | AW_ACTIVATE),
            // 从中心收缩/展开
            AnimationType.Center => isClose ? (AW_CENTER | AW_HIDE) : (AW_CENTER | AW_ACTIVATE),
            _ => isClose ? AW_HIDE : AW_ACTIVATE // 无动画
        };
    }

    public enum AnimationType
    {
        None, // 无动画
        Fade, // 淡入/淡出（推荐）
        SlideLeft, // 向左滑动
        SlideRight, // 向右滑动
        SlideUp, // 向上滑动
        Center // 中心展开/收缩
    }
}