-- 178. Rank Scores - Medium
-- Link: https://leetcode.com/problems/rank-scores
-- Solution in MySQL
SELECT
    Score,
    DENSE_RANK() OVER (ORDER BY Score DESC) AS `Rank`
FROM Scores;

