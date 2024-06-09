using SomerenModel;
using SomerenService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class ModifyStudentForm : Form
    {
        StudentService studentService;
        protected Student selectedStudent;

        public ModifyStudentForm(bool enableDeleteAndUpdate, bool enableSubmit)
        {
            InitializeComponent();

            RoomService roomService = new RoomService();
            foreach (var room in roomService.GetRooms())
            {
                comboBoxStudentRoom.Items.Add(room.RoomNumber);
            }

            studentService = new StudentService();

            btnDeleteStudent.Enabled = enableDeleteAndUpdate;
            btnUpdateStudent.Enabled = enableDeleteAndUpdate;
            btnSubmitNewStudent.Enabled = enableSubmit;
        }

        public ModifyStudentForm(bool enableDeleteAndUpdate, bool enableSubmit, Student selectedStudent)
            : this(enableDeleteAndUpdate, enableSubmit)
        {
            this.selectedStudent = selectedStudent;
            LoadSelectedStudentData(selectedStudent);
        }

        private void ModifyStudentForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadSelectedStudentData(Student selectedStudent)
        {
            textBoxStudentID.Text = selectedStudent.StudentId.ToString();
            textBoxStudentFirstName.Text = selectedStudent.FirstName.ToString();
            textBoxStudentLastName.Text = selectedStudent.LastName.ToString();
            textBoxStudentPhoneNumber.Text = selectedStudent.PhoneNumber.ToString();
            textBoxStudentClass.Text = selectedStudent.Class.ToString();
            comboBoxStudentRoom.SelectedItem = selectedStudent.RoomNumber.ToString();
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {

        }


        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmitNewStudent_Click(object sender, EventArgs e)
        {


        }


        private void comboBoxStudentRoom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
