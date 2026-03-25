using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// Unit tests for the PriorityQueue class.
/// 
/// These tests verify the correct behavior of the PriorityQueue implementation, including:
/// - Enqueueing items with priorities
/// - Dequeueing the highest priority item (with FIFO for ties)
/// - Exception handling for empty queue
/// - ToString output correctness
/// 
/// Each test method includes a scenario description, expected result, and a place to record defects found during testing.
/// </summary>

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

/// <summary>
/// Contains test cases for various scenarios involving the PriorityQueue.
/// </summary>
[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue adds to the back and Dequeue removes highest priority item.
    // Expected Result: Items are dequeued in order of highest priority first.
    // Defect(s) Found: 
    public void TestPriorityQueue_EnqueueAndDequeueHighestPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 2);
        Assert.AreEqual("B", pq.Dequeue()); // Highest priority
        Assert.AreEqual("C", pq.Dequeue()); // Next highest
        Assert.AreEqual("A", pq.Dequeue()); // Last
    }

    [TestMethod]
    // Scenario: If multiple items have the same highest priority, the one closest to the front is removed (FIFO).
    // Expected Result: First-in, first-out for ties.
    // Defect(s) Found: 
    public void TestPriorityQueue_FIFOTieBreaker()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 5);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 5);
        Assert.AreEqual("A", pq.Dequeue()); // Both A and C have 5, but A was first
        Assert.AreEqual("C", pq.Dequeue()); // Now C
        Assert.AreEqual("B", pq.Dequeue()); // Then B
    }

    [TestMethod]
    // Scenario: Dequeue throws InvalidOperationException with correct message if the queue is empty.
    // Expected Result: Exception thrown with message "The queue is empty."
    // Defect(s) Found: 
    public void TestPriorityQueue_EmptyDequeueThrows()
    {
        var pq = new PriorityQueue();
        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception of type {e.GetType()} caught: {e.Message}");
        }
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and check ToString for order.
    // Expected Result: ToString should show all items in enqueue order.
    // Defect(s) Found: 
    public void TestPriorityQueue_ToStringOrder()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 2);
        pq.Enqueue("C", 3);
        var str = pq.ToString();
        Assert.IsTrue(str.Contains("A (Pri:1)"));
        Assert.IsTrue(str.Contains("B (Pri:2)"));
        Assert.IsTrue(str.Contains("C (Pri:3)"));
    }
}