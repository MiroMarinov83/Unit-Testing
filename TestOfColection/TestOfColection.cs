using Collections;
using NUnit.Framework;
using System;
using System.Linq;

namespace TestOfColection
{
    public class Test_Collection_EmptyConstructo
    {


        [Test]
        public void Test_Collection_EmptyConstructorCount()
        {
            var num = new Collection<int>();
            Assert.AreEqual(0, num.Count);
        }
        [Test]
        public void Test_Collection_EmptyConstructorString()
        {
            var num = new Collection<int>();
            Assert.That(num.ToString, Is.EqualTo("[]"));
        }
        [Test]
        public void Test_Collection_EmptyConstructorIsNotEqualString()
        {
            var num = new Collection<int>();
            Assert.That(num.ToString, Is.Not.EqualTo("5"));
        }
        [Test]
        public void Test_Collection_EmptyConstructorCountNotInRange()
        {
            var num = new Collection<int>();
            Assert.That(num.Count, Is.Not.InRange(1, 1000));
        }
    }
    public class Test_Collection_ConstructorSingleItem
    {
        [Test]
        public void Test_Collection_ConstructorSingleItemCount()
        {
            var num = new Collection<int>(5);
            Assert.AreEqual(1, num.Count);
        }
        [Test]
        public void Test_Collection_ConstructorSingleItemString()
        {
            var num = new Collection<int>(5);
            Assert.That(num.ToString, Is.EqualTo("[5]"));
        }
        [Test]
        public void Test_Collection_ConstructorSingleItemIsNotEqualString()
        {
            var num = new Collection<int>(5);
            Assert.That(num.ToString, Is.Not.EqualTo("[]"));
        }
        [Test]
        public void Test_Collection_ConstructorSingleItemIsInRange()
        {
            var num = new Collection<int>(5);
            Assert.That(num[0], Is.InRange(4, 6));
        }
    }
    public class Test_Collection_ConstructorMultipleItems
    {
        [Test]
        public void Test_Collection_ConstructorMultipleItemsleItemCount()
        {
            var num = new Collection<int>(5, 6);
            Assert.AreEqual(2, num.Count);
        }
        [Test]
        public void Test_Collection_ConstructorMultipleItemsString()
        {
            var num = new Collection<int>(5, 6);
            Assert.That(num.ToString, Is.EqualTo("[5, 6]"));
        }
        [Test]
        public void Test_Collection_ConstructorMultipleItemsIsNotEqualString()
        {
            var num = new Collection<int>(5, 6);
            Assert.That(num.ToString, Is.Not.EqualTo("[]"));
        }

    }
    public class Test_Collections_Add
    {
        [Test]
        public void Test_Collections_AddCount()
        {
            var num = new Collection<int>();
            num.Add(5);
            Assert.AreEqual(1, num.Count);
        }
        [Test]
        public void Test_Collections_AddString()
        {
            var num = new Collection<int>(5, 6);
            num.RemoveAt(0);
            num.Add(8);
            Assert.That(num.ToString, Is.EqualTo("[6, 8]"));
        }
        [Test]
        public void Test_Collections_AddIsNotEqualString()
        {
            var num = new Collection<int>();
            num.Add(2);
            Assert.That(num.ToString, Is.Not.EqualTo("[]"));
        }
    }
    public class Test_Collection_AddRangeWithGrow
    {
        [Test]
        public void Test_Collection_AddRangeWithGrow1()
        {
            var nums = new Collection<int>();
            int oldCapacity = nums.Capacity;
            var newNums = Enumerable.Range(1000, 2000).ToArray();
            nums.AddRange(newNums);
            string expectedNums = "[" + string.Join(", ", newNums) + "]";
            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }

    }
    public class Test_Collection_GetByIndex
    {
        [Test]
        public void Test_CollectionGetByIndex()
        {
            var name = new Collection<string>("pepo");
            Assert.AreEqual(1, name.Count);
        }
        [Test]
        public void Test_Collection_GetByIndexStringPosition()
        {
            var name = new Collection<string>("pepo");
            var name0 = name[0];
            Assert.That(name0, Is.EqualTo("pepo"));
        }
        [Test]
        public void Test_Collection_GetByIndexString()
        {
            var name = new Collection<string>("pepo");
            Assert.That(name.ToString, Is.EqualTo("[pepo]"));
        }
        [Test]
        public void Test_Collection_GetByIndexIsNotEqualString()
        {
            var name = new Collection<string>("pepo");
            Assert.That(name, Is.Not.EqualTo("[]"));
        }
    }
    public class Test_Collection_GetByInvalidIndex
    {
        [Test]
        public void TestCollectionGetByInvalidIndex()
        {
            var names = new Collection<string>("Chochko", "Bopko");
            Assert.That(() => { var name = names[-1]; },
              Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { var name = names[2]; },
              Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { var name = names[500]; },
              Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(names.ToString(), Is.EqualTo("[Chochko, Bopko]"));

        }
        public class Test_Collection_SetByIndex
        {
            [Test]
            public void Test_CollectionSetByIndex()
            {
                var name = new Collection<string>("pepo");
                name[0] = "gogo";
                var name0 = name[0];
                Assert.That(name0, Is.EqualTo("gogo"));
            }
        }
        public class Test_Collection_InsertAtStart
        {
            [Test]
            public void Test_CollectionInsertAtStart()
            {
                var nums = new Collection<int>(5,6);
                nums.InsertAt(1, 1);
                Assert.That(nums.ToString, Is.EqualTo("[5, 1, 6]"));
            }
        }
        public class Test_Collection_Exchange
        {
            [Test]
            public void Test_CollectionExchange()
            {
                var nums = new Collection<int>(5,6,8,2);
                nums.Exchange(1, 3);
                Assert.That(nums.ToString, Is.EqualTo("[5, 2, 8, 6]"));
            }
        }
        public class Test_Collection_Clear
        {
            [Test]
            public void Test_CollectionClear()
            {
                var nums = new Collection<int>(5, 6, 8, 2);
                nums.Clear();
                Assert.That(nums.ToString, Is.EqualTo("[]"));
            }
        }
    }
}