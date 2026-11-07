CREATE TABLE FacilitiesIssues
(
    IssueID INT IDENTITY(1,1) PRIMARY KEY,
    Location NVARCHAR(100) NOT NULL,
    Category NVARCHAR(50) NOT NULL,
    Description NVARCHAR(500) NOT NULL,
    DateReported DATE NOT NULL,
    Priority NVARCHAR(20) NOT NULL,
    Status NVARCHAR(20) NOT NULL,
    ReportedBy NVARCHAR(100) NOT NULL
);