using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursachOOP
{
    class User
    {
        public List<Group> GroupsVector = new List<Group>();
        public List<Educator> EducatorsVector = new List<Educator>();
        public List<Auditorium> AuditoriumsVector = new List<Auditorium>();
        public List<Curriculum> CurriculumsVector = new List<Curriculum>();
        public List<Schedule> ScheduleVector = new List<Schedule>();

        public User() {}

        public bool AddInSchedule(Schedule tempSchedule, bool flag)
        {
            if (ScheduleVector.Count() != 0)
            {
                if (!GroupHaveTime(tempSchedule, flag))
                    return false;
                else if (!AuditoriumFull(tempSchedule, flag))
                    return false;
                else if (!EducatorHavePair(tempSchedule, flag))
                    return false;
                else if (!EducatorHaveTime(tempSchedule, flag))
                    return false;
                else if (!Lecture(tempSchedule, flag))
                    return false;
                else if (!HaveLection(tempSchedule, flag))
                    return false;
                else
                {
                    EducatorWorkloadLower(tempSchedule);
                    ScheduleVector.Add(tempSchedule);
                    return true;
                }
            }
            else
            {
                EducatorWorkloadLower(tempSchedule);
                ScheduleVector.Add(tempSchedule);
                return true;
            }
        }

        private bool GroupHaveTime(Schedule schedule, bool flag)
        {
            foreach (Schedule tmpSchedule in ScheduleVector)
            {
                if (tmpSchedule.NumGroup == schedule.NumGroup && tmpSchedule.Day == schedule.Day && tmpSchedule.NumPair == schedule.NumPair)
                {
                    if (flag == true)
                    {
                        MessageBox.Show("У данной группы уже есть занятие в это время!");
                    }
                    return false;
                }
            }
            return true;
        }

        private bool AuditoriumFull(Schedule schedule, bool flag)
        {
            if (schedule.TypeDiscp == "Л")
            {
                foreach (Schedule tmpSchedule in ScheduleVector)
                {
                    if (tmpSchedule.Day == schedule.Day && tmpSchedule.NumPair == schedule.NumPair && tmpSchedule.NumAuditorium == schedule.NumAuditorium)
                    {
                        if (tmpSchedule.Discipline == schedule.Discipline)
                        {
                            foreach (Group tmpGroup in GroupsVector)
                            {
                                if (tmpGroup.Num == schedule.NumGroup)
                                {
                                    foreach (Auditorium tmpAuditorium in AuditoriumsVector)
                                    {
                                        if (tmpAuditorium.Num == schedule.NumAuditorium)
                                        {
                                            if (tmpGroup.CountStud > tmpAuditorium.Cap)
                                            {
                                                if (flag == true)
                                                {
                                                    MessageBox.Show("К сожалению, аудитория не может поместить столько людей!");
                                                }
                                                return false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (flag == true)
                            {
                                MessageBox.Show("В данной аудитории уже проводится занятие по другой дисциплине!");
                            }
                            return false;
                        }
                    }
                }
            }
            else
            {
                foreach (Schedule tmpSchedule in ScheduleVector)
                {
                    if (tmpSchedule.Day == schedule.Day && tmpSchedule.NumPair == schedule.NumPair && tmpSchedule.NumAuditorium == schedule.NumAuditorium)
                    {
                        if (flag == true)
                        {
                            MessageBox.Show("В данной аудитории уже проводится занятие!");
                        }
                        return false;
                    }
                }
            }
            foreach (Group tmpGroup in GroupsVector)
            {
                if (tmpGroup.Num == schedule.NumGroup)
                {
                    foreach (Auditorium tmpAuditorium in AuditoriumsVector)
                    {
                        if (tmpAuditorium.Num == schedule.NumAuditorium)
                        {
                            if (tmpGroup.CountStud > tmpAuditorium.Cap)
                            {
                                if (flag == true)
                                {
                                    MessageBox.Show("Данная аудитория слишком маленькая!");
                                }
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private bool EducatorHavePair(Schedule schedule, bool flag)
        {
            foreach (Schedule tmpSchedule in ScheduleVector)
            {
                if (tmpSchedule.Day == schedule.Day && tmpSchedule.NumPair == schedule.NumPair && tmpSchedule.Educator == schedule.Educator)
                {
                    if (tmpSchedule.Discipline == schedule.Discipline && schedule.TypeDiscp == "Л")
                    {
                        return true;
                    }
                    else
                    {
                        if (flag == true)
                        {
                            MessageBox.Show("Преподаватель занят в это время!");
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        private bool EducatorHaveTime(Schedule schedule, bool flag)
        {
            foreach (Schedule tmpSchedule in ScheduleVector)
            {
                if (tmpSchedule.Discipline == schedule.Discipline && tmpSchedule.TypeDiscp == schedule.TypeDiscp && schedule.TypeDiscp == "Л")
                    return true;
            }

            foreach (Educator tmpEducator in EducatorsVector)
            {
                if (tmpEducator.Name == schedule.Educator)
                {
                    foreach (Curriculum tmpCurriculum in CurriculumsVector)
                    {
                        if (tmpCurriculum.Discipline == schedule.Discipline && tmpCurriculum.TypeDiscp == schedule.TypeDiscp )
                        {
                            if ((tmpCurriculum.Time == 68) && ((tmpEducator.Time - tmpCurriculum.Time / 2) < 0))
                            {
                                if (flag == true)
                                {
                                    MessageBox.Show("Нагрузка преподавателя будет превышена!");
                                }
                                return false;
                            }
                            else if ((tmpCurriculum.Time == 34) && (tmpEducator.Time - tmpCurriculum.Time) < 0)
                            {
                                if (flag == true)
                                {
                                    MessageBox.Show("Нагрузка преподавателя будет превышена!");
                                }
                                return false;
                            }
                            else
                                return true;
                        }
                    }
                }
            }
            return true;
        }

        private bool Lecture(Schedule schedule, bool flag)
        {
            if (schedule.TypeDiscp == "Л")
            {
                foreach (Schedule tmpSchedule in ScheduleVector)
                {
                    if (tmpSchedule.Discipline == schedule.Discipline && tmpSchedule.TypeDiscp == schedule.TypeDiscp)
                    {
                        if (tmpSchedule.Day != schedule.Day)
                        {
                            if (flag == true)
                            {
                                MessageBox.Show("Лекции по одному предмету должны проходить у всех групп в один день!");
                            }
                            return false;
                        }
                        else if (tmpSchedule.NumPair != schedule.NumPair)
                        {
                            if (flag == true)
                            {
                                MessageBox.Show("Лекции по одному предмету должны проходить у всех групп в одно время!");
                            }
                            return false;
                        }
                        else if (tmpSchedule.NumAuditorium != schedule.NumAuditorium)
                        {
                            if (flag == true)
                            {
                                MessageBox.Show("Лекции по одному предмету должны проходить у всех групп в одной аудитории!");
                            }
                            return false;
                        }
                        else if (tmpSchedule.Educator != schedule.Educator)
                        {
                            if (flag == true)
                            {
                                MessageBox.Show("Лекции по одному предмету должны проводиться у всех групп одним преподавателем!");
                            }
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                return true;
            }
            else
            {
                return true;
            }
        }

        private bool HaveLection(Schedule schedule, bool flag)
        {
            if (schedule.TypeDiscp != "Л")
            {
                foreach (Schedule tmpSchedule in ScheduleVector)
                {
                    if (tmpSchedule.TypeDiscp == "Л" && tmpSchedule.Day == schedule.Day && tmpSchedule.NumPair == schedule.NumPair)
                    {
                        if (flag == true)
                        {
                            MessageBox.Show("Лекции по одному предмету должны проводиться у всех групп в одно время!");
                        }
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return true;
            }
        }

        private void EducatorWorkloadLower(Schedule schedule)
        {
            foreach (Educator tmpEducator in EducatorsVector)
            {
                if (tmpEducator.Name == schedule.Educator)
                {
                    foreach (Curriculum tmpCurriculum in CurriculumsVector)
                    {
                        if (tmpCurriculum.Discipline == schedule.Discipline && tmpCurriculum.TypeDiscp == schedule.TypeDiscp && tmpCurriculum.TypeDiscp == "Л")
                        {
                            foreach (Schedule tmpSchedule in ScheduleVector)
                            {
                                if (tmpSchedule.Discipline == tmpCurriculum.Discipline && tmpSchedule.TypeDiscp == tmpCurriculum.TypeDiscp)
                                    return;
                            }
                            if (tmpCurriculum.Time == 68)
                            {
                                tmpEducator.Workload(tmpCurriculum.Time / 2);
                                return;
                            }
                            else
                            {
                                tmpEducator.Workload(tmpCurriculum.Time);
                                return;
                            }
                        }
                        else if (tmpCurriculum.Discipline == schedule.Discipline && tmpCurriculum.TypeDiscp == schedule.TypeDiscp)
                        {
                            if (tmpCurriculum.Time == 68)
                            {
                                tmpEducator.Workload(tmpCurriculum.Time / 2);
                                return;
                            }
                            else
                            {
                                tmpEducator.Workload(tmpCurriculum.Time);
                                return;
                            }
                        }
                    }
                }
            }
        }

        public bool DeleteInSchedule(Schedule schedule)
        {
            if (!ScheduleVector.Remove(schedule))
            {
                MessageBox.Show("Такой записи нет в расписании!");
                return false;
            }
            else
            {
                EducatorWorkloadUpper(schedule);
                return true;
            }
        }

        private void EducatorWorkloadUpper(Schedule schedule)
        {
            foreach (Schedule tmpSchedule in ScheduleVector)
            {
                if (tmpSchedule.Discipline == schedule.Discipline && tmpSchedule.TypeDiscp == schedule.TypeDiscp && schedule.TypeDiscp == "Л")
                {
                    return;
                }
            }
            foreach (Educator educator in EducatorsVector)
            {
                if (schedule.Educator == educator.Name)
                {
                    educator.Time += 34;
                    return;
                }
            }
        }


        public bool AddInGroups(int num, string spec, int countStud)
        {
            Group group = new Group(num, spec, countStud);
            if (GroupsVector.Count() != 0)
            {
                foreach (Group tmpGroup in GroupsVector)
                {
                    if (tmpGroup.Equals(group))
                    {
                        MessageBox.Show("Такая группа уже имеется!");
                        return false;
                    }
                }
                GroupsVector.Add(group);
                return true;
            }
            else
            {
                GroupsVector.Add(group);
                return true;
            }
        }

        public bool DeleteInGroups(Group group)
        {
            if (!GroupsVector.Remove(group))
            {
                MessageBox.Show("Такой группы нет!");
                return false;
            }
            else
            {
                List<Schedule> list = new List<Schedule>();
                foreach (Schedule tmpSchedule in ScheduleVector)
                {
                    list.Add(tmpSchedule);
                }
                foreach (Schedule schedule in list)
                {
                    if (schedule.NumGroup == group.Num)
                    {
                        ScheduleVector.Remove(schedule);
                        EducatorWorkloadUpper(schedule);
                    }
                }
                return true;
            }
        }

        public bool AddInEducators(string name, string position, int numDep, int time)
        {
            Educator educator = new Educator(name, position, numDep, time);
            if (EducatorsVector.Count() != 0)
            {
                foreach (Educator tmpEducator in EducatorsVector)
                {
                    if (tmpEducator.Equals(educator))
                    {
                        MessageBox.Show("Такой преподаватель уже существует!");
                        return false;
                    }
                }
                EducatorsVector.Add(educator);
                return true;
            }
            else
            {
                EducatorsVector.Add(educator);
                return true;
            }
        }

        public bool DeleteInEducators(Educator educator)
        {
            if (!EducatorsVector.Remove(educator))
            {
                MessageBox.Show("Такого преподавателя нет!");
                return false;
            }
            else
            {
                List<Schedule> list = new List<Schedule>();
                foreach (Schedule tmpSchedule in ScheduleVector)
                {
                    list.Add(tmpSchedule);
                }
                foreach (Schedule schedule in list)
                {
                    if (schedule.Educator == educator.Name)
                    {
                        ScheduleVector.Remove(schedule);
                    }
                }
                return true;
            }
        }

        public bool AddInAuditoriums(string num, int cap)
        {
            Auditorium auditorium = new Auditorium(num, cap);
            if (AuditoriumsVector.Count() != 0)
            {
                foreach (Auditorium tmpAuditorium in AuditoriumsVector)
                {
                    if (tmpAuditorium.Equals(auditorium))
                    {
                        MessageBox.Show("Такая аудитория уже существует!");
                        return false;
                    }
                }
                AuditoriumsVector.Add(auditorium);
                return true;
            }
            else
            {
                AuditoriumsVector.Add(auditorium);
                return true;
            }
        }

        public bool DeleteInAuditoriums(Auditorium auditorium)
        {
            if (!AuditoriumsVector.Remove(auditorium))
            {
                MessageBox.Show("Такой аудитории нет!");
                return false;
            }
            else
            {
                List<Schedule> list = new List<Schedule>();
                foreach (Schedule tmpSchedule in ScheduleVector)
                {
                    list.Add(tmpSchedule);
                }
                foreach (Schedule schedule in list)
                {
                    if (schedule.NumAuditorium == auditorium.Num)
                    {
                        ScheduleVector.Remove(schedule);
                        EducatorWorkloadUpper(schedule);
                    }
                }
                return true;
            }
        }

        public bool AddInCurriculum(string discipline, int time, string typeDiscp)
        {
            Curriculum curriculum = new Curriculum(discipline, time, typeDiscp);
            if (CurriculumsVector.Count() != 0)
            {
                foreach (Curriculum tmpCurriculum in CurriculumsVector)
                {
                    if (tmpCurriculum.Equals(curriculum))
                    {
                        MessageBox.Show("Такая запись в учебном плане уже существует!");
                        return false;
                    }
                }
                CurriculumsVector.Add(curriculum);
                return true;
            }
            else
            {
                CurriculumsVector.Add(curriculum);
                return true;
            }
        }

        public bool DeleteInCurriculum(Curriculum curriculum)
        {
            if (!CurriculumsVector.Remove(curriculum))
            {
                MessageBox.Show("Такой записи в учебном плане нет!");
                return false;
            }
            else
            {
                List<Schedule> list = new List<Schedule>();
                foreach (Schedule tmpSchedule in ScheduleVector)
                {
                    list.Add(tmpSchedule);
                }
                foreach (Schedule schedule in list)
                {
                    if (schedule.Discipline == curriculum.Discipline && schedule.TypeDiscp == curriculum.TypeDiscp)
                    {
                        ScheduleVector.Remove(schedule);
                        EducatorWorkloadUpper(schedule);
                    }
                }
                return true;
            }
        }

        public List<Schedule> FindByGroup(int numGroup)
        {
            List<Schedule> ScheduleByGroupVector = new List<Schedule>();
            foreach (Schedule schedule in ScheduleVector)
            {
                if (schedule.NumGroup == numGroup)
                {
                    ScheduleByGroupVector.Add(schedule);
                }
            }
            return ScheduleByGroupVector;
        }

        public List<Schedule> FindByEducator(string educator)
        {
            List<Schedule> ScheduleByEducatorVector = new List<Schedule>();
            foreach (Schedule schedule in ScheduleVector)
            {
                if (schedule.Educator == educator)
                {
                    ScheduleByEducatorVector.Add(schedule);
                }
            }
            return ScheduleByEducatorVector;
        }

        public List<Schedule> FindByDay(string day)
        {
            List<Schedule> ScheduleByDayVector = new List<Schedule>();
            foreach (Schedule schedule in ScheduleVector)
            {
                if (schedule.Day == day)
                {
                    ScheduleByDayVector.Add(schedule);
                }
            }
            return ScheduleByDayVector;
        }

        public List<Schedule> FindByGroupAndEducator(int numGroup, string educator)
        {
            List<Schedule> ScheduleByGroupAndEducatorVector = new List<Schedule>();
            foreach (Schedule schedule in ScheduleVector)
            {
                if (schedule.NumGroup == numGroup && schedule.Educator == educator)
                {
                    ScheduleByGroupAndEducatorVector.Add(schedule);
                }
            }
            return ScheduleByGroupAndEducatorVector;
        }

        public List<Schedule> FindByGroupAndDay(int numGroup, string day)
        {
            List<Schedule> ScheduleByGroupAndDayVector = new List<Schedule>();
            foreach (Schedule schedule in ScheduleVector)
            {
                if (schedule.NumGroup == numGroup && schedule.Day == day)
                {
                    ScheduleByGroupAndDayVector.Add(schedule);
                }
            }
            return ScheduleByGroupAndDayVector;
        }

        public List<Schedule> FindByEducatorAndDay(string educator, string day)
        {
            List<Schedule> ScheduleByEducatorAndDayVector = new List<Schedule>();
            foreach (Schedule schedule in ScheduleVector)
            {
                if (schedule.Educator == educator && schedule.Day == day)
                {
                    ScheduleByEducatorAndDayVector.Add(schedule);
                }
            }
            return ScheduleByEducatorAndDayVector;
        }

        public void GenerateSchedule()
        {
            GroupsVector.Add(new Group(4832, "Программная инженерия", 22));
            GroupsVector.Add(new Group(4831, "Программная инженерия", 19));

            EducatorsVector.Add(new Educator("Шумова Е.О.", "Старший преподаватель", 43, 68));
            EducatorsVector.Add(new Educator("Поляк М.Д.", "Старший преподаватель", 43, 170));
            EducatorsVector.Add(new Educator("Степанов П.А.", "Старший преподаватель", 43, 136));
            EducatorsVector.Add(new Educator("Кочин Д.А.", "Ассистент", 43, 68));
            EducatorsVector.Add(new Educator("Павлов Е.В.", "Старший преподаватель", 43, 170));
            EducatorsVector.Add(new Educator("Лозоватский И.М.", "Ассистент", 43, 102));
            EducatorsVector.Add(new Educator("Щекин С.В.", "Доцент", 43, 34));
            EducatorsVector.Add(new Educator("Попов А.А.", "Доцент", 43, 68));
            EducatorsVector.Add(new Educator("Николаев Д.А.", "Старший преподаватель", 43, 34));
            EducatorsVector.Add(new Educator("Галковская Ю.М.", "Доцент", 63, 68));

            AuditoriumsVector.Add(new Auditorium("53-04", 30));
            AuditoriumsVector.Add(new Auditorium("43-04", 60));
            AuditoriumsVector.Add(new Auditorium("33-04", 30));
            AuditoriumsVector.Add(new Auditorium("23-04", 60));
            AuditoriumsVector.Add(new Auditorium("13-04", 60));

            CurriculumsVector.Add(new Curriculum("ООП", 34, "КП"));
            CurriculumsVector.Add(new Curriculum("МПП", 34, "Л"));
            CurriculumsVector.Add(new Curriculum("МПП", 34, "ЛР"));
            CurriculumsVector.Add(new Curriculum("МТ", 34, "КП"));
            CurriculumsVector.Add(new Curriculum("ТРСИС", 34, "Л"));
            CurriculumsVector.Add(new Curriculum("ТРСИС", 34, "ЛР"));
            CurriculumsVector.Add(new Curriculum("УКПО", 34, "Л"));
            CurriculumsVector.Add(new Curriculum("УКПО", 34, "ЛР"));
            CurriculumsVector.Add(new Curriculum("ППС", 34, "Л")); 
            CurriculumsVector.Add(new Curriculum("ППС", 34, "ЛР"));
            CurriculumsVector.Add(new Curriculum("ППС", 34, "ПР"));
            CurriculumsVector.Add(new Curriculum("КГ", 34, "ЛР"));
            CurriculumsVector.Add(new Curriculum("КГ", 34, "Л"));
            CurriculumsVector.Add(new Curriculum("АЭВМиС", 34, "ЛР"));
            CurriculumsVector.Add(new Curriculum("АЭВМиС", 34, "Л"));
            CurriculumsVector.Add(new Curriculum("ТП", 34, "ПР"));

            List<string> Days = new List<string>
            {
                "ПН",
                "ВТ",
                "СР",
                "ЧТ",
                "ПТ",
                "СБ"
            };

            List<int> NumPairs = new List<int>
            {
                1,
                2,
                3,
                4,
                5,
                6
            };

            foreach (Group group in GroupsVector)
            {
                foreach (Curriculum curriculum in CurriculumsVector)
                {
                    bool f = false;
                    Schedule schedule = new Schedule
                    {
                        NumGroup = group.Num,
                        Discipline = curriculum.Discipline,
                        TypeDiscp = curriculum.TypeDiscp
                    };
                    if (schedule.Discipline == "ООП")
                        schedule.Educator = "Шумова Е.О.";
                    else if (schedule.Discipline == "МПП" || schedule.Discipline == "МТ")
                        schedule.Educator = "Поляк М.Д.";
                    else if (schedule.Discipline == "ТРСИС" || (schedule.Discipline == "УКПО" && schedule.TypeDiscp == "Л"))
                        schedule.Educator = "Степанов П.А.";
                    else if (schedule.Discipline == "УКПО" && schedule.TypeDiscp == "ЛР")
                        schedule.Educator = "Кочин Д.А.";
                    else if (schedule.Discipline == "ППС")
                        schedule.Educator = "Павлов Е.В.";
                    else if (schedule.Discipline == "АЭВМиС" && schedule.TypeDiscp == "Л")
                        schedule.Educator = "Николаев Д.А.";
                    else if (schedule.Discipline == "АЭВМиС" && schedule.TypeDiscp == "ЛР")
                        schedule.Educator = "Попов А.А.";
                    else if (schedule.Discipline == "КГ" && schedule.TypeDiscp == "Л")
                        schedule.Educator = "Щекин С.В.";
                    else if (schedule.Discipline == "КГ" && schedule.TypeDiscp == "ЛР")
                        schedule.Educator = "Лозоватский И.М.";
                    else if (schedule.Discipline == "ТП")
                        schedule.Educator = "Галковская Ю.М.";
                    foreach (string day in Days)
                    {
                        schedule.Day = day;
                        foreach (int numPair in NumPairs)
                        {
                            schedule.NumPair = numPair;
                            schedule.SetTime();
                            foreach (Auditorium auditorium in AuditoriumsVector)
                            {
                                if (schedule.TypeDiscp == "Л" && auditorium.Cap < 41)
                                    continue;
                                else
                                {
                                    schedule.NumAuditorium = auditorium.Num;
                                    if (AddInSchedule(schedule, false))
                                    {
                                        f = true;
                                    }
                                }
                                if (f == true)
                                {
                                    break;
                                }
                            }
                            if (f == true)
                            {
                                break;
                            }
                        }
                        if (f == true)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
