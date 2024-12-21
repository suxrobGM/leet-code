using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution911
{
    /// <summary>
    /// 911. Online Election - Medium
    /// <a href="https://leetcode.com/problems/online-election">See the problem</a>
    /// </summary>
    public class TopVotedCandidate
    {
        private int[] times;
        private List<int> leaders;

        public TopVotedCandidate(int[] persons, int[] times)
        {
            this.times = times;
            this.leaders = new List<int>();

            // Dictionary to store vote counts
            var voteCounts = new Dictionary<int, int>();
            int currentLeader = -1;
            int maxVotes = 0;

            // Process votes
            for (int i = 0; i < persons.Length; i++)
            {
                int person = persons[i];
                if (!voteCounts.ContainsKey(person))
                {
                    voteCounts[person] = 0;
                }
                voteCounts[person]++;

                // Update leader
                if (voteCounts[person] > maxVotes || (voteCounts[person] == maxVotes && person != currentLeader))
                {
                    currentLeader = person;
                    maxVotes = voteCounts[person];
                }
                leaders.Add(currentLeader);
            }
        }

        public int Q(int t)
        {
            // Binary search to find the largest time <= t
            int left = 0, right = times.Length - 1;
            while (left < right)
            {
                int mid = left + (right - left + 1) / 2;
                if (times[mid] <= t)
                {
                    left = mid;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return leaders[left];
        }
    }
}
