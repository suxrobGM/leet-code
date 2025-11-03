-- 1890. The Latest Login in 2020 - Easy
-- Link: https://leetcode.com/problems/the-latest-login-in-2020
-- Solution in PostgreSQL

SELECT user_id, MAX(time_stamp) AS last_stamp
FROM Logins
WHERE time_stamp >= '2020-01-01 00:00:00' AND time_stamp < '2021-01-01 00:00:00'
GROUP BY user_id;
