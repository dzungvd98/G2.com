use master
create database G2
go
use G2
go
Drop table if exists Product
Create table Product ( ID int identity (1,1) primary key,
                       ProductName nvarchar (255),
                       Logo nvarchar (255),
                       Overview nvarchar (255),
                       Link nvarchar (255),
                       CompanyID int,
                       [Type] nvarchar (255),
                       CategoryID int,
                       Price text                         
                     );

Drop table if exists [User]
Create table [User] ( ID int identity (1,1) primary key,
                      UserName nvarchar (255),
                      UserPassword nvarchar (255),
                      Email nvarchar (255),
                      CompanyID int,
                      JoinedDate datetime,
                      LastedSignOut datetime                        
                    );

Drop table if exists Category
Create table Category ( ID int identity (1,1) primary key,
                        [Name] nvarchar(255),
                        ParentCategoryID int
                      );

Drop table if exists ProductFeature
Create table ProductFeature ( ID int identity (1,1) primary key,
                              ProductID int,
                              FeatureID int
                            );

Drop table if exists Company
Create table Company ( ID int identity (1,1) primary key,
                       [Name] nvarchar (255),
                       CountryID int,
                       CompanySizeID int,
                       IndustryID int
                     );

Drop table if exists Feature
Create table Feature ( ID int identity (1,1) primary key,
                       [Name] nvarchar (255),
                       ParentFeatureID int
                     );

Drop table if exists CompanySize
Create table CompanySize ( ID int identity (1,1) primary key,
                           [Name] nvarchar (255)
                         );

Drop table if exists Industry                
Create table Industry ( ID int identity (1,1) primary key,
                        [Name] nvarchar (255)
                      );

Drop table if exists Rating
Create table Rating ( ID int identity (1,1) primary key,
                      [Name] nvarchar (255)
                    );

Drop table if exists Review
Create table Review ( ID int identity (1,1) primary key,
                      UserID int,
                      ProductID int,
                      Content text,
                      Rate int,
                      CreatedAt datetime,
                      UpdatedAt datetime
                    );

Drop table if exists ReviewDetail                  
Create table ReviewDetail ( ID int identity (1,1) primary key,
                            ReviewID int, 
                            RatingID int,
                            Rate int
                          );

Drop table if exists ReviewFeature
Create table ReviewFeature ( ID int identity (1,1) primary key,
                             ReviewID int,
                             FeatureID int,
                             Rate int
                           );

Drop table if exists Continent
Create table Continent ( ID int identity (1,1) primary key,
                         [Name] nvarchar (255)
                       );

Drop table if exists Country
Create table Country ( ID int identity (1,1) primary key,
                       [Name] nvarchar (255),
                       ContinentID int
                     );

Drop table if exists Award
Create table Award ( ID int identity (1,1) primary key,
                     [Name] nvarchar (255),
                     Img nvarchar (255),
                     [Year] int
                   );

Drop table if exists ProductAwards
Create table ProductAwards ( ID int identity (1,1) primary key,
                             ProductID int,
                             AwardsID int
                           );

Drop table if exists Favorite
Create table Favorite ( ID int identity (1,1) primary key,
                        UserID int,
                        ProductID int
                      );


-- Add data for Product table (representing software products)
Insert into Product (ProductName, Logo, Overview, Link, CompanyID, [Type], CategoryID, Price)
Values 
('Software A', 'software_a_logo.png', 'A comprehensive project management software.', 'http://softwareA.com', 1, 'Project Management', 1, '500'),
('Software B', 'software_b_logo.png', 'A CRM solution for customer relationship management.', 'http://softwareB.com', 2, 'CRM', 2, '800'),
('Software C', 'software_c_logo.png', 'A financial software for accounting and budgeting.', 'http://softwareC.com', 3, 'Finance', 3, '600'),
('Software D', 'software_d_logo.png', 'An email marketing tool for creating campaigns.', 'http://softwareD.com', 1, 'Marketing', 4, '300'),
('Software E', 'software_e_logo.png', 'A collaborative document editing tool for teams.', 'http://softwareE.com', 2, 'Collaboration', 5, '400');
go
select * from Product
go
-- Add data for User table (representing users of the software)
Insert into [User] (UserName, UserPassword, Email, CompanyID, JoinedDate, LastedSignOut)
Values 
('john_doe', 'password123', 'john_doe@example.com', 1, '2023-01-10', NULL),
('jane_smith', 'securepass456', 'jane_smith@example.com', 2, '2023-02-15', NULL),
('alice_jones', 'password789', 'alice_jones@example.com', 3, '2023-03-20', NULL),
('bob_white', 'mysecurepass321', 'bob_white@example.com', 1, '2023-04-05', NULL),
('carol_green', 'strongpass987', 'carol_green@example.com', 2, '2023-05-12', NULL);
go
select * from [User]
go
-- Add data for Category table (software categories)
Insert into Category ([Name], ParentCategoryID)
Values
('Project Management', NULL),
('CRM', NULL),
('Finance', NULL),
('Marketing', NULL),
('Collaboration', NULL);
go
select * from Category
go
-- Add data for ProductFeature table (features of software products)
Insert into ProductFeature (ProductID, FeatureID)
Values
(1, 1), 
(2, 2), 
(3, 3), 
(4, 4), 
(5, 5); 
go
select * from ProductFeature
go
-- Add data for Company table (software companies)
Insert into Company ([Name], CountryID, CompanySizeID, IndustryID)
Values
('TechCorp', 1, 1, 1),
('SoftSolutions', 2, 2, 2),
('FinanceSoft', 3, 3, 3),
('MarketPro', 1, 1, 4),
('CollabTech', 2, 2, 5);
go
select * from Company
go
-- Add data for Feature table (features of software)
Insert into Feature ([Name], ParentFeatureID)
Values
('Task Management', NULL),
('Customer Data', NULL),
('Accounting', NULL),
('Campaign Creation', NULL),
('Real-Time Collaboration', NULL);
go
select * from Feature
go
-- Add data for CompanySize table
Insert into CompanySize ([Name])
Values
('Small'),
('Medium'),
('Large'),
('Enterprise'),
('Startup');
go
select * from CompanySize
go
-- Add data for Industry table (software industries)
Insert into Industry ([Name])
Values
('Technology'),
('Software'),
('Finance'),
('Marketing'),
('Collaboration');
go
select * from Industry
go
-- Add data for Rating table (software ratings)
Insert into Rating ([Name])
Values
('Ease of Use'),
('Features'),
('Organization'),
('AI Features'),
('AI Integration');
go
select * from Rating
go
-- Add data for Review table (software reviews)
Insert into Review (UserID, ProductID, Content, Rate, CreatedAt, UpdatedAt)
Values
(1, 1, 'Fantastic software for project management! Helps our team stay organized.', 5, '2023-01-15', NULL),
(2, 2, 'Great CRM solution, very easy to use and integrates well with other tools.', 4, '2023-02-20', NULL),
(3, 3, 'Solid financial software, but lacks some advanced features for large businesses.', 3, '2023-03-25', NULL),
(4, 4, 'Great for creating email campaigns, but needs better analytics features.', 4, '2023-04-10', NULL),
(5, 5, 'Perfect for team collaboration, especially for document editing.', 5, '2023-05-18', NULL);
go
select * from Review
go
-- Add data for ReviewDetail table (detailed ratings for software)
Insert into ReviewDetail (ReviewID, RatingID, Rate)
Values
(1, 1, 5),
(2, 2, 4),
(3, 3, 3),
(4, 4, 4),
(5, 5, 5);
go
select * from ReviewDetail
go
-- Add data for ReviewFeature table (ratings for specific software features)
Insert into ReviewFeature (ReviewID, FeatureID, Rate)
Values
(1, 1, 5), 
(2, 2, 4), 
(3, 3, 3), 
(4, 4, 4), 
(5, 5, 5); 
go
select * from ReviewFeature
go
-- Add data for Continent table
Insert into Continent ([Name])
Values
('North America'),
('Europe'),
('Asia'),
('South America'),
('Africa');
go
select * from Continent
go
-- Add data for Country table
Insert into Country ([Name], ContinentID)
Values
('USA', 1),
('Germany', 2),
('India', 3),
('Brazil', 4),
('South Africa', 5);
go
select * from Country
go
-- Add data for Award table
Insert into Award ([Name], Img, [Year])
Values
('Best Project Management Tool', 'award_pm.png', 2023),
('Top CRM Software', 'award_crm.png', 2022),
('Best Financial Software', 'award_financial.png', 2021),
('Best Marketing Tool', 'award_marketing.png', 2020),
('Top Collaboration Tool', 'award_collab.png', 2019);
go
select * from Award
go
-- Add data for ProductAwards table (software awards)
Insert into ProductAwards (ProductID, AwardsID)
Values
(1, 1), 
(2, 2), 
(3, 3), 
(4, 4), 
(5, 5); 
go
select * from ProductAwards
go
-- Add data for Favorite table (users' favorite software)
Insert into Favorite (UserID, ProductID)
Values
(1, 1), 
(2, 2), 
(3, 3), 
(4, 4), 
(5, 5); 
go
select * from Favorite
go