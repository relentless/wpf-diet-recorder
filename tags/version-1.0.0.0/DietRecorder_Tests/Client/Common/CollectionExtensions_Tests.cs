using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DietRecorder.Client.Common;
using NUnit.Framework;

namespace DietRecorder_Tests.Client.Common
{
    [TestFixture]
    public class CollectionExtensions_Tests
    {
        [Test]
        public void ToObservableCollection_CalledOnNullCollection_ReturnsNull()
        {
            // arrange
            List<object> nullList = null;

            // act
            ObservableCollection<object> result = nullList.ToObservableCollection<object>();

            // assert
            Assert.IsNull(result);
        }

        [Test]
        public void ToObservableCollection_CalledOnListWithNoItems_CreatesEmptyCollection()
        {
            // arrange
            List<object> emptyList = new List<object>();

            // act
            ObservableCollection<object> result = emptyList.ToObservableCollection<object>();

            // assert
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }

        [Test]
        public void ToObservableCollection_CalledOnListWithOneObject_CreatesCollectionWithSameObject()
        {
            // arrange
            object listObject = new object();
            List<object> objectList = new List<object>(){listObject};

            // act
            ObservableCollection<object> result = objectList.ToObservableCollection<object>();

            // assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(listObject, result[0]);
        }

        [Test]
        public void ToObservableCollection_CalledOnListWithMultipleObjects_CreatesCollectionWithSameObjects()
        {
            // arrange
            object listObject1 = new object();
            object listObject2 = new object();
            object listObject3 = new object();
            List<object> objectList = new List<object>() { listObject1, listObject2, listObject3 };

            // act
            ObservableCollection<object> result = objectList.ToObservableCollection<object>();

            // assert
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(listObject1, result[0]);
            Assert.AreEqual(listObject2, result[1]);
            Assert.AreEqual(listObject3, result[2]);
        }

        [Test]
        public void ToObservableCollection_CalledOnListWithOneIntger_CreatesCollectionWithSameInteger()
        {
            // arrange
            int listInt = 999;
            List<int> integerList = new List<int>() { listInt };

            // act
            ObservableCollection<int> result = integerList.ToObservableCollection<int>();

            // assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(listInt, result[0]);
        }
    }
}
