CREATE TABLE [dbo].[employee_hours]
(
	employee_id int,
	contract_id int,
	current_month_hours int,
	previous_month_hours int,
	primary key(employee_id, contract_id),
	foreign key(employee_id) references employee,
	foreign key(contract_id) references employee_contracts
)
