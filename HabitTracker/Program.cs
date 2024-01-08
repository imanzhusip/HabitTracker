using System;

class Program
{
    static void Main()
    {
        HabitBLL tracker = new HabitBLL();

        while (true)
        {
            Console.WriteLine("1. Добавить привычку");
            Console.WriteLine("2. Отметить выполнение привычки");
            Console.WriteLine("3. Просмотреть статистику");
            Console.WriteLine("4. Удалить все данные о привычках");
            Console.WriteLine("0. Выход");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Введите название привычки: ");
                    string habitName = Console.ReadLine();
                    tracker.AddHabit(habitName, DateTime.Now);
                    break;
                case 2:
                    Console.Write("Введите название выполненной привычки: ");
                    habitName = Console.ReadLine();
                    tracker.MarkCompleted(habitName);
                    break;
                case 3:
                    tracker.DisplayHabits();
                    break;
                case 4:
                    tracker.ClearData();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                    break;
            }
        }
    }
}
