-- 1661. Average Time of Process per Machine - Easy
-- Link: https://leetcode.com/problems/average-time-of-process-per-machine
-- Solution in PostgreSQL

WITH ProcessTimes AS (
  SELECT
    machine_id,
    process_id,
    MAX(CASE WHEN activity_type = 'start' THEN timestamp END) AS start_time,
    MAX(CASE WHEN activity_type = 'end' THEN timestamp END) AS end_time
  FROM Activity
  GROUP BY machine_id, process_id
),
Durations AS (
  SELECT
    machine_id,
    end_time - start_time AS duration
  FROM ProcessTimes
)
SELECT
  machine_id,
  ROUND(AVG(duration)::numeric, 3) AS processing_time
FROM Durations
GROUP BY machine_id;
