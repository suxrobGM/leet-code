-- 1667. Fix Names in a Table - Easy
-- Link: https://leetcode.com/problems/fix-names-in-a-table
-- Solution in PostgreSQL

SELECT
  user_id,
  UPPER(LEFT(name, 1)) || LOWER(SUBSTRING(name FROM 2)) AS name
FROM Users
ORDER BY user_id;
