CREATE DATABASE chtpz_test; 

-- \connect chtpz_test

CREATE SCHEMA test_task; 

CREATE SEQUENCE test_task.city_id_seq; 
CREATE TABLE IF NOT EXISTS test_task.city (
    city_id NUMERIC(10) NOT NULL DEFAULT nextval('test_task.city_id_seq'), 
    name VARCHAR(20) NOT NULL, 
    region_id NUMERIC(10) NOT NULL, 
    aokrug_id NUMERIC(10), 
    f_north NUMERIC(3), 
    status_of_local_sid NUMERIC(10) NOT NULL, 
    high_postindex NUMERIC(6), 
    low_postindex NUMERIC(6), 
    begin_date DATE, 
    end_date DATE, 
    f_input NUMERIC(1) NOT NULL, 
    CONSTRAINT city_pk PRIMARY KEY (city_id)
);
ALTER SEQUENCE test_task.city_id_seq INCREMENT BY 1 OWNED BY test_task.city.city_id; 

CREATE SEQUENCE test_task.firm_id_seq; 
CREATE TABLE IF NOT EXISTS test_task.firm (
    firm_id NUMERIC(10) NOT NULL DEFAULT nextval('test_task.firm_id_seq'), 
    name VARCHAR(20) NOT NULL, 
    altern_sys_code NUMERIC(10), 
    holding_sys_code NUMERIC(10), 
    business_prop VARCHAR(255), 
    post_index NUMERIC(10), 
    jur_index NUMERIC(10), 
    inn NUMERIC(15), 
    okponh NUMERIC(11), 
    okpokl NUMERIC(11), 
    okogu NUMERIC(10), 
    okato NUMERIC(11), 
    cont_station NUMERIC(10), 
    vagon_station NUMERIC(10), 
    railway_code VARCHAR(10), 
    date_corr DATE, 
    user_id NUMERIC(10), 
    phone VARCHAR(16), 
    email VARCHAR(30), 
    fax VARCHAR(16), 
    date_inn_close DATE, 
    ownership_sid NUMERIC(10) NOT NULL, 
    special_sign NUMERIC(10) NOT NULL, 
    reserve NUMERIC(3), 
    vip_sign NUMERIC(3), 
    post_address VARCHAR(100), 
    jur_address VARCHAR(100), 
    post_city_id NUMERIC(10), 
    jur_city_id NUMERIC(10), 
    lic_number VARCHAR(20), 
    begin_date DATE, 
    end_date DATE, 
    f_input NUMERIC(1), 
    CONSTRAINT firm_pk PRIMARY KEY (firm_id)
);
ALTER SEQUENCE test_task.firm_id_seq INCREMENT BY 1 OWNED BY test_task.firm.firm_id; 

CREATE SEQUENCE test_task.document_id_seq; 
CREATE TABLE IF NOT EXISTS test_task.document (
    document_id NUMERIC(10) NOT NULL DEFAULT nextval('test_task.document_id_seq'), 
    doc_date DATE, 
    sum NUMERIC(10) NOT NULL, 
    firm_id NUMERIC(10) NOT NULL, 
    CONSTRAINT document_pk PRIMARY KEY (document_id),
    FOREIGN KEY (firm_id) REFERENCES test_task.firm (firm_id)
);
ALTER SEQUENCE test_task.document_id_seq INCREMENT BY 1 OWNED BY test_task.document.document_id; 
