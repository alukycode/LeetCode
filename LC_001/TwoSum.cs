namespace LeetCode.LC_705;

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = i+1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return new[] { i, j };
                }
            }
        }

        throw new Exception("Unable to find a solution");
    }
}

public class TestCases
{
    [TestCase(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
    [TestCase(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
    [TestCase(new[] { 3, 3 }, 6, new[] { 0, 1 })]
    public void Test1(int[] nums, int target, int[] expected)
    {
        var solution = new Solution();
        var result = solution.TwoSum(nums, target);

        CollectionAssert.AreEqual(expected, result);
    }
}