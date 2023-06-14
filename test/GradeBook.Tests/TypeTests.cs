using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;

namespace GradeBook.Tests
{
    //delegates allow you to find a variable that can point to and invoke different methods (that have a specific shape and structure)
    //When I define a delegate I am defining what a method has to look like (what params, and how many, what returns)
    public delegate string WriteLogDelegate(string logMessage); //I can point this variable to any method that takes a string and returns a string
    public class TypeTests
    {
        int count = 0;  
        [Fact]
        public void WriteLogDelegateCanPointToMenthod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello");

            Assert.Equal("hello", result);
        }

        string IncrementCount(string msg)
        {
            count++;
            return msg.ToLower();
        }

        string ReturnMessage(string msg)
        {
            count++;
            return msg;
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private int GetInt()
        {
            return 3;

        }

        private void SetInt(ref int x)
        {
            x = 42;

        }

        [Fact]
        public void CSharpPassByRef()
        {
            //arrange
            var book1 = GetBook("Book 1");

            //act
            GetBookSetName(ref book1, "New Name");

            //assert
            Assert.Equal("New Name", book1.Name);

        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            //arrange
            var book1 = GetBook("Book 1");

            //act
            GetBookSetName(book1, "New Name");

            //assert
            Assert.Equal("Book 1", book1.Name);

        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
            book.Name = name;
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            //arrange
            var book1 = GetBook("Book 1");

            //act
            SetName(book1, "New Name");

            //assert
            Assert.Equal("New Name", book1.Name);

        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;   
        }

        [Fact]
        public void GetBookReturnsDiffObjects()
        {
            //arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            //act

            //assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);

        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            //arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;

            //act

            //assert
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}

