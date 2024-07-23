namespace LeetCode.Solutions;

public class Solution412
{
    /// <summary>
    /// 412. Fizz Buzz - Easy
    /// <a href="https://leetcode.com/problems/fizz-buzz">See the problem</a>
    /// </summary>
    public IList<string> FizzBuzz(int n)
    {
        var result = new List<string>();

        for (var i = 1; i <= n; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                result.Add("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                result.Add("Fizz");
            }
            else if (i % 5 == 0)
            {
                result.Add("Buzz");
            }
            else
            {
                result.Add(i.ToString());
            }
        }

        return result;
    }
}
