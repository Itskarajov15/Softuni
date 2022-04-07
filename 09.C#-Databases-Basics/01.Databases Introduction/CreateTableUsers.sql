CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARCHAR(MAX),
	LastLoginTime DATETIME,
	IsDeleted BIT
);

INSERT INTO Users(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted) 
VALUES
('karajov15', 'password123', 'https://images.pexels.com/photos/1704488/pexels-photo-1704488.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500', 2022/04/01, 0),
('asdsad', 'sadfasdf', 'https://images.pexels.com/photos/1704488/pexels-photo-1704488.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500', 2022/03/01, 0),
('fsadfasdf', 'sadf', 'https://images.pexels.com/photos/1704488/pexels-photo-1704488.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500', 2022/04/01, 0),
('dasfasdf', 'adsfasdf', 'https://images.pexels.com/photos/1704488/pexels-photo-1704488.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500', 2022/15/01, 0),
('adsfasdf', 'dasfasdf', 'https://images.pexels.com/photos/1704488/pexels-photo-1704488.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500', 2022/06/01, 0)

ALTER TABLE Users
ADD CONSTRAINT PK_IdUsername PRIMARY KEY (Id, Username);
 
ALTER TABLE Users
ADD CONSTRAINT CH_PasswordIsAtLeast5Symbols CHECK (LEN(Password) >= 5);

ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime;

ALTER TABLE Users
DROP CONSTRAINT PK_IdUsername;

ALTER TABLE Users
ADD CONSTRAINT PK_Id PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT PK_UsernameIsAtLeast3Symbols CHECK (LEN(Username) > 3);