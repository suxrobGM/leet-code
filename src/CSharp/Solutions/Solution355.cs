using System.Text;

namespace LeetCode.Solutions;

public class Solution355
{
    /// <summary>
    /// 355. Design Twitter - Medium
    /// <a href="https://leetcode.com/problems/design-twitter">See the problem</a>
    /// </summary>
    public class Twitter
    {
        private readonly Dictionary<int, HashSet<int>> _followers = [];
        private readonly Dictionary<int, List<(int TweetId, int Time)>> _tweets = [];
        private int _time;

        public void PostTweet(int userId, int tweetId)
        {
            if (!_tweets.ContainsKey(userId))
            {
                _tweets[userId] = [];
            }

            _tweets[userId].Add((tweetId, _time++));
        }

        public IList<int> GetNewsFeed(int userId)
        {
            var tweets = new List<(int TweetId, int Time)>();

            if (_tweets.ContainsKey(userId))
            {
                tweets.AddRange(_tweets[userId]);
            }

            if (_followers.ContainsKey(userId))
            {
                foreach (var follower in _followers[userId])
                {
                    if (_tweets.ContainsKey(follower))
                    {
                        tweets.AddRange(_tweets[follower]);
                    }
                }
            }

            return tweets.OrderByDescending(t => t.Time).Take(10).Select(t => t.TweetId).ToList();
        }

        public void Follow(int followerId, int followeeId)
        {
            if (!_followers.ContainsKey(followerId))
            {
                _followers[followerId] = [];
            }

            _followers[followerId].Add(followeeId);
        }

        public void Unfollow(int followerId, int followeeId)
        {
            if (_followers.ContainsKey(followerId))
            {
                _followers[followerId].Remove(followeeId);
            }
        }
    }
}
