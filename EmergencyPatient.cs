
using System;
namespace ClinicTriageSystem
{ 
class EmergencyPatient : Patient
{
    public int Severity { get; }

    public EmergencyPatient(string id, string name, int age, int severity) : base(id, name, age)
    {
        if (severity < 1 || severity > 5)
        {
            throw new ArgumentOutOfRangeException("Severity must be between 1 and 5");
        }
        Severity = severity;
    }
    public override bool IsUrgent
    {
        get { return true; }
    }
    public override string Category
    {
        get { return "Emergency"; }
    }
    public override string Describe()
    {
        return $"{Id} {Name} ({Category}, severity {Severity}, urgent)";
    }
}
    }
