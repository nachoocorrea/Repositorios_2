//------------------------------------------------------------------------------
// <copyright file="MovieJsonConverter.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Text.Json;

namespace Ucu.Poo.Repositories
{
    /// <summary>
    /// Esta clase se encarga de convertir una lista de películas a su
    /// representación en formato JSON, y viceversa. No conoce nada sobre
    /// cómo se almacenan las películas en memoria ni sobre archivos.
    /// </summary>
    public class MovieJsonConverter
    {
        /// <summary>
        /// Convierte una lista de películas a una representación en formato
        /// JSON.
        /// </summary>
        /// <param name="movies">La lista de películas a convertir.</param>
        /// <returns>Una representación de la lista de películas en formato
        /// JSON.</returns>
        public string ConvertToJson(List<Movie> movies)
        {
            return JsonSerializer.Serialize(movies);
        }

        /// <summary>
        /// Convierte una representación en formato JSON a una lista de
        /// películas.
        /// </summary>
        /// <param name="content">La representación en formato JSON desde la
        /// cual crear la lista de películas.</param>
        /// <returns>La lista de películas obtenida a partir del contenido
        /// JSON, o una lista vacía si el contenido no representa películas
        /// válidas.</returns>
        public List<Movie> ConvertFromJson(string content)
        {
            List<Movie> items = JsonSerializer.Deserialize<List<Movie>>(content);
            if (items != null)
            {
                return items;
            }
            else
            {
                return new List<Movie>();
            }
        }
    }
}