using System;
using System.IO;
using NUnit.Framework;

namespace Ucu.Poo.Repositories.Tests
{
    [TestFixture]
    public class FileManagerTests
    {
        private FileManager fileManager;

        [SetUp]
        public void SetUp()
        {
            this.fileManager = new FileManager();
        }

        [Test]
        public void Exists_ExistingFile_ReturnsTrue()
        {
            string filePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".json");
            File.WriteAllText(filePath, "contenido");

            try
            {
                Assert.That(this.fileManager.Exists(filePath), Is.True);
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [Test]
        public void Exists_NonExistingFile_ReturnsFalse()
        {
            string filePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".json");

            Assert.That(this.fileManager.Exists(filePath), Is.False);
        }

        [Test]
        public void WriteAllText_ValidContent_FileContainsContent()
        {
            string filePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".json");

            try
            {
                this.fileManager.WriteAllText(filePath, "hola mundo");

                Assert.That(File.ReadAllText(filePath), Is.EqualTo("hola mundo"));
            }
            finally
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
        }

        [Test]
        public void ReadAllText_ExistingFile_ReturnsContent()
        {
            string filePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".json");
            File.WriteAllText(filePath, "hola mundo");

            try
            {
                string content = this.fileManager.ReadAllText(filePath);

                Assert.That(content, Is.EqualTo("hola mundo"));
            }
            finally
            {
                File.Delete(filePath);
            }
        }
    }
}