CREATE DATABASE meet_planning; 

-- \connect meet_planning

-- Production. 
CREATE SCHEMA mp; 

CREATE SEQUENCE mp.nationality_id_seq; 
CREATE TABLE IF NOT EXISTS mp.nationality (
    nationality_id INTEGER NOT NULL DEFAULT nextval('mp.nationality_id_seq'), 
    name VARCHAR(20) NOT NULL, 
    CONSTRAINT nationality_pk PRIMARY KEY (nationality_id)
); 
ALTER SEQUENCE mp.nationality_id_seq INCREMENT BY 1 OWNED BY mp.nationality.nationality_id; 

CREATE SEQUENCE mp.gender_id_seq; 
CREATE TABLE IF NOT EXISTS mp.gender (
    gender_id INTEGER NOT NULL DEFAULT nextval('mp.gender_id_seq'), 
    name VARCHAR(20) NOT NULL, 
    CONSTRAINT gender_pk PRIMARY KEY (gender_id)
); 
ALTER SEQUENCE mp.gender_id_seq INCREMENT BY 1 OWNED BY mp.gender.gender_id; 

CREATE SEQUENCE mp.user_id_seq; 
CREATE TABLE IF NOT EXISTS mp.user (
    user_id INTEGER NOT NULL DEFAULT nextval('mp.user_id_seq'), 
    name VARCHAR(20) NOT NULL, 
    birth_date DATE NOT NULL, 
    password VARCHAR(20) NOT NULL, 
    nationality_id INTEGER NOT NULL, 
    gender_id INTEGER NOT NULL, 
    CONSTRAINT user_pk PRIMARY KEY (user_id), 
    FOREIGN KEY (nationality_id) REFERENCES mp.nationality (nationality_id), 
    FOREIGN KEY (gender_id) REFERENCES mp.gender (gender_id)
); 
ALTER SEQUENCE mp.user_id_seq INCREMENT BY 1 OWNED BY mp.user.user_id; 

CREATE SEQUENCE mp.partner_id_seq; 
CREATE TABLE IF NOT EXISTS mp.partner (
    partner_id INTEGER NOT NULL DEFAULT nextval('mp.partner_id_seq'), 
    name VARCHAR(20) NOT NULL, 
    birth_date DATE NOT NULL, 
    nationality_id INTEGER NOT NULL, 
    gender_id INTEGER NOT NULL, 
    CONSTRAINT partner_pk PRIMARY KEY (partner_id), 
    FOREIGN KEY (nationality_id) REFERENCES mp.nationality (nationality_id), 
    FOREIGN KEY (gender_id) REFERENCES mp.gender (gender_id)
); 
ALTER SEQUENCE mp.partner_id_seq INCREMENT BY 1 OWNED BY mp.partner.partner_id; 

CREATE SEQUENCE mp.meeting_type_id_seq; 
CREATE TABLE IF NOT EXISTS mp.meeting_type (
    meeting_type_id INTEGER NOT NULL DEFAULT nextval('mp.meeting_type_id_seq'), 
    name VARCHAR(20) NOT NULL, 
    CONSTRAINT meeting_type_pk PRIMARY KEY (meeting_type_id)
); 
ALTER SEQUENCE mp.meeting_type_id_seq INCREMENT BY 1 OWNED BY mp.meeting_type.meeting_type_id; 

CREATE SEQUENCE mp.meeting_id_seq; 
CREATE TABLE IF NOT EXISTS mp.meeting (
    meeting_id INTEGER NOT NULL DEFAULT nextval('mp.meeting_id_seq'), 
    name VARCHAR(20) NOT NULL, 
    descrition VARCHAR(20), 
    date_time TIMESTAMP NOT NULL, 
    meeting_type_id INTEGER NOT NULL, 
    opinion VARCHAR(20), 
    CONSTRAINT meeting_pk PRIMARY KEY (meeting_id), 
    FOREIGN KEY (meeting_type_id) REFERENCES mp.meeting_type (meeting_type_id)
); 
ALTER SEQUENCE mp.meeting_id_seq INCREMENT BY 1 OWNED BY mp.meeting.meeting_id; 

CREATE SEQUENCE mp.participant_id_seq; 
CREATE TABLE IF NOT EXISTS mp.participant (
    participant_id INTEGER NOT NULL DEFAULT nextval('mp.participant_id_seq'), 
    partner_id INTEGER NOT NULL, 
    meeting_id INTEGER NOT NULL, 
    CONSTRAINT participant_pk PRIMARY KEY (participant_id), 
    FOREIGN KEY (partner_id) REFERENCES mp.partner (partner_id), 
    FOREIGN KEY (meeting_id) REFERENCES mp.meeting (meeting_id)
); 
ALTER SEQUENCE mp.participant_id_seq INCREMENT BY 1 OWNED BY mp.participant.partner_id; 

-- For tests. 
CREATE SCHEMA test; 

CREATE SEQUENCE test.nationality_id_seq; 
CREATE TABLE IF NOT EXISTS test.nationality (
    nationality_id INTEGER NOT NULL DEFAULT nextval('test.nationality_id_seq'), 
    name VARCHAR(20) NOT NULL, 
    CONSTRAINT nationality_pk PRIMARY KEY (nationality_id)
); 
ALTER SEQUENCE test.nationality_id_seq INCREMENT BY 1 OWNED BY test.nationality.nationality_id; 

CREATE SEQUENCE test.gender_id_seq; 
CREATE TABLE IF NOT EXISTS test.gender (
    gender_id INTEGER NOT NULL DEFAULT nextval('test.gender_id_seq'), 
    name VARCHAR(20) NOT NULL, 
    CONSTRAINT gender_pk PRIMARY KEY (gender_id)
); 
ALTER SEQUENCE test.gender_id_seq INCREMENT BY 1 OWNED BY test.gender.gender_id; 

CREATE SEQUENCE test.user_id_seq; 
CREATE TABLE IF NOT EXISTS test.user (
    user_id INTEGER NOT NULL DEFAULT nextval('test.user_id_seq'), 
    name VARCHAR(20) NOT NULL, 
    birth_date DATE NOT NULL, 
    password VARCHAR(20) NOT NULL, 
    nationality_id INTEGER NOT NULL, 
    gender_id INTEGER NOT NULL, 
    CONSTRAINT user_pk PRIMARY KEY (user_id), 
    FOREIGN KEY (nationality_id) REFERENCES test.nationality (nationality_id), 
    FOREIGN KEY (gender_id) REFERENCES test.gender (gender_id)
); 
ALTER SEQUENCE test.user_id_seq INCREMENT BY 1 OWNED BY test.user.user_id; 

CREATE SEQUENCE test.partner_id_seq; 
CREATE TABLE IF NOT EXISTS test.partner (
    partner_id INTEGER NOT NULL DEFAULT nextval('test.partner_id_seq'), 
    name VARCHAR(20) NOT NULL, 
    birth_date DATE NOT NULL, 
    nationality_id INTEGER NOT NULL, 
    gender_id INTEGER NOT NULL, 
    CONSTRAINT partner_pk PRIMARY KEY (partner_id), 
    FOREIGN KEY (nationality_id) REFERENCES test.nationality (nationality_id), 
    FOREIGN KEY (gender_id) REFERENCES test.gender (gender_id)
); 
ALTER SEQUENCE test.partner_id_seq INCREMENT BY 1 OWNED BY test.partner.partner_id; 

CREATE SEQUENCE test.meeting_type_id_seq; 
CREATE TABLE IF NOT EXISTS test.meeting_type (
    meeting_type_id INTEGER NOT NULL DEFAULT nextval('test.meeting_type_id_seq'), 
    name VARCHAR(20) NOT NULL, 
    CONSTRAINT meeting_type_pk PRIMARY KEY (meeting_type_id)
); 
ALTER SEQUENCE test.meeting_type_id_seq INCREMENT BY 1 OWNED BY test.meeting_type.meeting_type_id; 

CREATE SEQUENCE test.meeting_id_seq; 
CREATE TABLE IF NOT EXISTS test.meeting (
    meeting_id INTEGER NOT NULL DEFAULT nextval('test.meeting_id_seq'), 
    name VARCHAR(20) NOT NULL, 
    descrition VARCHAR(20), 
    date_time TIMESTAMP NOT NULL, 
    meeting_type_id INTEGER NOT NULL, 
    opinion VARCHAR(20), 
    CONSTRAINT meeting_pk PRIMARY KEY (meeting_id), 
    FOREIGN KEY (meeting_type_id) REFERENCES test.meeting_type (meeting_type_id)
); 
ALTER SEQUENCE test.meeting_id_seq INCREMENT BY 1 OWNED BY test.meeting.meeting_id; 

CREATE SEQUENCE test.participant_id_seq; 
CREATE TABLE IF NOT EXISTS test.participant (
    participant_id INTEGER NOT NULL DEFAULT nextval('test.participant_id_seq'), 
    partner_id INTEGER NOT NULL, 
    meeting_id INTEGER NOT NULL, 
    CONSTRAINT participant_pk PRIMARY KEY (participant_id), 
    FOREIGN KEY (partner_id) REFERENCES test.partner (partner_id), 
    FOREIGN KEY (meeting_id) REFERENCES test.meeting (meeting_id)
); 
ALTER SEQUENCE test.participant_id_seq INCREMENT BY 1 OWNED BY test.participant.partner_id; 
