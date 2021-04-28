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
using System.Windows.Shapes;

namespace Vika
{
    /// <summary>
    /// Логика взаимодействия для Vhod.xaml
    /// </summary>
    public partial class Vhod : Window
    {
        public Vhod()
        {
            InitializeComponent();
        }

        private void vhod_Click(object sender, RoutedEventArgs e)
        {
            //Получение данных от пользователя
            string loginUser = loginText.Text;
            string pass = parolText.Password;

            //Проверка наличия пользователя в базе
            Persona autPerson = null;
            using (RegistraciaEntities2 user = new RegistraciaEntities2())
            {
                autPerson = user.Persona.Where(b => b.LoginReg == loginUser && b.ParolReg == pass).FirstOrDefault();
            }

            if (autPerson != null)
            {
                MessageBox.Show("Вход выполнен успешно!");
                var testLogin = loginText.Text;


                //Переход в кабинет администратора
                if (autPerson.CodRol==1)
                {
                    Admin admin = new Admin(testLogin);
                    admin.Show();
                    Close();
                }
                //Переход в кабинет пользователя
                else if (autPerson.CodRol==2)
                {
                    User user = new User(testLogin);
                    user.Show();
                    Close();
                }
                //Переход в кабинет разработчика
                else
                {
                    Razrab razrab = new Razrab( testLogin);
                    razrab.Show();
                    Close();
                }
                
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }

        private void perehod_Click(object sender, RoutedEventArgs e)
        {
            //Переход на окно регистрации
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
