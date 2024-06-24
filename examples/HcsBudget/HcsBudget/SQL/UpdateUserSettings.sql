UPDATE user
SET 
    language_id = (
        SELECT MIN(language_id) 
        FROM language 
        WHERE UPPER(name) LIKE UPPER('{0}')
    ), 
    currency_id = (
        SELECT MIN(currency_id) 
        FROM currency 
        WHERE UPPER(abbreviation) LIKE UPPER('{1}')
    ), 
    database_id = (
        SELECT MIN(database_id) 
        FROM database 
        WHERE UPPER(name) LIKE UPPER('{2}')
    )
WHERE user_id = {3}