using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursachOOP
{
    class Educator : IEquatable<Educator>
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public int NumDep { get; set; }
        public int Time { get; set; }

        public Educator(string name, string position, int numDep, int time)
        {
            Name = name;
            Position = position;
            NumDep = numDep;
            Time = time;
        }

        public Educator() { }

        public void Workload(int time)
        {
            Time -= time;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Educator);
        }

        public bool Equals(Educator other)
        {
            return other != null &&
                   Name == other.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}
