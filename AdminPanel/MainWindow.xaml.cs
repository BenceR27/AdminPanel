using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;

namespace AdminPanel
{
    public partial class MainWindow : Window
    {
        private readonly DatabaseStatements db = new DatabaseStatements();

        public MainWindow()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            var user = felhasznalonev.Text.Trim();
            var pass = Pass.Password;
            var again = PassAgain.Password;

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
                return;

            if (pass != again)
            {
                MessageBox.Show("A jelszavak nem egyeznek.");
                return;
            }

            if (db.RegisterUser(user, pass))
                MessageBox.Show("Sikeres regisztráció!");
            else
                MessageBox.Show("A felhasználónév már létezik vagy hiba történt.");

            felhasznalonev.Clear();
            Pass.Clear();
            PassAgain.Clear();
        }
        private void LoadUsers()
        {
            Lista.ItemsSource = db.GetAllUsers().DefaultView;
        }
    }
}
