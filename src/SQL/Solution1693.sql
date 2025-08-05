-- 1693. 1693. Daily Leads and Partners - Easy
-- Link: https://leetcode.com/problems/daily-leads-and-partners
-- Solution in PostgreSQL

SELECT
  date_id,
  make_name,
  COUNT(DISTINCT lead_id) AS unique_leads,
  COUNT(DISTINCT partner_id) AS unique_partners
FROM
  DailySales
GROUP BY
  date_id,
  make_name;
