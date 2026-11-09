namespace LC_458;

// https://leetcode.com/problems/poor-pigs/

public class Solution
{
    public int PoorPigs(int buckets, int minutesToDie, int minutesToTest)
    {
        var numberOfTests = minutesToTest / minutesToDie;

         // states:
         // 1 = pig died after 1st test,
         // 2 = pig died after 2nd test,
         // ...
         // 0 = pig alive after all tests 
        var numberOfStates = numberOfTests + 1;
        
        var result = 0;

        var maxBucketIndex = buckets - 1;
        while (maxBucketIndex > 0)
        {
            maxBucketIndex = maxBucketIndex / numberOfStates;
            result++;
        }

        return result;
    }
}

[TestFixture]
public class TestCases
{
    [TestCase(4, 15, 15, 2)]
    [TestCase(4, 15, 30, 2)]
    [TestCase(240, 24, 48, 5)]
    public void PoorPigs_ReturnsMinimumPigCount(
        int buckets,
        int minutesToDie,
        int minutesToTest,
        int expected)
    {
        var solution = new Solution();

        var result = solution.PoorPigs(buckets, minutesToDie, minutesToTest);

        Assert.AreEqual(expected, result);
    }
}