namespace SomerenUI
{
    partial class ModifyLectureForm
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
            textBoxLectureID = new System.Windows.Forms.TextBox();
            textBoxLectureLastName = new System.Windows.Forms.TextBox();
            textBoxLectureFirstName = new System.Windows.Forms.TextBox();
            textBoxLectureAge = new System.Windows.Forms.TextBox();
            textBoxLecturePhone = new System.Windows.Forms.TextBox();
            btnSubmitNewLecture = new System.Windows.Forms.Button();
            btnUpdateLecture = new System.Windows.Forms.Button();
            btnDeleteLecture = new System.Windows.Forms.Button();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            comboBoxLectureRoom = new System.Windows.Forms.ComboBox();
            SuspendLayout();
            // 
            // textBoxLectureID
            // 
            textBoxLectureID.Location = new System.Drawing.Point(366, 60);
            textBoxLectureID.Name = "textBoxLectureID";
            textBoxLectureID.Size = new System.Drawing.Size(263, 31);
            textBoxLectureID.TabIndex = 33;
            // 
            // textBoxLectureLastName
            // 
            textBoxLectureLastName.Location = new System.Drawing.Point(366, 187);
            textBoxLectureLastName.Name = "textBoxLectureLastName";
            textBoxLectureLastName.Size = new System.Drawing.Size(263, 31);
            textBoxLectureLastName.TabIndex = 28;
            // 
            // textBoxLectureFirstName
            // 
            textBoxLectureFirstName.Location = new System.Drawing.Point(366, 125);
            textBoxLectureFirstName.Name = "textBoxLectureFirstName";
            textBoxLectureFirstName.Size = new System.Drawing.Size(263, 31);
            textBoxLectureFirstName.TabIndex = 29;
            // 
            // textBoxLectureAge
            // 
            textBoxLectureAge.Location = new System.Drawing.Point(366, 255);
            textBoxLectureAge.Name = "textBoxLectureAge";
            textBoxLectureAge.Size = new System.Drawing.Size(263, 31);
            textBoxLectureAge.TabIndex = 31;
            // 
            // textBoxLecturePhone
            // 
            textBoxLecturePhone.Location = new System.Drawing.Point(366, 319);
            textBoxLecturePhone.Name = "textBoxLecturePhone";
            textBoxLecturePhone.Size = new System.Drawing.Size(263, 31);
            textBoxLecturePhone.TabIndex = 32;
            // 
            // btnSubmitNewLecture
            // 
            btnSubmitNewLecture.Location = new System.Drawing.Point(485, 472);
            btnSubmitNewLecture.Name = "btnSubmitNewLecture";
            btnSubmitNewLecture.Size = new System.Drawing.Size(144, 53);
            btnSubmitNewLecture.TabIndex = 25;
            btnSubmitNewLecture.Text = "SUBMIT";
            btnSubmitNewLecture.UseVisualStyleBackColor = true;
            btnSubmitNewLecture.Click += btnSubmitNewLecture_Click;
            // 
            // btnUpdateLecture
            // 
            btnUpdateLecture.Location = new System.Drawing.Point(322, 472);
            btnUpdateLecture.Name = "btnUpdateLecture";
            btnUpdateLecture.Size = new System.Drawing.Size(144, 53);
            btnUpdateLecture.TabIndex = 26;
            btnUpdateLecture.Text = "UPDATE";
            btnUpdateLecture.UseVisualStyleBackColor = true;
            btnUpdateLecture.Click += btnUpdateLecture_Click;
            // 
            // btnDeleteLecture
            // 
            btnDeleteLecture.Location = new System.Drawing.Point(159, 472);
            btnDeleteLecture.Name = "btnDeleteLecture";
            btnDeleteLecture.Size = new System.Drawing.Size(144, 53);
            btnDeleteLecture.TabIndex = 27;
            btnDeleteLecture.Text = "DELETE";
            btnDeleteLecture.UseVisualStyleBackColor = true;
            btnDeleteLecture.Click += btnDeleteLecture_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(160, 383);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(136, 25);
            label6.TabIndex = 22;
            label6.Text = "Room number :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(160, 261);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(53, 25);
            label5.TabIndex = 23;
            label5.Text = "Age :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(160, 193);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(103, 25);
            label3.TabIndex = 20;
            label3.Text = "First name :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(160, 325);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(143, 25);
            label4.TabIndex = 24;
            label4.Text = "Phone number : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(160, 131);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(103, 25);
            label2.TabIndex = 21;
            label2.Text = "First name :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(160, 66);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(100, 25);
            label1.TabIndex = 19;
            label1.Text = "Lecture ID :";
            // 
            // comboBoxLectureRoom
            // 
            comboBoxLectureRoom.FormattingEnabled = true;
            comboBoxLectureRoom.Location = new System.Drawing.Point(366, 382);
            comboBoxLectureRoom.Name = "comboBoxLectureRoom";
            comboBoxLectureRoom.Size = new System.Drawing.Size(263, 33);
            comboBoxLectureRoom.TabIndex = 34;
            // 
            // ModifyLectureForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 563);
            Controls.Add(comboBoxLectureRoom);
            Controls.Add(textBoxLectureID);
            Controls.Add(textBoxLectureLastName);
            Controls.Add(textBoxLectureFirstName);
            Controls.Add(textBoxLectureAge);
            Controls.Add(textBoxLecturePhone);
            Controls.Add(btnSubmitNewLecture);
            Controls.Add(btnUpdateLecture);
            Controls.Add(btnDeleteLecture);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ModifyLectureForm";
            Text = "Modify Lecture Form";
            Load += ModifyLectureForm_Load;
            Leave += ModifyLectureForm_Leave;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public System.Windows.Forms.TextBox textBoxLectureID;
        public System.Windows.Forms.TextBox textBoxLectureLastName;
        public System.Windows.Forms.TextBox textBoxLectureFirstName;
        public System.Windows.Forms.TextBox textBoxLectureAge;
        public System.Windows.Forms.TextBox textBoxLecturePhone;
        private System.Windows.Forms.Button btnSubmitNewLecture;
        private System.Windows.Forms.Button btnUpdateLecture;
        private System.Windows.Forms.Button btnDeleteLecture;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxLectureRoom;
    }
}