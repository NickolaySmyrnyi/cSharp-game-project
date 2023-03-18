using System;
using System.Collections.Generic;
using System.Text;

namespace Ulearn_project
{
    static class MoneyModel
    {
        static public int Money { get; set; }
        static public int Income { get; set; }

        public const int fixedExpenses = 1000;

        static public void AddIncome(int money)
        {
            Income += money;
            AddMoney(money);
        }

        static public void AddMoney(int money)
        {
            Money += money;
            MoneyChanged();
        }

        static public event Action MoneyChanged;
    }
}
