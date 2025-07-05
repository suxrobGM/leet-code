-- 1587. Bank Account Summary II - Easy
-- Link: https://leetcode.com/problems/bank-account-summary-ii
-- Solution in PostgreSQL

SELECT u.name, SUM(t.amount) AS balance
FROM Users u
JOIN Transactions t ON u.account = t.account
GROUP BY u.name
HAVING SUM(t.amount) > 10000;
