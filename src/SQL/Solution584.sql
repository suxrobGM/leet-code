-- 584. Find Customer Referee - Easy
-- Link: https://leetcode.com/problems/find-customer-referee
-- Solution in PostgreSQL

SELECT name
FROM Customer
WHERE referee_id IS NULL OR referee_id != 2;
