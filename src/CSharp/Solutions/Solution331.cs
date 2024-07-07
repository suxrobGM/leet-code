using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution331
{
    /// <summary>
    /// 331. Verify Preorder Serialization of a Binary Tree - Medium
    /// <a href="https://leetcode.com/problems/verify-preorder-serialization-of-a-binary-tree">See the problem</a>
    /// </summary>
    public bool IsValidSerialization(string preorder)
    {
        var slots = 1;

        foreach (var node in preorder.Split(','))
        {
            slots--;

            if (slots < 0)
            {
                return false;
            }

            if (node != "#")
            {
                slots += 2;
            }
        }

        return slots == 0;
    }
}
