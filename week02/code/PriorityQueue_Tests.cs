using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Try to add an item with both data and priority
    // Expected Result: item is properly saved at the back of the queue
    // Defect(s) Found: For loop in Dequeue() function started at the wrong index, Dequeue() function did not remove items from the queue, if statement to test for highest priority used ">=" instead of ">"
    public void TestPriorityQueue_Enqueue()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue( "a" , 0);
        priorityQueue.Enqueue( "b" , 0);
        priorityQueue.Enqueue( "c" , 0);

        List<String> expectedResult = ["a", "b", "c"];

        for (int i = 0; i < 3; ++i)
        {
            var result = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], result);
        }
    }

    [TestMethod]
    // Scenario: Try to dequeue the item with the highest priority
    // Expected Result: The item with the highest priority is dequeued first
    // Defect(s) Found: None
    public void TestPriorityQueue_Dequeue()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue( "a" , 0);
        priorityQueue.Enqueue( "b" , 1);
        priorityQueue.Enqueue( "c" , 2);

        List<String> expectedResult = ["c", "b", "a"];

        for (int i = 0; i < 3; ++i)
        {
            var result = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], result);
        }
    }

    [TestMethod]
    // Scenario: Try to dequeue items with the highest priority in a list where multiple items have the same priority
    // Expected Result: The first of the highest priority items will be dequed first followed by the rest
    // Defect(s) Found: 
    public void TestPriorityQueue_DequeueMultiple()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue( "a" , 0);
        priorityQueue.Enqueue( "b" , 1);
        priorityQueue.Enqueue( "c" , 2);
        priorityQueue.Enqueue( "d" , 1);

        List<String> expectedResult = ["c", "d", "b", "a"];

        for (int i = 0; i < 4; ++i)
        {
            var result = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], result);
        }
    }

    [TestMethod]
    // Scenario: Try to dequeue on an empty queue
    // Expected Result: An InvalidOperationException will be thrown
    // Defect(s) Found: 
    public void TestPriorityQueue_QueueEmpty()
    {
        var priorityQueue = new PriorityQueue();
        
        try
        {
            priorityQueue.Dequeue();
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
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}