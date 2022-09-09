using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursachOOP
{
    class Curriculum : IEquatable<Curriculum>
    {
        public string Discipline { get; set; }
        public int Time { get; set; }
        public string TypeDiscp { get; set; }

        public Curriculum(string discipline, int time, string typeDiscp)
        {
            Discipline = discipline;
            Time = time;
            TypeDiscp = typeDiscp;
        }

        public Curriculum() { }

        public override bool Equals(object obj)
        {
            return Equals(obj as Curriculum);
        }

        public bool Equals(Curriculum other)
        {
            return other != null &&
                   Discipline == other.Discipline &&
                   TypeDiscp == other.TypeDiscp;
        }

        public override int GetHashCode()
        {
            int hashCode = 904361603;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Discipline);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TypeDiscp);
            return hashCode;
        }
    }
}
