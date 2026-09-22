using System.Collections.Generic;
using NUnit.Framework;

namespace Ucu.Poo.Repositories.Tests
{
    [TestFixture]
    public class CarJsonConverterTests
    {
        private CarJsonConverter converter;

        [SetUp]
        public void SetUp()
        {
            this.converter = new CarJsonConverter();
        }

        [Test]
        public void ConvertToJson_ListWithCar_ReturnsCarAsJson()
        {
            List<Car> cars = new List<Car>();
            cars.Add(new Car("Jimny", "Suzuki", 2024));

            string json = this.converter.ConvertToJson(cars);

            Assert.That(json, Is.EqualTo("[{\"Model\":\"Jimny\",\"Maker\":\"Suzuki\",\"Year\":2024}]"));
        }

        [Test]
        public void ConvertFromJson_ValidJson_ReturnsListWithCar()
        {
            List<Car> cars = this.converter.ConvertFromJson("[{\"Model\":\"Focus\",\"Maker\":\"Ford\",\"Year\":2018}]");

            Assert.That(cars, Has.Count.EqualTo(1));
            Assert.That(cars[0].Model, Is.EqualTo("Focus"));
            Assert.That(cars[0].Maker, Is.EqualTo("Ford"));
            Assert.That(cars[0].Year, Is.EqualTo(2018));
        }

        [Test]
        public void ConvertFromJson_EmptyArrayJson_ReturnsEmptyList()
        {
            List<Car> cars = this.converter.ConvertFromJson("[]");

            Assert.That(cars, Is.Empty);
        }

        [Test]
        public void ConvertFromJson_NullJson_ReturnsEmptyList()
        {
            List<Car> cars = this.converter.ConvertFromJson("null");

            Assert.That(cars, Is.Empty);
        }
    }
}