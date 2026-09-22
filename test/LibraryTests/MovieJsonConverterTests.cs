using System.Collections.Generic;
using NUnit.Framework;

namespace Ucu.Poo.Repositories.Tests
{
    [TestFixture]
    public class MovieJsonConverterTests
    {
        private MovieJsonConverter converter;

        [SetUp]
        public void SetUp()
        {
            this.converter = new MovieJsonConverter();
        }

        [Test]  
        public void ConvertToJson_ListWithMovie_ReturnsMovieAsJson()
        {
            List<Movie> movies = new List<Movie>();
            movies.Add(new Movie("Inception", 2010));

            string json = this.converter.ConvertToJson(movies);

            Assert.That(json, Is.EqualTo("[{\"Name\":\"Inception\",\"Year\":2010}]"));
        }

        [Test]
        public void ConvertFromJson_ValidJson_ReturnsListWithMovie()
        {
            List<Movie> movies = this.converter.ConvertFromJson("[{\"Name\":\"The Matrix\",\"Year\":1999}]");

            Assert.That(movies, Has.Count.EqualTo(1));
            Assert.That(movies[0].Name, Is.EqualTo("The Matrix"));
            Assert.That(movies[0].Year, Is.EqualTo(1999));
        }

        [Test]
        public void ConvertFromJson_EmptyArrayJson_ReturnsEmptyList()
        {
            List<Movie> movies = this.converter.ConvertFromJson("[]");

            Assert.That(movies, Is.Empty);
        }

        [Test]
        public void ConvertFromJson_NullJson_ReturnsEmptyList()
        {
            List<Movie> movies = this.converter.ConvertFromJson("null");

            Assert.That(movies, Is.Empty);
        }
    }
}