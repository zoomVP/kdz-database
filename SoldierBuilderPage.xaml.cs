using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace HSEmilitary
{
    /// <summary>
    /// Interaction logic for SoldierBuilderPage.xaml
    /// </summary>
    public partial class SoldierBuilderPage : Page
    {
        public SoldierBuilderPage()
        {
            InitializeComponent();

            List<uint> ages = new List<uint>();
            for (uint i = 16; i < 71; i++)
            {
                ages.Add(i);
            }
            ageComboBox.ItemsSource = ages;

            List<uint> eff = new List<uint>();
            for (uint i = 1; i < 11; i++)
            {
                eff.Add(i);
            }
            efficiencyComboBox.ItemsSource = eff;

            var ranks = System.IO.File.ReadAllLines("ranks.txt", Encoding.Default);
            rankComboBox.ItemsSource = ranks;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (nameTextBox.Text != "" && ageComboBox.SelectedItem != null && efficiencyComboBox.SelectedItem != null && rankComboBox.SelectedItem != null)
            {
                List<Soldier> soldiers = new List<Soldier>();

                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream("soldiers.dat", FileMode.OpenOrCreate))
                {
                    soldiers = (List<Soldier>)formatter.Deserialize(fs);
                }

                var soldier = new Soldier((uint)ageComboBox.SelectedItem, nameTextBox.Text, rankComboBox.SelectedItem.ToString(), (uint)efficiencyComboBox.SelectedItem);
                soldiers.Add(soldier);

                using (FileStream fs = new FileStream("soldiers.dat", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, soldiers);
                }

                MessageBox.Show($"Добавлен военный: {soldier.Name}.");
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
            }
        }

        private void bookButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BookPage());
        }
    }
}
