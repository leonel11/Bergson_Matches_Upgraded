using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BergsonMatchesUpgraded
{

    /// <summary>
    /// Логика взаимодействия для About_program.xaml (окно "О программе")
    /// </summary>
    
    public partial class AboutProgram : Window
    {
        
        public AboutProgram()
        {
            InitializeComponent();
        }

        // OK click
        private void ButtonAboutOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // закрытие окна и его последующее уничтожение
        }

        // Обработка события нажатия кнопки, когда это окно активно
        private void AboutWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Enter) || (e.Key == Key.Escape)) // Enter или Escape
                this.ButtonAboutOk_Click(sender, e);
        }

    }
}
