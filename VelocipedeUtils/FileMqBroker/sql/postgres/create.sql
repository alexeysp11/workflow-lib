CREATE TABLE RequestMessageFiles (
    Id SERIAL PRIMARY KEY,
    Name TEXT NOT NULL,
    HttpMethod TEXT,
    HttpPath TEXT,
    Size INTEGER,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    MessageFileState INTEGER NOT NULL
);

CREATE TABLE FileStateHistory (
    Id SERIAL PRIMARY KEY,
    RequestMessageFileId INTEGER NOT NULL,
    NewState TEXT NOT NULL,
    Timestamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (RequestMessageFileId) REFERENCES RequestMessageFiles(Id)
);

CREATE TABLE ResponseMessageFiles (
    Id SERIAL PRIMARY KEY,
    Name TEXT NOT NULL,
    HttpMethod TEXT,
    HttpPath TEXT,
    Size INTEGER,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    MessageFileState INTEGER NOT NULL
);

CREATE TABLE ExceptionLog (
    Id SERIAL PRIMARY KEY,
    ExceptionMessage TEXT NOT NULL,
    StackTrace TEXT,
    Timestamp TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE INDEX IF NOT EXISTS RequestMessageFiles_Name_Inx ON RequestMessageFiles (Name);
CREATE INDEX IF NOT EXISTS ResponseMessageFiles_Name_Inx ON ResponseMessageFiles (Name);
