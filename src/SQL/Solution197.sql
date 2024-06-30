-- 197. Rising Temperature - Easy
-- Link: https://leetcode.com/problems/rising-temperature
-- Solution in PostgreSQL
SELECT weather.id AS "Id"
FROM Weather
WHERE Temperature > 
(
    SELECT Temperature 
    FROM Weather AS PreviousDay
    WHERE PreviousDay.RecordDate = Weather.RecordDate - INTERVAL '1 day'
);
