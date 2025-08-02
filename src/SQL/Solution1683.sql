-- 1683. Invalid Tweets - Easy
-- Link: https://leetcode.com/problems/invalid-tweets
-- Solution in PostgreSQL

SELECT tweet_id
FROM Tweets
WHERE LENGTH(content) > 15;
