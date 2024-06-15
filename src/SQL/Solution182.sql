-- 182. Duplicate Emails - Easy
-- Link: https://leetcode.com/problems/duplicate-emails
-- Solution in MySQL
SELECT Email FROM Person
GROUP BY Email
HAVING COUNT(Email) > 1;
