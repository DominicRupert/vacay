CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS vacations(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'Vacation Name',

  description varchar(255) COMMENT 'Vacation Description',
  userId VARCHAR(255) COMMENT 'User Id',
  FOREIGN KEY (userId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS cruises(
id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
accountId VARCHAR(255) COMMENT 'User Id',
vacationId INT NOT NULL,
FOREIGN KEY (accountId) REFERENCES accounts(id) ON DELETE CASCADE,
FOREIGN KEY (vacationId) REFERENCES vacations(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

