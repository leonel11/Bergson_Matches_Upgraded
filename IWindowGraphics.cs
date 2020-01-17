using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BergsonMatchesUpgraded
{
    interface IWindowGraphics
    {

        // Отрисовка одной спички в WrapPanel в окне
        void DrawMatch(bool fire);

        // Отрисовка всех спичек
        void PaintMatches(int amountTakenMatches);

        // Перерисовка окна игры
        void RedrawWindowGame(int amountTakenMatches);

    }
}
