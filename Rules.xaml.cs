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
    /// Логика взаимодействия для Rules.xaml (окно с правилами игры)
    /// </summary>
    
    public partial class Rules : Window
    {

        public Rules()
        {
            InitializeComponent();
        }

        // OK click
        private void ButtonRulesOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // закрытие окна и его последующее уничтожение
        }

        // Обработка события нажатия кнопки, когда это окно активно
        private void RulesWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Enter) || (e.Key == Key.Escape)) // Enter или Escape
                this.ButtonRulesOk_Click(sender, e);
        }

    }
}
