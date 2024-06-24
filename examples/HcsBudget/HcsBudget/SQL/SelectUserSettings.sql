SELECT 
    u.user_id, 
    u.name AS username, 
    db.name AS db_name, 
    l.name AS language, 
    c.name AS curr_name, 
    c.abbreviation AS curr_abbreviation, 
    db.is_protected, 
    db.password
FROM user u
INNER JOIN language l ON u.language_id = l.language_id 
INNER JOIN currency c ON u.currency_id = c.currency_id  
INNER JOIN database db ON db.database_id = u.database_id
