CREATE TABLE RequestMessageFiles (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    HttpMethod TEXT,
    HttpPath TEXT,
    Size INTEGER,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    MessageFileState TEXT NOT NULL
);

CREATE TABLE FileStateHistory (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    RequestMessageFileId INTEGER NOT NULL,
    NewState TEXT NOT NULL,
    Timestamp DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (RequestMessageFileId) REFERENCES RequestMessageFiles(Id)
);

CREATE TABLE ResponseMessageFiles (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    HttpMethod TEXT,
    HttpPath TEXT,
    Size INTEGER,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    MessageFileState TEXT NOT NULL
);

CREATE TABLE ExceptionLog (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    ExceptionMessage TEXT NOT NULL,
    StackTrace TEXT,
    Timestamp DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE INDEX IF NOT EXISTS RequestMessageFiles_Name_Inx ON RequestMessageFiles (Name);
CREATE INDEX IF NOT EXISTS ResponseMessageFiles_Name_Inx ON ResponseMessageFiles (Name);
