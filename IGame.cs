using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BergsonMatchesUpgraded
{
    interface IGame
    {

        // Инициализация начальных данных для игры
        void InitDataGame(SettingsData settdata);

        // Установка (восстановление) необходимой игровой ситуации (используется в случае загрузки сохранённой ранее игры)
        void SetGameSituation(int[] data_array);

        // Функция, проверяющая может ли пользователь (игрок) сделать ход с выбранным количеством спичек: true - может, false - не может
        bool CanMakeCourse(int possible_matches);

        // Ход игрока (пользователя)
        void UserCourse(int confirm_matches);

        // Функция, определяющая победил ли пользователь (игрок) в игре, в зависимости от числа оставшихся в игре спичек и очерёдности хода
        // true - победил пользователь (игрок), false - пользователь (игрок) проиграл,  победил компьютер
        bool IsUserWinGame();

        // Ход компьютера
        void CompCourse();

        // Стратегия компьютера (определяет количество взятых компьютером спичек в зависимости от сложности игры)
        // суть её заключается в оставлении сопернику количества спичек с остатком 1 при делении на n+1
        void CompStrategy();

        // Передача хода
        void TransferCourse();

        // Функция, проверяющая окончена ли сейчас игра или нет: true - окончена, false - не окончена
        bool IsGameOver();

    }
}
