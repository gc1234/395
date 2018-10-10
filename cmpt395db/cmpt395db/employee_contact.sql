CREATE TABLE [dbo].[employee_contact]
(
	employee_id int,
	phone nvarchar(20),
	street nvarchar(20),
	email nvarchar(20) NOT NULL,
	postal_code nvarchar(20),
	city nvarchar(20),
	province nvarchar(20),
	country nvarchar(20),
	birth date,
	emergency_contact_first_name nvarchar(20),
	emergency_contact_last_name nvarchar(20),
	emergency_contact_last_phone nvarchar(20),
	primary key(employee_id),
	foreign key(employee_id) references employee
)
