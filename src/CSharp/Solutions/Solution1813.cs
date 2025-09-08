using System.Text;

namespace LeetCode.Solutions;

public class Solution1813
{
    /// <summary>
    /// 1813. Sentence Similarity III - Medium
    /// <a href="https://leetcode.com/problems/sentence-similarity-iii">See the problem</a>
    /// </summary>
    public bool AreSentencesSimilar(string sentence1, string sentence2)
    {
        var w1 = sentence1.Split(' ');
        var w2 = sentence2.Split(' ');

        // Ensure w1 is longer
        if (w1.Length < w2.Length)
        {
            (w2, w1) = (w1, w2);
        }

        int n1 = w1.Length, n2 = w2.Length;

        int left = 0;
        while (left < n2 && w1[left] == w2[left])
        {
            left++;
        }

        int right = 0;
        while (right < n2 - left && w1[n1 - 1 - right] == w2[n2 - 1 - right])
        {
            right++;
        }

        return left + right == n2;
    }
}

