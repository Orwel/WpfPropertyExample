using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfDependency
{
    class TextBase : TextBlock
    {
        #region MessageProperty Attached

        public static readonly DependencyProperty MessageProperty =
                    DependencyProperty.RegisterAttached("MessageProperty", typeof(string), typeof(TextBase),
                    new PropertyMetadata("DefaultBase", MessagePropertyChanged));

        public static string GetMessageProperty(TextBase obj)
        {
            return (string)obj.GetValue(MessageProperty);
        }

        public static void SetMessageProperty(TextBase obj, string value)
        {
            obj.SetValue(MessageProperty, value);
        }

        public static void MessagePropertyChanged(DependencyObject obj,
                       DependencyPropertyChangedEventArgs args)
        {
            var textBase = obj as TextBlock;
            if (textBase != null)
                textBase.Text = (string)args.NewValue;
        }
        #endregion

        #region ColourDependency
        public static readonly DependencyProperty ColourProperty =
            DependencyProperty.Register("ColourProperty", typeof(Color), typeof(TextBase),
            new PropertyMetadata(Color.FromRgb(0, 200, 200), ColourPropertyChanged));

        public Color GetColourProperty()
        {
            return (Color)this.GetValue(ColourProperty);
        }

        public void SetColourProperty(Color value)
        {
            this.SetValue(ColourProperty, value);
        }

        public static void ColourPropertyChanged(DependencyObject obj,
               DependencyPropertyChangedEventArgs args)
        {
            var textBase = obj as TextBlock;
            if (textBase != null)
                textBase.Background = new SolidColorBrush((Color)args.NewValue);
        }
        #endregion

        public TextBase()
        {
            this.Text = GetMessageProperty(this);
            this.Background = new SolidColorBrush(GetColourProperty());
        }
    }
}
