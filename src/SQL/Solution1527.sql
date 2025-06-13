-- 1527. Patients With a Condition - Easy
-- Link: https://leetcode.com/problems/patients-with-a-condition
-- Solution in PostgreSQL

SELECT
    patient_id,
    patient_name,
    conditions
FROM
    Patients
WHERE
    -- look for a code that begins with the prefix `DIAB1`
    -- the code must either be at the start of the string (`^`)
    -- or be preceded by a space, and must be followed by a space
    -- or the end of the string so we do not match substrings
    -- inside other words.
    conditions ~ '(^| )DIAB1[0-9]*( |$)';
