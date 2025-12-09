using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Input;
using ProjectRecord.Common.Services;

namespace ProjectRecord.Common.Extensions;

public static class FrmBindingExtensions
{
    extension<T>(IViewModelFrm<T> form)
    {
        public IViewModelFrm<T> SetBinding()
        {
            if (form is Control control)
            {
                control.DataContext = form.ViewModel;
            }

            return form;
        }

        public IViewModelFrm<T> BindingProperty<TSource>(Control control,
            object controlProperty,
            TSource source,
            Expression<Func<TSource, object>> viewModelPropertyExpr)
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control), "绑定的控件不能为null");
            if (controlProperty == null)
                throw new ArgumentNullException(nameof(controlProperty), "控件属性不能为null");
            if (viewModelPropertyExpr == null)
                throw new ArgumentNullException(nameof(viewModelPropertyExpr), "ViewModel属性表达式不能为null");
            if (form.ViewModel == null)
                throw new InvalidOperationException("请先初始化 ViewModel 再绑定");

            var viewModelPropName = string.Empty;
            if (viewModelPropertyExpr.Body is MemberExpression memberExpr)
            {
                viewModelPropName = memberExpr.Member.Name;
            }

            if (viewModelPropertyExpr.Body is UnaryExpression unaryExpr &&
                unaryExpr.Operand is MemberExpression unaryMemberExpr)
            {
                viewModelPropName = unaryMemberExpr.Member.Name;
            }

            if (string.IsNullOrEmpty(viewModelPropName))
                throw new ArgumentException("无法从 Lambda 表达式中解析出 ViewModel 属性名", nameof(viewModelPropertyExpr));

            // 解析控件属性（WinForms 中 controlProperty 传属性名字符串/PropertyInfo 都兼容）
            string controlPropName = controlProperty.ToString();
            // 兼容 WPF 的 DependencyProperty（如果是 WinForms 直接用属性名）
            if (controlProperty is PropertyInfo propInfo)
                controlPropName = propInfo.Name;

            // 校验控件属性是否存在
            PropertyInfo ctrlProp = control.GetType().GetProperty(controlPropName);
            if (ctrlProp == null)
                throw new ArgumentException($"控件 {control.Name} 不存在属性 {controlPropName}", nameof(controlProperty));

            var targetBinding = control.DataBindings.Cast<Binding>()
                .FirstOrDefault(b =>
                    b.PropertyName == controlPropName);

            // 精准移除这个绑定（而非移除所有）
            if (targetBinding != null)
            {
                control.DataBindings.Remove(targetBinding);
            }

            // 建立强类型绑定（核心逻辑）
            control.DataBindings.Add(
                new Binding(
                    controlPropName, // 控件属性名
                    source, // source 实例
                    viewModelPropName, // 解析后的 source 属性名
                    true,
                    DataSourceUpdateMode.OnPropertyChanged
                )
            );
            return form;
        }

        public IViewModelFrm<T> BindingProperty<TControl, TSource>(TControl control, TSource source,
            Expression<Func<TControl, object?>> controlPropertyExpr,
            Expression<Func<TSource, object>> viewModelPropertyExpr)
            where TControl : Control
        {
            if (controlPropertyExpr == null)
                throw new ArgumentNullException(nameof(controlPropertyExpr), "控件属性表达式不能为null");

            var controlPropertyName = string.Empty;
            if (controlPropertyExpr.Body is MemberExpression memberExpr)
            {
                controlPropertyName = memberExpr.Member.Name;
            }

            if (controlPropertyExpr.Body is UnaryExpression unaryExpr &&
                unaryExpr.Operand is MemberExpression unaryMemberExpr)
            {
                controlPropertyName = unaryMemberExpr.Member.Name;
            }

            return form.BindingProperty<T, TSource>(control, controlPropertyName, source, viewModelPropertyExpr);
        }

        public IViewModelFrm<T> BindingProperty(Control control,
            object controlProperty,
            Expression<Func<T, object>> viewModelPropertyExpr)
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control), "绑定的控件不能为null");
            if (controlProperty == null)
                throw new ArgumentNullException(nameof(controlProperty), "控件属性不能为null");
            if (viewModelPropertyExpr == null)
                throw new ArgumentNullException(nameof(viewModelPropertyExpr), "ViewModel属性表达式不能为null");
            if (form.ViewModel == null)
                throw new InvalidOperationException("请先初始化 ViewModel 再绑定");

            string viewModelPropName = form.GetPropertyNameFromLambda(viewModelPropertyExpr);
            if (string.IsNullOrEmpty(viewModelPropName))
                throw new ArgumentException("无法从 Lambda 表达式中解析出 ViewModel 属性名", nameof(viewModelPropertyExpr));

            // 解析控件属性（WinForms 中 controlProperty 传属性名字符串/PropertyInfo 都兼容）
            string controlPropName = controlProperty.ToString();
            // 兼容 WPF 的 DependencyProperty（如果是 WinForms 直接用属性名）
            if (controlProperty is PropertyInfo propInfo)
                controlPropName = propInfo.Name;

            // 校验控件属性是否存在
            PropertyInfo ctrlProp = control.GetType().GetProperty(controlPropName);
            if (ctrlProp == null)
                throw new ArgumentException($"控件 {control.Name} 不存在属性 {controlPropName}", nameof(controlProperty));

            var targetBinding = control.DataBindings.Cast<Binding>()
                .FirstOrDefault(b =>
                    b.PropertyName == controlPropName);

            // 精准移除这个绑定（而非移除所有）
            if (targetBinding != null)
            {
                control.DataBindings.Remove(targetBinding);
            }

            // 建立强类型绑定（核心逻辑）
            control.DataBindings.Add(
                new Binding(
                    controlPropName, // 控件属性名
                    form.ViewModel, // ViewModel 实例
                    viewModelPropName, // 解析后的 ViewModel 属性名
                    true,
                    DataSourceUpdateMode.OnPropertyChanged
                )
            );
            return form;
        }

        public IViewModelFrm<T> BindingProperty<TControl>(TControl control,
            Expression<Func<TControl, object?>> controlPropertyExpr, Expression<Func<T, object>> viewModelPropertyExpr)
            where TControl : Control
        {
            if (controlPropertyExpr == null)
                throw new ArgumentNullException(nameof(controlPropertyExpr), "控件属性表达式不能为null");

            var controlPropertyName = string.Empty;
            if (controlPropertyExpr.Body is MemberExpression memberExpr)
            {
                controlPropertyName = memberExpr.Member.Name;
            }

            if (controlPropertyExpr.Body is UnaryExpression unaryExpr &&
                unaryExpr.Operand is MemberExpression unaryMemberExpr)
            {
                controlPropertyName = unaryMemberExpr.Member.Name;
            }

            return form.BindingProperty(control, controlPropertyName, viewModelPropertyExpr);
        }


        public IViewModelFrm<T> CommandBinding(Control control, Expression<Func<T, object>> viewModelCommandExpr,
            Func<object?>? commandParameter = null)
        {
            // 基础参数校验
            if (control == null)
                throw new ArgumentNullException(nameof(control), "绑定的控件不能为null");
            if (viewModelCommandExpr == null)
                throw new ArgumentNullException(nameof(viewModelCommandExpr), "Command表达式不能为null");
            if (form.ViewModel == null)
                throw new InvalidOperationException("请先初始化 ViewModel 再绑定命令");

            string commandPropName = form.GetPropertyNameFromLambda(viewModelCommandExpr);
            if (string.IsNullOrEmpty(commandPropName))
                throw new ArgumentException("无法从 Lambda 表达式中解析出 Command 属性名", nameof(viewModelCommandExpr));

            PropertyInfo commandProp = typeof(T).GetProperty(commandPropName);
            if (commandProp == null)
                throw new ArgumentException($"ViewModel 中不存在 {commandPropName} 属性", nameof(viewModelCommandExpr));
            var command = commandProp.GetValue(form.ViewModel) as ICommand;
            if (command == null)
                throw new InvalidCastException($"{commandPropName} 必须实现 ICommand 接口");

            // 适配控件事件（优先处理 Button.Click，也支持其他有 Click 事件的控件）
            var clickEvent = control.GetType().GetEvent("Click");
            if (clickEvent == null)
                throw new NotSupportedException($"控件 {control.GetType().Name} 不支持 Click 事件，无法绑定 Command");

            // 定义命令执行委托（精准绑定/移除，避免重复）
            EventHandler executeHandler = (s, e) => command.Execute(commandParameter?.Invoke());

            // 先移除原有委托，再添加新委托（避免多次绑定导致命令执行多次）
            clickEvent.RemoveEventHandler(control, executeHandler);
            clickEvent.AddEventHandler(control, executeHandler);

            // 绑定 CanExecute → 控件 Enabled 状态（核心增强）
            void UpdateControlEnabled()
            {
                // 确保控件支持 Enabled 属性（几乎所有 WinForms 控件都支持）
                var enabledProp = control.GetType().GetProperty("Enabled");
                if (enabledProp != null && enabledProp.CanWrite)
                {
                    enabledProp.SetValue(control, command.CanExecute(commandParameter?.Invoke()));
                }
            }

            // 初始化控件启用状态
            UpdateControlEnabled();

            // 监听 Command 可执行状态变化，自动更新控件状态
            EventHandler canExecuteChangedHandler = (s, e) => UpdateControlEnabled();
            command.CanExecuteChanged -= canExecuteChangedHandler; // 先移除避免重复
            command.CanExecuteChanged += canExecuteChangedHandler;

            // 控件销毁时解绑事件（防止内存泄漏）
            control.Disposed += (s, e) =>
            {
                clickEvent.RemoveEventHandler(control, executeHandler);
                command.CanExecuteChanged -= canExecuteChangedHandler;
            };
            return form;
        }
    }
}