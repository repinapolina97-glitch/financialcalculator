using System;

namespace BudgetCalculator
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("============================================");
            Console.WriteLine("         КАЛЬКУЛЯТОР ДОХОДОВ И РАСХОДОВ     ");
            Console.WriteLine("============================================");
            Console.WriteLine();

            // Ввод данных с проверками
            double income = InputDouble("Введите ежемесячный доход (руб.): ");

            // Проверка: доход > 0
            if (income <= 0)
            {
                Console.WriteLine("Ошибка: Доход должен быть больше 0!");
                Console.WriteLine("\nНажмите Enter для выхода...");
                Console.ReadLine();
                return;
            }

            double expenses = InputDouble("Введите сумму обязательных ежемесячных расходов (руб.): ");

            // Проверка: расходы >= 0
            if (expenses < 0)
            {
                Console.WriteLine("Ошибка: Расходы не могут быть отрицательными!");
                Console.WriteLine("\nНажмите Enter для выхода...");
                Console.ReadLine();
                return;
            }

            int days = InputInt("Введите количество дней в текущем месяце: ");

            // Проверка: количество дней в допустимом диапазоне (28-31)
            if (days < 28 || days > 31)
            {
                Console.WriteLine("Ошибка: Количество дней в месяце должно быть от 28 до 31!");
                Console.WriteLine("\nНажмите Enter для выхода...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine();

            // Расчёты
            double netIncome = income - expenses;      // Чистый доход
            double dailyBudget = netIncome / days;     // Дневной бюджет
            double expensePercent = (expenses / income) * 100;  // Процент расходов

            // Проверка: если расходы > дохода
            if (expenses > income)
            {
                Console.WriteLine("Внимание! Ваши расходы превышают доходы!");
                Console.WriteLine();
            }
            else if (expenses == income)
            {
                Console.WriteLine("Внимание! Вы тратите ровно столько, сколько зарабатываете.");
                Console.WriteLine();
            }

            // Вывод результатов
            Console.WriteLine("============================================");
            Console.WriteLine("                 РЕЗУЛЬТАТЫ                 ");
            Console.WriteLine("============================================");
            Console.WriteLine($"Чистый доход: {netIncome:F2} руб.");
            Console.WriteLine($"Дневной бюджет: {dailyBudget:F2} руб.");
            Console.WriteLine($"Расходы составляют: {expensePercent:F1}% от дохода.");
            Console.WriteLine("============================================");

            // Дополнительные рекомендации
            Console.WriteLine();
            if (netIncome < 0)
            {
                Console.WriteLine("⚠️ Рекомендация: Пересмотрите свои расходы, чтобы избежать долгов.");
            }
            else if (netIncome < 5000)
            {
                Console.WriteLine("⚠️ Рекомендация: Попробуйте сократить расходы или увеличить доход.");
            }
            else
            {
                Console.WriteLine("✅ Отличный баланс! Продолжайте в том же духе.");
            }

            Console.WriteLine("\nНажмите Enter для выхода...");
            Console.ReadLine();
        }

        /// <summary>
        /// Безопасный ввод вещественного числа
        /// </summary>
        static double InputDouble(string prompt)
        {
            double value;
            Console.Write(prompt);
            while (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Ошибка! Введите число: ");
            }
            return value;
        }

        /// <summary>
        /// Безопасный ввод целого числа
        /// </summary>
        static int InputInt(string prompt)
        {
            int value;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Ошибка! Введите целое число: ");
            }
            return value;
        }
    }
}
