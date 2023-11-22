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
using System.Diagnostics;

namespace LR9
{
    /// <summary>
    /// Interaction logic for Basket.xaml
    /// </summary>
    public partial class Basket : Window
    {
        public int summ = 0;
        public Basket()
        {
            InitializeComponent();
            PhoneNum.TextChanged += TextBox_TextChanged;

            string[] allLines = File.ReadAllLines(@"D:\Урочки\ООП\ЛР9\orders.txt");
            foreach (string line in allLines)
            {
                string[] parts = line.Split(',');
                
                string categoryName = parts[0].Trim();
                string name = parts[1];
                int price;
                int.TryParse(parts[2], out price);
                summ += price;
                AddItemsToListView(categoryName, name, price);
            }
            Summ.Content = summ;
        }
        public void AddItemsToListView(string categoryName, string name, int price)
        {
            Products product = new Products
            {
                CategoryName = categoryName,
                ItemName = name,
                Price = price
            };
            orderList.Items.Add(product);
        }
        public bool dog;
        //Кнопка збереження замовлення
        private void ViewBtn_Click(object sender, RoutedEventArgs e)
        {            
            if (dog == false)
            {
                MessageBox.Show("Некоректна адреса, потрібно ввести '@'!");
            }
            else if (NameText.Text == "")
            {
                MessageBox.Show("Введіть ПІБ");
            }
            else if(PhoneNum.Text == "") MessageBox.Show("Введіть номер телефону");
            else if (Adress.Text == "") MessageBox.Show("Введіть адресу доставки");
            else
            {
                string pib = NameText.Text;
                int phone;
                int.TryParse((PhoneNum.Text), out phone);
                string gmail = GMail.Text;
                string adress = Adress.Text;

                string filePath = @"D:\Урочки\ООП\ЛР9\OrdersList.txt";
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine($"{pib}, {phone}, {gmail}, {adress}, {summ}");
                }
                AllOrders orders = new AllOrders();
                orders.Show();
                Close();
                File.WriteAllText(@"D:\Урочки\ООП\ЛР9\orders.txt", string.Empty);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (!int.TryParse(textBox.Text, out _))
                {
                    textBox.Text = string.Empty;
                }
            }
        }

        private void GMail_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (!textBox.Text.Contains("@"))
                {
                    // Якщо в тексті немає символу '@', показуємо повідомлення
                    MessageBox.Show("Некоректна адреса, потрібно ввести '@'!");
                    dog = false;
                }else dog = true;
            }
        }
    }
}
