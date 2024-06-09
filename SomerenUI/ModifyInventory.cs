using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SomerenModel;
using SomerenService;
using static System.Windows.Forms.LinkLabel;

namespace SomerenUI
{
    public partial class ModifyInventory : Form
    {
        DrinkSupplyService drinkSuppliesService;
        protected Drink selectedDrink;

        public ModifyInventory(bool enableDeleteAndUpdate, bool enableSubmit)
        {
            InitializeComponent();

            drinkSuppliesService = new DrinkSupplyService();

            btnDeleteDrink.Enabled = enableDeleteAndUpdate;
            btnUpdateDrink.Enabled = enableDeleteAndUpdate;
            btnSubmitNewDrink.Enabled = enableSubmit;
        }

        public ModifyInventory(bool enableDeleteAndUpdate, bool enableSubmit, Drink selectedDrink)
            : this(enableDeleteAndUpdate, enableSubmit)
        {
            this.selectedDrink = selectedDrink;
            LoadSelectedDrinkData(selectedDrink);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddDrink_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateDrink_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmitNewDrink_Click(object sender, EventArgs e)
        {
            string DrinkName = textBoxDrinkName.Text;
            decimal Price = decimal.Parse(textBoxPrice.Text);
            string VATtype = "";
            int AmountInStock = int.Parse(textBoxAmountInStock.Text);

            if (checkBoxAlcoholic.Checked)
            {
                VATtype = "21";
            }
            else if (checkBoxNonAlcoholic.Checked)
            {
                VATtype = "9";
            }

            Drink drink = new Drink(0, DrinkName, Price, VATtype, AmountInStock);
            drinkSuppliesService.CreateDrink(drink);

            textBoxDrinkName.Text = "";
            textBoxPrice.Text = "";
            textBoxAmountInStock.Text = "";
            checkBoxAlcoholic.Checked = false;
            checkBoxNonAlcoholic.Checked = false;

            MessageBox.Show($"{DrinkName} is added!");
        }

        private void checkBoxAlcoholic_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAlcoholic.Checked)
            {
                checkBoxNonAlcoholic.Checked = false;
            }
        }

        private void checkBoxNonAlcoholic_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNonAlcoholic.Checked)
            {
                checkBoxAlcoholic.Checked = false;
            }
        }

        private void btnUpdateDrink_Click_1(object sender, EventArgs e)
        {
            UpdateDrink();

        }

        private void ModifyInventory_Load(object sender, EventArgs e)
        {

        }

        private void LoadSelectedDrinkData(Drink selectedDrink)
        {
            if (selectedDrink.VATtype == "Non Alcoholic") //vat 9
            {
                checkBoxNonAlcoholic.Checked = true;
                checkBoxAlcoholic.Checked = false;
            }
            else if (selectedDrink.VATtype == "Alcoholic") //vat 21
            {
                checkBoxAlcoholic.Checked = true;
                checkBoxNonAlcoholic.Checked = false;
            }

            textBoxDrinkName.Text = selectedDrink.DrinkName.ToString();
            textBoxPrice.Text = selectedDrink.Price.ToString();
            textBoxAmountInStock.Text = selectedDrink.AmountInStock.ToString();
        }

        private void UpdateDrink()
        {
            string VATtype = "";
            if (checkBoxAlcoholic.Checked)
            {
                VATtype = "21";
            }
            else if (checkBoxNonAlcoholic.Checked)
            {
                VATtype = "9";
            }

            Drink updatedDrink = new Drink(
               // selectedDrink.DrinkID,
               textBoxDrinkName.Text.ToString(),
               decimal.Parse(textBoxPrice.Text),
               VATtype.ToString(),
               int.Parse(textBoxAmountInStock.Text));

            drinkSuppliesService.UpdateDrink(selectedDrink, updatedDrink);
            MessageBox.Show("Drink updated!");
        }

        private void btnDeleteDrink_Click(object sender, EventArgs e)
        {
            DeleteDrink();
        }

        public void DeleteDrink()
        {
            drinkSuppliesService.DeleteDrink(selectedDrink);
            MessageBox.Show("Drink deleted!");
        }

        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
