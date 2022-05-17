using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_11_CofeeMachine
{
    /// <summary>
    /// Класс описывающий работу кофе машины.
    /// Содержит информацию о доступных ингредиентах и их количестве.
    /// Содержит логику приготовления различных напитков, использующих
    /// соответствующие ингредиенты в нужных пропорциях.
    /// </summary>
    public class CoffeeMachine
    {
        public string name;
        public int gramsOfCoffee = 0;
        public int gramsOfWater = 0;
        public int gramsOfMilk = 0;

        private Drink[] drinks;

        public CoffeeMachine(Drink[] drinks)
        {
            this.drinks = drinks;
        }

        public int MakeDrink()
        {
            int millilitersOfDrink = gramsOfWater + gramsOfMilk;
            return millilitersOfDrink;
        }
        public void GetInfo()
        {
            Console.WriteLine("Ваш выбор: {0}", name);
            Console.WriteLine("Использовано кофе: {0} грамм", gramsOfCoffee);
            Console.WriteLine("Количество воды: {0} грамм", gramsOfWater);
            Console.WriteLine("Количество молока: {0} грамм", gramsOfMilk);
            Console.WriteLine("Готовый напиток: {0} мл", MakeDrink());
            Console.WriteLine("Кушай, не обляпайся");
        }
        public enum drink
        {
            Espresso,
            Americano,
            Cappuchino
        }

        public void PrepareDrink(string userDrink)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAvailableDrinks()
        {
            return this.drinks.Select(drink => drink.name);
        }
    }
}
