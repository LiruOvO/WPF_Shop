using System;
using System.Collections.Generic;
using System.IO;
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

namespace LR9
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
        //Кнопка оформити замовлення
        private void ViewBtn_Click(object sender, RoutedEventArgs e)
        {
            Basket basket = new Basket();
            basket.Show();
            Close();
        }

        private void AddBtn_Doll_Click(object sender, RoutedEventArgs e)
        {
            Toys doll = new Toys();
            doll.CategoryName = "Іграшки";
            doll.Price = 350;
            doll.ItemName = "Лялька";
            string filePath = @"D:\Урочки\ООП\ЛР9\orders.txt";
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine($"{doll.CategoryName}, {doll.ItemName}, {doll.Price}");
            }
        }

        private void AddBtn_Car_Click(object sender, RoutedEventArgs e)
        {
            Toys car = new Toys();
            car.CategoryName = "Іграшки";
            car.Price = 999;
            car.ItemName = "Машинка";
            string filePath = @"D:\Урочки\ООП\ЛР9\orders.txt";
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine($"{car.CategoryName}, {car.ItemName}, {car.Price}");
            }
        }

        private void AddBtn_Tablet_Click(object sender, RoutedEventArgs e)
        {
            Electronics tablet = new Electronics();
            tablet.CategoryName = "Електроніка";
            tablet.Price = 11599;
            tablet.ItemName = "Планшет";
            string filePath = @"D:\Урочки\ООП\ЛР9\orders.txt";
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine($"{tablet.CategoryName}, {tablet.ItemName}, {tablet.Price}");
            }
        }

        private void AddBtn_Smartphone_Click(object sender, RoutedEventArgs e)
        {
            Electronics smartphone = new Electronics();
            smartphone.CategoryName = "Електроніка";
            smartphone.Price = 8599;
            smartphone.ItemName = "Сматрфон";
            string filePath = @"D:\Урочки\ООП\ЛР9\orders.txt";
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine($"{smartphone.CategoryName}, {smartphone.ItemName}, {smartphone.Price}");
            }
        }

        private void ViewBtn_Copy_Click(object sender, RoutedEventArgs e)
        {
            AllOrders orders = new AllOrders();
            orders.Show();
            Close();
        }
    }
}
