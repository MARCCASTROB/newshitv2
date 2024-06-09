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
    public partial class ModifyLectureForm : Form
    {
        LectureService lectureService;
        protected Lecture selectedLecture;

        public ModifyLectureForm(bool enableDeleteAndUpdate, bool enableSubmit)
        {
            InitializeComponent();

            RoomService roomService = new RoomService();
            foreach (var room in roomService.GetRooms())
            {
                comboBoxLectureRoom.Items.Add(room.RoomNumber);
            }

            lectureService = new LectureService();

            btnDeleteLecture.Enabled = enableDeleteAndUpdate;
            btnUpdateLecture.Enabled = enableDeleteAndUpdate;
            btnSubmitNewLecture.Enabled = enableSubmit;
        }

        public ModifyLectureForm(bool enableDeleteAndUpdate, bool enableSubmit, Lecture selectedLecture)
            : this(enableDeleteAndUpdate, enableSubmit)
        {
            this.selectedLecture = selectedLecture;
            LoadSelectedLectureData(selectedLecture);
        }


        private void LoadSelectedLectureData(Lecture selectedLecture)
        {
            textBoxLectureID.Text = selectedLecture.LectureID.ToString();
            textBoxLectureFirstName.Text = selectedLecture.FirstName.ToString();
            textBoxLectureLastName.Text = selectedLecture.LastName.ToString();
            textBoxLecturePhone.Text = selectedLecture.PhoneNumber.ToString();
            textBoxLectureAge.Text = selectedLecture.Age.ToString();
            comboBoxLectureRoom.SelectedItem = selectedLecture.RoomNumber.ToString();
        }

        private void btnUpdateLecture_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteLecture_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmitNewLecture_Click(object sender, EventArgs e)
        {

        }


        private void ModifyLectureForm_Load(object sender, EventArgs e)
        {

        }

        private void ModifyLectureForm_Leave(object sender, EventArgs e)
        {

        }
    }
}
