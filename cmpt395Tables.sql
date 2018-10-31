create table employee

(employee_id int,

firstName varchar(20),

lastName varchar(20),

email varchar(20),

primary key(employee_id));



create table company

(company_id int,

name varchar(20),

primary key(company_id));



create table contractor

(contractor_id int,

contractor_first_name varchar(20),

contractor_last_name varchar(20),

company_id int,

email varchar(20),

password varchar(20),

primary key(contractor_id),

foreign key(company_id) references company);





create table contract

(contract_id int,

contractor_id int,

company_id int,

p1_CharRate int,

p1_payRate int,

p1_startDate date,

p1_endDate date,

p2_CharRate int,

p2_payRate int,

p2_startDate date,

p2_endDate date,

p3_CharRate int,

p3_payRate int,

p3_startDate date,

p3_endDate date,

p4_CharRate int,

p4_payRate int,

p4_startDate date,

p4_endDate date,

renewal varchar(3),

active_contract varchar(3),

primary key(contract_id),

foreign key(company_id) references company,

foreign key(contractor_id) references contractor);



create table employee_hour

(time_sheet_id int,

contract_id int,

year int,

month int,

currentMonthHours int,

previousMonthHours int,

primary key(time_sheet_id),

foreign key(contract_id) references contract);



create table admin

(admin_id int primary key,

firstName varchar(20),

lastName varchar(20),

password varchar(20));