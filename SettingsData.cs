using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xceed.Wpf.DataGrid;

namespace BergsonMatchesUpgraded
{

    /// <summary>
    /// Класс, выполняющий работу с изначальными данными программы
    /// </summary>

    sealed class SettingsData
    {

        private int start_value; // начальное количество спичек
        private int max_value;  // максимальное количество спичек, которое можно взять за ход
        private int level; // уровень сложности игры (амстерство компьютера)
                           // 1 - легкий уровень, 2 - сложный уровень

        public SettingsData()
        {
            this.start_value = 15;
            this.max_value = 3;
            this.level = 1;
            this.InitData();
        }

        // Инициализация начальных данных для игры
        public void InitData()
        {
            // считывание нужных данных из файла с помощью лямбда-функции
            int[] data_array = System.IO.File.ReadAllText(@"../../settings.txt").Split(' ').Select(n => int.Parse(n)).ToArray();
            this.start_value = data_array[0];
            if (this.start_value > 60)
                this.start_value = 60;
            this.max_value = data_array[1];
            if (this.max_value > 9)
                this.max_value = 9;
            this.level = data_array[2];
            if ((this.level != 1) && (this.level != 2))
                this.level = 2;
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

    }
}
