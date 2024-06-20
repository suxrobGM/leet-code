-- 196. Delete Duplicate Emails - Easy
-- Link: https://leetcode.com/problems/delete-duplicate-emails
-- Solution in PostgreSQL
DELETE FROM Person
WHERE id NOT IN
(
    SELECT MIN(id)
    FROM Person
    GROUP BY email
);
