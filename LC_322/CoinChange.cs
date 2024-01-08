namespace LeetCode.LC_322;

public class Solution
{
    public int CoinChange(int[] coins, int amount)
    {
        var weights = new int[amount+1];
        foreach (var coin in coins)
        {
            if (coin <= amount)
            {
                weights[coin] = 1;
            }
        }

        for (var currentValue = 1; currentValue <= amount; currentValue++)
        {
            if (weights[currentValue] == 1)
            {
                continue;
            }
            else
            {
                weights[currentValue] = -1;
            }


            for (var j = currentValue / 2; j > 0; j--)
            {
                var firstWeight = weights[j];
                var secondWeight = weights[currentValue - j];
                if (firstWeight == -1 || secondWeight == -1)
                {
                    continue;
                }

                var anotherWeight = firstWeight + secondWeight;
                if (weights[currentValue] == -1 || anotherWeight < weights[currentValue])
                {
                    weights[currentValue] = anotherWeight;
                }
            }
        }

        return weights[amount];
    }
}

public class TestCases
{
    [TestCase(new[] { 1, 2, 5 }, 11, 3)]
    [TestCase(new[] { 2 }, 3, -1)]
    [TestCase(new[] { 1 }, 0, 0)]
    [TestCase(new[] { 1 }, 1, 1)]
    public void Test1(int[] coins, int amount, int expected)
    {
        var solution = new Solution();
        var result = solution.CoinChange(coins, amount);

        Assert.AreEqual(expected, result);
    }
}