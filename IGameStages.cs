using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BergsonMatchesUpgraded
{
    interface IGameStages
    {

        // Подготовка игры
        void PrepareGame();

        // Пауза (во время хода компьютера)
        void Pause();

        // Окончание игры
        void EndRoundGame();

        // Победа игрока (пользователя) и соответственно проигрыш компьютера (показ соответствующего окна)
        void WinGameWindow();

        // Проигрыш игрока (пользователя) и соответственно победа компьютера (показ соответствующего окна)
        void LoseGameWindow();

    }
}
