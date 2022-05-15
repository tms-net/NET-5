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
        /// <summary>
        /// Предоставляет информацию о доступных напитках для приготовления.
        /// </summary>
        /// <returns>Названия доступных напитков.</returns>
        public IEnumerable<string> GetAvailableDrinks()
        {
            return Enumerable.Empty<string>();
        }
    }
}
