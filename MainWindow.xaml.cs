using System;
using System.Data;
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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            
            foreach (UIElement el in numButtons.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += Button_Click;
                }
            }
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
 string str = (string)((Button)e.OriginalSource).Content;
                
                if (str == "C")
                    textBlock.Text = "";
                else if (str == "=")
                {
                    string value = new DataTable().Compute(textBlock.Text, null).ToString();
                    textBlock.Text = value;
                }
                else if (str == "🠴")
                {
                    textBlock.Text = textBlock.Text.Remove(textBlock.Text.Length - 1, 1);

                }
                else if (str == "х") textBlock.Text = textBlock.Text.Replace("х","*");
                else
                    textBlock.Text += str;
            }
           catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
