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
using System.Data;

namespace PlainCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //MainContainer.Children - Children - это получение всех дочерних элементов
            foreach (UIElement element in MainContainer.Children)
            {
                if (element is Button)
                {
                    (element as Button).Click += Button_Click;
                }
            }
        }
        string Expression = string.Empty;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Expression = (e.OriginalSource as Button).Content.ToString();

            if (Expression == "C")
            {
                TxtBkRes.Text = string.Empty;
            }
            else if (Expression == "=")
            {
                try
                {
                    //вычисление результата
                    string Res = new DataTable().Compute(TxtBkRes.Text.Trim(), null).ToString();
                    TxtBkRes.Text = Res;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    TxtBkRes.Text = string.Empty;
                    return;
                }
            }
            else
            {
                TxtBkRes.Text += Expression;
            }
        }
    }
}
