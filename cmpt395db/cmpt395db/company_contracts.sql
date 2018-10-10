CREATE TABLE [dbo].[company_contracts]
(
	contract_id int,
	company_id int,
	primary key(company_id, contract_id),
	foreign key(company_id) references company,
	foreign key(contract_id) references employee_contracts
)
