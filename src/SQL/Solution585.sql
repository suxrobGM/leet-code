-- 585. Investments in 2016 - Medium
-- Link: https://leetcode.com/problems/investments-in-2016
-- Solution in PostgreSQL

SELECT 
    ROUND(CAST(SUM(tiv_2016) AS numeric), 2) AS tiv_2016
FROM
    Insurance
WHERE 
    -- Policyholders who share the same tiv_2015 with at least one other policyholder
    tiv_2015 IN (
        SELECT tiv_2015
        FROM Insurance
        GROUP BY tiv_2015
        HAVING COUNT(*) > 1
    )
    -- Policyholders whose lat, lon pair is unique
    AND (lat, lon) IN (
        SELECT lat, lon
        FROM Insurance
        GROUP BY lat, lon
        HAVING COUNT(*) = 1
    );

