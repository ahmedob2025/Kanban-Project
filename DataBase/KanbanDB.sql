-- =============================================
-- KanbanDB - Database Creation Script
-- =============================================

USE master;
GO

-- حذف القاعدة إن وُجدت (للإعادة الإنشاء)
IF DB_ID('KanbanDB') IS NOT NULL
BEGIN
    ALTER DATABASE KanbanDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE KanbanDB;
END
GO

-- إنشاء قاعدة البيانات
CREATE DATABASE KanbanDB;
GO

USE KanbanDB;
GO

-- ═══════════════ 1. جدول الأدوار ═══════════════
CREATE TABLE Roles (
    RoleID INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(50) NOT NULL UNIQUE
);
GO

INSERT INTO Roles (RoleName) VALUES 
    ('Administrator'), 
    ('ProjectLeader'), 
    ('TeamMember');
GO

-- ═══════════════ 2. جدول المستخدمين ═══════════════
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    RoleID INT NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Users_Role FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
);
GO

-- Insert Default Administrator (Username: admin | Password: admin123)
INSERT INTO Users (Username, FullName, Email, PasswordHash, RoleID, IsActive, CreatedDate) 
VALUES (
    'admin', 
    'System Administrator', 
    'admin@kanban.local', 
    'zzyl9/VOnOUX8t7K8wQG1Q==.q+xZOhxHejVjG1QsKQkoGgXIia6Qpk1ABkA+gg8Hlow=', 
    1, 
    1, 
    GETDATE()
);
GO



-- ═══════════════ 3. جدول المشاريع ═══════════════
CREATE TABLE Projects (
    ProjectID INT PRIMARY KEY IDENTITY(1,1),
    ProjectName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    StartDate DATE NOT NULL,
    ExpectedEndDate DATE NULL,
    Status NVARCHAR(20) NOT NULL DEFAULT 'New',
    CreatedBy INT NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Projects_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES Users(UserID),
    CONSTRAINT CHK_ProjectDates CHECK (ExpectedEndDate IS NULL OR ExpectedEndDate >= StartDate)
);
GO

-- ═══════════════ 4. جدول أعضاء المشروع ═══════════════
CREATE TABLE ProjectMembers (
    ProjectMemberID INT PRIMARY KEY IDENTITY(1,1),
    ProjectID INT NOT NULL,
    UserID INT NOT NULL,
    JoinedDate DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_PM_Project FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID) ON DELETE CASCADE,
    CONSTRAINT FK_PM_User FOREIGN KEY (UserID) REFERENCES Users(UserID),
    CONSTRAINT UQ_ProjectMember UNIQUE (ProjectID, UserID)
);
GO

-- ═══════════════ 5. جدول المهام ═══════════════
CREATE TABLE Tasks (
    TaskID INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    ProjectID INT NOT NULL,
    ParentTaskID INT NULL,
    AssignedTo INT NULL,
    Priority INT NOT NULL DEFAULT 2,
    Status NVARCHAR(20) NOT NULL DEFAULT 'New',
    DueDate DATE NULL,
    CreatedBy INT NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    LastModifiedDate DATETIME NULL,
    CONSTRAINT FK_Tasks_Project FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID) ON DELETE CASCADE,
    CONSTRAINT FK_Tasks_ParentTask FOREIGN KEY (ParentTaskID) REFERENCES Tasks(TaskID),
    CONSTRAINT FK_Tasks_AssignedTo FOREIGN KEY (AssignedTo) REFERENCES Users(UserID),
    CONSTRAINT FK_Tasks_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES Users(UserID),
    CONSTRAINT CHK_TaskDueDate CHECK (DueDate IS NULL OR DueDate >= CAST(CreatedDate AS DATE))
);
GO

-- ═══════════════ 6. جدول سجل النشاطات ═══════════════
CREATE TABLE TaskHistory (
    HistoryID INT PRIMARY KEY IDENTITY(1,1),
    TaskID INT NOT NULL,
    UserID INT NOT NULL,
    ActionType NVARCHAR(50) NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    ActionDate DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_History_Task FOREIGN KEY (TaskID) REFERENCES Tasks(TaskID) ON DELETE CASCADE,
    CONSTRAINT FK_History_User FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
GO

-- ═══════════════ 7. الفهارس ═══════════════
CREATE INDEX IX_Tasks_ProjectID ON Tasks(ProjectID);
CREATE INDEX IX_Tasks_ParentTaskID ON Tasks(ParentTaskID);
CREATE INDEX IX_Tasks_AssignedTo ON Tasks(AssignedTo);
CREATE INDEX IX_TaskHistory_TaskID ON TaskHistory(TaskID);
CREATE INDEX IX_ProjectMembers_UserID ON ProjectMembers(UserID);
GO

PRINT '✅ تم إنشاء قاعدة البيانات KanbanDB بنجاح';
GO