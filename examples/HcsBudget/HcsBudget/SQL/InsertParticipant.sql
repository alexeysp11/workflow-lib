INSERT INTO participant (name) 
SELECT '{0}'
WHERE
(
    SELECT COUNT(*)
    FROM participant
    WHERE UPPER(name) LIKE UPPER('{0}')
) = 0