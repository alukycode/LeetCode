namespace LeetCode.LC_049;

public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Array.Sort(strs);

        var resultDictionary = new Dictionary<string, IList<string>>();

        foreach (var str in strs)
        {
            var key = GetKey(str);
            if (!resultDictionary.ContainsKey(key))
            {
                resultDictionary[key] = new List<string>();
            }
            resultDictionary[key].Add(str);
        }

        var result = resultDictionary.Select(kvp => kvp.Value).ToList();

        return result;
    }

    private string GetKey(string str)
    {
        char[] charArray = str.ToCharArray();
        Array.Sort(charArray);
        string sortedStr = new string(charArray);
        return sortedStr;
    }
}