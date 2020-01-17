using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Xceed;
using Xceed.Wpf;
using Xceed.Wpf.Toolkit;
using System.Diagnostics;
using Cursors = System.Windows.Input.Cursors;
using MessageBox = System.Windows.Forms.MessageBox;

namespace BergsonMatchesUpgraded
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window, ISetValuesFromWindow, IWindowGraphics, IGameStages
    {
        private SettingsData startData; // изначальные данные
        private Game roundGame; // данные с состоянием игры

        public MainWindow()
        {
            InitializeComponent();
            startData = new SettingsData();
            roundGame = new Game();
            this.PrepareGame();
            mediaElementSounds.IsMuted = false;
        }

        public void PrepareGame()
        {
            startData.InitData(); // инициализация начальных данных настроек
            roundGame.InitDataGame(startData); // инициализация начальных данных для игры
            this.SetMaximumValueConfirm();
            IntegerUpDownInput.Value = 1;
            StatusGameTextBlock.Text = "Please, make your course";
            this.RedrawWindowGame(0);
        }

        // Закрытие приложения
        private void CloseApplication()
        {
            this.Close();
        }

        partial void UpdateLabels(); // Обновление содержимого меток окна после действия в приложении

        public void SetMaximumValueConfirm()
        {
            IntegerUpDownInput.Maximum = roundGame.N;
        }

        public void SetFaceValuesFromWindowElements()
        {
            return;
        }

        public void SetLevelToRadioButton()
        {
            return;
        }

        partial void UpdateLabels()
        {
            LabelFoe.Content = roundGame.CompMatches; // обновление информации о количестве спичек, взятых компьютером
            LabelDifficulty.Content = roundGame.CompLevel; // обновление информации о сложности игры
            LabelAmountMatches.Content = roundGame.Matches; // обновление информации о количестве спичек, взятых пользователем (игроком)
            this.UpdateLabelSound();
        }

        // File -> Exit
        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure, what you want to leave game?", "Abort game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
                this.CloseApplication();
        }

        // Help -> About
        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AboutProgram aboutProgram = new AboutProgram();
            aboutProgram.ShowDialog();
        }

        // File -> Settings
        private void SettingsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            bool need_message_box = !(roundGame.IsGameOver());
            Settings settingsWindow = new Settings(need_message_box);
            settingsWindow.ShowDialog();
        }

        // Help -> Rules
        private void RulesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Rules rulesWindow = new Rules();
            rulesWindow.ShowDialog();
        }

        public void DrawMatch(bool fire)
        {
            Image matchImage = new Image(); // Create the image element
            matchImage.Width = 16;
            matchImage.Height = 48;
            BitmapImage bi = new BitmapImage(); // Create source
            // BitmapImage.UriSource must be in a BeginInit/EndInit block
            bi.BeginInit();
            if (fire)
                bi.UriSource = new Uri("/fire.bmp", UriKind.Relative);
            else
                bi.UriSource = new Uri("/match.bmp", UriKind.Relative);
            bi.EndInit();
            matchImage.Source = bi; // Set the image source
            WrapPanelMatches.Children.Add(matchImage);
        }

        public void PaintMatches(int amountTakenMatches)
        {
            WrapPanelMatches.Children.Clear(); // очистка области рисования
            int amountMatches = roundGame.Matches;
            while (amountMatches != 0) // пока есть что отрисовывать
            {
                this.DrawMatch(false);
                amountMatches--;
            } 
            while (amountTakenMatches != 0) // отрисовка только что взятых спичек
            {
                this.DrawMatch(true);
                amountTakenMatches--;
            }
        }

        public void Pause()
        {
            this.Cursor = Cursors.Wait; // курсор-часики
            // искусственное течение времени, используется из-за того, что стандартная функция Sleep перекрывает поток отрисовки UI
            int i = -100000000;
            while (i < 100000000)
                i++;
            this.Cursor = Cursors.Hand; // курсор-рука
        }

        public void RedrawWindowGame(int amountTakenMatches)
        {
            this.PaintMatches(amountTakenMatches);
            this.UpdateLabels();
        }

        // Проигрывание звука, выступает в качестве звукового сигнала, указывающего пользователю (игроку) его очередь ходить
        private void PlaySoundCourse()
        {
            mediaElementSounds.LoadedBehavior = MediaState.Manual;
            mediaElementSounds.Source = new Uri(@"../../Match.wav", UriKind.Relative);
            mediaElementSounds.Play();
        }

        // Confirm click
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {          
            int user_amount = Convert.ToInt32(IntegerUpDownInput.Value);
            if (roundGame.CanMakeCourse(user_amount)) // если пользователь (игрок) может сделать ход с выбранным количеством спичек
            {
                roundGame.UserCourse(user_amount); // ход игрока (пользователя)
                this.RedrawWindowGame(roundGame.UserMatches);
                ButtonConfirm.IsEnabled = false; // временно кнопка Confirm становится недоступной
                this.Pause();
                this.RedrawWindowGame(0);
                if (roundGame.IsGameOver()) // проверка, окончена ли текущая партия игры 
                {
                    this.EndRoundGame();
                    this.RedrawWindowGame(0);
                }
                else // игра продолжается, компьютер может ходить
                {
                    StatusGameTextBlock.Text = "Computer course...";
                    roundGame.CompCourse(); // ход компьютера
                    this.RedrawWindowGame(roundGame.CompMatches);
                    this.Pause();
                    this.RedrawWindowGame(0);
                    StatusGameTextBlock.Text = "Please, make your course";
                    if (roundGame.IsGameOver()) // проверка, окончена ли текущая партия игры
                    {
                        this.EndRoundGame();
                    }
                    else
                        this.PlaySoundCourse(); // звуковой сигнал пользователю о том, что сейчас его очередь сделать ход в игре
                }
            }
            else // действия в случае, если с данным выбранным пользователем (игроком) количеством спичек сделать ход нвозможно
                this.ErrorButtonConfirm_Click();
            ButtonConfirm.IsEnabled = true; // кнопка Confirm снова становится доступной
            this.RedrawWindowGame(0);
        }

        // Обработка ошибок при несрабатывании нажатия кнопки Confirm
        private void ErrorButtonConfirm_Click()
        {
            if (roundGame.CourseInfoError != "") // если совершена ошибка при выборе пользователем количества спичек
                MessageBox.Show(roundGame.CourseInfoError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else // в случае если игра уже окончена, программа попросит начать новую игру
                MessageBox.Show("Please, begin new game...", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void EndRoundGame()
        {
            StatusGameTextBlock.Text = "Game over! Please, start new game";
            if (roundGame.IsUserWinGame()) // победил ил пользователь в этой партии
                this.WinGameWindow();
            else
                this.LoseGameWindow();
        }

        public void WinGameWindow()
        {
            mediaElementSounds.LoadedBehavior = MediaState.Manual;
            mediaElementSounds.Source = new Uri(@"../../Ta Da.mp3", UriKind.Relative);
            mediaElementSounds.Play();
            MessageBox.Show("Congratulations! You win!", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void LoseGameWindow()
        {
            SystemSounds.Asterisk.Play();
            MessageBox.Show("Sorry, you lose", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // File -> New game
        private void NewGameMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (!roundGame.IsGameOver()) // проверка, окончена ли текущая партия игры 
            {
                var result = MessageBox.Show("Current game is not over yet! Do you want to abort this game and start a new game?", "Abort game", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == System.Windows.Forms.DialogResult.No)
                    return;
            }
            this.PrepareGame();
            this.RedrawWindowGame(0);
        }

        // загрузка сохраненной игры
        private void LoadGameSituation(int[] data_array)
        {
            roundGame.SetGameSituation(data_array);
            this.SetMaximumValueConfirm();
            IntegerUpDownInput.Value = 1;
            this.RedrawWindowGame(0);
        }

        // File -> Load
        private void LoadGameMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Title = "Browse for a file to load";
            openFileDlg.Multiselect = false;
            openFileDlg.InitialDirectory = @"D:\Visual Studio Projects\BergsonMatchesUpgraded";
            openFileDlg.Filter = "Text documents (*.txt)|*.txt";
            openFileDlg.ShowDialog();
            string selectedFileName = openFileDlg.FileName;
            if (selectedFileName == @"D:\Visual Studio Projects\BergsonMatchesUpgraded\settings.txt")
            {
                MessageBox.Show("You can not load the game from the setting file", "Error! Illegal operation!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                openFileDlg.ShowDialog();
            }
            else
            {
                if (selectedFileName != "")
                    this.ReadDataFromFile(selectedFileName);
            } 
        }

        // считывание нужных данных из файла
        private void ReadDataFromFile(string selectedFileName)
        {
            int[] data_array = System.IO.File.ReadAllText(selectedFileName).Split(' ').Select(n => int.Parse(n)).ToArray(); // lambda-function
            this.LoadGameSituation(data_array);
        }

        // File -> Save
        private void SaveGameMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (roundGame.IsGameOver()) // нельзя сохранять уже законченную игру
            {
                MessageBox.Show("You can not save the complete game!", "Error! Illegal operation!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (roundGame.IsCompCourse) // нельзя сохранить игру во время хода компьютера
            {
                MessageBox.Show("You can not save the game during the course of the computer!", "Error! Illegal operation!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }   
            SaveFileDialog saveFileDlg = new SaveFileDialog();
            saveFileDlg.Title = "Browse for a file to save";
            saveFileDlg.AddExtension = true;
            saveFileDlg.InitialDirectory = @"D:\Visual Studio Projects\BergsonMatchesUpgraded";
            saveFileDlg.OverwritePrompt = true;
            saveFileDlg.FileName = "Saved_Game";
            saveFileDlg.Filter = "Text documents (*.txt)|*.txt"; // Filter files by extension 
            saveFileDlg.ShowDialog();
            string selectedFileName = saveFileDlg.FileName;
            if (selectedFileName == @"D:\Visual Studio Projects\BergsonMatchesUpgraded\settings.txt")
            {
                MessageBox.Show("You can not save the game in the setting file", "Error! Illegal operation!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                saveFileDlg.ShowDialog();
            }
            else
            {
                if (selectedFileName != "")
                    this.WriteDataToFile(selectedFileName);
            }            
        }

        // запись нужных данных в файл
        private void WriteDataToFile(string selectedFileName)
        {
            // формирование строки для записи в файл
            string[] arr = { Convert.ToString(roundGame.Matches) + " ", Convert.ToString(roundGame.UserMatches) + " ", Convert.ToString(roundGame.CompMatches) + " ", Convert.ToString(roundGame.N) + " ", Convert.ToString(roundGame.CompLevel) };
            File.WriteAllLines(selectedFileName, arr); // запись данных в файл
        }

        // обработка события нажатия кнопки (или комбинации клавиш), когда это окно активно
        private void AppWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Shift && e.Key == Key.N) // Shift + N
                this.NewGameMenuItem_Click(sender, e);
            if (Keyboard.Modifiers == ModifierKeys.Shift && e.Key == Key.T) // Shift + T
                this.SettingsMenuItem_Click(sender, e);
            if (Keyboard.Modifiers == ModifierKeys.Shift && e.Key == Key.R) // Shift + R
                this.RulesMenuItem_Click(sender, e);
            if (e.Key == Key.O) // O
                this.ButtonSounds_Click(sender, e);
            if (e.Key == Key.Escape) // Escape
                this.ExitMenuItem_Click(sender, e);
            if (e.Key == Key.Enter) // Enter
                this.ButtonConfirm_Click(sender, e);
            if ((e.Key == Key.W) || (e.Key == Key.Up) || (e.Key == Key.PageUp) || (e.Key == Key.P) || (e.Key == Key.I)) // W | UpArrow | PageUp | P | I
            {
                if (IntegerUpDownInput.Value < IntegerUpDownInput.Maximum)
                    IntegerUpDownInput.Value++;
            }
            if (Keyboard.Modifiers != ModifierKeys.Shift && /* не нажата клавиша Shift */
               ((e.Key == Key.S) || (e.Key == Key.Down) || (e.Key == Key.PageDown) || (e.Key == Key.M) || (e.Key == Key.D))) // S | DownArrow | PageDown | M | D
            {
                if (IntegerUpDownInput.Value > IntegerUpDownInput.Minimum)
                    IntegerUpDownInput.Value--;
            }  
            if (e.Key == Key.Home) // Home
                IntegerUpDownInput.Value = IntegerUpDownInput.Minimum;
            if (e.Key == Key.End) // End
                IntegerUpDownInput.Value = IntegerUpDownInput.Maximum;
            if (Keyboard.Modifiers == ModifierKeys.Shift && e.Key == Key.L) // Shift + L
                this.LoadGameMenuItem_Click(sender, e);
            if (Keyboard.Modifiers == ModifierKeys.Shift && e.Key == Key.S) // Shift + S
                this.SaveGameMenuItem_Click(sender, e);
        }

        // обработка нажатия кнопки, управляющая звуками в программе 
        // (смена картинки в кнопки и обновление информации о громкости дополнительных звуков программе для наглядности пользователю (игроку))
        private void ButtonSounds_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage bi = new BitmapImage();
            ImageSourceConverter converter = new ImageSourceConverter();
            // BitmapImage.UriSource must be in a BeginInit/EndInit block
            bi.BeginInit();
            if (mediaElementSounds.IsMuted) // установка нужной картинки в кнопку в зависимости от состояния проигрывания дпоплнительных звуков в программе
                bi.UriSource = new Uri(@"Sound2.ico", UriKind.RelativeOrAbsolute);
            else
                bi.UriSource = new Uri(@"Mute2.ico", UriKind.RelativeOrAbsolute);
            bi.EndInit();
            ImageSound.Source = bi;
            mediaElementSounds.IsMuted = !mediaElementSounds.IsMuted; // смена состояния проигрывания дополнительных звуков в программе
            this.UpdateLabels();
        }

        // функция, проверяющая доступно ли проигрывание дополнительных звуков в программе
        private void UpdateLabelSound()
        {
            if (mediaElementSounds.IsMuted)
                LabelSounds.Content = "Sound off";
            else
                LabelSounds.Content = "Sound on";
        }

    }
}
