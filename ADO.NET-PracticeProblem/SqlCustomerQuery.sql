use PracticeProblem
select * from Customer
---Add new Customer data


Create PROCEDURE spAddNewCustomer
@CustomerName varchar(200),
@Address varchar(200),
@PhoneNumber nvarchar(200),
@Country varchar(200),
@Salary varchar(100),
@Pincode varchar (100)
AS
insert into Customer(CustomerName,Address,PhoneNumber,Country,Salary,Pincode)values (@CustomerName,@Address,@PhoneNumber,@Country,@Salary,@Pincode);