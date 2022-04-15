namespace WebApplication2.Entity
{
    public class Performance
    {
        public Performance(string category, string counter, string instance)
        {
            Category = category;
            Counter = counter;
            Instance = instance;
        }

        public string Category { get; set; }
        public string Counter { get; set; }
        public string Instance { get; set; }
    }
}