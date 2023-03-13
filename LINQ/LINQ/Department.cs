using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Department
    {
        private string name;
        public string Name { get { return name;} set { name = value; } }

        private string reg;
        public string Reg { get { return reg;} set { reg = value; } }

        public Department(string name, string reg)
        {
            this.name = name;
            this.reg = reg;
        }
    }

    internal class Employ
    {
        private string name;
        public string Name { get { return name; } set { name = value; } }

        private string department;
        public string Department { get { return department; } set { department = value; } }

        public Employ(string name, string department)
        {
            this.name = name;
            this.department = department;
        }
    }
}
