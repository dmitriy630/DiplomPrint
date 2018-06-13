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

namespace DiplomPrint
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Properties.Settings.Default.ChairpersonStateCommission = txtChairpersonStateCommission.Text;
                Properties.Settings.Default.Leader = txtLeader.Text;
                Properties.Settings.Default.Secretary = txtSecretary.Text;
                Properties.Settings.Default.Secession = txtSecession.Text;
                Properties.Settings.Default.Save();
                System.Windows.Forms.MessageBox.Show("Настройки сохранены.");
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("При сохранении настроек произошел сбой, обратитесь к системному администратору.");
            }
            finally
            {
                this.Close();
            }
        }
    }
}
