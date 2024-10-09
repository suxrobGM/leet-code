-- 627. Swap Salary - Easy
-- Link: https://leetcode.com/problems/swap-salary
-- Solution in PostgreSQL

UPDATE Salary
SET sex = CASE 
            WHEN sex = 'f' THEN 'm' 
            WHEN sex = 'm' THEN 'f' 
            ELSE sex
          END;
