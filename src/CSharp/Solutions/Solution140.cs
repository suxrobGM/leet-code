namespace LeetCode.Solutions;

public class Solution140
{
    /// <summary>
    /// 140. Word Break II - Hard
    /// <a href="https://leetcode.com/problems/word-break-ii">See the problem</a>
    /// </summary>
    public IList<string> WordBreak(string s, IList<string> wordDict)
    {
        var wordSet = new HashSet<string>(wordDict);
        var memo = new Dictionary<int, List<string>>();
        return DFS(s, 0, wordSet, memo);
    }
    
    private List<string> DFS(string s, int start, HashSet<string> wordSet, Dictionary<int, List<string>> memo)
    {
        if (memo.ContainsKey(start))
        {
            return memo[start];
        }
        
        var result = new List<string>();
        
        if (start == s.Length)
        {
            result.Add("");
        }
        
        for (var end = start + 1; end <= s.Length; end++)
        {
            var word = s[start..end];
            
            if (wordSet.Contains(word))
            {
                var list = DFS(s, end, wordSet, memo);
                
                foreach (var next in list)
                {
                    result.Add(word + (string.IsNullOrEmpty(next) ? "" : " ") + next);
                }
            }
        }
        
        memo[start] = result;
        return result;
    }
}
