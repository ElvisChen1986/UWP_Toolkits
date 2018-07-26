using Microsoft.Xaml.Interactivity;
using System;
using System.Reflection;
using Windows.UI.Xaml;

namespace UWP.Toolkits.Behaviors
{
    internal class DataTriggerBehavior : Behavior<DependencyObject>
    {
        public string AssessPropertyName { get; set; }

        public object ExpectValue { get; set; }

        public string PropertyName { get; set; }

        public object Value { get; set; }

        protected override void OnAttached()
        {
            base.OnAttached();

            if (GetDependencyProperty(AssociatedObject.GetType()) is DependencyProperty conditionDp)
            {
                AssociatedObject.RegisterPropertyChangedCallback(conditionDp, (sender, dp) =>
                {
                    var curVal = AssociatedObject.GetValue(conditionDp);

                    if (curVal.Equals(ExpectValue))
                    {
                        if(AssociatedObject.GetType().GetProperty(PropertyName, BindingFlags.Public | BindingFlags.Instance) is PropertyInfo propInfo)
                        {
                            propInfo.SetValue(AssociatedObject, Value);
                        }
                    }
                });
            }
        }

        DependencyProperty GetDependencyProperty(Type type)
        {
            if (type == null) return null;

            if (type.GetProperty(AssessPropertyName, BindingFlags.Public | BindingFlags.Static) is PropertyInfo propInfo)
            {
                if (propInfo.GetValue(AssociatedObject) is DependencyProperty dp)
                {
                    return dp;
                }
            }

            return GetDependencyProperty(type.BaseType);
        }
    }
}
