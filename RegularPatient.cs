using System;
namespace ClinicTriageSystem
{
    class RegularPatient : Patient
    {
        public RegularPatient(string id, string name, int age) : base(id, name, age)
        {

        }

        public override bool IsUrgent
        {
            get { return Age >= 65; }
        }
        public override string Category
        {
            get { return "Regular"; }
        }
    }
}
    
