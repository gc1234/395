CREATE TABLE [dbo].[contract_empoyees]
(
	company_id int,
	employee_id int,
	primary key(company_id, employee_id),
	foreign key(employee_id) references employee,
	foreign key(company_id) references company
)
