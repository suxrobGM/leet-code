using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1282
{
    /// <summary>
    /// 1282. Group the People Given the Group Size They Belong To - Medium
    /// <a href="https://leetcode.com/problems/group-the-people-given-the-group-size-they-belong-to">See the problem</a>
    /// </summary>
    public IList<IList<int>> GroupThePeople(int[] groupSizes)
    {
        var groups = new List<IList<int>>();
        var sizeToPeople = new Dictionary<int, List<int>>();

        for (int i = 0; i < groupSizes.Length; i++)
        {
            int size = groupSizes[i];
            if (!sizeToPeople.ContainsKey(size))
            {
                sizeToPeople[size] = [];
            }
            sizeToPeople[size].Add(i);

            if (sizeToPeople[size].Count == size)
            {
                groups.Add(sizeToPeople[size]);
                sizeToPeople[size] = [];
            }
        }

        return groups;
    }
}
