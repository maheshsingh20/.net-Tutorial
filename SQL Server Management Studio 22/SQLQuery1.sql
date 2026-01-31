--Create Database LPU_Db;

--use LPU_Db

--create schema PankajBatch

--Create Table PankajBatch.Person(

--Id int primary key,
--Name varchar(28) Not Null,
--Address varchar(50),
--PhoneId varchar(10)

--)

-- use LPU_Db
-- create table Dummy(
-- dummy_ID uniqueidentifier,
-- name varchar(15)
-- )

-- select * from Dummy

-- insert into Dummy(name) values('Mahesh Singh');



--CREATE TYPE Address FROM VARCHAR(50) NOT NULL; --creating data type

--create table Student(
--roll_Number int primary key,
--name varchar(15),
--age smallint Not Null,
--localAddress Address,
-- Address
--)

--select count(*) from Orders
--insert into Student(roll_Number, name,age, localAddress, permanentAddress) values(11,'Mahesh Singh', 23,'Ludhiana', 'Punjab');
--insert into Student(roll_Number, name,age, localAddress, permanentAddress) values(13,'Chandan Singh', 24,'Ayodhya', 'UP');
--select * from Student;

--DROP TABLE Student;  --deleting table

-- deleting datatype ... always delete its all reference before deleting type
--DROP TYPE Address; 

USE LPU_Db;

CREATE TYPE Addres FROM VARCHAR(50) NOT NULL;

CREATE TABLE Student (
    roll_Number INT PRIMARY KEY,
    name VARCHAR(30),
    age SMALLINT NOT NULL,
    localAddress Addres,
    permanentAddress Addres
);

SELECT * FROM Student;
