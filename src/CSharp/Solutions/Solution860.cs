using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution860
{
    /// <summary>
    /// 860. Lemonade Change - Easy
    /// <a href="https://leetcode.com/problems/lemonade-change">See the problem</a>
    /// </summary>
    public bool LemonadeChange(int[] bills)
    {
        int five = 0;
        int ten = 0;

        foreach (int bill in bills)
        {
            if (bill == 5)
            {
                five++;
            }
            else if (bill == 10)
            {
                if (five == 0)
                {
                    return false;
                }

                five--;
                ten++;
            }
            else
            {
                if (ten > 0 && five > 0)
                {
                    ten--;
                    five--;
                }
                else if (five >= 3)
                {
                    five -= 3;
                }
                else
                {
                    return false;
                }
            }
        }

        return true;
    }
}
