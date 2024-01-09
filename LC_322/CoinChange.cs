namespace LeetCode.LC_322;

public class Solution
{
    public int CoinChange(int[] coins, int amount)
    {
        if (amount == 0)
        {
            return 0;
        }

        var weights = new short[amount + 1];

        for (var i = coins.Length - 1; i >= 0; i--)
        {
            int coin = coins[i];
            for (short currentValue = 0; currentValue <= amount; currentValue++)
            {
                if (weights[currentValue] == 0 && currentValue != 0)
                {
                    continue;
                }

                var nextValue = currentValue + coin;
                short nextWeight = (short)(weights[currentValue] + 1);

                if (nextValue > amount)
                {
                    break;
                }

                if (weights[nextValue] == 0 || weights[nextValue] > nextWeight)
                {
                    weights[nextValue] = (short)nextWeight;
                }
            }
        }

        return weights[amount] == 0 ? -1 : weights[amount];
    }
}


public class SolutionV2
{
    public int CoinChange(int[] coins, int amount)
    {
        Array.Sort(coins);

        var weights = new int[amount + 1];
        Array.Fill(weights, -1);
        weights[0] = 0;

        for (var i = coins.Length - 1; i >= 0; i--)
        {
            var coin = coins[i];
            for (var currentValue = 0; currentValue <= amount; currentValue++)
            {
                if (weights[currentValue] == -1)
                {
                    continue;
                }

                var nextValue = currentValue + coin;
                var nextWeight = weights[currentValue] + 1;

                if (nextValue > amount)
                {
                    break;
                }

                if (weights[nextValue] == -1 || weights[nextValue] > nextWeight)
                {
                    weights[nextValue] = nextWeight;
                }
            }
        }

        return weights[amount];
    }
}

public class SolutionV1
{
    public int CoinChange(int[] coins, int amount)
    {
        var weights = new int[amount + 1];
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