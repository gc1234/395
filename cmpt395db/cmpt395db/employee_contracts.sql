CREATE TABLE [dbo].[employee_contracts]
(
	contract_id int primary key,
	pay_rate int NOT NULL,
	total_hours int,
	start_date date,
	end_date date,
	job varchar(20),
	renewal varchar(3),
	active_contract varchar(3)
)
