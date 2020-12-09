using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalQueue_Miller
{
    class Patient
    {
        private string name;
        private int priority;

        public Patient(string pName, int pPriority)
        {
            name = pName;
            priority = pPriority;
        }

        public string getName()
        {
            return name;
        }

        public int getPriority()
        {
            return priority;
        }
    }
}
