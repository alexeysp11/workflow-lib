UPDATE participant
SET name = '{0}'
WHERE participant_id = (
    SELECT participant_id 
    FROM participant p 
    WHERE UPPER(name) LIKE UPPER('{1}')
)