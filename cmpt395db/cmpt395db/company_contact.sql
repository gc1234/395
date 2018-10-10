CREATE TABLE [dbo].[company_contact]
(
	company_id int,
	phone nvarchar(20),
	street nvarchar(20),
	email nvarchar(20),
	postal_code nvarchar(20),
	city nvarchar(20),
	province nvarchar(20),
	country nvarchar(20),
	primary key(company_id),
	foreign key(company_id) references company
)
