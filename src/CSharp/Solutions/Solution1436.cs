namespace LeetCode.Solutions;

public class Solution1436
{
    /// <summary>
    /// 1436. Destination City - Easy
    /// <a href="https://leetcode.com/problems/destination-city">See the problem</a>
    /// </summary>
    public string DestCity(IList<IList<string>> paths)
    {
        var startCities = new HashSet<string>();
        var endCities = new HashSet<string>();

        foreach (var path in paths)
        {
            startCities.Add(path[0]);
            endCities.Add(path[1]);
        }

        foreach (var city in endCities)
        {
            if (!startCities.Contains(city))
            {
                return city;
            }
        }

        return string.Empty; // This line should never be reached based on the problem constraints.
    }
}
