Create database G2;

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