using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static HabitDAL;

public class HabitBLL
{
    private List<Habit> habits;

    public HabitBLL()
    {
        habits = new List<Habit>();
        LoadData(); // Загрузка данных при старте приложения
    }

    public void AddHabit(string name, DateTime startDate)
    {
        habits.Add(new Habit
        {
            Name = name,
            StartDate = startDate,
            CurrentStreak = 0,
            BestStreak = 0
        });
        SaveData();
    }

    public void MarkCompleted(string habitName)
    {
        var habit = habits.Find(h => h.Name.Equals(habitName, StringComparison.OrdinalIgnoreCase));

        if (habit != null)
        {
            if ((DateTime.Now - habit.StartDate).Days == habit.CurrentStreak)
            {
                habit.CurrentStreak++;
                habit.BestStreak = Math.Max(habit.BestStreak, habit.CurrentStreak);
            }
            else
            {
                habit.CurrentStreak = 1;
            }

            SaveData();
        }
        else
        {
            Console.WriteLine("Привычка не найдена.");
        }
    }

    public void DisplayHabits()
    {
        Console.WriteLine("Список привычек:");
        foreach (var habit in habits)
        {
            Console.WriteLine($"{habit.Name} - Текущая серия: {habit.CurrentStreak}, Рекордная серия: {habit.BestStreak}");
        }
    }

    public void ClearData()
    {
        habits.Clear();
        SaveData();
        Console.WriteLine("Все данные о привычках удалены.");
    }

    private void LoadData()
    {
        if (File.Exists("habits.txt"))
        {
            string[] lines = File.ReadAllLines("habits.txt");

            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 4)
                {
                    habits.Add(new Habit
                    {
                        Name = parts[0],
                        StartDate = DateTime.Parse(parts[1]),
                        CurrentStreak = int.Parse(parts[2]),
                        BestStreak = int.Parse(parts[3])
                    });
                }
            }
        }
    }

    private void SaveData()
    {
        using (StreamWriter writer = new StreamWriter("habits.txt"))
        {
            foreach (var habit in habits)
            {
                writer.WriteLine($"{habit.Name},{habit.StartDate},{habit.CurrentStreak},{habit.BestStreak}");
            }
        }
    }
}
