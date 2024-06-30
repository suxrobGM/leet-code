-- 262. Trips and Users - Hard
-- Link: https://leetcode.com/problems/trips-and-users
-- Solution in PostgreSQL
WITH unbanned_requests AS (
    SELECT
        request_at,
        status,
        client_id,
        driver_id
    FROM
        Trips
    WHERE
        request_at BETWEEN '2013-10-01' AND '2013-10-03'
        AND client_id NOT IN (SELECT user_id FROM Users WHERE banned = 'Yes')
        AND driver_id NOT IN (SELECT user_id FROM Users WHERE banned = 'Yes')
)
SELECT
    request_at AS Day,
    ROUND(
        CAST(SUM(CASE WHEN status = 'cancelled_by_client' OR status = 'cancelled_by_driver' THEN 1 ELSE 0 END) AS NUMERIC)
        /
        CAST(COUNT(*) AS NUMERIC), 2
    ) AS CancellationRate
FROM
    unbanned_requests
GROUP BY
    request_at
ORDER BY
    request_at;
