namespace SomerenUI
{
    partial class ModifyStudentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxStudentID = new System.Windows.Forms.TextBox();
            textBoxStudentPhoneNumber = new System.Windows.Forms.TextBox();
            btnSubmitNewStudent = new System.Windows.Forms.Button();
            btnUpdateStudent = new System.Windows.Forms.Button();
            btnDeleteStudent = new System.Windows.Forms.Button();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            textBoxStudentFirstName = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            textBoxStudentLastName = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            textBoxStudentClass = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            comboBoxStudentRoom = new System.Windows.Forms.ComboBox();
            SuspendLayout();
            // 
            // textBoxStudentID
            // 
            textBoxStudentID.Location = new System.Drawing.Point(372, 40);
            textBoxStudentID.Name = "textBoxStudentID";
            textBoxStudentID.Size = new System.Drawing.Size(263, 31);
            textBoxStudentID.TabIndex = 18;
            // 
            // textBoxStudentPhoneNumber
            // 
            textBoxStudentPhoneNumber.Location = new System.Drawing.Point(372, 225);
            textBoxStudentPhoneNumber.Name = "textBoxStudentPhoneNumber";
            textBoxStudentPhoneNumber.Size = new System.Drawing.Size(263, 31);
            textBoxStudentPhoneNumber.TabIndex = 17;
            // 
            // btnSubmitNewStudent
            // 
            btnSubmitNewStudent.Location = new System.Drawing.Point(491, 452);
            btnSubmitNewStudent.Name = "btnSubmitNewStudent";
            btnSubmitNewStudent.Size = new System.Drawing.Size(144, 53);
            btnSubmitNewStudent.TabIndex = 14;
            btnSubmitNewStudent.Text = "SUBMIT";
            btnSubmitNewStudent.UseVisualStyleBackColor = true;
            btnSubmitNewStudent.Click += btnSubmitNewStudent_Click;
            // 
            // btnUpdateStudent
            // 
            btnUpdateStudent.Location = new System.Drawing.Point(328, 452);
            btnUpdateStudent.Name = "btnUpdateStudent";
            btnUpdateStudent.Size = new System.Drawing.Size(144, 53);
            btnUpdateStudent.TabIndex = 15;
            btnUpdateStudent.Text = "UPDATE";
            btnUpdateStudent.UseVisualStyleBackColor = true;
            btnUpdateStudent.Click += btnUpdateStudent_Click;
            // 
            // btnDeleteStudent
            // 
            btnDeleteStudent.Location = new System.Drawing.Point(165, 452);
            btnDeleteStudent.Name = "btnDeleteStudent";
            btnDeleteStudent.Size = new System.Drawing.Size(144, 53);
            btnDeleteStudent.TabIndex = 16;
            btnDeleteStudent.Text = "DELETE";
            btnDeleteStudent.UseVisualStyleBackColor = true;
            btnDeleteStudent.Click += btnDeleteStudent_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(166, 231);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(143, 25);
            label4.TabIndex = 13;
            label4.Text = "Phone number : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(166, 111);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(103, 25);
            label2.TabIndex = 11;
            label2.Text = "First name :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(166, 46);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(105, 25);
            label1.TabIndex = 10;
            label1.Text = "Student ID :";
            // 
            // textBoxStudentFirstName
            // 
            textBoxStudentFirstName.Location = new System.Drawing.Point(372, 105);
            textBoxStudentFirstName.Name = "textBoxStudentFirstName";
            textBoxStudentFirstName.Size = new System.Drawing.Size(263, 31);
            textBoxStudentFirstName.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(166, 173);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(103, 25);
            label3.TabIndex = 11;
            label3.Text = "First name :";
            // 
            // textBoxStudentLastName
            // 
            textBoxStudentLastName.Location = new System.Drawing.Point(372, 167);
            textBoxStudentLastName.Name = "textBoxStudentLastName";
            textBoxStudentLastName.Size = new System.Drawing.Size(263, 31);
            textBoxStudentLastName.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(166, 298);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(61, 25);
            label5.TabIndex = 13;
            label5.Text = "Class :";
            // 
            // textBoxStudentClass
            // 
            textBoxStudentClass.Location = new System.Drawing.Point(372, 292);
            textBoxStudentClass.Name = "textBoxStudentClass";
            textBoxStudentClass.Size = new System.Drawing.Size(263, 31);
            textBoxStudentClass.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(166, 363);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(136, 25);
            label6.TabIndex = 13;
            label6.Text = "Room number :";
            // 
            // comboBoxStudentRoom
            // 
            comboBoxStudentRoom.FormattingEnabled = true;
            comboBoxStudentRoom.Location = new System.Drawing.Point(372, 363);
            comboBoxStudentRoom.Name = "comboBoxStudentRoom";
            comboBoxStudentRoom.Size = new System.Drawing.Size(263, 33);
            comboBoxStudentRoom.TabIndex = 19;
            comboBoxStudentRoom.SelectedIndexChanged += comboBoxStudentRoom_SelectedIndexChanged;
            // 
            // ModifyStudentForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(865, 549);
            Controls.Add(comboBoxStudentRoom);
            Controls.Add(textBoxStudentID);
            Controls.Add(textBoxStudentLastName);
            Controls.Add(textBoxStudentFirstName);
            Controls.Add(textBoxStudentClass);
            Controls.Add(textBoxStudentPhoneNumber);
            Controls.Add(btnSubmitNewStudent);
            Controls.Add(btnUpdateStudent);
            Controls.Add(btnDeleteStudent);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ModifyStudentForm";
            Text = "Modify Student Form";
            Load += ModifyStudentForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public System.Windows.Forms.TextBox textBoxStudentID;
        public System.Windows.Forms.TextBox textBoxStudentPhoneNumber;
        private System.Windows.Forms.Button btnSubmitNewStudent;
        private System.Windows.Forms.Button btnUpdateStudent;
        private System.Windows.Forms.Button btnDeleteStudent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxStudentFirstName;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBoxStudentLastName;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textBoxStudentClass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxStudentRoom;
    }
}