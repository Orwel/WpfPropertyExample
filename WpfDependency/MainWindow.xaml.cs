using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDependency
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var WeirdoColor = Color.FromRgb(100, 100, 0);
            TextAdvanced.OverrideMetaData();
            InitializeComponent();

            TextBase01.SetColourProperty(WeirdoColor);
            TextBase.SetMessageProperty(TextBase01, "TextBase01");

            TextBlock02.Text = (string)TextBlock02.GetValue(TextBase.MessageProperty);
            TextBlock02.Background = new SolidColorBrush((Color)TextBlock02.GetValue(TextBase.ColourProperty));

            TextBlock03.SetValue(TextBase.MessageProperty, "TextBlock03");
            TextBlock03.SetValue(TextBase.ColourProperty, WeirdoColor);

            TextBase.SetMessageProperty(TextBasePlus11, "TextBasePlus11");
            TextBasePlus11.SetColourProperty(WeirdoColor); 

            TextBase.SetMessageProperty(TextAdvanced13, "TextAdvanced13");
            TextAdvanced13.SetColourProperty(WeirdoColor);

            TextBase.SetMessageProperty(TextAdvancedPlus23, "TextAdvancedPlus23");
            TextAdvancedPlus23.SetColourProperty(WeirdoColor);
        }
    }
}
