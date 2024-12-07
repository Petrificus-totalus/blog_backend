1. install
   a. Microsoft.EntityFrameworkCore.SqlServer
   b. Microsoft.EntityFrameworkCore.Design
   c. Microsoft.EntityFrameworkCore.Tools
2. create Models Folder
3. create Data Folder
   program.cs -> builder.Services.AddDbContext
   appsettings.json -> ConnectionStrings     "Data Source=localhost;Initial Catalog=finshark;User Id=sa;Password=MyPass@word;Integrated Security=True;TrustServerCertificate=true;Trusted_Connection=false"
4. controllers
   program.cs -> builder.Services.AddControllers();  &  app.MapControllers();
5. interfaces
   repository
   builder.Services.AddScoped<IReactRepo, ReactRepo>();


1. Includes  program.cs -> builder.Services.AddControllers().AddNewtonsoftJson(options => { options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; });




CREATE TABLE Spend (
    Id INT IDENTITY(1,1) PRIMARY KEY,      
    CreateTime DATETIME NOT NULL DEFAULT GETDATE(), 
    Title NVARCHAR(255) NOT NULL,          
    Location NVARCHAR(255) NULL,           
    Price DECIMAL(10,1) NOT NULL,          
    Description NVARCHAR(MAX) NULL         
);


CREATE TABLE Tag (
    Id INT IDENTITY(1,1) PRIMARY KEY,       
    TagName NVARCHAR(100) NOT NULL          
);


CREATE TABLE Picture (
    Id INT IDENTITY(1,1) PRIMARY KEY,       
    Link NVARCHAR(255) NOT NULL,           
    SpendId INT NOT NULL,             
    CONSTRAINT FK_Picture_Spend FOREIGN KEY (SpendId) REFERENCES Spend(Id) ON DELETE CASCADE
);


CREATE TABLE SpendTag (
    SpendId INT NOT NULL,             
    TagId INT NOT NULL,                     
    PRIMARY KEY (SpendId, TagId),     
    CONSTRAINT FK_SpendTag_Spend FOREIGN KEY (SpendId) REFERENCES Spend(Id) ON DELETE CASCADE,
    CONSTRAINT FK_SpendTag_Tag FOREIGN KEY (TagId) REFERENCES Tag(Id) ON DELETE CASCADE
);
