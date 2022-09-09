using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursachOOP
{
    class Group : IEquatable<Group>
    {
        public int Num { get; set; }
        public string Spec { get; set; }
        public int CountStud { get; set; }

        public Group(int num, string spec, int countStud)
        {
            Num = num;
            Spec = spec;
            CountStud = countStud;
        }

        public Group() {}

        public override bool Equals(object obj)
        {
            return Equals(obj as Group);
        }

        public bool Equals(Group other)
        {
            return other != null &&
                   Num == other.Num;
        }

        public override int GetHashCode()
        {
            return 159832395 + Num.GetHashCode();
        }
    }
}
