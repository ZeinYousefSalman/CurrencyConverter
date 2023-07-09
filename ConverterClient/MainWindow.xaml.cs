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

namespace ConverterClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private  async void NumberStringInputButtonClic(object sender, RoutedEventArgs e)
        {
            string strNumber = NumberStringInput.Text;
            try
            {
                var res = await ApiClientGrpc.Send(strNumber);
                NumberStringResult.Content = res.Message;
            }
            catch(Exception ex)
            {
                NumberStringResult.Content = "Error in your string , please make sure that your string matches the conditions like: 999 999 767,56";
            }

        }
    }
}
