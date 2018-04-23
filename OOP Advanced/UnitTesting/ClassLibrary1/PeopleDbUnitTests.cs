using DatabaseProject;
using NUnit.Framework;
using System;
using System.Reflection;
using System.Linq;

namespace DatabaseUnitTests
{


    [TestFixture]
    public class PeopleDbUnitTests
    {
        [Test]
        [TestCase("User1")]
        [TestCase("User2")]
        [TestCase("aaaa")]
        [TestCase("AAAA")]
        public void FindByUsernameMethod_Valid(string input)
        {
            PeopleDatabase db = new PeopleDatabase();

            Person[] initialPeople = new Person[]
                {
                    new Person(1111, "User1"),
                    new Person(1234, "User2"),
                    new Person(0, "aaaa"),
                    new Person(1, "AAAA")
                };

            FieldInfo peopleFieldInfo = typeof(PeopleDatabase).GetField("people", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo indexFieldInfo = typeof(PeopleDatabase).GetField("currentIndex", BindingFlags.NonPublic | BindingFlags.Instance);

            peopleFieldInfo.SetValue(db, initialPeople);
            indexFieldInfo.SetValue(db, initialPeople.Length);

            string result = db.FindByUsername(input).UserName;
            var resultedPeople = peopleFieldInfo.GetValue(db);

            Assert.That(result, Is.EqualTo(input));
            Assert.That(resultedPeople, Is.EquivalentTo(initialPeople));

        }

        [Test]
        public void FindByUsernameMethod_WithoutUsers_Invalid()
        {
            PeopleDatabase db = new PeopleDatabase();

            Assert.That(() => db.FindByUsername("Pesho"), Throws.InvalidOperationException);

        }

        [Test]
        [TestCase("gosho")]
        [TestCase("AAAA")]
        public void FindByUsernameMethod_WithUsers_Invalid(string input)
        {
            PeopleDatabase db = new PeopleDatabase();

            Person[] initialPeople = new Person[]
                {
                    new Person(1111, "User1"),
                    new Person(1234, "User2"),
                    new Person(0, "aaaa")
                };

            FieldInfo peopleFieldInfo = typeof(PeopleDatabase).GetField("people", BindingFlags.NonPublic | BindingFlags.Instance);
            peopleFieldInfo.SetValue(db, initialPeople);


            Assert.That(() => db.FindByUsername(input), Throws.InvalidOperationException);

        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void FindByUsernameMethod_Null_Invalid(string input)
        {
            PeopleDatabase db = new PeopleDatabase();

            Assert.That(() => db.FindByUsername(""), Throws.ArgumentNullException);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(1234)]
        [TestCase(long.MaxValue)]
        public void FindByIdMethod_Valid(long input)
        {
            PeopleDatabase db = new PeopleDatabase();

            Person[] initialPeople = new Person[]
                {
                    new Person(long.MaxValue, "User1"),
                    new Person(1234, "User2"),
                    new Person(0, "aaaa"),
                    new Person(1, "AAAA")
                };

            FieldInfo peopleFieldInfo = typeof(PeopleDatabase).GetField("people", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo indexFieldInfo = typeof(PeopleDatabase).GetField("currentIndex", BindingFlags.NonPublic | BindingFlags.Instance);

            peopleFieldInfo.SetValue(db, initialPeople);
            indexFieldInfo.SetValue(db, initialPeople.Length);

            long resultId = db.FindById(input).Id;
            var resultedPeople = peopleFieldInfo.GetValue(db);

            Assert.That(resultId, Is.EqualTo(input));
            Assert.That(resultedPeople, Is.EquivalentTo(initialPeople));

        }

        [Test]
        public void FindByIdMethod_IdNegative_Invalid()
        {
            PeopleDatabase db = new PeopleDatabase();
            Assert.That(() => db.FindById(-1), Throws.ArgumentException);
        }

    }
}
