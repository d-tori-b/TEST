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
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        public Edit()
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
                Pol = Gender,
                Dolzhnost = Position,
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

        private void Vihod_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            //Получение данных
            string loginUser = loginText.Text;
            string pass = parolText.Password;
            string fio = imiaText.Text;
            string phone = telefonText.Text;
            string email = pochtaText.Text;
            string gender = polText.Text;
            string position = positionText.Text;
            int rol = Convert.ToInt32(rolText.Text);


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
                rolText.Clear();
            }
        }

        private void deleteion_Click(object sender, RoutedEventArgs e)
        {
            //Скрытие ненужных элементов
            //Надписи
            parolL.Visibility = Visibility.Hidden;
            fioL.Visibility = Visibility.Hidden;
            pochtaL.Visibility = Visibility.Hidden;
            telefonL.Visibility = Visibility.Hidden;
            polL.Visibility = Visibility.Hidden;
            dolzhnostL.Visibility = Visibility.Hidden;
            rolL.Visibility = Visibility.Hidden;

            //Поля
            parolText.Visibility = Visibility.Hidden;
            imiaText.Visibility = Visibility.Hidden;
            pochtaText.Visibility = Visibility.Hidden;
            telefonText.Visibility = Visibility.Hidden;
            polText.Visibility = Visibility.Hidden;
            positionText.Visibility = Visibility.Hidden;
            rolText.Visibility = Visibility.Hidden;
            rolExpl.Visibility = Visibility.Hidden;

            //Кнопки
            deleteion.Visibility = Visibility.Hidden;
            add.Visibility = Visibility.Hidden;

            //Открытие кнопок
            delete.Visibility = Visibility.Visible;
            addition.Visibility = Visibility.Visible;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            //Получение данных
            string loginUser = loginText.Text;

            //Удаление
            RegistraciaEntities2 registraciaEntities2 = new RegistraciaEntities2();
            Persona persona = registraciaEntities2.Persona.Where(b => b.LoginReg == loginUser).FirstOrDefault();
            registraciaEntities2.Persona.Remove(persona);
            Polzovatel polzovatel = registraciaEntities2.Polzovatel.Where(b => b.LoginVhod == loginUser).FirstOrDefault();
            registraciaEntities2.Polzovatel.Remove(polzovatel);
            registraciaEntities2.SaveChanges();

            MessageBox.Show("Удаление прошло успешно!");

            //Очистка поля
            loginText.Clear();
        }

        private void addition_Click(object sender, RoutedEventArgs e)
        {
            //Открытие элементов
            //Надписи
            parolL.Visibility = Visibility.Visible;
            fioL.Visibility = Visibility.Visible;
            pochtaL.Visibility = Visibility.Visible;
            telefonL.Visibility = Visibility.Visible;
            polL.Visibility = Visibility.Visible;
            dolzhnostL.Visibility = Visibility.Visible;
            rolL.Visibility = Visibility.Visible;

            //Поля
            parolText.Visibility = Visibility.Visible;
            imiaText.Visibility = Visibility.Visible;
            pochtaText.Visibility = Visibility.Visible;
            telefonText.Visibility = Visibility.Visible;
            polText.Visibility = Visibility.Visible;
            positionText.Visibility = Visibility.Visible;
            rolText.Visibility = Visibility.Visible;
            rolExpl.Visibility = Visibility.Visible;

            //Кнопки
            deleteion.Visibility = Visibility.Visible;
            add.Visibility = Visibility.Visible;

            //Скрытие кнопок
            delete.Visibility = Visibility.Hidden;
            addition.Visibility = Visibility.Hidden;
        }
    }
}
