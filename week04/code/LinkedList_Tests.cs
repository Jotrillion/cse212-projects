using Microsoft.VisualStudio.TestTools.UnitTesting;

// DO NOT MODIFY THIS FILE

// DEFECTS FOUND (from test results):
// - RemoveTail_Single: RemoveTail does not set head/tail to null when list has one item.
// - RemoveTail_Basic: RemoveTail does not remove the last node correctly (extra node remains).
// - Remove_Single: Remove does not remove the only node in the list.
// - Remove_Multiple: Remove does not remove the correct node(s) in sequence.
// - Replace_Multiple: Replace does not update all matching values.
// - Reverse_Empty, Reverse_Single, Reverse_Basic: Reverse does not yield correct values (returns 0 or wrong sequence).
// All InsertTail tests pass, including InsertTail_MultipleValues.
// Fix the above methods in LinkedList.cs to pass all tests.

[TestClass]
public class InsertTailTests
{
    [TestMethod]
    public void InsertTail_Empty()
    {
        var ll = new LinkedList();

        Assert.IsTrue(ll.HeadAndTailAreNull());
        ll.InsertTail(1);
        Assert.IsTrue(ll.HeadAndTailAreNotNull());
        Assert.AreEqual("<LinkedList>{1}", ll.ToString());
    }

    [TestMethod]
    public void InsertTail_Basic()
    {
        var ll = new LinkedList();

        ll.InsertTail(1);
        ll.InsertHead(2);
        ll.InsertHead(2);
        ll.InsertHead(2);
        ll.InsertHead(3);
        ll.InsertHead(4);
        ll.InsertHead(5);

        Assert.AreEqual("<LinkedList>{5, 4, 3, 2, 2, 2, 1}", ll.ToString());

        ll.InsertTail(0);
        ll.InsertTail(-1);

        Assert.AreEqual("<LinkedList>{5, 4, 3, 2, 2, 2, 1, 0, -1}", ll.ToString());
    }

    [TestMethod]
    public void InsertTail_MultipleValues()
    {
        var ll = new LinkedList();
        ll.InsertTail(10);
        ll.InsertTail(20);
        ll.InsertTail(30);
        ll.InsertTail(40);
        Assert.AreEqual("<LinkedList>{10, 20, 30, 40}", ll.ToString());
    }
}

[TestClass]
public class RemoveTailTests
{
    [TestMethod]
    public void RemoveTail_Empty()
    {
        var ll = new LinkedList();

        ll.RemoveTail();
        Assert.IsTrue(ll.HeadAndTailAreNull());
        Assert.AreEqual("<LinkedList>{}", ll.ToString());
    }

    [TestMethod]
    public void RemoveTail_Single()
    {
        var ll = new LinkedList();

        ll.InsertHead(1);
        ll.RemoveTail();
        Assert.IsTrue(ll.HeadAndTailAreNull());
        Assert.AreEqual("<LinkedList>{}", ll.ToString());
    }

    [TestMethod]
    public void RemoveTail_Basic()
    {
        var ll = new LinkedList();

        ll.InsertHead(2);
        ll.InsertHead(2);
        ll.InsertHead(2);
        ll.InsertHead(3);
        ll.InsertHead(4);
        ll.InsertHead(5);

        ll.RemoveTail();
        Assert.AreEqual("<LinkedList>{5, 4, 3, 2, 2}", ll.ToString());

        ll.RemoveTail();
        Assert.AreEqual("<LinkedList>{5, 4, 3, 2}", ll.ToString());
    }

    [TestMethod]
    public void RemoveTail_MultipleValues()
    {
        var ll = new LinkedList();
        ll.InsertTail(1);
        ll.InsertTail(2);
        ll.InsertTail(3);
        ll.RemoveTail();
        Assert.AreEqual("<LinkedList>{1, 2}", ll.ToString());
        ll.RemoveTail();
        Assert.AreEqual("<LinkedList>{1}", ll.ToString());
        ll.RemoveTail();
        Assert.AreEqual("<LinkedList>{}", ll.ToString());
        Assert.IsTrue(ll.HeadAndTailAreNull());
    }
}

[TestClass]
public class RemoveTests
{
    [TestMethod]
    public void Remove_NonExistant()
    {
        var ll = new LinkedList();

        ll.InsertHead(2);
        ll.InsertHead(2);
        ll.InsertHead(2);
        ll.InsertHead(3);
        ll.InsertHead(4);
        ll.InsertHead(5);

        ll.InsertAfter(3, 35);
        ll.InsertAfter(5, 6);

        Assert.AreEqual("<LinkedList>{5, 6, 4, 3, 35, 2, 2, 2}", ll.ToString());
        ll.Remove(-1);
        Assert.AreEqual("<LinkedList>{5, 6, 4, 3, 35, 2, 2, 2}", ll.ToString());
    }

    [TestMethod]
    public void Remove_Empty()
    {
        var ll = new LinkedList();
        ll.Remove(0);
        Assert.AreEqual("<LinkedList>{}", ll.ToString());
        Assert.IsTrue(ll.HeadAndTailAreNull());
    }

    [TestMethod]
    public void Remove_Single()
    {
        var ll = new LinkedList();
        ll.InsertHead(2);
        ll.Remove(2);
        Assert.AreEqual("<LinkedList>{}", ll.ToString());
        Assert.IsTrue(ll.HeadAndTailAreNull());
    }

    [TestMethod]
    public void Remove_Multiple()
    {
        var ll = new LinkedList();

        ll.InsertHead(2);
        ll.InsertHead(2);
        ll.InsertHead(3);
        ll.InsertHead(4);
        ll.InsertHead(2);
        ll.InsertHead(5);

        ll.InsertAfter(3, 35);
        ll.InsertAfter(5, 6);

        Assert.AreEqual("<LinkedList>{5, 6, 2, 4, 3, 35, 2, 2}", ll.ToString());
        ll.Remove(3);
        Assert.AreEqual("<LinkedList>{5, 6, 2, 4, 35, 2, 2}", ll.ToString());
        ll.Remove(6);
        Assert.AreEqual("<LinkedList>{5, 2, 4, 35, 2, 2}", ll.ToString());
        ll.Remove(2);
        Assert.AreEqual("<LinkedList>{5, 4, 35, 2, 2}", ll.ToString());
        ll.Remove(2);
        Assert.AreEqual("<LinkedList>{5, 4, 35, 2}", ll.ToString());
        ll.Remove(2);
        Assert.AreEqual("<LinkedList>{5, 4, 35}", ll.ToString());
    }
}

[TestClass]
public class ReplaceTests
{
    [TestMethod]
    public void Replace_NonExistant()
    {
        var ll = new LinkedList();

        ll.InsertHead(2);
        ll.InsertHead(2);
        ll.InsertHead(3);
        ll.InsertHead(4);
        ll.InsertHead(2);
        ll.InsertHead(5);

        ll.Replace(-1, 4);
        Assert.AreEqual("<LinkedList>{5, 2, 4, 3, 2, 2}", ll.ToString());
    }

    [TestMethod]
    public void Replace_Empty()
    {
        var ll = new LinkedList();

        ll.Replace(-1, 4);
        Assert.AreEqual("<LinkedList>{}", ll.ToString());
    }

    [TestMethod]
    public void Replace_Multiple()
    {
        var ll = new LinkedList();

        ll.InsertHead(2);
        ll.InsertHead(2);
        ll.InsertHead(3);
        ll.InsertHead(4);
        ll.InsertHead(2);
        ll.InsertHead(5);

        ll.Replace(2, 4);
        Assert.AreEqual("<LinkedList>{5, 4, 4, 3, 4, 4}", ll.ToString());

        ll.Replace(3, -1);
        Assert.AreEqual("<LinkedList>{5, 4, 4, -1, 4, 4}", ll.ToString());
    }
}

[TestClass]
public class ReverseTests
{
    [TestMethod]
    public void Reverse_Empty()
    {
        var ll = new LinkedList();
        Assert.AreEqual("<IEnumerable>{}", ll.Reverse().AsString());
    }

    [TestMethod]
    public void Reverse_Single()
    {
        var ll = new LinkedList();
        ll.InsertHead(5);
        Assert.AreEqual("<IEnumerable>{5}", ll.Reverse().AsString());
    }

    [TestMethod]
    public void Reverse_Basic()
    {
        var ll = new LinkedList();
        ll.InsertHead(2);
        ll.InsertHead(2);
        ll.InsertHead(3);
        ll.InsertHead(4);
        ll.InsertHead(2);
        ll.InsertHead(5);
        Assert.AreEqual("<IEnumerable>{2, 2, 3, 4, 2, 5}", ll.Reverse().AsString());
    }
}