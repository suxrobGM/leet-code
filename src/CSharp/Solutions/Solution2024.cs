namespace LeetCode.Solutions;

public class Solution2024
{
    /// <summary>
    /// 2024. Maximize the Confusion of an Exam - Medium
    /// <a href="https://leetcode.com/problems/maximize-the-confusion-of-an-exam">See the problem</a>
    /// </summary>
    public int MaxConsecutiveAnswers(string answerKey, int k)
    {
        var maxConsecutiveT = 0;
        var maxConsecutiveF = 0;
        var countT = 0;
        var countF = 0;
        var left = 0;

        for (var right = 0; right < answerKey.Length; right++)
        {
            if (answerKey[right] == 'T')
            {
                countT++;
            }
            else
            {
                countF++;
            }

            while (countT > k && countF > k)
            {
                if (answerKey[left] == 'T')
                {
                    countT--;
                }
                else
                {
                    countF--;
                }

                left++;
            }

            maxConsecutiveT = Math.Max(maxConsecutiveT, right - left + 1);
            maxConsecutiveF = Math.Max(maxConsecutiveF, right - left + 1);
        }

        return Math.Max(maxConsecutiveT, maxConsecutiveF);
    }
}
