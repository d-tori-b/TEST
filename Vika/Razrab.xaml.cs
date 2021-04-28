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
    /// Логика взаимодействия для Razrab.xaml
    /// </summary>
    public partial class Razrab : Window
    {
        public Razrab( string TestLogin)
        {
            InitializeComponent();

            //Вывод данных из таблицы
            RegistraciaEntities2 registraciaEntities = new RegistraciaEntities2();

            var Sravnenie = registraciaEntities.Persona.FirstOrDefault(p => p.LoginReg == TestLogin);
            if (Sravnenie!=null)
            {
                loginText.Content = Sravnenie.LoginReg;
                fioText.Text = Sravnenie.Imia;
                pochtaText.Content = Sravnenie.Pochta;
                telefonText.Content = Sravnenie.Telefon;
                polText.Content = Sravnenie.Pol;
                dolzhnostText.Content = Sravnenie.Dolzhnost;
            }
        }

        private void perehod_Click(object sender, RoutedEventArgs e)
        {
            //Переход на окно входа
            Vhod vhod = new Vhod();
            vhod.Show();
            Close();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            Edit edit = new Edit();
            edit.Show();
        }
    }
}
