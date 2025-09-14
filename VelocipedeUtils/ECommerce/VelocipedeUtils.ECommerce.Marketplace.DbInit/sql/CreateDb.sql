-- Database: pg-tst-mpstore

-- DROP DATABASE "pg-tst-mpstore";

CREATE DATABASE "pg-tst-mpstore"
    WITH 
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'English_United States.1252'
    LC_CTYPE = 'English_United States.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;

COMMENT ON DATABASE "pg-tst-mpstore"
    IS 'Test database for the marketplace application';
