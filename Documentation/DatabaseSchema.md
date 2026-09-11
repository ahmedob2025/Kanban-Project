# 🗄️ مخطط قاعدة بيانات KanbanDB

## 📖 نظرة عامة

قاعدة بيانات **KanbanDB** مبنية على **SQL Server**، تحتوي على **6 جداول رئيسية** مع علاقات كاملة وقيود محكمة.

---

## 🏗️ مخطط ERD

```
┌──────────────────┐
│      Roles       │
│──────────────────│
│ 🔑 RoleID (PK)   │
│    RoleName (UQ) │
└────────┬─────────┘
         │ 1:N
         ▼
┌──────────────────┐        ┌──────────────────┐
│      Users       │        │     Projects     │
│──────────────────│        │──────────────────│
│ 🔑 UserID (PK)   │        │ 🔑 ProjectID (PK)│
│    Username (UQ) │        │    ProjectName   │
│    FullName      │◄───────│    Description   │
│    Email         │  1:N   │    StartDate     │
│    PasswordHash  │        │    ExpectedEndDate│
│ 🔗 RoleID (FK)   │        │    Status        │
│    IsActive      │        │ 🔗 CreatedBy (FK)│
│    CreatedDate   │        │    CreatedDate   │
└────────┬─────────┘        └────────┬─────────┘
         │                           │
         │ 1:N                       │ 1:N
         ▼                           ▼
┌──────────────────────────────────────────────┐
│              ProjectMembers                   │
│──────────────────────────────────────────────│
│ 🔑 ProjectMemberID (PK)                       │
│ 🔗 ProjectID (FK)                             │
│ 🔗 UserID (FK)                                │
│    JoinedDate                                 │
│    UQ (ProjectID, UserID)                     │
└────────┬─────────────────────────────────────┘
         │ 1:N
         ▼
┌──────────────────┐
│      Tasks       │
│──────────────────│
│ 🔑 TaskID (PK)   │
│    Title         │
│    Description   │
│ 🔗 ProjectID (FK)│
│ 🔗 ParentTaskID  │◄──┐ self-ref
│ 🔗 AssignedTo(FK)│   │
│    Priority      │   │
│    Status        │   │
│    DueDate       │   │
│ 🔗 CreatedBy (FK)│   │
│    CreatedDate   │   │
│    LastModified  │   │
└────────┬─────────┘   │
         │ 1:N         │
         ▼             │
┌──────────────────┐   │
│  TaskHistory     │   │
│──────────────────│   │
│ 🔑 HistoryID(PK) │   │
│ 🔗 TaskID (FK)   │───┘
│ 🔗 UserID (FK)   │
│    ActionType    │
│    Description   │
│    ActionDate    │
└──────────────────┘
```

---

## 📋 الجداول بالتفصيل

### 1️⃣ جدول Roles (الأدوار)

**الغرض:** تخزين أدوار المستخدمين الثابتة.

| العمود | النوع | القيد | الوصف |
|--------|------|-------|-------|
| RoleID | INT | PK, IDENTITY | المعرف الفريد |
| RoleName | NVARCHAR(50) | NOT NULL, UNIQUE | اسم الدور |

**البيانات الثابتة:**
```sql
INSERT INTO Roles (RoleName) VALUES 
    ('Administrator'), 
    ('ProjectLeader'), 
    ('TeamMember');
```

---

### 2️⃣ جدول Users (المستخدمون)

**الغرض:** تخزين بيانات المستخدمين مع كلمات المرور المشفرة.

| العمود | النوع | القيد | الوصف |
|--------|------|-------|-------|
| UserID | INT | PK, IDENTITY | المعرف الفريد |
| Username | NVARCHAR(50) | NOT NULL, UNIQUE | اسم المستخدم |
| FullName | NVARCHAR(100) | NOT NULL | الاسم الكامل |
| Email | NVARCHAR(100) | NOT NULL | البريد الإلكتروني |
| PasswordHash | NVARCHAR(255) | NOT NULL | هاش PBKDF2 |
| RoleID | INT | FK → Roles | الدور |
| IsActive | BIT | NOT NULL, DEFAULT 1 | حالة التفعيل |
| CreatedDate | DATETIME | NOT NULL, DEFAULT GETDATE() | تاريخ الإنشاء |

**القيود:**
- `FK_Users_Role`: RoleID يشير إلى Roles.RoleID
- `UQ` على Username (منع التكرار)

---

### 3️⃣ جدول Projects (المشاريع)

**الغرض:** تخزين المشاريع البرمجية.

| العمود | النوع | القيد | الوصف |
|--------|------|-------|-------|
| ProjectID | INT | PK, IDENTITY | المعرف الفريد |
| ProjectName | NVARCHAR(100) | NOT NULL | اسم المشروع |
| Description | NVARCHAR(MAX) | NULL | الوصف |
| StartDate | DATE | NOT NULL | تاريخ البداية |
| ExpectedEndDate | DATE | NULL | تاريخ النهاية المتوقع |
| Status | NVARCHAR(20) | NOT NULL, DEFAULT 'New' | الحالة |
| CreatedBy | INT | FK → Users | المنشئ |
| CreatedDate | DATETIME | NOT NULL, DEFAULT GETDATE() | تاريخ الإنشاء |

**القيود:**
- `CHK_ProjectDates`: ExpectedEndDate >= StartDate
- `FK_Projects_CreatedBy`: CreatedBy يشير إلى Users.UserID

**حالات المشروع:** New, InProgress, Completed, OnHold

---

### 4️⃣ جدول ProjectMembers (أعضاء المشروع)

**الغرض:** ربط المستخدمين بالمشاريع (علاقة Many-to-Many).

| العمود | النوع | القيد | الوصف |
|--------|------|-------|-------|
| ProjectMemberID | INT | PK, IDENTITY | المعرف |
| ProjectID | INT | FK → Projects | المشروع |
| UserID | INT | FK → Users | المستخدم |
| JoinedDate | DATETIME | NOT NULL, DEFAULT GETDATE() | تاريخ الانضمام |

**القيود:**
- `UQ_ProjectMember`: (ProjectID, UserID) فريد (منع التكرار)
- `FK_PM_Project`: ON DELETE CASCADE
- `FK_PM_User`: UserID يشير إلى Users

---

### 5️⃣ جدول Tasks (المهام)

**الغرض:** تخزين المهام مع دعم المهام الفرعية.

| العمود | النوع | القيد | الوصف |
|--------|------|-------|-------|
| TaskID | INT | PK, IDENTITY | المعرف |
| Title | NVARCHAR(200) | NOT NULL | العنوان |
| Description | NVARCHAR(MAX) | NULL | الوصف |
| ProjectID | INT | FK → Projects | المشروع |
| ParentTaskID | INT | FK → Tasks, NULL | المهمة الأب |
| AssignedTo | INT | FK → Users, NULL | المسند إليه |
| Priority | INT | NOT NULL, DEFAULT 2 | الأولوية |
| Status | NVARCHAR(20) | NOT NULL, DEFAULT 'New' | الحالة |
| DueDate | DATE | NULL | تاريخ الاستحقاق |
| CreatedBy | INT | FK → Users | المنشئ |
| CreatedDate | DATETIME | NOT NULL, DEFAULT GETDATE() | تاريخ الإنشاء |
| LastModifiedDate | DATETIME | NULL | آخر تعديل |

**القيود:**
- `CHK_TaskDueDate`: DueDate >= CreatedDate
- `FK_Tasks_Project`: ON DELETE CASCADE
- `FK_Tasks_ParentTask`: Self-Reference
- `FK_Tasks_AssignedTo`
- `FK_Tasks_CreatedBy`

**الأولويات:** 1=High, 2=Medium, 3=Low
**الحالات:** New, InProgress, Done

---

### 6️⃣ جدول TaskHistory (سجل النشاطات)

**الغرض:** تسجيل كل العمليات على المهام.

| العمود | النوع | القيد | الوصف |
|--------|------|-------|-------|
| HistoryID | INT | PK, IDENTITY | المعرف |
| TaskID | INT | FK → Tasks | المهمة |
| UserID | INT | FK → Users | المنفذ |
| ActionType | NVARCHAR(50) | NOT NULL | نوع العملية |
| Description | NVARCHAR(MAX) | NOT NULL | الوصف |
| ActionDate | DATETIME | NOT NULL, DEFAULT GETDATE() | التاريخ |

**أنواع العمليات:** Created, Updated, StatusChanged, Assigned, PriorityChanged, Deleted

**القيود:**
- `FK_History_Task`: ON DELETE CASCADE
- `FK_History_User`: UserID

---

## 🔗 العلاقات

| العلاقة | النوع | الوصف |
|---------|-------|-------|
| Roles → Users | 1:N | كل دور له مستخدمون |
| Users → Projects | 1:N | كل مستخدم ينشئ مشاريع |
| Users → ProjectMembers | 1:N | كل مستخدم عضو في مشاريع |
| Projects → ProjectMembers | 1:N | كل مشروع له أعضاء |
| Projects → Tasks | 1:N | كل مشروع له مهام |
| Users → Tasks | 1:N | كل مستخدم مسند إليه مهام |
| Tasks → Tasks | Self-Ref | مهمة أب ومهام فرعية |
| Tasks → TaskHistory | 1:N | كل مهمة لها سجل |
| Users → TaskHistory | 1:N | كل مستخدم له أنشطة |

**عدد العلاقات:** 11 علاقة Foreign Key

---

## 📊 الفهارس (Indexes)

| اسم الفهرس | الجدول | الغرض |
|-----------|--------|-------|
| `IX_Tasks_ProjectID` | Tasks | تسريع البحث حسب المشروع |
| `IX_Tasks_ParentTaskID` | Tasks | تسريع البحث عن المهام الفرعية |
| `IX_Tasks_AssignedTo` | Tasks | تسريع البحث عن مهام مستخدم |
| `IX_TaskHistory_TaskID` | TaskHistory | تسريع سجل مهمة |
| `IX_ProjectMembers_UserID` | ProjectMembers | تسريع البحث عن مشاريع مستخدم |

---

## 🎯 أمثلة استعلامات مفيدة

### 1. جلب جميع المشاريع النشطة
```sql
SELECT ProjectID, ProjectName, Status
FROM Projects
WHERE Status = 'InProgress';
```

### 2. جلب المهام المسندة لمستخدم معين
```sql
SELECT t.TaskID, t.Title, t.Status, t.DueDate
FROM Tasks t
WHERE t.AssignedTo = @UserID
ORDER BY t.Priority;
```

### 3. حساب نسبة إنجاز مشروع
```sql
SELECT 
    COUNT(*) AS Total,
    SUM(CASE WHEN Status = 'Done' THEN 1 ELSE 0 END) AS Done,
    CAST(SUM(CASE WHEN Status = 'Done' THEN 1.0 ELSE 0 END) 
        / COUNT(*) * 100 AS DECIMAL(5,2)) AS ProgressPercent
FROM Tasks
WHERE ProjectID = @ProjectID;
```

### 4. أداء الفريق
```sql
SELECT 
    u.FullName,
    COUNT(t.TaskID) AS CompletedTasks
FROM Users u
INNER JOIN ProjectMembers pm ON u.UserID = pm.UserID
LEFT JOIN Tasks t ON u.UserID = t.AssignedTo 
    AND t.Status = 'Done' 
    AND t.ProjectID = @ProjectID
WHERE pm.ProjectID = @ProjectID
GROUP BY u.UserID, u.FullName;
```

### 5. سجل النشاطات لمشروع
```sql
SELECT th.ActionDate, u.FullName, th.ActionType, th.Description
FROM TaskHistory th
INNER JOIN Tasks t ON th.TaskID = t.TaskID
INNER JOIN Users u ON th.UserID = u.UserID
WHERE t.ProjectID = @ProjectID
ORDER BY th.ActionDate DESC;
```

---

## ⚙️ ملاحظات مهمة

### ✅ الحذف
- حذف مشروع ⇒ يحذف مهامه وأعضائه (CASCADE)
- حذف مهمة ⇒ يحذف سجلها (CASCADE)
- حذف مستخدم ⇒ لا يمكن (يُعطَّل فقط)

### ✅ الأمان
- كلمات المرور مشفرة بـ PBKDF2 (لا تُخزَّن كنص)
- استخدام Parameterized Queries

### ✅ الأداء
- 5 فهارس لتسريع الاستعلامات الشائعة
- استخدام `COUNT` و `SUM` بدلاً من جلب كل البيانات

---

**آخر تحديث:** 2026
**المؤلف:** Junaid Mohammad
**المراجع:** Ahmad Obeidat