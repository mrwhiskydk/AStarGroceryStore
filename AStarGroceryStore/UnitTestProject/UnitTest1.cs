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
    }
}
