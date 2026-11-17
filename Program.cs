
using System;

namespace ClinicTriageSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Clinic clinic = new Clinic();

            clinic.CheckIn(new RegularPatient("P105", "Ali Khan", 34));
            clinic.CheckIn(new RegularPatient("P102", "Fatima Noor", 70));
            clinic.CheckIn(new EmergencyPatient("P110", "Usman Tariq", 28, 3));
            clinic.CheckIn(new FollowUpPatient("P101", "Zara Ahmed", 45));
            clinic.CheckIn(new EmergencyPatient("P108", "Hamza Ali", 52, 5));
            clinic.CheckIn(new RegularPatient("P104", "Ayesha Malik", 30));
            clinic.CheckIn(new FollowUpPatient("P107", "Bilal Shah", 81));
            try
            {
                clinic.CheckIn(new RegularPatient("P105", "Duplicate Patient", 30));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            try
            {
                EmergencyPatient invalidPatient =
                    new EmergencyPatient("P111", "Test", 40, 7);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            clinic.PrintQueues();
            clinic.UndoLastCheckIn();
            clinic.CheckIn(new RegularPatient("P103", "Sana Javed", 66));
            clinic.PrintQueues();
            for (int i = 0; i < 6; i++)
            {
                clinic.TreatNext();
            }

            clinic.UndoLastCheckIn();
            clinic.PrintTreatedLog();
            clinic.PrintRegistry();
            clinic.FindPatient("P104");
            clinic.FindPatient("P999");
            clinic.PrintWaitingPatient();
        }
    }
}
