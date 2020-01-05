using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AStarGroceryStore;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MyStack_Add()
        {
            MyStack<int> myStack = new MyStack<int>();
            int expected = 7;
            int actual;

            myStack.Push(expected);
            actual = myStack.Pop();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MyStack_AddNegative()
        {
            MyStack<int> myStack = new MyStack<int>();
            int expected = -7;
            int actual;

            myStack.Push(expected);
            actual = myStack.Pop();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MyStack_Remove()
        {
            MyStack<int> myStack = new MyStack<int>();
            int expected = 7;
            int actual;
            int expectedSize = 0;
            int actualSize;

            myStack.Push(expected);
            actual = myStack.Pop();

            actualSize = myStack.Count;

            //check removed object
            Assert.AreEqual(expected, actual);

            //check size
            Assert.AreEqual(expectedSize, actualSize);
        }

        [TestMethod]
        public void MyStack_RemoveNegative()
        {
            MyStack<int> myStack = new MyStack<int>();
            int expected = -7;
            int actual;
            int expectedSize = 0;
            int actualSize;

            myStack.Push(expected);
            actual = myStack.Pop();

            actualSize = myStack.Count;

            //check removed object
            Assert.AreEqual(expected, actual);

            //check size
            Assert.AreEqual(expectedSize, actualSize);
        }

        [TestMethod]
        public void MyStack_Peek()
        {
            MyStack<int> myStack = new MyStack<int>();
            int expected = 7;
            int actual;
            int expectedSize = 1;
            int actualSize;

            myStack.Push(expected);
            actual = myStack.Peek();

            actualSize = myStack.Count;

            //check peeked object
            Assert.AreEqual(expected, actual);

            //check size
            Assert.AreEqual(expectedSize, actualSize);
        }

        [TestMethod]
        public void MyStack_PeekNegative()
        {
            MyStack<int> myStack = new MyStack<int>();
            int expected = -7;
            int actual;
            int expectedSize = 1;
            int actualSize;

            myStack.Push(expected);
            actual = myStack.Peek();

            actualSize = myStack.Count;

            //check peeked object
            Assert.AreEqual(expected, actual);

            //check size
            Assert.AreEqual(expectedSize, actualSize);
        }

        [TestMethod]
        public void MyList_Add()
        {
            MyList<int> myList = new MyList<int>();
            int expected = 22;
            int actual;

            myList.Add(expected);
            actual = myList.GetElementAt(0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MyList_AddCount()
        {
            MyList<int> myList = new MyList<int>();
            int expected = 1;
            int actual;

            myList.Add(52);
            actual = myList.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MyList_Remove()
        {
            MyList<int> myList = new MyList<int>();
            int expected = 0;
            int actual;

            myList.Add(99999);
            myList.Remove(99999);
            actual = myList.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MyList_GetElementAt()
        {
            MyList<int> myList = new MyList<int>();
            int expected = 12345;
            int actual;

            myList.Add(99999);
            myList.Add(12345);
            myList.Add(111);
            myList.Add(333);
            myList.Add(99);
            actual = myList.GetElementAt(1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MyList_AddNegative()
        {
            MyList<int> myList = new MyList<int>();
            int expected = -5;
            int actual;

            myList.Add(expected);
            actual = myList.GetElementAt(0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MyList_RemoveNegative()
        {
            MyList<int> myList = new MyList<int>();
            int expected = 0;
            int actual;

            myList.Add(-20);
            myList.Remove(-20);
            actual = myList.Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
