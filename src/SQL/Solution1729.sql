-- 1729. Find Followers Count - Easy
-- Link: https://leetcode.com/problems/find-followers-count
-- Solution in PostgreSQL

SELECT
  user_id,
  COUNT(follower_id) AS followers_count
FROM
  Followers
GROUP BY
  user_id
ORDER BY
  user_id;
