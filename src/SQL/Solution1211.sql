-- 1211. Queries Quality and Percentage - Easy
-- Link: https://leetcode.com/problems/queries-quality-and-percentage
-- Solution in PostgreSQL

SELECT 
    query_name,
    ROUND(AVG(rating * 1.0 / position), 2) AS quality,
    ROUND(100.0 * SUM(CASE WHEN rating < 3 THEN 1 ELSE 0 END) / COUNT(*), 2) AS poor_query_percentage
FROM Queries
GROUP BY query_name;
