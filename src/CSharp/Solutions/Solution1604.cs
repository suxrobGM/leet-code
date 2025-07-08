using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1604
{
    /// <summary>
    /// 1604. Alert Using Same Key-Card Three or More Times in a One Hour Period - Medium
    /// <a href="https://leetcode.com/problems/alert-using-same-key-card-three-or-more-times-in-a-one-hour-period">See the problem</a>
    /// </summary>
    public IList<string> AlertNames(string[] keyName, string[] keyTime)
    {
        var map = new Dictionary<string, List<int>>();

        // Convert time to minutes and group by name
        for (int i = 0; i < keyName.Length; i++)
        {
            string name = keyName[i];
            string time = keyTime[i];
            int minutes = ConvertToMinutes(time);

            if (!map.ContainsKey(name))
                map[name] = new List<int>();
            map[name].Add(minutes);
        }

        var result = new List<string>();

        foreach (var kvp in map)
        {
            var times = kvp.Value;
            times.Sort();

            // Sliding window to check for any 3 uses within 60 minutes
            for (int i = 0; i + 2 < times.Count; i++)
            {
                if (times[i + 2] - times[i] <= 60)
                {
                    result.Add(kvp.Key);
                    break;
                }
            }
        }

        result.Sort(); // Alphabetical order
        return result;
    }

    private int ConvertToMinutes(string time)
    {
        var parts = time.Split(':');
        int hours = int.Parse(parts[0]);
        int minutes = int.Parse(parts[1]);
        return hours * 60 + minutes;
    }
}
