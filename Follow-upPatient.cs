using System;
namespace ClinicTriageSystem
{
    sealed class FollowUpPatient : Patient
    {
        public FollowUpPatient(string id, string name, int age) : base(id, name, age)
        {
        }
        public override bool IsUrgent
        {
            get { return false; }
        }
        public override string Category
        {
            get { return "Follow-Up"; }
        }
    }
}
