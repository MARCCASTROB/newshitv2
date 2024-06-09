namespace SomerenUI
{
    partial class ModifyInventory
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
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            btnDeleteDrink = new System.Windows.Forms.Button();
            textBoxAmountInStock = new System.Windows.Forms.TextBox();
            textBoxDrinkName = new System.Windows.Forms.TextBox();
            textBoxPrice = new System.Windows.Forms.TextBox();
            btnUpdateDrink = new System.Windows.Forms.Button();
            btnSubmitNewDrink = new System.Windows.Forms.Button();
            checkBoxAlcoholic = new System.Windows.Forms.CheckBox();
            checkBoxNonAlcoholic = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(205, 102);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(112, 25);
            label1.TabIndex = 0;
            label1.Text = "Drink name :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(205, 180);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(58, 25);
            label2.TabIndex = 1;
            label2.Text = "Price :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(205, 256);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(123, 25);
            label3.TabIndex = 2;
            label3.Text = "Choose Type :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(205, 330);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(134, 25);
            label4.TabIndex = 3;
            label4.Text = "Stock quantity :";
            // 
            // btnDeleteDrink
            // 
            btnDeleteDrink.Location = new System.Drawing.Point(204, 413);
            btnDeleteDrink.Name = "btnDeleteDrink";
            btnDeleteDrink.Size = new System.Drawing.Size(144, 53);
            btnDeleteDrink.TabIndex = 4;
            btnDeleteDrink.Text = "DELETE";
            btnDeleteDrink.UseVisualStyleBackColor = true;
            btnDeleteDrink.Click += btnDeleteDrink_Click;
            // 
            // textBoxAmountInStock
            // 
            textBoxAmountInStock.Location = new System.Drawing.Point(411, 324);
            textBoxAmountInStock.Name = "textBoxAmountInStock";
            textBoxAmountInStock.Size = new System.Drawing.Size(263, 31);
            textBoxAmountInStock.TabIndex = 5;
            // 
            // textBoxDrinkName
            // 
            textBoxDrinkName.Location = new System.Drawing.Point(411, 96);
            textBoxDrinkName.Name = "textBoxDrinkName";
            textBoxDrinkName.Size = new System.Drawing.Size(263, 31);
            textBoxDrinkName.TabIndex = 6;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new System.Drawing.Point(411, 174);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.PlaceholderText = "example 1,20 or 12.50,00";
            textBoxPrice.Size = new System.Drawing.Size(263, 31);
            textBoxPrice.TabIndex = 7;
            textBoxPrice.TextChanged += textBoxPrice_TextChanged;
            // 
            // btnUpdateDrink
            // 
            btnUpdateDrink.Location = new System.Drawing.Point(367, 413);
            btnUpdateDrink.Name = "btnUpdateDrink";
            btnUpdateDrink.Size = new System.Drawing.Size(144, 53);
            btnUpdateDrink.TabIndex = 4;
            btnUpdateDrink.Text = "UPDATE";
            btnUpdateDrink.UseVisualStyleBackColor = true;
            btnUpdateDrink.Click += btnUpdateDrink_Click_1;
            // 
            // btnSubmitNewDrink
            // 
            btnSubmitNewDrink.Location = new System.Drawing.Point(530, 413);
            btnSubmitNewDrink.Name = "btnSubmitNewDrink";
            btnSubmitNewDrink.Size = new System.Drawing.Size(144, 53);
            btnSubmitNewDrink.TabIndex = 4;
            btnSubmitNewDrink.Text = "SUBMIT";
            btnSubmitNewDrink.UseVisualStyleBackColor = true;
            btnSubmitNewDrink.Click += btnSubmitNewDrink_Click;
            // 
            // checkBoxAlcoholic
            // 
            checkBoxAlcoholic.AutoSize = true;
            checkBoxAlcoholic.Location = new System.Drawing.Point(411, 252);
            checkBoxAlcoholic.Name = "checkBoxAlcoholic";
            checkBoxAlcoholic.Size = new System.Drawing.Size(110, 29);
            checkBoxAlcoholic.TabIndex = 9;
            checkBoxAlcoholic.Text = "Alcoholic";
            checkBoxAlcoholic.UseVisualStyleBackColor = true;
            checkBoxAlcoholic.CheckedChanged += checkBoxAlcoholic_CheckedChanged;
            // 
            // checkBoxNonAlcoholic
            // 
            checkBoxNonAlcoholic.AutoSize = true;
            checkBoxNonAlcoholic.Location = new System.Drawing.Point(525, 255);
            checkBoxNonAlcoholic.Name = "checkBoxNonAlcoholic";
            checkBoxNonAlcoholic.Size = new System.Drawing.Size(149, 29);
            checkBoxNonAlcoholic.TabIndex = 9;
            checkBoxNonAlcoholic.Text = "Non Alcoholic";
            checkBoxNonAlcoholic.UseVisualStyleBackColor = true;
            checkBoxNonAlcoholic.CheckedChanged += checkBoxNonAlcoholic_CheckedChanged;
            // 
            // ModifyInventory
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(891, 555);
            Controls.Add(checkBoxNonAlcoholic);
            Controls.Add(checkBoxAlcoholic);
            Controls.Add(textBoxPrice);
            Controls.Add(textBoxDrinkName);
            Controls.Add(textBoxAmountInStock);
            Controls.Add(btnSubmitNewDrink);
            Controls.Add(btnUpdateDrink);
            Controls.Add(btnDeleteDrink);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ModifyInventory";
            Text = "Modify Drink Form";
            Load += ModifyInventory_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDeleteDrink;
        private System.Windows.Forms.Button btnUpdateDrink;
        private System.Windows.Forms.Button btnSubmitNewDrink;
        public System.Windows.Forms.TextBox textBoxAmountInStock;
        public System.Windows.Forms.TextBox textBoxDrinkName;
        public System.Windows.Forms.TextBox textBoxPrice;
        public System.Windows.Forms.CheckBox checkBoxAlcoholic;
        public System.Windows.Forms.CheckBox checkBoxNonAlcoholic;
    }
}