namespace LeetCode.LC_233;

public class Solution
{
    public int CountDigitOne(int n)
    {
        return (int)CountDigit(n, 1);
    }

    public long CountDigit(long maxNumber, int digitToCount)
    {
        if (digitToCount == 0)
        {
            throw new NotImplementedException();
        }

        var totalSum = 0L;

        var divisor = 1; // 1 for last digit, 10 for second last digit, etc.

        while (maxNumber >= divisor)
        {
            totalSum += maxNumber / (divisor * 10) * divisor;

            var digit = maxNumber / divisor % 10;

            if (digit < digitToCount)
            {
                // do nothing
            }
            else if (digit == digitToCount)
            {
                totalSum += maxNumber % divisor + 1;
            }
            else if (digit > digitToCount)
            {
                totalSum += divisor;
            }

            divisor *= 10;
        }

        return totalSum;
    }
}

public class TestCases
{
    [TestCase(123456789, 2, 666)]
    [TestCase(13, 1, 6)]
    [TestCase(0, 1, 0)]
    [TestCase(1, 1, 1)]
    [TestCase(100, 1, 21)]
    [TestCase(25, 2, 9)]
    [TestCase(50,2,15)]
    [TestCase(12,2,2)]
    [TestCase(3,2,1)]
    [TestCase(0, 0, 1)]
    [TestCase(10, 0, 2)]
    [TestCase(20, 0, 3)]
    [TestCase(100, 0, 3)]
    public void Test1(long maxNumber, int digitToCount, long expected)
    {
        var solution = new Solution();
        var result = solution.CountDigit(maxNumber, digitToCount);

        Assert.AreEqual(expected, actual: result);
    }
}