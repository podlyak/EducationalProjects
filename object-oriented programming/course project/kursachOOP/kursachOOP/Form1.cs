using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursachOOP
{
    public partial class FormSchedule : Form
    {
        User user = new User();
        public FormSchedule()
        {
            InitializeComponent();
        }

        private void FormSchedule_Load(object sender, EventArgs e)
        {
            
        }

        private void generation_Click(object sender, EventArgs e)
        {
            user.GenerateSchedule();
            dataSchedule.DataSource = null;
            dataSchedule.DataSource = user.ScheduleVector;

            dataCurriculum.DataSource = null;
            dataCurriculum.DataSource = user.CurriculumsVector;

            dataEducators.DataSource = null;
            dataEducators.DataSource = user.EducatorsVector;

            dataGroups.DataSource = null;
            dataGroups.DataSource = user.GroupsVector;

            dataAuditoriums.DataSource = null;
            dataAuditoriums.DataSource = user.AuditoriumsVector;
        }

        private void findGroupUpdate(object sender, EventArgs e)
        {
            List<string> list = user.GroupsVector.Select(g => g.Num.ToString()).ToList();
            list.Add("-нет-");
            ((ComboBox)sender).DataSource = list;
        }

        private void findEducatorUpdate(object sender, EventArgs e)
        {
            List<string> list = user.EducatorsVector.Select(g => g.Name.ToString()).ToList();
            list.Add("-нет-");
            ((ComboBox)sender).DataSource = list;
        }

        private void groupsComboUpdate(object sender, EventArgs e)
        {
            ((ComboBox)sender).DataSource = user.GroupsVector.Select(g => g.Num.ToString()).ToList();
        }

        private void disciplinesComboUpdate(object sender, EventArgs e)
        {
            List<string> listDisciplineFalse = user.CurriculumsVector.Select(g => g.Discipline.ToString()).ToList();
            List<string> listDisciplineTrue = new List<string>();
            foreach (string tmpDisciplineFalse in listDisciplineFalse)
            {
                bool flag = true;
                if (listDisciplineTrue.Count() != 0)
                {
                    foreach (string tmpDisiplineTrue in listDisciplineTrue)
                    {
                        if (tmpDisciplineFalse == tmpDisiplineTrue)
                            flag = false;
                    }
                    if (flag)
                        listDisciplineTrue.Add(tmpDisciplineFalse);
                }
                else
                    listDisciplineTrue.Add(tmpDisciplineFalse);
            }
            ((ComboBox)sender).DataSource = listDisciplineTrue;
        }

        private void auditoriumsComboUpdate(object sender, EventArgs e)
        {
            ((ComboBox)sender).DataSource = user.AuditoriumsVector.Select(g => g.Num.ToString()).ToList();
        }

        private void educatorsComboUpdate(object sender, EventArgs e)
        {
            ((ComboBox)sender).DataSource = user.EducatorsVector.Select(g => g.Name.ToString()).ToList();
        }

        private void addSchedule_Click(object sender, EventArgs e)
        {
            int Group = int.Parse(GroupsAD.SelectedItem.ToString());
            string Day = DayAD.SelectedItem.ToString();
            int NumPair = int.Parse(NumPairAD.SelectedItem.ToString());
            string Discipline = DisciplineAD.SelectedItem.ToString();
            string TypeDiscp = TypeDiscpAD.SelectedItem.ToString();
            string NumAuditorium = NumAudAD.SelectedItem.ToString();
            string Educator = EducatorAD.SelectedItem.ToString();
            Schedule schedule = new Schedule(Group, Day, NumPair, Discipline, TypeDiscp, NumAuditorium, Educator);
            if (user.AddInSchedule(schedule, true))
            {
                dataSchedule.DataSource = null;
                dataSchedule.DataSource = user.ScheduleVector;

                dataEducators.DataSource = null;
                dataEducators.DataSource = user.EducatorsVector;
            }
        }

        private void deleteSchedule_Click(object sender, EventArgs e)
        {
            int Group = int.Parse(GroupsAD.SelectedItem.ToString());
            string Day = DayAD.SelectedItem.ToString();
            int NumPair = int.Parse(NumPairAD.SelectedItem.ToString());
            string Discipline = DisciplineAD.SelectedItem.ToString();
            string TypeDiscp = TypeDiscpAD.SelectedItem.ToString();
            string NumAuditorium = NumAudAD.SelectedItem.ToString();
            string Educator = EducatorAD.SelectedItem.ToString();
            Schedule schedule = new Schedule(Group, Day, NumPair, Discipline, TypeDiscp, NumAuditorium, Educator);
            if (user.DeleteInSchedule(schedule))
            {
                dataSchedule.DataSource = null;
                dataSchedule.DataSource = user.ScheduleVector;

                dataEducators.DataSource = null;
                dataEducators.DataSource = user.EducatorsVector;
            }
        }

        private void find_Click(object sender, EventArgs e)
        {
            if (findGroup.SelectedItem.ToString() == "-нет-" && findDay.SelectedItem.ToString() == "-нет-" && findEducator.SelectedItem.ToString() == "-нет-")
            {
                dataSchedule.DataSource = user.ScheduleVector;
            }
            else if (findGroup.SelectedItem.ToString() != "-нет-" && findDay.SelectedItem.ToString() == "-нет-" && findEducator.SelectedItem.ToString() == "-нет-")
            {
                dataSchedule.DataSource = user.FindByGroup(int.Parse(findGroup.SelectedItem.ToString()));
            }
            else if (findGroup.SelectedItem.ToString() == "-нет-" && findDay.SelectedItem.ToString() != "-нет-" && findEducator.SelectedItem.ToString() == "-нет-")
            {
                dataSchedule.DataSource = user.FindByDay(findDay.SelectedItem.ToString());
            }
            else if (findGroup.SelectedItem.ToString() == "-нет-" && findDay.SelectedItem.ToString() == "-нет-" && findEducator.SelectedItem.ToString() != "-нет-")
            {
                dataSchedule.DataSource = user.FindByEducator(findEducator.SelectedItem.ToString());
            }
            else if (findGroup.SelectedItem.ToString() != "-нет-" && findDay.SelectedItem.ToString() != "-нет-" && findEducator.SelectedItem.ToString() == "-нет-")
            {
                dataSchedule.DataSource = user.FindByGroupAndDay(int.Parse(findGroup.SelectedItem.ToString()), findDay.SelectedItem.ToString());
            }
            else if (findGroup.SelectedItem.ToString() != "-нет-" && findDay.SelectedItem.ToString() == "-нет-" && findEducator.SelectedItem.ToString() != "-нет-")
            {
                dataSchedule.DataSource = user.FindByGroupAndEducator(int.Parse(findGroup.SelectedItem.ToString()), findEducator.SelectedItem.ToString());
            }
            else if (findGroup.SelectedItem.ToString() == "-нет-" && findDay.SelectedItem.ToString() != "-нет-" && findEducator.SelectedItem.ToString() != "-нет-")
            {
                dataSchedule.DataSource = user.FindByEducatorAndDay(findEducator.SelectedItem.ToString(), findDay.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Нельзя найти расписание по всем трем параметрам!");
            }
        }

        private void addCurriculum_Click(object sender, EventArgs e)
        {
            string Discipline = discpCurric.Text;
            int Time = int.Parse(timeCurric.Text);
            string TypeDiscp = typeDiscpCurric.Text;
            if (user.AddInCurriculum(Discipline, Time, TypeDiscp))
            {
                dataCurriculum.DataSource = null;
                dataCurriculum.DataSource = user.CurriculumsVector;
            }
        }

        private void deleteCurriculum_Click(object sender, EventArgs e)
        {
            string Discipline = discpCurric.Text;
            int Time = int.Parse(timeCurric.Text);
            string TypeDiscp = typeDiscpCurric.Text;
            Curriculum curriculum = new Curriculum(Discipline, Time, TypeDiscp);
            if (user.DeleteInCurriculum(curriculum))
            {
                dataCurriculum.DataSource = null;
                dataCurriculum.DataSource = user.CurriculumsVector;

                dataSchedule.DataSource = null;
                dataSchedule.DataSource = user.ScheduleVector;

                dataEducators.DataSource = null;
                dataEducators.DataSource = user.EducatorsVector;
            }
        }

        private void addGroups_Click(object sender, EventArgs e)
        {
            int Num = int.Parse(numGroupGroup.Text);
            string Spec = specGroup.Text;
            int CountStud = int.Parse(countStudGroup.Text);
            if (user.AddInGroups(Num, Spec, CountStud))
            {
                dataGroups.DataSource = null;
                dataGroups.DataSource = user.GroupsVector;
            }
        }

        private void deleteGroups_Click(object sender, EventArgs e)
        {
            int Num = int.Parse(numGroupGroup.Text);
            string Spec = specGroup.Text;
            int CountStud = int.Parse(countStudGroup.Text);
            Group group = new Group(Num, Spec, CountStud);
            if (user.DeleteInGroups(group))
            {
                dataGroups.DataSource = null;
                dataGroups.DataSource = user.GroupsVector;

                dataSchedule.DataSource = null;
                dataSchedule.DataSource = user.ScheduleVector;

                dataEducators.DataSource = null;
                dataEducators.DataSource = user.EducatorsVector;
            }
        }

        private void addEducators_Click(object sender, EventArgs e)
        {
            string Name = nameEducator.Text;
            string Position = positionEducator.Text;
            int NumDep = int.Parse(numDepEducator.Text);
            int Time = int.Parse(timeEducator.Text);
            if (user.AddInEducators(Name, Position, NumDep, Time))
            {
                dataEducators.DataSource = null;
                dataEducators.DataSource = user.EducatorsVector;
            }
        }

        private void deleteEducators_Click(object sender, EventArgs e)
        {
            string Name = nameEducator.Text;
            string Position = positionEducator.Text;
            int NumDep = int.Parse(numDepEducator.Text);
            int Time = int.Parse(timeEducator.Text);
            Educator educator = new Educator(Name, Position, NumDep, Time);
            if (user.DeleteInEducators(educator))
            {
                dataEducators.DataSource = null;
                dataEducators.DataSource = user.EducatorsVector;

                dataSchedule.DataSource = null;
                dataSchedule.DataSource = user.ScheduleVector;
            }
        }

        private void addAuditoriums_Click(object sender, EventArgs e)
        {
            string Num = numAudAud.Text;
            int Cap = int.Parse(capAud.Text);
            if (user.AddInAuditoriums(Num, Cap))
            {
                dataAuditoriums.DataSource = null;
                dataAuditoriums.DataSource = user.AuditoriumsVector;
            }
        }

        private void deleteAuditoriums_Click(object sender, EventArgs e)
        {
            string Num = numAudAud.Text;
            int Cap = int.Parse(capAud.Text);
            Auditorium auditorium = new Auditorium(Num, Cap);
            if (user.DeleteInAuditoriums(auditorium))
            {
                dataAuditoriums.DataSource = null;
                dataAuditoriums.DataSource = user.AuditoriumsVector;

                dataSchedule.DataSource = null;
                dataSchedule.DataSource = user.ScheduleVector;

                dataEducators.DataSource = null;
                dataEducators.DataSource = user.EducatorsVector;
            }
        }
    }
}
