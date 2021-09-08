using System;
using NUnit.Framework;

namespace AwesomeStack.Tests
{
    public class Tests
    {
        [Test]
        public void Count_WithNewStack_IsZero()
        {
            // Arrange
            var stack = Stack.Empty<int>();

            // Act
            // Do nothing

            // Assert
            Assert.AreEqual(0, stack.Count);
        }

        [Test]
        public void Count_AfterSinglePush_IsOne()
        {
            // Arrange
            var stack = Stack.Empty<int>();

            // Act
            stack.Push(default);

            // Assert
            Assert.AreEqual(1, stack.Count);
        }

        [Test]
        public void Count_AfterDoublePush_IsTwo()
        {
            // Arrange
            var stack = Stack.Empty<int>();

            // Act
            stack.Push(default);
            stack.Push(default);

            // Assert
            Assert.AreEqual(2, stack.Count);
        }

        [Test]
        public void Count_AfterSinglePushAndSinglePop_IsZero()
        {
            // Arrange
            var stack = Stack.Empty<int>();

            // Act
            stack.Push(default);
            stack.Pop();

            // Assert
            Assert.AreEqual(0, stack.Count);
        }

        [Test]
        public void Count_AfterDoublePushAndSinglePop_IsOne()
        {
            // Arrange
            var stack = Stack.Empty<int>();

            // Act
            stack.Push(default);
            stack.Push(default);
            stack.Pop();

            // Assert
            Assert.AreEqual(1, stack.Count);
        }

        [Test]
        public void Push_WithFullStack_ThrowsInvalidOperationException()
        {
            // Arrange
            var stack = Stack.Full<int>();

            // Act
            var action = new TestDelegate(() => stack.Push(default));

            // Assert
            Assert.Throws<InvalidOperationException>(action);
        }

        [Test]
        public void Push_WithCapacityTenEmpty_CanPushTenTimes()
        {
            // Arrange
            var capacity = 10;
            var stack = Stack.Empty<int>(capacity);
            
            // Act
            var action = new TestDelegate(() =>
            {
                for (var i = 0; i < capacity; i++)
                {
                    stack.Push(default);
                }
            });

            // Assert
            Assert.DoesNotThrow(action);
        }

        [Test]
        public void Pop_WithEmptyStack_ThrowsInvalidOperationException()
        {
            // Arrange
            var stack = Stack.Empty<int>();

            // Act
            var action = new TestDelegate(() => stack.Pop());

            // Assert
            Assert.Throws<InvalidOperationException>(action);
        }

        [Test]
        public void Pop_WithCapacityTenFull_CanPopTenTimes()
        {
            // Arrange
            var capacity = 10;
            var stack = Stack.Full<int>(capacity);
            
            // Act
            var action = new TestDelegate(() =>
            {
                for (var i = 0; i < capacity; i++)
                {
                    stack.Pop();
                }
            });

            // Assert
            Assert.DoesNotThrow(action);
        }

        [Test]
        public void IsEmpty_WithEmptyStack_IsTrue()
        {
            // Arrange
            var stack = Stack.Empty<int>();

            // Act
            // Nothing

            // Assert
            Assert.IsTrue(stack.IsEmpty);
        }

        [Test]
        public void IsEmpty_WithEmptyStackAndSinglePush_IsFalse()
        {
            // Arrange
            var stack = Stack.Empty<int>();

            // Act
            stack.Push(default);

            // Assert
            Assert.IsFalse(stack.IsEmpty);
        }

        [Test]
        public void IsFull_WithFullStack_IsTrue()
        {
            // Arrange
            var stack = Stack.Full<int>();

            // Act
            // Nothing

            // Assert
            Assert.IsTrue(stack.IsFull);
        }

        [Test]
        public void IsFull_WithFullStackAndSinglePop_IsFalse()
        {
            // Arrange
            var stack = Stack.Full<int>();

            // Act
            stack.Pop();

            // Assert
            Assert.IsFalse(stack.IsFull);
        }

        [Test]
        public void Empty_WithCapacityZero_ThrowsArgumentException()
        {
            // Arrange
            var capacity = 0;
            
            // Act
            var action = new TestDelegate(() => Stack.Empty<int>(capacity));

            // Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Test]
        public void Full_WithCapacityZero_ThrowsArgumentException()
        {
            // Arrange
            var capacity = 0;
            
            // Act
            var action = new TestDelegate(() => Stack.Full<int>(capacity));

            // Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Test]
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(100)]
        public void Pop_AfterSinglePush_ReturnsPushedValue(int expected)
        {
            // Arrange
            var stack = Stack.Empty<int>();

            // Act
            stack.Push(expected);
            var value = stack.Pop();

            // Assert
            Assert.AreEqual(expected, value);
        }

        [Test]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        public void Pop_AfterDoublePush_ReturnsSecondPushedValue(int expected)
        {
            // Arrange
            var stack = Stack.Empty<int>();

            // Act
            stack.Push(default);
            stack.Push(expected);
            var value = stack.Pop();

            // Assert
            Assert.AreEqual(expected, value);
        }
    }
}
