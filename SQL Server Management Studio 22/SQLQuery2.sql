USE LPU_Db
select * from Student;

Alter table Student ADD SchoolName Varchar(40) default 'IPS';
Alter table Student ADD PhoneNumber char(10) default '6284492546';

Insert into Student(roll_Number, name, age, localAddress, permanentAddress, SchoolName, PhoneNumber) values(102,'Mahi', 24, 'Pgw','LDH','IPS', '7740009542') 


CREATE TABLE StudentMarks (
    sr_no INT IDENTITY(1000,1) PRIMARY KEY,
    roll_Number INT References dbo.Student(roll_Number) NOT NULL,
    phy INT NOT NULL,
    chem INT NOT NULL,
    maths INT NOT NULL,
    total_marks AS (phy + chem + maths),
    percentage AS ((phy + chem + maths) * 100.0 / 300),
);


insert into StudentMarks(roll_Number, phy, chem, maths) values(12,56,78,98);
insert into StudentMarks(roll_Number, phy, chem, maths) values(13,66,98,88);

select * from StudentMarks