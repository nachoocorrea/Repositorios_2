//------------------------------------------------------------------------------
// <copyright file="CarJsonConverter.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Text.Json;

namespace Ucu.Poo.Repositories
{
    /// <summary>
    /// Esta clase se encarga de convertir una lista de autos a su
    /// representación en formato JSON, y viceversa. No conoce nada sobre
    /// cómo se almacenan los autos en memoria ni sobre archivos.
    /// </summary>
    public class CarJsonConverter
    {
        /// <summary>
        /// Convierte una lista de autos a una representación en formato
        /// JSON.
        /// </summary>
        /// <param name="cars">La lista de autos a convertir.</param>
        /// <returns>Una representación de la lista de autos en formato
        /// JSON.</returns>
        public string ConvertToJson(List<Car> cars)
        {
            return JsonSerializer.Serialize(cars);
        }

        /// <summary>
        /// Convierte una representación en formato JSON a una lista de
        /// autos.
        /// </summary>
        /// <param name="content">La representación en formato JSON desde la
        /// cual crear la lista de autos.</param>
        /// <returns>La lista de autos obtenida a partir del contenido JSON,
        /// o una lista vacía si el contenido no representa autos
        /// válidos.</returns>
        public List<Car> ConvertFromJson(string content)
        {
            List<Car> items = JsonSerializer.Deserialize<List<Car>>(content);
            if (items != null)
            {
                return items;
            }
            else
            {
                return new List<Car>();
            }
        }
    }
}