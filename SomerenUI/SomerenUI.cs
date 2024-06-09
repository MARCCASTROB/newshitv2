using SomerenService;
using SomerenModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System;
using System.Xml.Linq;
using static System.Windows.Forms.LinkLabel;

namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            InitializeComponent();

            ShowDashboardPanel();
        }

        private void ShowDashboardPanel()
        {
            HideAllPanels();

            pnlDashboard.Show();
        }

        private void ShowLecturePanel()
        {
            HideAllPanels();

            pnlLectures.Show();

            try
            {
                List<Lecture> lectures = GetLectures();
                DisplayLectures(lectures);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the lectures: " + e.Message);
            }
        }

        private void ShowRoomPanel()
        {
            HideAllPanels();

            pnlRoom.Show();

            try
            {
                List<Room> rooms = GetRooms();
                DisplayRooms(rooms);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the rooms: " + e.Message);
            }
        }

        private void ShowActivityPanel()
        {
            HideAllPanels();

            pnlActivities.Show();

            try
            {
                List<Activity> activities = GetActivities();
                DisplayActivities(activities);

                List<Student> students = GetStudents();
                List<Lecture> lectures = GetLectures();

                comboBoxSupervisors.SelectedItem = null;
                comboBoxParticipators.SelectedItem = null;
                listBoxParticipators.Items.Clear();
                listBoxSupervisors.Items.Clear();
                comboBoxParticipators.Items.Clear();
                comboBoxSupervisors.Items.Clear();

                foreach (Student student in students)
                {
                    if (!listBoxParticipators.Items.Contains(student))
                    {
                        comboBoxParticipators.Items.Add(student);
                    }
                }

                foreach (Lecture lecture in lectures)
                {
                    if (!listBoxSupervisors.Items.Contains(lecture))
                    {
                        comboBoxSupervisors.Items.Add(lecture);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the activities: " + e.Message);
            }
        }

        private void ShowStudentsPanel()
        {
            HideAllPanels();

            pnlStudents.Show();

            try
            {
                List<Student> students = GetStudents();
                DisplayStudents(students);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the students: " + e.Message);
            }
        }

        private void ShowInventoryPanel()
        {
            HideAllPanels();

            pnlDrinkInventory.Show();

            try
            {
                List<Drink> drinks = GetDrinks();
                DisplayDrinks(drinks);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the drinks: " + e.Message);
            }
        }

        private void ShowOrdersPanel()
        {
            HideAllPanels();
            pnlOrderDrinks.Show();

            try
            {

            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the students or drinks: " + e.Message);
            }
        }

        private void ShowRevenueReport()
        {
            HideAllPanels();
            pnlRevenueReport.Show();
            ClearRevenueSalesPanel();
        }

        private void ShowTaxReport()
        {
            HideAllPanels();
            pnlTaxReport.Show();
            comboBoxTaxYears.Items.Clear();
            ClearTaxReportPanel(true);

            TaxReportService taxReportService = new TaxReportService();

            try
            {
                foreach (var year in taxReportService.GetAllOrderYears())
                {
                    comboBoxTaxYears.Items.Add(year);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the years: " + e.Message);
            }
        }

        private List<Student> GetStudents()
        {
            StudentService studentService = new StudentService();
            List<Student> students = studentService.GetStudents();
            return students;
        }

        private List<Lecture> GetLectures()
        {
            LectureService lectureService = new LectureService();
            List<Lecture> lecturesList = lectureService.GetLectures();
            return lecturesList;
        }

        private List<Activity> GetActivities()
        {
            ActivityService activityService = new ActivityService();
            List<Activity> activityList = activityService.GetActivities();
            return activityList;
        }

        private List<ActivitySupervisors> GetActivitySupervisors(string activityID, DateTime activityDate)
        {
            ActivityService activityService = new ActivityService();
            List<ActivitySupervisors> activitySupervisorList = activityService.GetActivitySupervisors(activityID, activityDate);
            return activitySupervisorList;
        }

        private List<Room> GetRooms()
        {
            RoomService roomService = new RoomService();
            List<Room> roomsList = roomService.GetRooms();
            return roomsList;
        }

        private List<Drink> GetDrinks()
        {
            DrinkSupplyService drinkSuppliesService = new DrinkSupplyService();
            List<Drink> drinkList = drinkSuppliesService.GetDrinks();
            return drinkList;
        }

        private void DisplayDrinks(List<Drink> drinksList)
        {
            ListViewInventory.Items.Clear();

            foreach (Drink drink in drinksList)
            {
                ListViewItem listViewInventory = new ListViewItem(drink.DrinkID.ToString());
                listViewInventory.Tag = drink;

                listViewInventory.SubItems.Add(drink.DrinkName.ToString());
                listViewInventory.SubItems.Add(drink.VATtype.ToString());
                listViewInventory.SubItems.Add(drink.Price.ToString());
                listViewInventory.SubItems.Add(drink.AmountInStock.ToString());
                listViewInventory.SubItems.Add(drink.TotalConsumed.ToString());
                listViewInventory.SubItems.Add(drink.StockStatus.ToString());

                ListViewInventory.Items.Add(listViewInventory);
            }
        }

        private void DisplayStudents(List<Student> students)
        {
            listViewStudents.Items.Clear();
            foreach (Student student in students)
            {
                ListViewItem studentlistView = new ListViewItem(student.StudentId.ToString());
                studentlistView.Tag = student;   // links student object to listview item

                studentlistView.SubItems.Add(student.FirstName);
                studentlistView.SubItems.Add(student.LastName);
                studentlistView.SubItems.Add(student.PhoneNumber);
                studentlistView.SubItems.Add(student.Class);
                studentlistView.SubItems.Add(student.RoomNumber);

                listViewStudents.Items.Add(studentlistView);
            }
        }

        private void DisplayLectures(List<Lecture> lectures)
        {
            listViewLectures.Items.Clear();
            foreach (Lecture lecture in lectures)
            {
                ListViewItem lectureListView = new ListViewItem(lecture.LectureID.ToString());
                lectureListView.Tag = lecture;   // link lecture object to listview item

                lectureListView.SubItems.Add(lecture.FirstName);
                lectureListView.SubItems.Add(lecture.LastName);
                lectureListView.SubItems.Add(lecture.Age.ToString());
                lectureListView.SubItems.Add(lecture.PhoneNumber);
                lectureListView.SubItems.Add(lecture.RoomNumber);

                listViewLectures.Items.Add(lectureListView);
            }
        }

        private void DisplayActivities(List<Activity> activities)
        {
            listViewActivities.Items.Clear();
            foreach (Activity activity in activities)
            {
                ListViewItem activityListView = new ListViewItem(activity.ActivityID.ToString());
                activityListView.Tag = activity;

                activityListView.SubItems.Add(activity.ActivityName);
                activityListView.SubItems.Add(activity.Location);

                listViewActivities.Items.Add(activityListView);
            }
        }

        private void DisplayRooms(List<Room> rooms)
        {
            listViewRooms.Items.Clear();
            foreach (Room room in rooms)
            {
                ListViewItem roomListView = new ListViewItem(room.RoomNumber.ToString());
                roomListView.Tag = room;

                roomListView.SubItems.Add(room.RoomType);
                roomListView.SubItems.Add(room.NumberOfBeds.ToString());
                roomListView.SubItems.Add(room.FloorLevel.ToString());

                listViewRooms.Items.Add(roomListView);
            }
        }

        private void HideAllPanels()
        {
            pnlDashboard.Hide();
            pnlLectures.Hide();
            pnlActivities.Hide();
            pnlRoom.Hide();
            pnlDrinkInventory.Hide();
            pnlStudents.Hide();
            pnlOrderDrinks.Hide();
            pnlRevenueReport.Hide();
            pnlTaxReport.Hide();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            ShowDashboardPanel();
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowStudentsPanel();
        }

        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLecturePanel();
        }

        private void listViewStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pnlLectures_Paint(object sender, PaintEventArgs e)
        {

        }

        private void activitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowActivityPanel();
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowStudentsPanel();
        }

        private void pnlActivities_Paint(object sender, PaintEventArgs e)
        {

        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowRoomPanel();
        }

        private void pnlDrinkSupplies_Paint(object sender, PaintEventArgs e)
        {

        }

        private void drinkSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowInventoryPanel();
        }


        private void listView1_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void btnAddNewDrink_Click(object sender, EventArgs e)
        {
            ModifyInventory modifyInventory = new ModifyInventory(false, true);
            modifyInventory.Text = "NEW DRINK SUPPLY";
            modifyInventory.ShowDialog();
        }

        private void btnModifyDrink_Click(object sender, EventArgs e)
        {
            if (ListViewInventory.SelectedItems.Count > 0)
            {
                Drink selectedDrinkForModification = (Drink)ListViewInventory.SelectedItems[0].Tag;
                ModifyInventory modifyInventory = new ModifyInventory(true, false, selectedDrinkForModification);
                modifyInventory.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a drink to modify.");
            }
        }

        private void ModifyDrink(Drink drink)
        {
            ModifyInventory modifyInventory = new ModifyInventory(true, false, drink);
            modifyInventory.ShowDialog();
        }

        private void ListViewInventory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Drink selectedDrink = (Drink)ListViewInventory.SelectedItems[0].Tag;
            ModifyInventory modifyInventory = new ModifyInventory(true, false, selectedDrink);
            modifyInventory.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pnlDashboard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOrdersPanel();
        }

        private void listViewOrdersStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewOrdersDrinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelEnterPriceUpDown.Text = "0";
        }

        private void btnOrderDrink_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void listViewOrdersStudents_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void listViewOrdersDrinks_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void enterPriceUpDown_SelectedItemChanged(object sender, EventArgs e)
        {

        }


        private void revenueReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowRevenueReport();
        }

        private void taxReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTaxReport();

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxQ4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTaxQuarter4.Checked)
            {
                checkBoxTaxQuarter1.Checked = false;
                checkBoxTaxQuarter2.Checked = false;
                checkBoxTaxQuarter3.Checked = false;
            }
        }

        private void checkBoxTaxQuarter3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTaxQuarter3.Checked)
            {
                checkBoxTaxQuarter2.Checked = false;
                checkBoxTaxQuarter1.Checked = false;
                checkBoxTaxQuarter4.Checked = false;
            }
        }

        private void checkBoxTaxQuarter2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTaxQuarter2.Checked)
            {
                checkBoxTaxQuarter1.Checked = false;
                checkBoxTaxQuarter3.Checked = false;
                checkBoxTaxQuarter4.Checked = false;
            }
        }

        private void checkBoxTaxQuarter1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTaxQuarter1.Checked)
            {
                checkBoxTaxQuarter2.Checked = false;
                checkBoxTaxQuarter3.Checked = false;
                checkBoxTaxQuarter4.Checked = false;
            }
        }

        private void startDatePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void endDatePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnGenerateSales_Click(object sender, EventArgs e)
        {

            ClearRevenueSalesPanel();

        }

        private void comboBoxTaxYears_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pnlTaxReport_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGenerateTax_Click(object sender, EventArgs e)
        {
            if (comboBoxTaxYears.SelectedItem != null)
            {
                string yearInput = comboBoxTaxYears.SelectedItem.ToString();
                int year = int.Parse(yearInput);

                DisplayQuartalTaxDates(year);
            }
            else
            {
                MessageBox.Show("Please choose year");
            }
        }

        private void DisplayQuartalTaxDates(int year)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;

            if (year != 0)
            {
                ClearTaxReportPanel(false);

                if (checkBoxTaxQuarter1.Checked)
                {
                    startDate = new DateTime(year, 1, 01);
                    endDate = new DateTime(year, 3, 31);
                    labelQuarterDates.Text = $"Quarter 1: {startDate:yyyy-MM-dd} TO {endDate:yyyy-MM-dd}";

                }
                else if (checkBoxTaxQuarter2.Checked)
                {
                    startDate = new DateTime(year, 4, 01);
                    endDate = new DateTime(year, 6, 30);
                    labelQuarterDates.Text = $"Quarter 1: {startDate:yyyy-MM-dd} TO {endDate:yyyy-MM-dd}";
                }
                else if (checkBoxTaxQuarter3.Checked)
                {
                    startDate = new DateTime(year, 7, 01);
                    endDate = new DateTime(year, 9, 30);
                    labelQuarterDates.Text = $"Quarter 1: {startDate:yyyy-MM-dd} TO {endDate:yyyy-MM-dd}";
                }
                else if (checkBoxTaxQuarter4.Checked)
                {
                    startDate = new DateTime(year, 10, 01);
                    endDate = new DateTime(year, 12, 31);
                    labelQuarterDates.Text = $"Quarter 1: {startDate:yyyy-MM-dd} TO {endDate:yyyy-MM-dd}";
                }
                else
                {
                    MessageBox.Show("Select quartal");
                }

                DisplayOuartalTax2Pay(startDate, endDate);
            }
        }

        private void DisplayOuartalTax2Pay(DateTime startDate, DateTime endDate)
        {
            decimal salesVATpay6 = 0;
            decimal salesVATpay21 = 0;
            decimal totalsalesVATpayment = 0;

            TaxReportService taxReportService = new TaxReportService();
            List<TaxReport> vatlist = taxReportService.GetQuartalTaxReport(startDate, endDate);

            foreach (TaxReport taxReport in vatlist)
            {
                if (taxReport.VAT == "9")
                {
                    salesVATpay6 = taxReport.totalVAT2pay;
                    labelTaxPayable9.Text = $"{salesVATpay6:0.00} ";
                }
                else if (taxReport.VAT == "21")
                {
                    salesVATpay21 = taxReport.totalVAT2pay;
                    labelTaxPayable21.Text = $"{salesVATpay21:0.00} ";
                }
            }

            totalsalesVATpayment = salesVATpay6 + salesVATpay21;

            labelTaxPayableTotal.Text = $"{totalsalesVATpayment:0.00} ";
        }


        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void pnlRoom_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddLecture_MouseClick(object sender, MouseEventArgs e)
        {
            ModifyLectureForm modifyLectureForm = new ModifyLectureForm(false, true);

            modifyLectureForm.ShowDialog();
        }

        private void btnModifyLecture_MouseClick(object sender, MouseEventArgs e)
        {
            if (listViewLectures.SelectedItems.Count > 0)
            {
                Lecture selectedLectureForModification = (Lecture)listViewLectures.SelectedItems[0].Tag;
                ModifyLectureForm modifyLectureForm = new ModifyLectureForm(true, false, selectedLectureForModification);
                modifyLectureForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a Lecture to modify.");
            }
        }

        private void btnAddStudent_MouseClick(object sender, MouseEventArgs e)
        {
            ModifyStudentForm modifyStudentForm = new ModifyStudentForm(false, true);

            modifyStudentForm.ShowDialog();
        }

        private void btnModifyStudent_MouseClick(object sender, MouseEventArgs e)
        {
            if (listViewStudents.SelectedItems.Count > 0)
            {
                Student selectedStudentForModification = (Student)listViewStudents.SelectedItems[0].Tag;
                ModifyStudentForm modifyStudentForm = new ModifyStudentForm(true, false, selectedStudentForModification);
                modifyStudentForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a Student to modify.");
            }
        }

        private void pnlDrinkInventory_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void listViewActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxParticipators.Items.Clear();
            listBoxSupervisors.Items.Clear();

        }

        private void listBoxParticipators_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void listBoxSupervisors_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxParticipators_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxParticipators_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxSupervisors_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerActivity_ValueChanged(object sender, EventArgs e)
        {
            listBoxParticipators.Items.Clear();
            listBoxSupervisors.Items.Clear();
        }

        private void btnShowActivityEvents_Click(object sender, EventArgs e)
        {
            if (listViewActivities.SelectedItems.Count > 0)
            {
                DateTime date = dateTimePickerActivity.Value;
                Activity activity = (Activity)listViewActivities.SelectedItems[0].Tag;
                DisplayActivitySupervisors(activity.ActivityID, date);
                DisplayActivityParticipants(activity.ActivityID, date);
            }
            else
            {
                MessageBox.Show("Please select an activity.");
            }
        }

        private void btnAddSupervisors_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSupervisors.SelectedItem != null)
                {
                    DateTime date = dateTimePickerActivity.Value;
                    Activity activity = (Activity)listViewActivities.SelectedItems[0].Tag;
                    Lecture selectedLecture = (Lecture)comboBoxSupervisors.SelectedItem;
                    ActivityService activityService = new ActivityService();

                    List<ActivitySupervisors> activitySupervisorsList = activityService.GetActivitySupervisors(activity.ActivityID, date);

                    foreach (ActivitySupervisors activitySupervisor in activitySupervisorsList)
                    {
                        if (activitySupervisor.LectureID == selectedLecture.LectureID)
                        {
                            MessageBox.Show("Supervisor already added!");
                            return;
                        }
                    }
                    activityService.AddActivitySupervisor(selectedLecture, activity.ActivityID, date);
                    btnShowActivityEvents.PerformClick();
                }
                else
                {
                    MessageBox.Show("Please choose activity Supervisor to add");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("First select an activity and date");
            }
        }

        private void btnRemoveSupervisors_Click(object sender, EventArgs e)
        {
            if (listBoxSupervisors.SelectedItem != null)
            {

                DateTime date = dateTimePickerActivity.Value;
                Activity activity = (Activity)listViewActivities.SelectedItems[0].Tag;
                ActivitySupervisors selectedLecture = (ActivitySupervisors)listBoxSupervisors.SelectedItem;
                ActivityService activityService = new ActivityService();

                if (MessageBox.Show("Are you sure to remove Supervisor?", "Remove supervisor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    activityService.DeleteActivitySupervisor(selectedLecture.LectureID, activity.ActivityID, date);
                    btnShowActivityEvents.PerformClick();
                }
                else
                {
                    MessageBox.Show("Supervisor not removed", "Remove supervisor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select activity Supervisor to remove");
            }

        }

        private void btnAddParticipators_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxParticipators.SelectedItem != null)
                {
                    DateTime date = dateTimePickerActivity.Value;
                    Activity activity = (Activity)listViewActivities.SelectedItems[0].Tag;
                    Student selectedStudent = (Student)comboBoxParticipators.SelectedItem;
                    ActivityService activityService = new ActivityService();

                    List<ActivityParticipants> activityParticipantsList = activityService.GetActivityParticipatants(activity.ActivityID, date);

                    foreach (ActivityParticipants activityParticipant in activityParticipantsList)
                    {
                        if (activityParticipant.StudentID == selectedStudent.StudentId)
                        {
                            MessageBox.Show("Participant already added!");
                            return;
                        }
                    }
                    activityService.AddActivityParticipator(selectedStudent, activity.ActivityID, date);
                    btnShowActivityEvents.PerformClick();
                }
                else
                {
                    MessageBox.Show("Please select activity Participator to add");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("First select an activity and date");
            }
        }

        private void btnRemoveParticipators_Click(object sender, EventArgs e)
        {
            if (listBoxParticipators.SelectedItem != null)
            {
                DateTime date = dateTimePickerActivity.Value;
                Activity activity = (Activity)listViewActivities.SelectedItems[0].Tag;
                ActivityParticipants selectedStudent = (ActivityParticipants)listBoxParticipators.SelectedItem;
                ActivityService activityService = new ActivityService();

                if (MessageBox.Show("Are you sure to remove Participant?", "Remove Participant", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    activityService.DeleteActivityParticipator(selectedStudent.StudentID, activity.ActivityID, date);
                    btnShowActivityEvents.PerformClick();
                }
                else
                {
                    MessageBox.Show("Participant not removed", "Remove participant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select activity Participator to remove");
            }
        }

        private void DisplayActivityParticipants(string activityID, DateTime activityDate)
        {
            comboBoxParticipators.SelectedItem = null;
            ActivityService activityService = new ActivityService();
            List<ActivityParticipants> activityParticipantsList = activityService.GetActivityParticipatants(activityID, activityDate);

            listBoxParticipators.Items.Clear();

            foreach (ActivityParticipants activityParticipants in activityParticipantsList)
            {
                listBoxParticipators.Items.Add(activityParticipants);
            }
        }

        private void DisplayActivitySupervisors(string activityID, DateTime activityDate)
        {
            comboBoxSupervisors.SelectedItem = null;
            ActivityService activityService = new ActivityService();
            List<ActivitySupervisors> activitySupervisorsList = activityService.GetActivitySupervisors(activityID, activityDate);

            listBoxSupervisors.Items.Clear();

            foreach (ActivitySupervisors activitySupervisors in activitySupervisorsList)
            {
                listBoxSupervisors.Items.Add(activitySupervisors);
            }
        }

        private void checkBoxActivateAllDates_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxActivateAllDates.Checked == true)
            {
                startDatePicker.Enabled = true;
                endDatePicker.Enabled = true;
            }
            else
            {
                startDatePicker.Enabled = false;
                endDatePicker.Enabled = false;

                startDatePicker.Value = DateTime.Now;
                endDatePicker.Value = DateTime.Now;
            }
            ClearRevenueSalesPanel();
        }

        private void ClearRevenueSalesPanel()
        {
            labelTotalDrinksSold.Text = $" ";
            labelTotalTurnover.Text = $"€ ";
            labelTotalCustomers.Text = $" ";
        }

        private void ClearTaxReportPanel(bool quartalchecked)
        {
            labelQuarterDates.Text = null;
            labelTaxPayableTotal.Text = null;
            labelTaxPayableTotal.Text = null;
            labelTaxPayable9.Text = null;
            labelTaxPayable21.Text = null;

            if (quartalchecked == true)
            {
                checkBoxTaxQuarter1.Checked = false;
                checkBoxTaxQuarter2.Checked = false;
                checkBoxTaxQuarter3.Checked = false;
                checkBoxTaxQuarter4.Checked = false;
            }
        }

        private void pnlOrderDrinks_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {

        }
    }
}