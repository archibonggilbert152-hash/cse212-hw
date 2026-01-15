using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueue_Tests
{
    // TEST RESULTS:
    // Confirms that items are added to the queue successfully.
    [TestMethod]
    public void Enqueue_AddsItemsCorrectly()
    {
        PriorityQueue queue = new PriorityQueue();
        queue.Enqueue("TaskOne", 1);
        queue.Enqueue("TaskTwo", 2);

        Assert.AreEqual("TaskTwo", queue.Dequeue());
    }

    // TEST RESULTS:
    // Verifies that the item with the highest priority is removed first.
    [TestMethod]
    public void Dequeue_RemovesHighestPriorityItem()
    {
        PriorityQueue queue = new PriorityQueue();
        queue.Enqueue("LowPriorityTask", 1);
        queue.Enqueue("HighPriorityTask", 5);
        queue.Enqueue("MediumPriorityTask", 3);

        Assert.AreEqual("HighPriorityTask", queue.Dequeue());
    }

    // TEST RESULTS:
    // Ensures FIFO behavior when multiple items have the same priority.
    [TestMethod]
    public void Dequeue_FollowsFIFOWhenPrioritiesMatch()
    {
        PriorityQueue queue = new PriorityQueue();
        queue.Enqueue("FirstTask", 2);
        queue.Enqueue("SecondTask", 2);

        Assert.AreEqual("FirstTask", queue.Dequeue());
    }

    // TEST RESULTS:
    // Confirms the correct exception and message are thrown for an empty queue.
    [TestMethod]
    public void Dequeue_EmptyQueue_ThrowsException()
    {
        PriorityQueue queue = new PriorityQueue();

        InvalidOperationException exception =
            Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());

        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}
