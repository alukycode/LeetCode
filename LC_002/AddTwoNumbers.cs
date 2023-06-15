namespace LeetCode.LC_002;

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode firstResultNode = null;
        ListNode previousResultNode = null;
        var previousSumOverflow = 0;

        while (l1 != null || l2 != null)
        {
            var currentResultValue = 0;
            if (l1 != null)
            {
                currentResultValue += l1.val;
                l1 = l1.next;
            }

            if (l2 != null)
            {
                currentResultValue += l2.val;
                l2 = l2.next;
            }

            currentResultValue += previousSumOverflow;

            previousSumOverflow = currentResultValue / 10;

            currentResultValue = currentResultValue % 10;

            var currentResultNode = new ListNode(currentResultValue);

            if (firstResultNode == null)
            {
                firstResultNode = currentResultNode;
            }

            if (previousResultNode != null)
            {
                previousResultNode.next = currentResultNode;
            }

            previousResultNode = currentResultNode;
        }

        if (previousSumOverflow > 0)
        {
            var overflowNode = new ListNode(previousSumOverflow);
            previousResultNode!.next = overflowNode;
        }

        return firstResultNode;
    }
}


public class TestCases
{
    [TestCase(new[] { 2, 4, 3 }, new[] { 5, 6, 4 }, new[] { 7, 0, 8 })] // 342 + 465 = 807.
    [TestCase(new[] { 0 }, new[] { 0 }, new[] { 0 })]
    [TestCase(new[] { 9, 9, 9, 9, 9, 9, 9 }, new[] { 9, 9, 9, 9 }, new[] { 8, 9, 9, 9, 0, 0, 0, 1 })]
    public void Test1(int[] l1, int[] l2, int[] expected)
    {
        var l1Node = ToListNode(l1);
        var l2Node = ToListNode(l2);

        var solution = new Solution();
        var resultNode = solution.AddTwoNumbers(l1Node, l2Node);

        var result = ToArray(resultNode);

        CollectionAssert.AreEqual(expected, result);
    }

    [TestCase(new[] { 1, 2, 3 })]
    [TestCase(new[] { 0 })]
    public void ConversionWorks(int[] expectedArray)
    {
        var node = ToListNode(expectedArray);
        var actualArray = ToArray(node);

        CollectionAssert.AreEqual(expectedArray, actualArray);
    }

    private static ListNode ToListNode(int[] array)
    {
        ListNode firstNode = null;
        ListNode previousNode = null;

        foreach (var item in array)
        {
            var currentNode = new ListNode(item);

            if (firstNode == null)
            {
                firstNode = currentNode;
            }

            if (previousNode != null)
            {
                previousNode.next = currentNode;
            }

            previousNode = currentNode;
        }

        return firstNode;
    }

    private static int[] ToArray(ListNode listNode)
    {
        var list = new List<int>();

        var currentListNode = listNode;

        while (currentListNode != null)
        {
            list.Add(currentListNode.val);
            currentListNode = currentListNode.next;
        }

        return list.ToArray();
    }
}