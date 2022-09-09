using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursachOOP
{
    class Schedule : IEquatable<Schedule>
    {
        public int NumGroup { get; set; }
        public string Day { get; set; }
        public int NumPair { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Discipline { get; set; }
        public string TypeDiscp { get; set; }
        public string NumAuditorium { get; set; }
        public string Educator { get; set; }

        public Schedule(int numGroup, string day, int numPair, string discipline, string typeDiscp, string numAuditorium, string educator)
        {
            NumGroup = numGroup;
            Day = day;
            NumPair = numPair;
            SetTime();
            Discipline = discipline;
            TypeDiscp = typeDiscp;
            NumAuditorium = numAuditorium;
            Educator = educator;
        }

        public Schedule() { }

        public void SetTime()
        {
            if (NumPair == 1)
            {
                StartTime = "9:30";
                EndTime = "11:00";
            }
            else if (NumPair == 2)
            {
                StartTime = "11:10";
                EndTime = "12:40";
            }
            else if (NumPair == 3)
            {
                StartTime = "13:00";
                EndTime = "14:30";
            }
            else if (NumPair == 4)
            {
                StartTime = "15:00";
                EndTime = "16:30";
            }
            else if (NumPair == 5)
            {
                StartTime = "16:40";
                EndTime = "18:10";
            }
            else if (NumPair == 6)
            {
                StartTime = "18:30";
                EndTime = "20:00";
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Schedule);
        }

        public bool Equals(Schedule other)
        {
            return other != null &&
                   NumGroup == other.NumGroup &&
                   Day == other.Day &&
                   NumPair == other.NumPair &&
                   Discipline == other.Discipline &&
                   TypeDiscp == other.TypeDiscp &&
                   NumAuditorium == other.NumAuditorium &&
                   Educator == other.Educator;
        }

        public override int GetHashCode()
        {
            int hashCode = -2112368879;
            hashCode = hashCode * -1521134295 + NumGroup.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Day);
            hashCode = hashCode * -1521134295 + NumPair.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Discipline);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TypeDiscp);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NumAuditorium);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Educator);
            return hashCode;
        }
    }
}
