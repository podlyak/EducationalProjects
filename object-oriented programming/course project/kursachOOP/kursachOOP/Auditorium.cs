using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursachOOP
{
    class Auditorium : IEquatable<Auditorium>
    {
        public string Num { get; set; }
        public int Cap { get; set; }

        public Auditorium(string num, int cap)
        {
            Num = num;
            Cap = cap;
        }

        public Auditorium() { }

        public override bool Equals(object obj)
        {
            return Equals(obj as Auditorium);
        }

        public bool Equals(Auditorium other)
        {
            return other != null &&
                   Num == other.Num;
        }

        public override int GetHashCode()
        {
            return 159832395 + EqualityComparer<string>.Default.GetHashCode(Num);
        }
    }
}
