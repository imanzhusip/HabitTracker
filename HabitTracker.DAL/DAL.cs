using System;

public class HabitDAL
{
    public class Habit
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public int CurrentStreak { get; set; }
        public int BestStreak { get; set; }
    }
}
