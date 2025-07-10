using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1610
{
    /// <summary>
    /// 1610. Maximum Number of Visible Points - Hard
    /// <a href="https://leetcode.com/problems/maximum-number-of-visible-points">See the problem</a>
    /// </summary>
    public int VisiblePoints(IList<IList<int>> points, int angle, IList<int> location)
    {
        var angles = new List<double>();
        int sameLocation = 0;

        int posx = location[0];
        int posy = location[1];

        foreach (var point in points)
        {
            int x = point[0], y = point[1];

            if (x == posx && y == posy)
            {
                sameLocation++;
                continue;
            }

            double theta = Math.Atan2(y - posy, x - posx) * (180.0 / Math.PI);
            if (theta < 0) theta += 360;
            angles.Add(theta);
        }

        angles.Sort();
        int n = angles.Count;

        // Extend angles by 360 to handle wrap-around
        var extended = new List<double>(angles);
        foreach (var a in angles)
        {
            extended.Add(a + 360);
        }

        int maxVisible = 0;
        int left = 0;
        double maxAngle = angle + 1e-9; // Add small tolerance for float comparison

        for (int right = 0; right < extended.Count; right++)
        {
            while (extended[right] - extended[left] > maxAngle)
            {
                left++;
            }
            maxVisible = Math.Max(maxVisible, right - left + 1);
        }

        return maxVisible + sameLocation;
    }
}
