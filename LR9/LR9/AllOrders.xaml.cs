using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Security.Policy;
using System.Net.NetworkInformation;
using System.Xml.Linq;

namespace LR9
{
    /// <summary>
    /// Interaction logic for AllOrders.xaml
    /// </summary>
    public partial class AllOrders : Window
    {
        public AllOrders()
        {
            InitializeComponent();
            string[] allLines = File.ReadAllLines(@"D:\Урочки\ООП\ЛР9\OrdersList.txt");
            foreach (string line in allLines)
            {
                string[] parts = line.Split(',');
                string pib = parts[0];
                string num = parts[1];
                string gmail = parts[2];
                string adress = parts[3];
                string summ = parts[4];

                
                AddItemsToListView(pib, num, gmail, adress, summ);
            }
        }
        public void AddItemsToListView(string pib, string num, string gmail, string adress, string summ)
        {
            Order newOrder = new Order
            {
                PIB = pib,
                Number = num,
                Gmail = gmail,
                Address = adress,
                Summ = summ
            };

            orderList.Items.Add(newOrder);
        }

        private void ViewBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow buy = new MainWindow();
            buy.Show();
            Close();
        }
    }
}
