using Windows.UI.Xaml;

namespace UWP.Toolkits
{
    public class DataTrigger : DependencyObject
    {
        #region *** AssessPropertyName ***

        private static readonly DependencyProperty AssessPropertyNameProperty = DependencyProperty.Register("AssessPropertyName", typeof(string), typeof(DataTrigger), new PropertyMetadata(null));

        public string AssessPropertyName
        {
            get => (string)GetValue(AssessPropertyNameProperty);
            set => SetValue(AssessPropertyNameProperty, value);
        }

        #endregion

        #region *** ExpectValue ***

        private static readonly DependencyProperty ExpectValueProperty = DependencyProperty.Register("ExpectValue", typeof(object), typeof(DataTrigger), new PropertyMetadata(null));

        public object ExpectValue
        {
            get => GetValue(ExpectValueProperty);
            set => SetValue(ExpectValueProperty, value);
        }

        #endregion

        #region *** TargetPropertyName ***

        private static readonly DependencyProperty PropertyNameProperty = DependencyProperty.Register("PropertyName", typeof(string), typeof(DataTrigger), new PropertyMetadata(null));

        public string PropertyName
        {
            get => (string)GetValue(PropertyNameProperty);
            set => SetValue(PropertyNameProperty, value);
        }

        #endregion

        #region *** Value ***

        private static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(object), typeof(DataTrigger), new PropertyMetadata(null));

        public object Value
        {
            get => GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        #endregion
    }
}
