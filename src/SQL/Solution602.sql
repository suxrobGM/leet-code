-- 602. Friend Requests II: Who Has the Most Friends - Medium
-- Link: https://leetcode.com/problems/friend-requests-ii-who-has-the-most-friends
-- Solution in PostgreSQL

WITH FriendCounts AS (
    -- Count the number of friends for each user
    SELECT requester_id AS user_id, COUNT(DISTINCT accepter_id) AS friend_count
    FROM RequestAccepted
    GROUP BY requester_id

    UNION ALL

    SELECT accepter_id AS user_id, COUNT(DISTINCT requester_id) AS friend_count
    FROM RequestAccepted
    GROUP BY accepter_id
),
AggregatedFriends AS (
    -- Aggregate the counts for each user
    SELECT user_id, SUM(friend_count) AS total_friends
    FROM FriendCounts
    GROUP BY user_id
),
MaxFriendCount AS (
    -- Get the maximum friend count
    SELECT MAX(total_friends) AS max_friends
    FROM AggregatedFriends
)

-- Select the person with the most friends and the number of friends
SELECT user_id AS id, total_friends AS num
FROM AggregatedFriends
WHERE total_friends = (SELECT max_friends FROM MaxFriendCount);
