using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace test5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Connect db = new Connect();
        public MainWindow()
        {
            InitializeComponent();

            db.Cars.Load();
            // toBindingList
            DGV.ItemsSource = db.Cars.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Edit Form = new Edit();
            if (Form.ShowDialog() == true)
            {
                Car car = new Car();
                car.CarNum = Form.TBCarNum.Text;
                car.FIO = Form.TBFIO.Text;
                car.Date = Form.DPDate.Text;
                car.Type = Form.CBType.Text;
                car.Cost = Convert.ToInt32(Form.TBCost.Text);

                db.Cars.Add(car);

                db.SaveChanges();

                MessageBox.Show("Новый объект добавлен");
            }

            DGV.ItemsSource = db.Cars.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Car car = DGV.SelectedItem as Car;
            // если ни одного объекта не выделено, выходим
            if (car is null) return;

            Edit Form = new Edit();
            if (Form.ShowDialog() == true)
            {
                car.CarNum = Form.TBCarNum.Text;
                car.FIO = Form.TBFIO.Text;
                car.Date = Form.DPDate.Text;
                car.Type = Form.CBType.Text;
                car.Cost = Convert.ToInt32(Form.TBCost.Text);
            }

            db.SaveChanges();

            MessageBox.Show("Объект изменен");
            DGV.ItemsSource = db.Cars.ToList();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Car car = DGV.SelectedItem as Car;
            // если ни одного объекта не выделено, выходим
            if (car is null) return;
            db.Cars.Remove(car);
            db.SaveChanges();
            DGV.ItemsSource = db.Cars.ToList();
        }
    }
}
