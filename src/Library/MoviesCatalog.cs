//------------------------------------------------------------------------------
// <copyright file="MoviesCatalog.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ucu.Poo.Repositories
{
    /// <summary>
    /// Esta clase representa un catálogo de películas. Se encarga
    /// únicamente de mantener la colección de películas en memoria; delega
    /// en <see cref="MovieJsonConverter"/> la conversión a/desde JSON, y en
    /// <see cref="FileManager"/> la lectura y escritura de archivos.
    /// </summary>
    public class MoviesCatalog
    {
        private List<Movie> movies = new List<Movie>();
        private MovieJsonConverter jsonConverter = new MovieJsonConverter();
        private FileManager fileManager = new FileManager();

        /// <summary>
        /// Obtiene la lista de películas en el catálogo.
        /// </summary>
        public ReadOnlyCollection<Movie> Movies
        {
            get { return this.movies.AsReadOnly(); }
        }

        /// <summary>
        /// Agrega una película al catálogo.
        /// </summary>
        /// <param name="movie">La película a agregar.</param>
        public void Add(Movie movie)
        {
            if (movie != null)
            {
                this.movies.Add(movie);
            }
        }

        /// <summary>
        /// Elimina una película del catálogo.
        /// </summary>
        /// <param name="movie">La película a remover.</param>
        public void Remove(Movie movie)
        {
            this.movies.Remove(movie);
        }

        /// <summary>
        /// Busca una película en el catálogo que cumpla con un criterio
        /// específico.
        /// </summary>
        /// <param name="field">El nombre del atributo por el cual
        /// buscar.</param>
        /// <param name="value">El valor del atributo por el cual
        /// buscar.</param>
        /// <returns>La película encontrada que cumple el criterio especificado
        /// o null si no se encuentra ninguna.</returns>
        public Movie Find(string field, string value)
        {
            foreach (Movie movie in this.movies)
            {
                if (movie.HasValue(field, value))
                {
                    return movie;
                }
            }

            return null;
        }

        /// <summary>
        /// Convierte el catálogo de películas a una representación en formato
        /// JSON.
        /// </summary>
        /// <returns>Una representación del catálogo en formato JSON.</returns>
        public string ConvertToJson()
        {
            return this.jsonConverter.ConvertToJson(this.movies);
        }

        /// <summary>
        /// Carga el catálogo de películas desde una representación en formato
        /// JSON.
        /// </summary>
        /// <param name="content">La representación en formato JSON desde la
        /// cual cargar el catálogo.</param>
        public void LoadFromJson(string content)
        {
            this.movies = this.jsonConverter.ConvertFromJson(content);
        }

        /// <summary>
        /// Guarda el catálogo de películas en un archivo en formato JSON.
        /// </summary>
        /// <param name="filePath">El nombre del archivo, incluyendo
        /// opcionalmente la ruta.</param>
        public void SaveToFile(string filePath)
        {
            string content = this.ConvertToJson();
            this.fileManager.WriteAllText(filePath, content);
        }

        /// <summary>
        /// Carga el catálogo de películas desde un archivo en formato JSON.
        /// </summary>
        /// <param name="filePath">El nombre del archivo, incluyendo
        /// opcionalmente la ruta.</param>
        /// <returns>Retorna <c>true</c> si se cargó el catálogo y <c>false</c>
        /// en caso contrario.</returns>
        public bool LoadFromFile(string filePath)
        {
            if (this.fileManager.Exists(filePath))
            {
                string content = this.fileManager.ReadAllText(filePath);
                this.LoadFromJson(content);
                return true;
            }

            return false;
        }
    }
}