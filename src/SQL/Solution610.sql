-- 610. Triangle Judgement - Easy
-- Link: https://leetcode.com/problems/triangle-judgement/
-- Solution in PostgreSQL

SELECT x, y, z,
    CASE
        WHEN x + y > z AND x + z > y AND y + z > x THEN 'Yes'
        ELSE 'No'
    END AS triangle
FROM triangle;
