using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BergsonMatchesUpgraded
{

    /// <summary>
    /// Класс, выполняющий логику процесса игры
    /// </summary>
    
    sealed class Game: IGame
    {

        private int matches; // количество оставшихся в игре спичек
        private int comp_matches; // количество спичек, взятых за последний ход компьютером
        private int user_matches; // количество спичек, взятых за последний ход игроком (пользователем)
        private int comp_level; // уровень сложности игры (мастерство компьютера): 
                                // 1 - легкий уровень, 2 - сложный уровень
        private int n; // максимальное количество спичек, которое можно взять за ход
        private bool is_сomp_сourse; // вспомогательная переменная, определяющая, кто на данный момент должен совершить ход в игре: 
                                     // true - если на данный момент ходить должен компьютер, false - пользователь (игрок)
        private string course_infoerror; // вспомогательная информация, содержащая текст ошибки или нарушения правил, в случае возникновения во время игры

        public Game()
        {
            this.matches = 15;
            this.user_matches = 1;
            this.comp_matches = 0;
            this.n = 3;
            this.comp_level = 1;
            this.is_сomp_сourse = false;
            this.course_infoerror = "";
        }

        public void InitDataGame(SettingsData settdata)
        {
            this.matches = settdata.StartValue;
            this.user_matches = 1;
            this.comp_matches = 0;
            this.n = settdata.MaxValue;
            this.comp_level = settdata.Level;
            this.is_сomp_сourse = false;
            this.course_infoerror = "";
        }

        public void SetGameSituation(int[] data_array)
        {
            this.matches = data_array[0];
            if (this.matches > 60)
                this.matches = 60;
            this.user_matches = data_array[1];
            if ((this.user_matches < 0) || (this.user_matches > this.matches))
                this.user_matches = 1;
            this.comp_matches = data_array[2];
            if ((this.comp_matches < 0) || (this.comp_matches > this.matches))
                this.comp_matches = 0;
            this.n = data_array[3];
            if (this.n > 9)
                this.n = 9;
            this.comp_level = data_array[4];
            if ((this.comp_level != 1) && (this.comp_level != 2))
                this.comp_level = 2;
            this.is_сomp_сourse = false;
            this.ClearCourseInfoError();
        }

        // Очистка специальной вспомогательной информации, содержащей текст ошибки или нарушения правил
        private void ClearCourseInfoError()
        {
            this.course_infoerror = "";
        }

        public bool CanMakeCourse(int possible_matches)
        {
            this.ClearCourseInfoError();
            if (this.IsGameOver())
                return false;
            if (possible_matches > this.n) // пользователь (игрок) пытается взять спичек больше, чем можно взять за ход
            {
                this.course_infoerror = "So many matches...";
                return false;
            }
            if (possible_matches < 0) // пользователь (игрок) пытается взять отрицательное число спичек
            {
                this.course_infoerror = "So few matches...";
                return false;
            }
            if (this.matches - possible_matches < 0) // пользователь (игрок) пытается взять спичек больше, чем осталось всего спичек в игре
            {
                this.course_infoerror = "Amount of matches can not be unpositive after your course!";
                return false;
            }
            return true;
        }

        public bool IsGameOver()
        {
            if ((this.matches == 0) || (this.matches == 1)) // условие окончания игры
                return true;
            else
                return false;
        } 

        public void UserCourse(int confirm_matches)
        {  
            this.matches -= confirm_matches;
            this.TransferCourse();
        }

        public void CompCourse()
        {
            this.CompStrategy();
            this.matches -= this.comp_matches;
            this.TransferCourse();
        }

        public void TransferCourse()
        {
            this.is_сomp_сourse = !(this.is_сomp_сourse);
        }

        public void CompStrategy()
        {
            int k;
            this.PreInitStrategyValue(out k);
            int rand_numb = 0; // случайное число, необходимо при ходе, если текущий игрок находится в проигрышной позиции
            this.GetRandomNumber(ref rand_numb);
            if (k == 0)
                k += (n + 1);
            //стратегия пошла
            if ((k == 1) || ((this.comp_level == 1) && (this.matches >= 2*this.n)))
            {
                if (n == 1)
                    this.comp_matches = 1;
                else
                {
                    this.comp_matches = rand_numb % (n - 1) + 1;
                    if (this.comp_matches >= this.matches)
                        this.comp_matches = this.matches - 1;
                }
            }
            else
                this.comp_matches = k - 1;
        }

        private void PreInitStrategyValue(out int k)
        {
            k = this.matches % (n + 1);
        }

        // Функция, возвращающая случайное число
        private void GetRandomNumber(ref int rand_numb)
        {
            Random random_number = new Random(); // определение специальной переменной для работы со случайными числами
            rand_numb = random_number.Next(1, this.n); // генерация случайного числа из нужного числового интервала
        }

        public bool IsUserWinGame()
        {
            if ((this.matches == 1) && this.is_сomp_сourse) // осталось спичек: 1, ходит компьютер
                return true;
            if ((this.matches == 1) && !this.is_сomp_сourse) // осталось спичек: 1, ходит игрок (пользователь)
                return false;
            if ((this.matches == 0) && this.is_сomp_сourse) // осталось спичек: 0, ходит компьютер
                return false;
            if ((this.matches == 0) && !this.is_сomp_сourse) // осталось спичек: 0, ходит игрок (пользователь)
                return true;
            return false;
        }

        public int Matches
        {
            get
            {
                return this.matches;
            }
            set
            {
                this.matches = value;
            }
        }

        public int CompMatches
        {
            get
            {
                return this.comp_matches;
            }
            set
            {
                this.comp_matches = value;
            }
        }

        public int UserMatches
        {
            get
            {
                return this.user_matches;
            }
            set
            {
                this.user_matches = value;
            }
        }

        public int CompLevel
        {
            get
            {
                return this.comp_level;
            }
            set
            {
                this.comp_level = value;
            }
        }

        public int N
        {
            get
            {
                return this.n;
            }
            set
            {
                this.n = value;
            }
        }

        public bool IsCompCourse
        {
            get
            {
                return this.is_сomp_сourse;
            }
            set
            {
                this.is_сomp_сourse = value;
            }
        }

        public string CourseInfoError
        {
            get
            {
                return this.course_infoerror;
            }
            set
            {
                this.course_infoerror = value;
            }
        }

    }
}
