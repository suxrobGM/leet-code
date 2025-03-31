﻿-- 1174. Immediate Food Delivery II - Medium
-- Link: https://leetcode.com/problems/immediate-food-delivery-ii
-- Solution in PostgreSQL

SELECT 
    ROUND(100.0 * 
        SUM(CASE 
                WHEN order_date = customer_pref_delivery_date THEN 1 
                ELSE 0 
            END) 
        / COUNT(*), 2) AS immediate_percentage
FROM Delivery
WHERE (customer_id, order_date) IN (
    SELECT customer_id, MIN(order_date)
    FROM Delivery
    GROUP BY customer_id
);
