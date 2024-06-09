using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenService
{
    public class DrinkSupplyService
    {
        public DrinkDao DrinkDao;
        public DrinkSupplyService() 
        {
           DrinkDao = new DrinkDao();
        }

        public List<Drink> GetDrinks()
        {
            List<Drink> drinksList = DrinkDao.GetAllDrinks();
            return drinksList;
        }

        public void CreateDrink(Drink newDrink)
        {
            DrinkDao.CreateNewDrink(newDrink);
        }

        public void UpdateDrink(Drink oldDrink, Drink updateDrink)
        {
            DrinkDao.UpdateDrinkData(oldDrink, updateDrink);
        }

        public void DeleteDrink(Drink drinkToDelete)
        {
            DrinkDao.DeleteDrinkData(drinkToDelete);
        }
    }
}
