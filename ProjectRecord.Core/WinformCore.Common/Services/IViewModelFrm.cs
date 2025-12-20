using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace WinformCore.Common.Services;

public interface IViewModelFrm<T>
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public T ViewModel { get; set; }

    void FrmBinding();

    public string GetPropertyNameFromLambda(Expression<Func<T, object>> expr)
    {
        if (expr.Body is MemberExpression memberExpr)
        {
            // 直接获取属性名（如 vm=>vm.ICommAND → "ICommAND"）
            return memberExpr.Member.Name;
        }

        // 处理值类型属性（如 int/bool）的装箱情况
        if (expr.Body is UnaryExpression unaryExpr && unaryExpr.Operand is MemberExpression unaryMemberExpr)
        {
            return unaryMemberExpr.Member.Name;
        }

        return null;
    }
}