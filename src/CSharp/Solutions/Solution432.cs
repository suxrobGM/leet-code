namespace LeetCode.Solutions;

public class Solution432
{
    /// <summary>
    /// 432. All O`one Data Structure - Hard
    /// <a href="https://leetcode.com/problems/all-oone-data-structure">See the problem</a>
    /// </summary>
    public class AllOne
    {
        // Dictionary to store the count of each string
        private Dictionary<string, int> keyCount;

        // Dictionary to store sets of strings for each count
        private Dictionary<int, HashSet<string>> countKeys;

        // Sorted sets to keep track of minimum and maximum counts
        private SortedSet<int> counts;

        public AllOne()
        {
            keyCount = new Dictionary<string, int>();
            countKeys = new Dictionary<int, HashSet<string>>();
            counts = new SortedSet<int>();
        }

        public void Inc(string key)
        {
            if (keyCount.ContainsKey(key))
            {
                int oldCount = keyCount[key];
                keyCount[key] = oldCount + 1;
                countKeys[oldCount].Remove(key);
                if (countKeys[oldCount].Count == 0)
                {
                    countKeys.Remove(oldCount);
                    counts.Remove(oldCount);
                }
                if (!countKeys.ContainsKey(oldCount + 1))
                {
                    countKeys[oldCount + 1] = new HashSet<string>();
                    counts.Add(oldCount + 1);
                }
                countKeys[oldCount + 1].Add(key);
            }
            else
            {
                keyCount[key] = 1;
                if (!countKeys.ContainsKey(1))
                {
                    countKeys[1] = [];
                    counts.Add(1);
                }
                countKeys[1].Add(key);
            }
        }

        public void Dec(string key)
        {
            if (keyCount.ContainsKey(key))
            {
                int oldCount = keyCount[key];
                keyCount[key] = oldCount - 1;
                countKeys[oldCount].Remove(key);
                if (countKeys[oldCount].Count == 0)
                {
                    countKeys.Remove(oldCount);
                    counts.Remove(oldCount);
                }
                if (keyCount[key] == 0)
                {
                    keyCount.Remove(key);
                }
                else
                {
                    if (!countKeys.ContainsKey(oldCount - 1))
                    {
                        countKeys[oldCount - 1] = new HashSet<string>();
                        counts.Add(oldCount - 1);
                    }
                    countKeys[oldCount - 1].Add(key);
                }
            }
        }

        public string GetMaxKey()
        {
            if (counts.Count == 0)
                return "";

            int maxCount = counts.Max;
            if (countKeys.ContainsKey(maxCount))
                return countKeys[maxCount].First();

            return "";
        }

        public string GetMinKey()
        {
            if (counts.Count == 0)
                return "";

            int minCount = counts.Min;
            if (countKeys.ContainsKey(minCount))
                return countKeys[minCount].First();

            return "";
        }
    }
}
