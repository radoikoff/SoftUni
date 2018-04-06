using DatabaseProject;
using NUnit.Framework;
using System;
using System.Reflection;
using System.Linq;

namespace DatabaseUnitTests
{

    [TestFixture]
    public class DatabaseUnitTests
    {
        [Test]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 0, 2, 3 })]
        [TestCase(new int[] { -10, 2, 3, 0 })]
        [TestCase(new int[] { })]
        public void Constructor_Valid(int[] values)
        {
            Database db = new Database(values);
            var fieldInfo = typeof(Database).GetField("values", BindingFlags.NonPublic | BindingFlags.Instance);

            int[] fieldValues = (int[])fieldInfo.GetValue(db);
            int[] buffer = new int[fieldValues.Length - values.Length];
            Assert.That(fieldValues, Is.EquivalentTo(values.Concat(buffer)));
        }

        [Test]
        public void Constructor_Invalid()
        {
            var values = new int[18];

            Assert.That(() => new Database(values), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        [TestCase(0)]
        [TestCase(-1000)]
        [TestCase(500)]
        public void AddMethod_Valid(int value)
        {
            Database db = new Database();
            db.Add(value);

            FieldInfo fieldInfo = typeof(Database).GetField("values", BindingFlags.NonPublic | BindingFlags.Instance);
            int actualValue = ((int[])fieldInfo.GetValue(db)).First();

            Assert.That(actualValue, Is.EqualTo(value));

            FieldInfo indexInfo = typeof(Database).GetField("currentIndex", BindingFlags.NonPublic | BindingFlags.Instance);
            int actualIndex = (int)indexInfo.GetValue(db);

            Assert.That(actualIndex, Is.EqualTo(1));
        }

        [Test]
        public void AddMethod_Invalid()
        {
            Database db = new Database();

            FieldInfo indexInfo = typeof(Database).GetField("currentIndex", BindingFlags.NonPublic | BindingFlags.Instance);
            indexInfo.SetValue(db, 16);

            Assert.That(() => db.Add(1), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 0, 2, 3 })]
        [TestCase(new int[] { -10, 2, 3, 0 })]
        public void RemoveMethod_Valid(int[] values)
        {
            Database db = new Database(values);
            var fieldInfo = typeof(Database).GetField("values", BindingFlags.NonPublic | BindingFlags.Instance);
            var indexInfo = typeof(Database).GetField("currentIndex", BindingFlags.NonPublic | BindingFlags.Instance);

            fieldInfo.SetValue(db, values);
            indexInfo.SetValue(db, values.Length);

            db.Remove();

            int[] fieldValues = (int[])fieldInfo.GetValue(db);
            int[] buffer = new int[fieldValues.Length - (values.Length - 1)];

            values = values.Take(values.Length - 1).Concat(buffer).ToArray();

            Assert.That(fieldValues, Is.EquivalentTo(values));
        }

        [Test]
        public void RemoveMethod_Invalid()
        {
            Database db = new Database();

            var indexInfo = typeof(Database).GetField("currentIndex", BindingFlags.NonPublic | BindingFlags.Instance);
            indexInfo.SetValue(db, 0);

            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, -90 })]
        [TestCase(new int[] { 0, 0, 0 })]
        [TestCase(new int[] { })]
        public void FetchMethod_Valid(int[] values)
        {
            Database db = new Database(values);
            var valuesfieldInfo = typeof(Database).GetField("values", BindingFlags.NonPublic | BindingFlags.Instance);
            var indexFieldInfo = typeof(Database).GetField("currentIndex", BindingFlags.NonPublic | BindingFlags.Instance);

            valuesfieldInfo.SetValue(db, values);
            indexFieldInfo.SetValue(db, values.Length);

            int[] resultValues = db.Fetch();

            Assert.That(resultValues, Is.EquivalentTo(values));
        }

    }
}
