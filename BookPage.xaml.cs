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
    /// Interaction logic for BookPage.xaml
    /// </summary>
    public partial class BookPage : Page
    {
        public BookPage()
        {
            InitializeComponent();

            List<Soldier> soldiers = new List<Soldier>();

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("soldiers.dat", FileMode.OpenOrCreate))
            {
                soldiers = (List<Soldier>)formatter.Deserialize(fs);
            }
            dataGrid.ItemsSource = soldiers;
        }
    }
}
