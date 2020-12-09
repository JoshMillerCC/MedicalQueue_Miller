using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalQueue_Miller
{
    class ERQueue
    {
        Patient[] patientQ = new Patient[13];

        public int Enqueue(string name, int priority)
        {
            Patient temp = new Patient(name, priority);
            int total = 0;
            if(patientQ[patientQ.Length-1] != null)
            {
                return -1;
            }
            for(int i = 0; i < patientQ.Length; i++)
            {
                if(patientQ[i] == null)
                { 
                    patientQ[i] = temp;
                    total++;
                    break;
                } else
                {
                    total++;
                }
            }
            if(total <= 13)
            {
                return total;
            } else
            {
                return -1;
            }
        }

        public Patient Dequeue()
        {
            Patient temp = patientQ[0];
            if(temp == null)
            {
                return null;
            }
            for(int i = 0; i < patientQ.Length; i++)
            {
                if(patientQ[i] == null)
                {
                    break;
                }
                if(i == 13)
                {
                    patientQ[i] = null;
                }
                patientQ[i] = patientQ[i + 1];
            }
            return temp;
        }

        override public string ToString()
        {
            string listOfPatients = "";
            if(patientQ[0] == null)
            {
                return "There is nobody in the queue.\n";
            }
            foreach(Patient patients in patientQ)
            {
                if(patients == null)
                {
                    break;
                }
                listOfPatients = listOfPatients + "Name: " + patients.getName() + ", Priority: " + patients.getPriority() + "\n";
            }
            return listOfPatients;
        }
    }
}
