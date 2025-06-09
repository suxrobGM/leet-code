-- 1517. Find Users With Valid E-Mails - Easy
-- Link: https://leetcode.com/problems/find-users-with-valid-e-mails
-- Solution in PostgreSQL

SELECT *
FROM Users
WHERE mail ~* '^[a-zA-Z][a-zA-Z0-9._-]*@leetcode\.com$';
