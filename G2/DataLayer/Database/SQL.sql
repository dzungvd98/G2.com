use master
go
-- Create database
Create database G2;
go
use G2
go
-- Create tables
Drop table if exists [Type]
Create table [Type] ( TypeID int identity (1,1) primary key,
                      TypeName nvarchar (255)
                    );

Drop table if exists Category
Create table Category ( CategoryID int identity (1,1) primary key,
                        CategoryName nvarchar(255),
                        ParentCategoryID int,
                        [Description] text,
                        Slug nvarchar (255),
                        TypeID int
                        -- Foreign key (ParentCategoryID) references Category (CategoryID),
                        -- Foreign key (TypeID) references [Type] (TypeID),
                      );

Drop table if exists Feature
Create table Feature ( FeatureID int identity (1,1) primary key,
                       FeatureName nvarchar (255),
                       ParentFeatureID int,
                    --    Foreign key (ParentFeatureID) references Feature (FeatureID)
                     );

Drop table if exists CategoryFeature
Create table CategoryFeature ( CategoryFeatureID int identity (1,1) primary key,
                               CategoryID int,
                               FeatureID int
                            --    Foreign key (CategoryID) references Category (CategoryID),
                            --    Foreign key (FeatureID) references Feature (FeatureID)
                             );

Drop table if exists CompanySize
Create table CompanySize ( CompanySizeID int identity (1,1) primary key,
                           CompanySizeName nvarchar (255)
                         );

Drop table if exists Industry
Create table Industry ( IndustryID int identity (1,1) primary key,
                        IndustryName nvarchar (255)
                      );

Drop table if exists Continent
Create table Continent ( ContinentID int identity (1,1) primary key,
                         ContinentName nvarchar (255)
                       );

Drop table if exists Country
Create table Country ( CountryID int identity (1,1) primary key,
                       CountryName nvarchar (255),
                       ContinentID int,
                    --    Foreign key (ContinentID) references Continent (ContinentID)
                     );

Drop table if exists Company
Create table Company ( CompanyID int identity (1,1) primary key,
                       CompanyName nvarchar (255),
                       CountryID int,
                       CompanySizeID int,
                       IndustryID int,
                       CompanyLink nvarchar (255),
                       Mail nvarchar (255),
                       CreatedAt datetime,
                       UpdatedAt datetime,
                    --    Foreign key (CountryID) references Country (CountryID),
                    --    Foreign key (CompanySizeID) references CompanySize (CompanySizeID),
                    --    Foreign key (IndustryID) references Industry (IndustryID)
                     );

Drop table if exists Product
Create table Product ( ProductID int identity (1,1) primary key,
                       ProductName nvarchar (255),
                       ProductLogo nvarchar (255),
                       CoverImage nvarchar (255),
                       ProductLink nvarchar (255),
                       [Description] nvarchar (255)
                     );

Drop table if exists ProductCategory
Create table ProductCategory ( ProductCategoryID int identity (1,1) primary key,
                               ProductID int,
                               CategoryID int
                            --    Foreign key (ProductID) references Product (ProductID),
                            --    Foreign key (CategoryID) references Category (CategoryID)
                             );

Drop table if exists Package
Create table Package ( PackageID int identity (1,1) primary key,
                       PackageName nvarchar (255)
                     );

Drop table if exists Price
Create table Price ( PriceID int identity (1,1) primary key,
                     ProductID int,
                     Price decimal (18,2),
                     [Description] text,
                     PackageID int,
                     IsFreeTrial int,
                     PriceType nvarchar (255),
                     CreatedAt datetime,
                     UpdatedAt datetime
                    --  Foreign key (ProductID) references Product (ProductID),
                    --  Foreign key (PackageID) references Package (PackageID)
                   );

Drop table if exists [User]
Create table [User] ( UserID int identity (1,1) primary key,
                      UserName nvarchar (255),
                      UserPassword nvarchar (255),
                      Email nvarchar (255),
                      Avatar nvarchar (255),
                      CompanyID int,
                      CreatedAt datetime,
                      UpdatedAt datetime,
                    --   Foreign key (CompanyID) references Company (CompanyID)
                    );

Drop table if exists ProductFeature
Create table ProductFeature ( ProductFeatureID int identity (1,1) primary key,
                              ProductID int,
                              FeatureID int,
                            --   Foreign key (ProductID) references Product (ProductID),
                            --   Foreign key (FeatureID) references Feature (FeatureID)
                            );

Drop table if exists Criteria
Create table Criteria ( CriteriaID int identity (1,1) primary key,
                        CriteriaName nvarchar (255)
                      );

Drop table if exists Review
Create table Review ( ReviewID int identity (1,1) primary key,
                      UserID int,
                      ProductID int,
                      Content text,
                      Rate int,
                      CreatedAt datetime,
                      UpdatedAt datetime,
                    --   Foreign key (UserID) references [User] (UserID),
                    --   Foreign key (ProductID) references Product (ProductID)
                    );

Drop table if exists Comment
Create table Comment ( CommentID int identity (1,1) primary key,
                       UserID int,
                       ReviewID int,
                       Content text,
                       CreatedAt datetime,
                       UpdatedAt datetime
                    --    Foreign key (UserID) references [User] (UserID),
                    --    Foreign key (ReviewID) references Review (ReviewID)
                     );

Drop table if exists [Like]
Create table [Like] ( LikeID int identity (1,1) primary key,
                      UserID int,
                      ReviewID int,
                      Content text,
                      CreatedAt datetime,
                      UpdatedAt datetime
                    --   Foreign key (UserID) references [User] (UserID),
                    --   Foreign key (ReviewID) references Review (ReviewID)
                    );                     

Drop table if exists Discussion
Create table Discussion ( DiscussionID int identity (1,1) primary key,
                          ProductID int,
                          UserID int,                       
                          Topic text,
                          CreatedAt datetime,
                          UpdatedAt datetime
                    --    Foreign key (ProductID) references Product (ProductID),
                    --    Foreign key (UserID) references [User] (UserID)
                        );                     

Drop table if exists ReplyDiscussion
Create table ReplyDiscussion ( ReplyDiscussionID int identity (1,1) primary key,
                               DiscussionID int,
                               UserID int,
                               Content text,
                               CreatedAt datetime,
                               UpdatedAt datetime
                            --    Foreign key (DiscussionID) references Discussion (DiscussionID),
                            --    Foreign key (UserID) references [User] (UserID)
                             );  
                     
Drop table if exists ReviewDetail
Create table ReviewDetail ( ReviewDetailID int identity (1,1) primary key,
                            ReviewID int,
                            CriteriaID int,
                            Rate int,
                            CreatedAt datetime,
                            UpdatedAt datetime
                            -- Foreign key (ReviewID) references Review (ID),
                            -- Foreign key (CriteriaID) references Criteria (CriteriaID)
                          );

Drop table if exists ReviewFeature
Create table ReviewFeature ( ReviewFeatureID int identity (1,1) primary key,
                             ReviewID int,
                             FeatureID int,
                             Rate int,
                             CreatedAt datetime,
                             UpdatedAt datetime
                            --  Foreign key (ReviewID) references Review (ReviewID),
                            --  Foreign key (FeatureID) references Feature (FeatureID)
                           );

Drop table if exists Award
Create table Award ( AwardID int identity (1,1) primary key,
                     AwardName nvarchar (255),
                     AwardImg nvarchar (255),
                     AwardYear int
                   );

Drop table if exists ProductAwards
Create table ProductAwards ( ProductAwardsIDID int identity (1,1) primary key,
                             ProductID int,
                             AwardsID int,
                            --  Foreign key (ProductID) references Product (ProductID),
                            --  Foreign key (AwardsID) references Award (AwardsID)
                           );

Drop table if exists Favorite
Create table Favorite ( FavoriteID int identity (1,1) primary key,
                        UserID int,
                        ProductID int,
                        -- Foreign key (UserID) references [User] (UserID),
                        -- Foreign key (ProductID) references Product (ProductID)
                      );

Drop table if exists ProsCons
Create table ProsCons ( ProsConsID int identity (1,1) primary key,
                        ProsConsName nvarchar (255),
                        IsPros int
                      );

Drop table if exists ReviewProsCons
Create table ReviewProsCons ( ReviewProsConsID int identity (1,1) primary key,
                              ReviewID int,
                              ProsConsID int,
                              CreatedAt datetime,
                              UpdatedAt datetime
                            --   Foreign key (ReviewID) references Review (ReviewID),
                            --   Foreign key (ProsConsID) references ProsCons (ProsConsID)
                            );

Drop table if exists Screenshots
Create table Screenshots ( ScreenshotsID int identity (1,1) primary key,
                           ProductID int,
                           Title text,
                           Link nvarchar (255),
                           IsImange int,
                           [Description] text,
                           CreatedAt datetime,
                           UpdatedAt datetime
                        --    Foreign key (ProductID) references Product (ProductID)
                         );

Drop table if exists ReviewVideo
Create table ReviewVideo ( ReviewVideoID int identity (1,1) primary key,
                           UserID int,
                           ReviewID int,
                           VideoRef nvarchar (255),
                           CreatedAt datetime,
                           UpdatedAt datetime
                        --    Foreign key (UserID) references [User] (UserID),
                        --    Foreign key (ReviewID) references Review (ReviewID),
                         );

Drop table if exists ProductHistory
Create table ProductHistory ( ProductHistoryID int identity (1,1) primary key,
                              ProductID int,
                              CompanyID int,
                              UpdatedAt datetime
                            --   Foreign key (ProductID) references Product (ProductID),
                            --   Foreign key (CompanyID) references Company (CompanyID)
                            );