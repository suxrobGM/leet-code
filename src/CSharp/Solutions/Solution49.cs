namespace LeetCode.Solutions;

public class Solution49
{
    /// <summary>
    /// 49. Group Anagrams - Medium
    /// <a href="https://leetcode.com/problems/group-anagrams">See the problem</a>
    /// </summary>
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        if (strs == null || strs.Length == 0)
        {
            return new List<IList<string>>();
        }

        // Dictionary to hold the groups of anagrams
        var anagrams = new Dictionary<string, IList<string>>();

        foreach (var str in strs)
        {
            // Convert string to char array to sort, then back to string
            var charArray = str.ToCharArray();
            Array.Sort(charArray);
            var sorted = new string(charArray);

            // Add original string to the correct group in the dictionary
            if (!anagrams.ContainsKey(sorted))
            {
                anagrams[sorted] = [];
            }
            
            anagrams[sorted].Add(str);
        }
        
        return anagrams.Values.ToList();
    }
}
