namespace Apiapp
{
    public class Habits
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartHabits { get; set; }
        public int ProcentDone { get; set; }

        public Habits(int id, string name , string description , DateTime Start, int Procent) 
        { 
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.StartHabits = Start;
            this.ProcentDone = Procent;
        }
    }
}
