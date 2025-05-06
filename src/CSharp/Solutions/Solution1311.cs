using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1311
{
    /// <summary>
    /// 1311. Get Watched Videos by Your Friends - Medium
    /// <a href="https://leetcode.com/problems/get-watched-videos-by-your-friends">See the problem</a>
    /// </summary>
    public IList<string> WatchedVideosByFriends(IList<IList<string>> watchedVideos, int[][] friends, int id, int level)
    {
        var visited = new HashSet<int> { id };
        var queue = new Queue<int>();
        queue.Enqueue(id);

        for (int i = 0; i < level; i++)
        {
            int size = queue.Count;
            for (int j = 0; j < size; j++)
            {
                int currentFriend = queue.Dequeue();
                foreach (var friend in friends[currentFriend])
                {
                    if (visited.Add(friend))
                    {
                        queue.Enqueue(friend);
                    }
                }
            }
        }

        var videoCount = new Dictionary<string, int>();
        while (queue.Count > 0)
        {
            int currentFriend = queue.Dequeue();
            foreach (var video in watchedVideos[currentFriend])
            {
                if (!videoCount.ContainsKey(video))
                {
                    videoCount[video] = 0;
                }
                videoCount[video]++;
            }
        }

        return [.. videoCount.OrderBy(kvp => kvp.Value).ThenBy(kvp => kvp.Key).Select(kvp => kvp.Key)];
    }
}
