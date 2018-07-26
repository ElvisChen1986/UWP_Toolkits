using Microsoft.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using UWP.Toolkits.Behaviors;
using Windows.UI.Xaml;

namespace UWP.Toolkits
{
    public class XamlToolkits
    {
        private static readonly DependencyProperty DataTriggerCollectionProperty = DependencyProperty.RegisterAttached("DataTriggerCollection", typeof(ICollection<DataTrigger>), typeof(XamlToolkits), new PropertyMetadata(null, (d, e) =>
        {
            if (e.NewValue is ICollection<DataTrigger> collection)
            {
                collection.ToList().ForEach(trigger =>
                {
                    var behavior = Activator.CreateInstance<DataTriggerBehavior>();
                    behavior.AssessPropertyName = trigger.AssessPropertyName;
                    behavior.ExpectValue = trigger.ExpectValue;
                    behavior.PropertyName = trigger.PropertyName;
                    behavior.Value = trigger.Value;

                    Interaction.GetBehaviors(d).Add(behavior);
                });
            }
        }));

        public static void SetDataTriggerCollection(UIElement reference, ICollection<DataTrigger> value)
        {
            reference.SetValue(DataTriggerCollectionProperty, value);
        }

        public static ICollection<DataTrigger> GetDataTriggerCollection(UIElement reference)
        {
            return reference.GetValue(DataTriggerCollectionProperty) as ICollection<DataTrigger>;
        }
    }
}
