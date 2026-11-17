using System;
namespace ClinicTriageSystem
{
    abstract class Patient : IQueueItem
    {
        public string Id { get; }
        public string Name { get; }
        public int Age { get; } 

        //Abstract properties and there child clases must provide implementation
        public abstract bool IsUrgent { get; }
        public abstract string Category { get; }

        public virtual string Describe()
        {
            string urgency;

            if (IsUrgent)
            {
                urgency = "emergency";
            }
            else
            {
                urgency = "normal";
            }
            // $ this symbol tell C# to insrt values into string this is
            // called string interpolation
            return $"{Id} {Name} ({Category},{urgency})"; 
        }

        public Patient(string id, string name, int age)
        {
            if (id == null || id == "")
            {
                throw new ArgumentException("Provide ID");
            }
            if (name == null || name == "")
            {
                throw new ArgumentException("Provide Name");
            }
            if (age < 0 || age > 120)
            {
                throw new ArgumentOutOfRangeException("The Patient must be between 0 to 120 years");
            }
            Id = id;
            Name = name;
            Age = age;
        }
    }
}