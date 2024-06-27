-- Create chache table. 
CREATE TABLE IF NOT EXISTS test_task.cache_docs (
    year INTEGER, 
    jan_sum NUMERIC(10), 
    feb_sum NUMERIC(10), 
    mar_sum NUMERIC(10), 
    apr_sum NUMERIC(10), 
    may_sum NUMERIC(10), 
    jun_sum NUMERIC(10), 
    jul_sum NUMERIC(10), 
    aug_sum NUMERIC(10), 
    sep_sum NUMERIC(10), 
    oct_sum NUMERIC(10), 
    nov_sum NUMERIC(10), 
    dec_sum NUMERIC(10) 
);

CREATE OR REPLACE FUNCTION test_task.GetDocsCalendar() RETURNS void
    LANGUAGE plpgsql
AS
$$
DECLARE
    doc_year INTEGER;
    r_doc_month RECORD; 
BEGIN
    -- Delete old values from cache table. 
    DELETE FROM test_task.cache_docs; 

    FOR doc_year IN SELECT DISTINCT date_part('year', d.doc_date) AS year FROM test_task.document d ORDER BY year

        LOOP
            -- Create cache table for storing sum for each month of the year. 
            CREATE TABLE test_task.doc_month (
                month INTEGER, 
                sum NUMERIC(10)
            );

            -- Insert all months and sums of the year. 
            INSERT INTO test_task.doc_month (month, sum)
            SELECT t1.month, t1.sum
            FROM
            (
                SELECT 
                    date_part('month', d.doc_date) AS month, 
                    date_part('year', d.doc_date) AS year, 
                    SUM(d.sum) AS sum
                FROM test_task.document d
                GROUP BY year, month
                ORDER BY year, month
            ) t1
            WHERE t1.year = doc_year; 

            FOR r_doc_month IN SELECT * FROM test_task.doc_month 
            LOOP
                -- Insert year if it does not exist. 
                INSERT INTO test_task.cache_docs (year) 
                SELECT doc_year
                WHERE (SELECT COUNT(*) FROM test_task.cache_docs WHERE year = doc_year) = 0;

                -- Update sum for each of the months in the year. 
                IF r_doc_month.month = 1 THEN 
                    UPDATE test_task.cache_docs SET jan_sum = r_doc_month.sum 
                    WHERE year = doc_year;
                END IF; 
                IF r_doc_month.month = 2 THEN 
                    UPDATE test_task.cache_docs SET feb_sum = r_doc_month.sum 
                    WHERE year = doc_year;
                END IF; 
                IF r_doc_month.month = 3 THEN 
                    UPDATE test_task.cache_docs SET mar_sum = r_doc_month.sum 
                    WHERE year = doc_year;
                END IF; 
                IF r_doc_month.month = 4 THEN 
                    UPDATE test_task.cache_docs SET apr_sum = r_doc_month.sum 
                    WHERE year = doc_year;
                END IF; 
                IF r_doc_month.month = 5 THEN 
                    UPDATE test_task.cache_docs SET may_sum = r_doc_month.sum 
                    WHERE year = doc_year;
                END IF; 
                IF r_doc_month.month = 6 THEN 
                    UPDATE test_task.cache_docs SET jun_sum = r_doc_month.sum 
                    WHERE year = doc_year;
                END IF; 
                IF r_doc_month.month = 7 THEN 
                    UPDATE test_task.cache_docs SET jul_sum = r_doc_month.sum 
                    WHERE year = doc_year;
                END IF; 
                IF r_doc_month.month = 8 THEN 
                    UPDATE test_task.cache_docs SET aug_sum = r_doc_month.sum 
                    WHERE year = doc_year;
                END IF; 
                IF r_doc_month.month = 9 THEN 
                    UPDATE test_task.cache_docs SET sep_sum = r_doc_month.sum 
                    WHERE year = doc_year;
                END IF; 
                IF r_doc_month.month = 10 THEN 
                    UPDATE test_task.cache_docs SET oct_sum = r_doc_month.sum 
                    WHERE year = doc_year;
                END IF; 
                IF r_doc_month.month = 11 THEN 
                    UPDATE test_task.cache_docs SET nov_sum = r_doc_month.sum 
                    WHERE year = doc_year;
                END IF; 
                IF r_doc_month.month = 12 THEN 
                    UPDATE test_task.cache_docs SET dec_sum = r_doc_month.sum 
                    WHERE year = doc_year;
                END IF; 
            END LOOP; 

            DROP TABLE test_task.doc_month;
        END LOOP;
END
$$;

SELECT test_task.GetDocsCalendar(); 
