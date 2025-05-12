using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1348
{
    /// <summary>
    /// 1348. Tweet Counts Per Frequency - Medium
    /// <a href="https://leetcode.com/problems/tweet-counts-per-frequency">See the problem</a>
    /// </summary>
    public class TweetCounts
    {
        private readonly Dictionary<string, List<int>> tweetMap = [];

        public void RecordTweet(string tweetName, int time)
        {
            if (!tweetMap.ContainsKey(tweetName))
                tweetMap[tweetName] = new List<int>();

            tweetMap[tweetName].Add(time);
        }

        public IList<int> GetTweetCountsPerFrequency(string freq, string tweetName, int startTime, int endTime)
        {
            int interval = freq == "minute" ? 60 : freq == "hour" ? 3600 : 86400;
            int bucketCount = (endTime - startTime) / interval + 1;
            int[] counts = new int[bucketCount];

            if (!tweetMap.ContainsKey(tweetName))
                return counts;

            foreach (int time in tweetMap[tweetName])
            {
                if (time >= startTime && time <= endTime)
                {
                    int idx = (time - startTime) / interval;
                    counts[idx]++;
                }
            }

            return counts;
        }
    }
}
