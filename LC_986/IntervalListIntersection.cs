namespace LeetCode.LC_986;

public class Solution
{
    public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
    {
        var result = new List<int[]>();

        var index1 = 0;
        var index2 = 0;

        while (index1 < firstList.Length && index2 < secondList.Length)
        {
            var interval1 = firstList[index1];
            var interval2 = secondList[index2];

            var resultingPair = new int[2];
            resultingPair[0] = Math.Max(interval1[0], interval2[0]);

            if (interval1[1] > interval2[1])
            {
                resultingPair[1] = interval2[1];
                index2++;
            }
            else
            {
                resultingPair[1] = interval1[1];
                index1++;
            }

            if (resultingPair[0] <= resultingPair[1])
            {
                result.Add(resultingPair);
            }
        }

        return result.ToArray();
    }
}