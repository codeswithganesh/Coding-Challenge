--1. Provide a SQL script that initializes the database for the Job Board scenario “CareerHub”.if not exists (
    select *
    from sys.databases
    where name = 'CareerHub'
)create database CarrerHub--using carrerhub dbuse CarrerHub--2 Create tables for Companies, Jobs, Applicants and Applications. --3. Define appropriate primary keys, foreign keys, and constraints.--4. Ensure the script handles potential errors, such as if the database or tables already exist/*Table: Companies
Attributes:
• CompanyID (Primary Key, int): Unique identifier for each company.
• CompanyName (string): The name of the hiring company.
• Location (string): The location of the company.*/if not exists (
    select *
    from INFORMATION_SCHEMA.TABLES
    where TABLE_NAME = 'Companies'
)create table Companies(CompanyId int primary key identity(1,1),CompanyName varchar(30),[Location] varchar(50))/*Table: Jobs
Attributes:
• JobID (Primary Key, int): Unique identifier for each job listing.
• CompanyID (Foreign Key, int): References the CompanyID of the hiring company.
• JobTitle (string): The title of the job.
• JobDescription (text): A detailed description of the job.
• JobLocation (string): The location where the job is based.
• Salary (decimal): The salary offered for the job.
• JobType (string): Type of job (e.g., Full-time, Part-time, Contract).
• PostedDate (datetime): Date and time when the job was posted.*/if not exists (
    select *
    from INFORMATION_SCHEMA.TABLES
    where TABLE_NAME = 'Jobs'
)create table Jobs(JobId int primary key identity(20,1),CompanyId int,JobTitle varchar(50),JobDescrption text,JobLocation varchar(50),Salary decimal(10,2),JobType varchar(20),PostedDate datetime,foreign key(CompanyId) references Companies(CompanyId))/*
Table: Applicants
Attributes:
ApplicantID (Primary Key, int): Unique identifier for each applicant.
• FirstName (string): The first name of the applicant.
• LastName (string): The last name of the applicant.
• Email (string): The email address of the applicant.
• Phone (string): The phone number of the applicant.
• Resume (text): The applicant's resume or CV (text or file reference).*/if not exists (
    select *
    from INFORMATION_SCHEMA.TABLES
    where TABLE_NAME = 'Applicants'
)create table Applicants(ApplicantId int primary key identity(50,1),FirstName varchar(20),LastName varchar(20),Email varchar(20) unique,Phone varchar(20),[Resume] text)
/*
Table: Applications
Attributes:
• ApplicationID (Primary Key, int): Unique identifier for each job application.
• JobID (Foreign Key, int): References the JobID of the job listing.
• ApplicantID (Foreign Key, int): References the ApplicantID of the applicant.
• ApplicationDate (datetime): Date and time when the application was submitted.
• CoverLetter (text): The applicant's cover letter for the specific job.*/if not exists (
    select *
    from INFORMATION_SCHEMA.TABLES
    where TABLE_NAME = 'Applications'
)create table Applications(ApplicationId int primary key identity(100,1),JobId int,ApplicantId int,ApplicationDate datetime,CoverLetter text,foreign key(JobId) references Jobs(JobId) on delete cascade,foreign key(ApplicantId) references Applicants(ApplicantId) on delete cascade)--insertig values into the customer tableinsert into Companies
VALUES('CompanyA', 'chennai'),
('CompanyB', 'banglore'),
('CompanyC', 'pune');--inserting values into the  jobsinsert into Jobs (CompanyId, JobTitle, JobDescrption, JobLocation, Salary, JobType, PostedDate) values
(1, 'Software Engineer', 'Description for Software Engineer position.', 'chennai', 80000.00, 'Full-time', getdate()),
(2, 'Data Analyst', 'Description for Data Analyst position.', 'mumbai', 70000.00, 'Full-time', getdate()),
(1, 'Web Developer', 'Description for Web Developer position.', 'chennai', 75000.00, 'Full-time', getdate())

--inserting values into the Applicants
insert into Applicants (FirstName, LastName, Email, Phone, [Resume]) values
('sunil', 'ganesh', 'sunil@gmail.com', '1234567890', '2 years of expereince'),
('rohith', 'Sai', 'rohith@gmail.com', '0987654321', '4 years of experience'),
('sai', 'surya', 'surya@gmail.com', '5555555555', '3 years of experience');

--inserting values into the Applications Table
insert into Applications (JobId, ApplicantId, ApplicationDate, CoverLetter) values
(20, 50, '2024-05-01', 'Cover letter for Software Engineer position.'),
(21, 51, '2024-05-02', 'Cover letter for Data Analyst position.'),
(22, 52, '2024-05-03', 'Cover letter for Web Developer position.');
select * from Companies
select * from Jobs
select * from Applicants
select * from Applications

/* 5. Write an SQL query to count the number of applications received for each job listing in the
"Jobs" table. Display the job title and the corresponding application count. Ensure that it lists all
jobs, even if they have no applications.*/

select Jobs.JobTitle,count(Applications.ApplicationId) as [Applicant Count] from Jobs
join Applications
on
Jobs.JobId=Applications.JobId
group by Jobs.JobTitle;

/*
6. Develop an SQL query that retrieves job listings from the "Jobs" table within a specified salary
range. Allow parameters for the minimum and maximum salary values. Display the job title,
company name, location, and salary for each matching job.*/

declare @min_salary int =70000
declare @max_salary int =80000

select Jobs.JobTitle,Companies.CompanyName,Companies.[Location],Jobs.Salary from Jobs join Companies
on
Jobs.CompanyId=Companies.CompanyId
where Jobs.Salary between @min_salary and @max_salary


/*
7. Write an SQL query that retrieves the job application history for a specific applicant. Allow a
parameter for the ApplicantID, and return a result set with the job titles, company names, and
application dates for all the jobs the applicant has applied to.
*/

select * from Applications
declare @applicant_id int =50

select Jobs.JobTitle,Companies.CompanyName,Applications.ApplicationDate from Applications
join Jobs on
Jobs.JobId=Applications.JobId
join Companies on
Companies.CompanyId=Jobs.CompanyId
where Applications.ApplicantId = @applicant_id

/*
8. Create an SQL query that calculates and displays the average salary offered by all companies for
job listings in the "Jobs" table. Ensure that the query filters out jobs with a salary of zero.
*/

select avg(Salary) as [Average salary] from Jobs
where Salary>0

/*
9. Write an SQL query to identify the company that has posted the most job listings. Display the
company name along with the count of job listings they have posted. Handle ties if multiple
companies have the same maximum count
*/

SELECT Companies.CompanyName, COUNT(Jobs.JobId) AS JobCount 
FROM Companies 
JOIN Jobs ON Jobs.CompanyId = Companies.CompanyId 
GROUP BY Companies.CompanyName 
HAVING COUNT(Jobs.JobId) = (
    SELECT MAX(JobCounts.JobCount) 
    FROM (
        SELECT COUNT(JobId) AS JobCount 
        FROM Jobs 
        GROUP BY CompanyId
    ) AS JobCounts
);
/*
10. Find the applicants who have applied for positions in companies located in 'CityX' and have at
least 3 years of experience
*/
alter table Applicants
alter column [Resume] int;

select concat(a.FirstName,concat(' ',a.LastName)) as [Name] from Applicants a join Applications on
Applications.ApplicantId=a.ApplicantId
join Jobs on Jobs.JobId=Applications.JobId
join Companies on
Companies.CompanyId=Jobs.CompanyId
where Companies.[Location]='chennai' and 
CAST(a.[Resume] AS INT) >=3

/*
11. Retrieve a list of distinct job titles with salaries between $60,000 and $80,000.
*/

select distinct JobTitle from Jobs
where Salary between 60000 and 80000

/*
12. Find the jobs that have not received any applications.
*/

select Jobs.JobId,Jobs.JobTitle from Jobs Left join Applications
on Applications.JobId=Jobs.JobId
where Applications.JobId is null

/*
13. Retrieve a list of job applicants along with the companies they have applied to and the positions
they have applied for
*/
select concat(Applicants.FirstName,' ',Applicants.LastName), Companies.CompanyName,Jobs.JobTitle from Applicants
join Applications on Applicants.ApplicantId=Applications.ApplicantId
join Jobs on Jobs.JobId=Applications.JobId
join Companies on Companies.CompanyId=Jobs.CompanyId

/*
14. Retrieve a list of companies along with the count of jobs they have posted, even if they have not
received any applications.
*/

select Companies.CompanyName ,count(Jobs.JobId) as JobCount from Companies left Join Jobs
on Jobs.CompanyId=Companies.CompanyId
group by Companies.CompanyName

/*
15. List all applicants along with the companies and positions they have applied for, including those
who have not applied.
*/
select concat(Applicants.FirstName,' ',Applicants.LastName),Companies.CompanyName,Jobs.JobTitle from Applicants
 left join Applications on Applicants.ApplicantId=Applications.ApplicantId
left join Jobs on Jobs.JobId=Applications.JobId
left join Companies on Companies.CompanyId=Jobs.CompanyId

/*
16. Find companies that have posted jobs with a salary higher than the average salary of all jobs.
*/
select Companies.CompanyName from Companies join Jobs
on Companies.CompanyId=Jobs.CompanyId
where Salary>(select avg(salary) from Jobs)

/*
17. Display a list of applicants with their names and a concatenated string of their city and state.
*/

alter table Applicants
add City varchar(20)

alter table Applicants
add state varchar(20)

select concat(FirstName,' ',LastName) as Name, concat(City,' ',state) as CityState  from Applicants


/*
18. Retrieve a list of jobs with titles containing either 'Developer' or 'Engineer'.
*/

select * from Jobs
where JobTitle like '%Developer%' or JobTitle like '%Engineer%'

/*
19. Retrieve a list of applicants and the jobs they have applied for, including those who have not
applied and jobs without applicants.
*/
select concat(Applicants.FirstName,' ',Applicants.LastName),Jobs.JobTitle from Applicants
left join Applications on Applicants.ApplicantId=Applications.ApplicantId
left join Jobs on Jobs.JobId=Applications.JobId

/*
20. List all combinations of applicants and companies where the company is in a specific city and the
applicant has more than 2 years of experience. For example: city=Chennai*/

select concat(Applicants.FirstName,' ',Applicants.LastName),Companies.CompanyName from Applicants cross join Companies
where Companies.Location='chennai' and
cast(Applicants.[Resume] as int)>2


