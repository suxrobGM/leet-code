-- 620. Not Boring Movies - Easy
-- Link: https://leetcode.com/problems/not-boring-movies
-- Solution in PostgreSQL

SELECT 
    id, 
    movie, 
    description, 
    rating
FROM 
    Cinema
WHERE 
    id % 2 = 1  -- Filter for odd-numbered IDs
    AND description != 'boring'  -- Exclude boring descriptions
ORDER BY 
    rating DESC;  -- Order by rating in descending order
