CREATE TABLE [dbo].[company_emplyee_contracts]
(
	contract_id int,
	company_id int,
	employee_id int,
	primary key(company_id, contract_id, employee_id),
	foreign key(employee_id) references employee,
	foreign key(company_id) references company,
	foreign key(contract_id) references employee_contracts
)
