CREATE TABLE [dbo].[employee_hours]
(
	time_sheet_id int,
	contract_id int,
	year int,
	month int,
	currentMonthHours int,
	previousMonthHours int,
	primary key(time_sheet_id),
	foreign key(contract_id) references contracts
)
