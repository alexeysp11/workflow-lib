-- Firms (all firms)
SELECT 
    f.name AS firm_name, 
    pc.name AS post_city_name, 
    jc.name AS jur_city_name
FROM test_task.firm f 
INNER JOIN test_task.city pc ON pc.city_id = f.post_city_id
INNER JOIN test_task.city jc ON jc.city_id = f.jur_city_id
ORDER BY firm_id; 

-- Firms (filtering)
SELECT 
    f.name AS firm_name, 
    pc.name AS post_city_name, 
    jc.name AS jur_city_name
FROM test_task.firm f 
INNER JOIN test_task.city pc ON pc.city_id = f.post_city_id
INNER JOIN test_task.city jc ON jc.city_id = f.jur_city_id
WHERE 
    (
        UPPER(f.name) LIKE UPPER('FiRM2') 
            AND UPPER(pc.name) LIKE UPPER('City1')
            AND UPPER(jc.name) LIKE UPPER('City2')
    )
    OR 
    (
        UPPER(f.name) LIKE UPPER('FiRM2')  
            AND UPPER('City1') IS NULL 
            AND UPPER(jc.name) LIKE UPPER('City2')
    ) 
    OR 
    (
        UPPER(f.name) LIKE UPPER('FiRM2')  
            AND UPPER(pc.name) LIKE UPPER('City1') 
            AND UPPER('City2') IS NULL 
    ); 
