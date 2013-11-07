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
    class TextAdvanced : TextBase
    {
        static public void OverrideMetaData()
        {
            TextBase.MessageProperty.OverrideMetadata(typeof(TextAdvanced), new PropertyMetadata("DefaultAdvanced", MessagePropertyChangedOverride));
            TextBase.ColourProperty.OverrideMetadata(typeof(TextAdvanced), new PropertyMetadata(Color.FromRgb(0, 0, 255), ColourPropertyChangedOverride));
        }

        public static void MessagePropertyChangedOverride(DependencyObject obj,
               DependencyPropertyChangedEventArgs args)
        {
            var textBase = obj as TextBlock;
            if (textBase != null)
                textBase.Text = "+="+(string)args.NewValue+"=+";
        }

        public static void ColourPropertyChangedOverride(DependencyObject obj,
                DependencyPropertyChangedEventArgs args)
        {
            var textBase = obj as TextBlock;
            if (textBase != null)
            {
                Color colour = (Color)args.NewValue;
                colour.A = 128;
                textBase.Background = new SolidColorBrush(colour);
            }
        }
    }
}
