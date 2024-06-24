CREATE TABLE IF NOT EXISTS nationality (
    nationality_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
    name VARCHAR(20) NOT NULL
); 

CREATE TABLE IF NOT EXISTS gender (
    gender_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
    name VARCHAR(20) NOT NULL 
); 

CREATE TABLE IF NOT EXISTS user (
    user_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
    name VARCHAR(20) NOT NULL, 
    birth_date DATE NOT NULL, 
    password VARCHAR(20) NOT NULL, 
    nationality_id INTEGER NOT NULL, 
    gender_id INTEGER NOT NULL, 
    FOREIGN KEY (nationality_id) REFERENCES nationality (nationality_id), 
    FOREIGN KEY (gender_id) REFERENCES gender (gender_id)
); 

CREATE TABLE IF NOT EXISTS partner (
    partner_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
    name VARCHAR(20) NOT NULL, 
    birth_date DATE NOT NULL, 
    nationality_id INTEGER NOT NULL, 
    gender_id INTEGER NOT NULL, 
    FOREIGN KEY (nationality_id) REFERENCES nationality (nationality_id), 
    FOREIGN KEY (gender_id) REFERENCES gender (gender_id)
); 

CREATE TABLE IF NOT EXISTS meeting_type (
    meeting_type_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
    name VARCHAR(20) NOT NULL
); 

CREATE TABLE IF NOT EXISTS meeting (
    meeting_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
    name VARCHAR(20) NOT NULL, 
    descrition VARCHAR(20), 
    date_time DATETIME NOT NULL, 
    meeting_type_id INTEGER NOT NULL, 
    opinion VARCHAR(20), 
    FOREIGN KEY (meeting_type_id) REFERENCES meeting_type (meeting_type_id)
); 

CREATE TABLE IF NOT EXISTS participant (
    participant_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
    partner_id INTEGER NOT NULL, 
    meeting_id INTEGER NOT NULL, 
    FOREIGN KEY (partner_id) REFERENCES nationality (partner_id), 
    FOREIGN KEY (meeting_id) REFERENCES gender (meeting_id)
); 
