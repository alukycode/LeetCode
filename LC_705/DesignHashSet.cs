namespace LeetCode.LC_705;

// https://leetcode.com/problems/design-hashset/

public class MyHashSet
{

    public MyHashSet()
    {

    }

    public void Add(int key)
    {

    }

    public void Remove(int key)
    {

    }

    public bool Contains(int key)
    {
        throw new NotImplementedException();
    }
}

public class DesignHashSet
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [Ignore("I don't remember why it doesn't work")]
    public void Test1()
    {
        var key = 5;
        MyHashSet obj = new MyHashSet();
        obj.Add(key);
        obj.Remove(key);
        bool param_3 = obj.Contains(key);
    }
}