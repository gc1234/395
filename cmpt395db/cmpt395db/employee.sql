CREATE TABLE [dbo].[employee]
(
	[employee_id] int NOT NULL PRIMARY KEY,
	[first_name] varchar(20),
	[last_name] varchar(20),
	[sex] char(1),
	[email] varchar(20) NOT NULL
)
