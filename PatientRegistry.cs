using System;
using System.Runtime.CompilerServices;
namespace ClinicTriageSystem
{
    class PatientRegistry
    {
        private Patient[] patient;
        private int count = 0;

        public PatientRegistry()
        {
            patient = new Patient[4];
        }
        public int Count
        {
            get { return count; }
        }
        public int Capacity
        {
            get { return patient.Length; }
        }

        public void Add(Patient p)
        {
            for (int i = 0; i < count; i++)
            {
                if (patient[i].Id == p.Id)
                {
                    throw new InvalidOperationException("Patient already exist");
                }
            }
            if (count == patient.Length)

            {
                Patient[] newPatient = new Patient[patient.Length * 2];

                for (int i = 0; i < count; i++)
                {
                    newPatient[i] = patient[i]; 
                }
                patient = newPatient;
            }
            patient[count] = p;
            count++;
        }

        public Patient? Find(string id)
        {
            for ( int i = 0; i < count; i++)
            {
                if (patient[i].Id == id)
                {
                    return patient[i];
                }
            }
            return null; 
        }
        public void Print()  
        {
            if (count == 0)
            {
                Console.WriteLine("No patients registered.");
                return; 
            }

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i + 1}. {patient[i].Id} {patient[i].Name}");
            }
        } 
    }
    }
