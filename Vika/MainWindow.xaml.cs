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
using System.Data.Entity;

namespace Vika
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static void RegistrPerson(string LoginUser, string Pass, string Fio, string Phone, string Email, string Gender, string Position, int Rol)
        {
            //Таблица Persona
            RegistraciaEntities2 registraciaEntities = new RegistraciaEntities2();
            Persona user = new Persona
            {
                LoginReg = LoginUser,
                ParolReg = Pass,
                Imia = Fio,
                Telefon = Phone,
                Pochta = Email,
                Pol= Gender,
                Dolzhnost=Position,
                CodRol = Rol
            };
            registraciaEntities.Persona.Add(user);
            registraciaEntities.SaveChanges();

            //Таблица Polzovatel
            Polzovatel autUser = new Polzovatel()
            {
                LoginVhod = user.LoginReg,
                ParolVhod = user.ParolReg,
                CodPerson = user.CodPerson
            };
            registraciaEntities.Polzovatel.Add(autUser);
            registraciaEntities.SaveChanges();
        }


        private void registr_Click(object sender, RoutedEventArgs e)
        {
            //Получение данных от пользователя
            string loginUser = loginText.Text;
            string pass = parolText.Password;
            string fio = imiaText.Text;
            string phone = telefonText.Text;
            string email = pochtaText.Text;
            string gender = polText.Text;
            string position = positionText.Text;
            int rol = 2;

            
            //Проверка на корректность ввода данных
            if (loginUser.Length < 3)
            {
                loginText.ToolTip = "Логин должен содержать более 3 символов.";
                loginText.Background = Brushes.Salmon;
            }
            else if (pass.Length < 3)
            {
                parolText.ToolTip = "Пароль должен содержать более 3 символов.";
                parolText.Background = Brushes.Salmon;
            }
            else
            {
                loginText.ToolTip = "";
                loginText.Background = Brushes.White;
                parolText.ToolTip = "";
                parolText.Background = Brushes.White;

                //Вызов функции
                RegistrPerson(loginUser, pass, fio, phone, email, gender, position, rol);

                MessageBox.Show("Регистрация прошла успешно!");

                //Очестка полей
                loginText.Clear();
                parolText.Clear();
                imiaText.Clear();
                telefonText.Clear();
                pochtaText.Clear();
                polText.Clear();
                positionText.Clear();
            }
        }

        private void perehod_Click(object sender, RoutedEventArgs e)
        {
            //Переход на окно входа
            Vhod vhod = new Vhod();
            vhod.Show();
            Close();
        }
    }
}
