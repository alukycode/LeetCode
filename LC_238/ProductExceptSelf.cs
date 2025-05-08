namespace LeetCode.LC_238;

public class Solution
{
    public int[] ProductExceptSelfV1(int[] input)
    {
        int length = input.Length;
        int[] multiplicationsLeft = new int[length];
        int[] multiplicationsRight = new int[length];

        multiplicationsLeft[0] = 1;
        multiplicationsRight[length - 1] = 1;

        for (int i = 1; i < length; i++)
        {
            multiplicationsLeft[i] = multiplicationsLeft[i - 1] * input[i - 1];
            multiplicationsRight[length - i - 1] = multiplicationsRight[length - i] * input[length - i];
        }

        int[] result = new int[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = multiplicationsLeft[i] * multiplicationsRight[i];
        }

        return result;
    }

    public int[] ProductExceptSelf(int[] input)
    {
        int length = input.Length;
        int[] multiplicationsRight = new int[length];

        multiplicationsRight[length - 1] = 1;

        for (int i = length - 1; i > 0; i--)
        {
            multiplicationsRight[i - 1] = multiplicationsRight[i] * input[i];
        }

        var multiplicationsLeft = 1;
        for (int i = 0; i < length; i++)
        {
            multiplicationsRight[i] = multiplicationsLeft * multiplicationsRight[i];
            multiplicationsLeft = multiplicationsLeft * input[i];
        }

        return multiplicationsRight;
    }
}

[TestFixture]
public class Tests
{
    [Test]
    public void Test1()
    {
        int[] input = { 1, 7, 3, 4 };
        int[] expected = { 84, 12, 28, 21 };

        int[] actual = new Solution().ProductExceptSelf(input);

        Assert.AreEqual(expected, actual);
    }
}