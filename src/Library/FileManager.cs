//------------------------------------------------------------------------------
// <copyright file="FileManager.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System.IO;

namespace Ucu.Poo.Repositories
{
    /// <summary>
    /// Esta clase se encarga de leer y escribir texto en archivos del disco.
    /// No conoce ningún detalle sobre autos, películas ni JSON: solo sabe
    /// trabajar con texto y archivos.
    /// </summary>
    public class FileManager
    {
        /// <summary>
        /// Determina si un archivo existe.
        /// </summary>
        /// <param name="filePath">El nombre del archivo, incluyendo opcionalmente la ruta.</param>
        /// <returns>Retorna <c>true</c> si el archivo existe y <c>false</c> en el
        /// caso contrario.</returns>
        public bool Exists(string filePath)
        {
            return File.Exists(filePath);
        }

        /// <summary>
        /// Lee todo el contenido de un archivo como texto.
        /// </summary>
        /// <param name="filePath">El nombre del archivo, incluyendo
        /// opcionalmente la ruta.</param>
        /// <returns>El contenido del archivo.</returns>
        public string ReadAllText(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        /// <summary>
        /// Escribe texto en un archivo, sobrescribiendo su contenido si ya
        /// existe.
        /// </summary>
        /// <param name="filePath">El nombre del archivo, incluyendo
        /// opcionalmente la ruta.</param>
        /// <param name="content">El texto a escribir en el archivo.</param>
        public void WriteAllText(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }
    }
}