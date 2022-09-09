namespace kursachOOP
{
    partial class FormSchedule
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataSchedule = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GroupsAD = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DayAD = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.NumPairAD = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DisciplineAD = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TypeDiscpAD = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.NumAudAD = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.EducatorAD = new System.Windows.Forms.ComboBox();
            this.addSchedule = new System.Windows.Forms.Button();
            this.deleteSchedule = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.findGroup = new System.Windows.Forms.ComboBox();
            this.findDay = new System.Windows.Forms.ComboBox();
            this.findEducator = new System.Windows.Forms.ComboBox();
            this.find = new System.Windows.Forms.Button();
            this.generation = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dataCurriculum = new System.Windows.Forms.DataGridView();
            this.label16 = new System.Windows.Forms.Label();
            this.dataEducators = new System.Windows.Forms.DataGridView();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dataAuditoriums = new System.Windows.Forms.DataGridView();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.discpCurric = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.timeCurric = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.typeDiscpCurric = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.addCurriculum = new System.Windows.Forms.Button();
            this.deleteCurriculum = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.numGroupGroup = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.specGroup = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.countStudGroup = new System.Windows.Forms.TextBox();
            this.addGroups = new System.Windows.Forms.Button();
            this.deleteGroups = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.nameEducator = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.positionEducator = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.numDepEducator = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.timeEducator = new System.Windows.Forms.TextBox();
            this.addEducators = new System.Windows.Forms.Button();
            this.deleteEducators = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.numAudAud = new System.Windows.Forms.TextBox();
            this.capAud = new System.Windows.Forms.TextBox();
            this.addAuditoriums = new System.Windows.Forms.Button();
            this.deleteAuditoriums = new System.Windows.Forms.Button();
            this.dataGroups = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataCurriculum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataEducators)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataAuditoriums)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSchedule
            // 
            this.dataSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSchedule.Location = new System.Drawing.Point(360, 41);
            this.dataSchedule.Name = "dataSchedule";
            this.dataSchedule.RowHeadersWidth = 51;
            this.dataSchedule.RowTemplate.Height = 24;
            this.dataSchedule.Size = new System.Drawing.Size(1294, 240);
            this.dataSchedule.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(355, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(442, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Расписание занятий в университете";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Группа:";
            // 
            // GroupsAD
            // 
            this.GroupsAD.FormattingEnabled = true;
            this.GroupsAD.Location = new System.Drawing.Point(158, 215);
            this.GroupsAD.Name = "GroupsAD";
            this.GroupsAD.Size = new System.Drawing.Size(145, 24);
            this.GroupsAD.TabIndex = 3;
            this.GroupsAD.DropDown += new System.EventHandler(this.groupsComboUpdate);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "День недели:";
            // 
            // DayAD
            // 
            this.DayAD.FormattingEnabled = true;
            this.DayAD.Items.AddRange(new object[] {
            "ПН",
            "ВТ",
            "СР",
            "ЧТ",
            "ПТ",
            "СБ"});
            this.DayAD.Location = new System.Drawing.Point(158, 245);
            this.DayAD.Name = "DayAD";
            this.DayAD.Size = new System.Drawing.Size(145, 24);
            this.DayAD.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Номер пары:";
            // 
            // NumPairAD
            // 
            this.NumPairAD.FormattingEnabled = true;
            this.NumPairAD.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.NumPairAD.Location = new System.Drawing.Point(158, 275);
            this.NumPairAD.Name = "NumPairAD";
            this.NumPairAD.Size = new System.Drawing.Size(145, 24);
            this.NumPairAD.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Дисциплина:";
            // 
            // DisciplineAD
            // 
            this.DisciplineAD.FormattingEnabled = true;
            this.DisciplineAD.Location = new System.Drawing.Point(158, 305);
            this.DisciplineAD.Name = "DisciplineAD";
            this.DisciplineAD.Size = new System.Drawing.Size(145, 24);
            this.DisciplineAD.TabIndex = 9;
            this.DisciplineAD.DropDown += new System.EventHandler(this.disciplinesComboUpdate);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 338);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Тип дисциплины:";
            // 
            // TypeDiscpAD
            // 
            this.TypeDiscpAD.FormattingEnabled = true;
            this.TypeDiscpAD.Items.AddRange(new object[] {
            "ЛР",
            "Л",
            "ПР",
            "КП"});
            this.TypeDiscpAD.Location = new System.Drawing.Point(158, 335);
            this.TypeDiscpAD.Name = "TypeDiscpAD";
            this.TypeDiscpAD.Size = new System.Drawing.Size(145, 24);
            this.TypeDiscpAD.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 368);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Номер аудитории:";
            // 
            // NumAudAD
            // 
            this.NumAudAD.FormattingEnabled = true;
            this.NumAudAD.Location = new System.Drawing.Point(158, 365);
            this.NumAudAD.Name = "NumAudAD";
            this.NumAudAD.Size = new System.Drawing.Size(145, 24);
            this.NumAudAD.TabIndex = 13;
            this.NumAudAD.DropDown += new System.EventHandler(this.auditoriumsComboUpdate);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 398);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Преподаватель:";
            // 
            // EducatorAD
            // 
            this.EducatorAD.FormattingEnabled = true;
            this.EducatorAD.Location = new System.Drawing.Point(158, 395);
            this.EducatorAD.Name = "EducatorAD";
            this.EducatorAD.Size = new System.Drawing.Size(145, 24);
            this.EducatorAD.TabIndex = 15;
            this.EducatorAD.DropDown += new System.EventHandler(this.educatorsComboUpdate);
            // 
            // addSchedule
            // 
            this.addSchedule.Location = new System.Drawing.Point(22, 435);
            this.addSchedule.Name = "addSchedule";
            this.addSchedule.Size = new System.Drawing.Size(119, 40);
            this.addSchedule.TabIndex = 16;
            this.addSchedule.Text = "Добавить";
            this.addSchedule.UseVisualStyleBackColor = true;
            this.addSchedule.Click += new System.EventHandler(this.addSchedule_Click);
            // 
            // deleteSchedule
            // 
            this.deleteSchedule.Location = new System.Drawing.Point(158, 435);
            this.deleteSchedule.Name = "deleteSchedule";
            this.deleteSchedule.Size = new System.Drawing.Size(119, 40);
            this.deleteSchedule.TabIndex = 17;
            this.deleteSchedule.Text = "Удалить";
            this.deleteSchedule.UseVisualStyleBackColor = true;
            this.deleteSchedule.Click += new System.EventHandler(this.deleteSchedule_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(11, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(168, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "Поиск расписания:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 17);
            this.label11.TabIndex = 23;
            this.label11.Text = "Группа:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 102);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 17);
            this.label12.TabIndex = 24;
            this.label12.Text = "День недели:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 132);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 17);
            this.label13.TabIndex = 25;
            this.label13.Text = "Преподаватель:";
            // 
            // findGroup
            // 
            this.findGroup.FormattingEnabled = true;
            this.findGroup.Items.AddRange(new object[] {
            "-Нет-"});
            this.findGroup.Location = new System.Drawing.Point(158, 69);
            this.findGroup.Name = "findGroup";
            this.findGroup.Size = new System.Drawing.Size(121, 24);
            this.findGroup.TabIndex = 26;
            this.findGroup.DropDown += new System.EventHandler(this.findGroupUpdate);
            // 
            // findDay
            // 
            this.findDay.FormattingEnabled = true;
            this.findDay.Items.AddRange(new object[] {
            "ПН",
            "ВТ",
            "СР",
            "ЧТ",
            "ПТ",
            "СБ",
            "-нет-"});
            this.findDay.Location = new System.Drawing.Point(158, 99);
            this.findDay.Name = "findDay";
            this.findDay.Size = new System.Drawing.Size(121, 24);
            this.findDay.TabIndex = 27;
            // 
            // findEducator
            // 
            this.findEducator.FormattingEnabled = true;
            this.findEducator.Location = new System.Drawing.Point(158, 129);
            this.findEducator.Name = "findEducator";
            this.findEducator.Size = new System.Drawing.Size(121, 24);
            this.findEducator.TabIndex = 28;
            this.findEducator.DropDown += new System.EventHandler(this.findEducatorUpdate);
            // 
            // find
            // 
            this.find.Location = new System.Drawing.Point(285, 96);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(69, 29);
            this.find.TabIndex = 29;
            this.find.Text = "Поиск";
            this.find.UseVisualStyleBackColor = true;
            this.find.Click += new System.EventHandler(this.find_Click);
            // 
            // generation
            // 
            this.generation.Location = new System.Drawing.Point(1681, 102);
            this.generation.Name = "generation";
            this.generation.Size = new System.Drawing.Size(145, 109);
            this.generation.TabIndex = 30;
            this.generation.Text = "Сгенерировать расписание";
            this.generation.UseVisualStyleBackColor = true;
            this.generation.Click += new System.EventHandler(this.generation_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(11, 182);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(259, 20);
            this.label14.TabIndex = 31;
            this.label14.Text = "Редактирование расписания:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(355, 300);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(142, 25);
            this.label15.TabIndex = 32;
            this.label15.Text = "Учебный план";
            // 
            // dataCurriculum
            // 
            this.dataCurriculum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataCurriculum.Location = new System.Drawing.Point(360, 325);
            this.dataCurriculum.Name = "dataCurriculum";
            this.dataCurriculum.RowHeadersWidth = 51;
            this.dataCurriculum.RowTemplate.Height = 24;
            this.dataCurriculum.Size = new System.Drawing.Size(493, 150);
            this.dataCurriculum.TabIndex = 33;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(900, 300);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(158, 25);
            this.label16.TabIndex = 34;
            this.label16.Text = "Преподаватели";
            // 
            // dataEducators
            // 
            this.dataEducators.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataEducators.Location = new System.Drawing.Point(905, 325);
            this.dataEducators.Name = "dataEducators";
            this.dataEducators.RowHeadersWidth = 51;
            this.dataEducators.RowTemplate.Height = 24;
            this.dataEducators.Size = new System.Drawing.Size(626, 150);
            this.dataEducators.TabIndex = 35;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(355, 492);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 25);
            this.label17.TabIndex = 36;
            this.label17.Text = "Группы";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(900, 492);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(113, 25);
            this.label18.TabIndex = 38;
            this.label18.Text = "Аудитории";
            // 
            // dataAuditoriums
            // 
            this.dataAuditoriums.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAuditoriums.Location = new System.Drawing.Point(905, 520);
            this.dataAuditoriums.Name = "dataAuditoriums";
            this.dataAuditoriums.RowHeadersWidth = 51;
            this.dataAuditoriums.RowTemplate.Height = 24;
            this.dataAuditoriums.Size = new System.Drawing.Size(361, 150);
            this.dataAuditoriums.TabIndex = 39;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.Location = new System.Drawing.Point(10, 509);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(292, 20);
            this.label19.TabIndex = 40;
            this.label19.Text = "Редактирование учебного плана:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(12, 546);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(94, 17);
            this.label20.TabIndex = 41;
            this.label20.Text = "Дисциплина:";
            // 
            // discpCurric
            // 
            this.discpCurric.Location = new System.Drawing.Point(195, 543);
            this.discpCurric.Name = "discpCurric";
            this.discpCurric.Size = new System.Drawing.Size(145, 22);
            this.discpCurric.TabIndex = 42;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(12, 574);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(163, 17);
            this.label21.TabIndex = 43;
            this.label21.Text = "Количество ауд. часов:";
            // 
            // timeCurric
            // 
            this.timeCurric.Location = new System.Drawing.Point(195, 571);
            this.timeCurric.Name = "timeCurric";
            this.timeCurric.Size = new System.Drawing.Size(145, 22);
            this.timeCurric.TabIndex = 44;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(12, 602);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(122, 17);
            this.label22.TabIndex = 45;
            this.label22.Text = "Тип дисциплины:";
            // 
            // typeDiscpCurric
            // 
            this.typeDiscpCurric.Location = new System.Drawing.Point(195, 599);
            this.typeDiscpCurric.Name = "typeDiscpCurric";
            this.typeDiscpCurric.Size = new System.Drawing.Size(145, 22);
            this.typeDiscpCurric.TabIndex = 46;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label23.Location = new System.Drawing.Point(11, 711);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(207, 20);
            this.label23.TabIndex = 47;
            this.label23.Text = "Редактирование групп:";
            // 
            // addCurriculum
            // 
            this.addCurriculum.Location = new System.Drawing.Point(22, 642);
            this.addCurriculum.Name = "addCurriculum";
            this.addCurriculum.Size = new System.Drawing.Size(119, 40);
            this.addCurriculum.TabIndex = 48;
            this.addCurriculum.Text = "Добавить";
            this.addCurriculum.UseVisualStyleBackColor = true;
            this.addCurriculum.Click += new System.EventHandler(this.addCurriculum_Click);
            // 
            // deleteCurriculum
            // 
            this.deleteCurriculum.Location = new System.Drawing.Point(158, 642);
            this.deleteCurriculum.Name = "deleteCurriculum";
            this.deleteCurriculum.Size = new System.Drawing.Size(119, 40);
            this.deleteCurriculum.TabIndex = 49;
            this.deleteCurriculum.Text = "Удалить";
            this.deleteCurriculum.UseVisualStyleBackColor = true;
            this.deleteCurriculum.Click += new System.EventHandler(this.deleteCurriculum_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(12, 746);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(105, 17);
            this.label24.TabIndex = 50;
            this.label24.Text = "Номер группы:";
            // 
            // numGroupGroup
            // 
            this.numGroupGroup.Location = new System.Drawing.Point(195, 743);
            this.numGroupGroup.Name = "numGroupGroup";
            this.numGroupGroup.Size = new System.Drawing.Size(145, 22);
            this.numGroupGroup.TabIndex = 51;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(12, 774);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(113, 17);
            this.label25.TabIndex = 52;
            this.label25.Text = "Специальность:";
            // 
            // specGroup
            // 
            this.specGroup.Location = new System.Drawing.Point(195, 771);
            this.specGroup.Name = "specGroup";
            this.specGroup.Size = new System.Drawing.Size(145, 22);
            this.specGroup.TabIndex = 53;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(12, 802);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(161, 17);
            this.label26.TabIndex = 54;
            this.label26.Text = "Количество студентов:";
            // 
            // countStudGroup
            // 
            this.countStudGroup.Location = new System.Drawing.Point(195, 799);
            this.countStudGroup.Name = "countStudGroup";
            this.countStudGroup.Size = new System.Drawing.Size(145, 22);
            this.countStudGroup.TabIndex = 55;
            // 
            // addGroups
            // 
            this.addGroups.Location = new System.Drawing.Point(22, 846);
            this.addGroups.Name = "addGroups";
            this.addGroups.Size = new System.Drawing.Size(119, 40);
            this.addGroups.TabIndex = 56;
            this.addGroups.Text = "Добавить";
            this.addGroups.UseVisualStyleBackColor = true;
            this.addGroups.Click += new System.EventHandler(this.addGroups_Click);
            // 
            // deleteGroups
            // 
            this.deleteGroups.Location = new System.Drawing.Point(158, 846);
            this.deleteGroups.Name = "deleteGroups";
            this.deleteGroups.Size = new System.Drawing.Size(119, 40);
            this.deleteGroups.TabIndex = 57;
            this.deleteGroups.Text = "Удалить";
            this.deleteGroups.UseVisualStyleBackColor = true;
            this.deleteGroups.Click += new System.EventHandler(this.deleteGroups_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label27.Location = new System.Drawing.Point(1575, 304);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(303, 20);
            this.label27.TabIndex = 58;
            this.label27.Text = "Редактирование преподавателей:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(1576, 343);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(39, 17);
            this.label28.TabIndex = 59;
            this.label28.Text = "Имя:";
            // 
            // nameEducator
            // 
            this.nameEducator.Location = new System.Drawing.Point(1709, 340);
            this.nameEducator.Name = "nameEducator";
            this.nameEducator.Size = new System.Drawing.Size(169, 22);
            this.nameEducator.TabIndex = 60;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(1576, 371);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(85, 17);
            this.label29.TabIndex = 61;
            this.label29.Text = "Должность:";
            // 
            // positionEducator
            // 
            this.positionEducator.Location = new System.Drawing.Point(1709, 368);
            this.positionEducator.Name = "positionEducator";
            this.positionEducator.Size = new System.Drawing.Size(169, 22);
            this.positionEducator.TabIndex = 62;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(1576, 399);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(119, 17);
            this.label30.TabIndex = 63;
            this.label30.Text = "Номер кафедры:";
            // 
            // numDepEducator
            // 
            this.numDepEducator.Location = new System.Drawing.Point(1709, 396);
            this.numDepEducator.Name = "numDepEducator";
            this.numDepEducator.Size = new System.Drawing.Size(169, 22);
            this.numDepEducator.TabIndex = 64;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(1576, 427);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(72, 17);
            this.label31.TabIndex = 65;
            this.label31.Text = "Нагрузка:";
            // 
            // timeEducator
            // 
            this.timeEducator.Location = new System.Drawing.Point(1709, 424);
            this.timeEducator.Name = "timeEducator";
            this.timeEducator.Size = new System.Drawing.Size(169, 22);
            this.timeEducator.TabIndex = 66;
            // 
            // addEducators
            // 
            this.addEducators.Location = new System.Drawing.Point(1592, 468);
            this.addEducators.Name = "addEducators";
            this.addEducators.Size = new System.Drawing.Size(119, 40);
            this.addEducators.TabIndex = 67;
            this.addEducators.Text = "Добавить";
            this.addEducators.UseVisualStyleBackColor = true;
            this.addEducators.Click += new System.EventHandler(this.addEducators_Click);
            // 
            // deleteEducators
            // 
            this.deleteEducators.Location = new System.Drawing.Point(1730, 468);
            this.deleteEducators.Name = "deleteEducators";
            this.deleteEducators.Size = new System.Drawing.Size(119, 40);
            this.deleteEducators.TabIndex = 68;
            this.deleteEducators.Text = "Удалить";
            this.deleteEducators.UseVisualStyleBackColor = true;
            this.deleteEducators.Click += new System.EventHandler(this.deleteEducators_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label32.Location = new System.Drawing.Point(1575, 546);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(251, 20);
            this.label32.TabIndex = 69;
            this.label32.Text = "Редактирование аудиторий:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(1576, 587);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(55, 17);
            this.label33.TabIndex = 70;
            this.label33.Text = "Номер:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(1576, 615);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(127, 17);
            this.label34.TabIndex = 71;
            this.label34.Text = "Вместительность:";
            // 
            // numAudAud
            // 
            this.numAudAud.Location = new System.Drawing.Point(1709, 584);
            this.numAudAud.Name = "numAudAud";
            this.numAudAud.Size = new System.Drawing.Size(169, 22);
            this.numAudAud.TabIndex = 72;
            // 
            // capAud
            // 
            this.capAud.Location = new System.Drawing.Point(1709, 612);
            this.capAud.Name = "capAud";
            this.capAud.Size = new System.Drawing.Size(169, 22);
            this.capAud.TabIndex = 73;
            // 
            // addAuditoriums
            // 
            this.addAuditoriums.Location = new System.Drawing.Point(1592, 653);
            this.addAuditoriums.Name = "addAuditoriums";
            this.addAuditoriums.Size = new System.Drawing.Size(119, 40);
            this.addAuditoriums.TabIndex = 74;
            this.addAuditoriums.Text = "Добавить";
            this.addAuditoriums.UseVisualStyleBackColor = true;
            this.addAuditoriums.Click += new System.EventHandler(this.addAuditoriums_Click);
            // 
            // deleteAuditoriums
            // 
            this.deleteAuditoriums.Location = new System.Drawing.Point(1730, 653);
            this.deleteAuditoriums.Name = "deleteAuditoriums";
            this.deleteAuditoriums.Size = new System.Drawing.Size(119, 40);
            this.deleteAuditoriums.TabIndex = 75;
            this.deleteAuditoriums.Text = "Удалить";
            this.deleteAuditoriums.UseVisualStyleBackColor = true;
            this.deleteAuditoriums.Click += new System.EventHandler(this.deleteAuditoriums_Click);
            // 
            // dataGroups
            // 
            this.dataGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGroups.Location = new System.Drawing.Point(360, 520);
            this.dataGroups.Name = "dataGroups";
            this.dataGroups.RowHeadersWidth = 51;
            this.dataGroups.RowTemplate.Height = 24;
            this.dataGroups.Size = new System.Drawing.Size(493, 150);
            this.dataGroups.TabIndex = 37;
            // 
            // FormSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.deleteAuditoriums);
            this.Controls.Add(this.addAuditoriums);
            this.Controls.Add(this.capAud);
            this.Controls.Add(this.numAudAud);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.deleteEducators);
            this.Controls.Add(this.addEducators);
            this.Controls.Add(this.timeEducator);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.numDepEducator);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.positionEducator);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.nameEducator);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.deleteGroups);
            this.Controls.Add(this.addGroups);
            this.Controls.Add(this.countStudGroup);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.specGroup);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.numGroupGroup);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.deleteCurriculum);
            this.Controls.Add(this.addCurriculum);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.typeDiscpCurric);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.timeCurric);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.discpCurric);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.dataAuditoriums);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.dataGroups);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.dataEducators);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dataCurriculum);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.generation);
            this.Controls.Add(this.find);
            this.Controls.Add(this.findEducator);
            this.Controls.Add(this.findDay);
            this.Controls.Add(this.findGroup);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.deleteSchedule);
            this.Controls.Add(this.addSchedule);
            this.Controls.Add(this.EducatorAD);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.NumAudAD);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TypeDiscpAD);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DisciplineAD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.NumPairAD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DayAD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GroupsAD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataSchedule);
            this.Name = "FormSchedule";
            this.Text = "Расписание занятий";
            this.Load += new System.EventHandler(this.FormSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataCurriculum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataEducators)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataAuditoriums)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGroups)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataSchedule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox GroupsAD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox DayAD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox NumPairAD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox DisciplineAD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox TypeDiscpAD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox NumAudAD;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox EducatorAD;
        private System.Windows.Forms.Button addSchedule;
        private System.Windows.Forms.Button deleteSchedule;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox findGroup;
        private System.Windows.Forms.ComboBox findDay;
        private System.Windows.Forms.ComboBox findEducator;
        private System.Windows.Forms.Button find;
        private System.Windows.Forms.Button generation;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dataCurriculum;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dataEducators;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridView dataAuditoriums;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox discpCurric;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox timeCurric;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox typeDiscpCurric;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button addCurriculum;
        private System.Windows.Forms.Button deleteCurriculum;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox numGroupGroup;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox specGroup;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox countStudGroup;
        private System.Windows.Forms.Button addGroups;
        private System.Windows.Forms.Button deleteGroups;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox nameEducator;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox positionEducator;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox numDepEducator;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox timeEducator;
        private System.Windows.Forms.Button addEducators;
        private System.Windows.Forms.Button deleteEducators;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox numAudAud;
        private System.Windows.Forms.TextBox capAud;
        private System.Windows.Forms.Button addAuditoriums;
        private System.Windows.Forms.Button deleteAuditoriums;
        private System.Windows.Forms.DataGridView dataGroups;
    }
}

