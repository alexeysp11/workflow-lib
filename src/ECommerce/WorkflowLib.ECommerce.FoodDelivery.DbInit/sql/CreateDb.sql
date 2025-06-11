-- Database: pg-tst-food

-- DROP DATABASE "pg-tst-food";

CREATE DATABASE "pg-tst-food"
    WITH 
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'English_United States.1252'
    LC_CTYPE = 'English_United States.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;

COMMENT ON DATABASE "pg-tst-food"
    IS 'Test database for the food delivery application';
