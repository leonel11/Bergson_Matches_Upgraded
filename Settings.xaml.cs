using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Xceed;
using Xceed.Wpf;
using Xceed.Wpf.DataGrid;
using Xceed.Wpf.Toolkit;
using MessageBox = System.Windows.Forms.MessageBox;

namespace BergsonMatchesUpgraded
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window, ISetValuesFromWindow
    {

        private int start_value; // начальное количество спичек
        private int max_value; // макисмальное количество спичек, которое можно взять за ход
        private int level; // уровень сложности игры
        private bool needAuxMessageBox; // вспомогательная булева переменная:
        // true - пользователю должна показываться вспомогательная информация при определённых действиях над настройками игры
        // false - пользователю не будет показываться вспомогательная информация при определённых действиях над настройками игры

        public Settings()
        {
            this.start_value = 15;
            this.max_value = 3;
            this.level = 1;
            this.needAuxMessageBox = true;
            InitializeComponent();
        }

        // Дополнительный конструктор с параметром
        public Settings(bool need_message_box)
        {
            InitializeComponent();
            // считывание нужных данных из файла с помощью лямбда-функции
            this.ReadDataFromFile();
            this.needAuxMessageBox = need_message_box;
        }

        // Инициализация необходимых начальных числовых значений
        private void InitData(int[] data_array)
        {
            this.start_value = data_array[0];
            if (this.start_value > 60)
                this.start_value = 60;
            this.max_value = data_array[1];
            if (this.max_value > 9)
                this.max_value = 9;
            this.level = data_array[2];
            if ((this.level != 1) && (this.level != 2))
                this.level = 2;
            this.SetFaceValuesFromWindowElements();
        }

        public void SetFaceValuesFromWindowElements()
        {
            IntegerUpDownInit.Value = this.start_value;
            IntegerUpDownMax.Value = this.max_value;
            this.SetLevelToRadioButton();
        }

        public void SetLevelToRadioButton()
        {
            if (this.level == 1)
            {
                RadioButtonEasy.IsChecked = true;
                RadioButtonHard.IsChecked = false;
            }
            else
            {
                RadioButtonEasy.IsChecked = false;
                RadioButtonHard.IsChecked = true;
            }
        }

        public void SetMaximumValueConfirm()
        {
            return;
        }

        // Запись данных в файл
        private void RecordDataToFile()
        {
            this.start_value = Convert.ToInt32(IntegerUpDownInit.Value);
            this.max_value = Convert.ToInt32(IntegerUpDownMax.Value);
            this.WriteDataToFile();
        }

        // считывание нужных данных из файла
        private void ReadDataFromFile()
        {
            int[] data_array = System.IO.File.ReadAllText(@"../../settings.txt").Split(' ').Select(n => int.Parse(n)).ToArray(); // lambda-function
            this.InitData(data_array);
        }

        // запись нужных данных в файл
        private void WriteDataToFile()
        {
            // формирование строки для записи в файл
            string[] fileinfo = { Convert.ToString(start_value) + " ", Convert.ToString(max_value) + " ", Convert.ToString(level) };
            File.WriteAllLines(@"../../settings.txt", fileinfo); // запись данных в файл
        }

        // OK click
        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            this.RecordDataToFile();
            if (this.needAuxMessageBox)
                MessageBox.Show("Settings of the game are changed! Changes will take effect in the new game only!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Close();
        }

        // Cancel click
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            if (this.needAuxMessageBox)
            {
                var result = MessageBox.Show("Modified game settings are not confirmed! Continue?", "Close settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
                this.Close();
        }

        private void RadioButtonEasy_Checked(object sender, RoutedEventArgs e)
        {
            level = 1;
        }

        private void RadioButtonHard_Checked(object sender, RoutedEventArgs e)
        {
            level = 2;
        }

        // обработка события нажатия кнопки, когда это окно активно
        private void SettingsWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape) // Escape
                this.ButtonCancel_Click(sender, e);
            if (e.Key == Key.Enter) // Enter
                this.ButtonOK_Click(sender, e);
        }

        public int StartValue
        {
            get
            {
                return this.start_value;
            }
            set
            {
                this.start_value = value;
            }
        }

        public int MaxValue
        {
            get
            {
                return this.max_value;
            }
            set
            {
                this.max_value = value;
            }
        }

        public int Level
        {
            get
            {
                return this.level;
            }
            set
            {
                this.level = value;
            }
        }

        public bool NeedAuxMessageBox
        {
            get
            {
                return this.needAuxMessageBox;
            }
            set
            {
                this.needAuxMessageBox = value;
            }
        }

    }
}
