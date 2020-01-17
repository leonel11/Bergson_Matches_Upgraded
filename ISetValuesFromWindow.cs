using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BergsonMatchesUpgraded
{
    interface ISetValuesFromWindow
    {

        // Установка начальных числовых значений в некоторые элементы окна
        void SetFaceValuesFromWindowElements();

        // Установка радиокнопок в нужное состояние в зависимости от загруженного уровня сложности игры
        void SetLevelToRadioButton();

        // Установка максимально возможного выбранного значения спичек в специальной области в окне программы
        void SetMaximumValueConfirm();

    }
}
