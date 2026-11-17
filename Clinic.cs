
using System;
namespace ClinicTriageSystem
{
    class Clinic
    {
        private LinkedQueue<Patient> urgentQueue;
        private LinkedQueue<Patient> normalQueue;
        private PatientRegistry registry;
        private StackHistory<string> history;
        private TreatedLog treatedLog;
        public Clinic()
        {
            urgentQueue = new LinkedQueue<Patient>();
            normalQueue = new LinkedQueue<Patient>();
            registry = new PatientRegistry();
            history = new StackHistory<string>();
            treatedLog = new TreatedLog();
        }
        public void CheckIn(Patient p)
        {
            registry.Add(p);

            if (p.IsUrgent)
            {
                urgentQueue.Enqueue(p);
            }
            else
            {
                normalQueue.Enqueue(p);
            }
            history.Push(p.Id);
            Console.WriteLine($"Checked in {p.Describe()}");
        }
        public void UndoLastCheckIn()
        {
            if (history.IsEmpty)
            {
                Console.WriteLine("There is nothing to undo");
                return;
            }
            string id = history.Pop();
            Patient? patient = registry.Find(id); 

            if (patient == null) 
            {
                return;
            }
            bool removed = urgentQueue.Remove(id);
            if (!removed)
            {
                removed = normalQueue.Remove(id);
            }
            if (removed)
            {
                Console.WriteLine($"Undo: removed {patient.Id} {patient.Name} from the queue"); 
            }
            else
            {
                Console.WriteLine($"Undo: cannot undo check-in of {id}, patient already treated");
            }
        }
        public void TreatNext()
        {
            Patient patient;

            if (!urgentQueue.IsEmpty)
            {
                patient = urgentQueue.Dequeue();
            }
            else if (!normalQueue.IsEmpty)
            {
                patient = normalQueue.Dequeue();
            }
            else
            {
                Console.WriteLine("No patients waiting.");
                return;
            }

            treatedLog.Add(patient);

            Console.WriteLine($"Treated {patient.Id} {patient.Name}");
        }
        public void PrintQueues()
        {
            Console.WriteLine($"=== Urgent queue ({urgentQueue.Count}) ===");
            urgentQueue.Print();

            Console.WriteLine($"=== Normal queue ({normalQueue.Count}) ===");
            normalQueue.Print();
        }
        public void PrintTreatedLog()
        {
            Console.WriteLine("Last 5 patients treated (oldest first)");
            treatedLog.PrintOldestToNewest();
        }
        public void PrintRegistry()
        {
            Console.WriteLine("Registry (check-in order)");

            registry.Print();

            Console.WriteLine($"Registered: {registry.Count} | Capacity: {registry.Capacity}");
        }
        public void FindPatient(string id)
        {
            Patient? patient = registry.Find(id);

            if (patient is null)
            {
                Console.WriteLine($"Find {id}: not found");
            }
            else
            {
                Console.WriteLine($"Find {id}: {patient.Name} ({patient.Category})");
            }
        }
        public void PrintWaitingPatient()
        {
            int totalWaiting = urgentQueue.Count + normalQueue.Count;

            Console.WriteLine($"Still waiting: {totalWaiting}");

            urgentQueue.Print();
            normalQueue.Print();
        }
    }
}