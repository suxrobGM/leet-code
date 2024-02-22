namespace LeetCode.Solutions;

public class Solution383
{
    /// <summary>
    /// 383. Ransom Note
    /// <a href="https://leetcode.com/problems/ransom-note">See the problem</a>
    /// </summary>
    public bool CanConstruct(string ransomNote, string magazine)
    {
        var ransomLetters = new List<char>(ransomNote);
        var counter = magazine.Count(letter => ransomLetters.Remove(letter));
        return ransomNote.Length == counter;
    }
}
