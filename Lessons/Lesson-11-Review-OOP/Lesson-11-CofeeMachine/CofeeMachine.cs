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
    public class CofeeMachine
    {
        private Drink[] drinks;

        private int totalGrammsCoffee;
        private int totalGrammsWater;
        private int totalGrammsMilk;

        public CoffeeMachine(Drink[] drinks)
        {
            this.drinks = drinks;
        }

        public void GetInfo()
        {
            //Console.WriteLine("Ваш выбор: {0}", Name);
            //Console.WriteLine("Использовано кофе: {0} грамм", gramsOfCoffee);
            //Console.WriteLine("Количество воды: {0} грамм", gramsOfWater);
            //Console.WriteLine("Количество молока: {0} грамм", gramsOfMilk);
           // Console.WriteLine("Готовый напиток: {0} мл", MakeDrink());
            Console.WriteLine("Кушай, не обляпайся");
        }

        public void PrepareDrink(string userDrink)
        {
            IEnumerable<decimal> prices = null;
            int i = 0;
            for (; i < 10; i++)
            {
                prices = this.drinks.Select(drink => drink.price += i);
            }

            i = 20;

            var arr = prices.ToArray();

            var drink = this.drinks.First(
                (drink) =>
                { 
                    return drink.Name == userDrink;
                });

            MakeDrink(drink);
        }

        public IEnumerable<string> GetAvailableDrinks()
        {

            return this.drinks.Select(drink => drink.Name);
        }

        private void MakeDrink(Drink drink)
        {
            // check coffee
            if (this.totalGrammsCoffee < drink.gramsOfCoffee)
            {
                throw new InvalidOperationException("Не достаточно кофе.");
            }

            // check water
            if (this.totalGrammsWater < drink.gramsOfWater)
            {
                throw new InvalidOperationException("Не достаточно воды.");
            }

            // check milk
            if (this.totalGrammsMilk < drink.gramsOfMilk)
            {
                throw new InvalidOperationException("Не достаточно молока.");
            }

            this.totalGrammsCoffee -= drink.gramsOfCoffee;
            this.totalGrammsWater -= drink.gramsOfWater;
            this.totalGrammsMilk -= drink.gramsOfMilk;

            Console.WriteLine($"Prepared {drink.Name}");

            //var output = "Prepared " + drink.name + drink.price.ToString("N"); // Prepared espresso

            //output = string.Format("Prepared {0} {1:N}", drink.name, drink.price);

            //var sb = new StringBuilder();
            //sb.Append("Prepared ");
            //sb.AppendFormat("{0}", drink.name);
            //output = sb.ToString();

            //output = $"Prepared {drink.name} {drink.price:N}";

            Console.WriteLine($"Prepared {drink.Name} {drink.price:N}");

            // ['s1', 's2', ........] 1000

            // var output = ""; // s1,s2,s3

            // string.Join(",", strings);
        }

        public void AddWater(int amount) => this.totalGrammsWater += amount;

        public void AddCoffee(int amount) => this.totalGrammsCoffee += amount;

        public void AddMilk(int amount) => this.totalGrammsMilk += amount;
    }

    public enum DrinkType
    {
        Espresso,
        Americano,
        Cappuchino
    }
}
