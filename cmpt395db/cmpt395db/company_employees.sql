CREATE TABLE [dbo].[company_employees]
(
	company_id int,
	employee_id int,
	primary key(company_id, employee_id),
	foreign key(employee_id) references employee,
	foreign key(company_id) references company
)
