-- Main table for storing IDs of user and books. 
CREATE TABLE IF NOT EXISTS UsersBooks (
    Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
    UserIdFK INTEGER, 
    BookIdFK INTEGER, 
    FOREIGN KEY(UserIdFK) REFERENCES Users(UserId), 
    FOREIGN KEY(BookIdFK) REFERENCES Books(BookId)
); 

-- Tables for respresenting information about the user. 
CREATE TABLE IF NOT EXISTS Users (
    UserId INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
    Fullname VARCHAR(50), 
    CityIdFK INTEGER, 
    Password VARCHAR(50), 
    FOREIGN KEY(CityIdFK) REFERENCES Cities(CityId)
);

CREATE TABLE IF NOT EXISTS Cities (
    CityId INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
    CityName VARCHAR(50),
    CountryIdFK INTEGER, 
    FOREIGN KEY(CountryIdFK) REFERENCES Countries(CountryId)
); 

CREATE TABLE IF NOT EXISTS Countries (
    CountryId INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
    CountryName VARCHAR(50)
); 

-- Tables for representing information about the books. 
CREATE TABLE IF NOT EXISTS Books (
    BookId INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
    BookName VARCHAR(255), 
    AuthorIdFK INTEGER, 
    Description TEXT, 
    FOREIGN KEY(AuthorIdFK) REFERENCES Authors(AuthorId)
); 

CREATE TABLE IF NOT EXISTS Authors (
    AuthorId INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
    AuthorName VARCHAR(255)
); 
