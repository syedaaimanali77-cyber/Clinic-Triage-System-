using System;
namespace ClinicTriageSystem
{
    class TreatedLog
    {
        private Patient[] patient;
        private int start = 0;
        private int count = 0;

        public TreatedLog()
        {
            patient = new Patient[5];
        }

        public int Count
        {
            get { return count; }
        }

        public bool IsFull
        {
            get { return count == patient.Length; }
        }

        public void Add(Patient p)
        {
            if (IsFull)
            {
                patient[start] = p;
                start = (start + 1) % patient.Length;
            }
            else
            {
                int index = (start + count) % patient.Length;
                patient[index] = p;
                count++;
            }
        }
            public void PrintOldestToNewest()
            {
                if (count == 0)
                {
                Console.WriteLine("No patients treated.");
                        return;
                }
                for (int i =0; i<count; i++)
                {
                    int index = (start + i) % patient.Length;

                    Console.WriteLine($"{patient[index].Id}{patient[index].Name}");
                }
            }
        }

   }
