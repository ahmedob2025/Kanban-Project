# 🎯 Kanban Project Management System

<div align="center">

![Version](https://img.shields.io/badge/version-1.0.0-blue.svg)
![Platform](https://img.shields.io/badge/platform-Windows-lightgrey.svg)
![.NET](https://img.shields.io/badge/.NET-8.0-purple.svg)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2016%2B-red.svg)
![License](https://img.shields.io/badge/license-Academic-green.svg)

**نظام سطح مكتب احترافي لإدارة المشاريع البرمجية باستخدام منهجية Kanban**

نظام أكاديمي متكامل مبني بتقنية **C# / Windows Forms / SQL Server** باستخدام **البنية ثلاثية الطبقات (3-Tier Architecture)**

</div>

---

## 📖 نظرة عامة

**Kanban Project Management System** هو تطبيق سطح مكتب متكامل يهدف إلى إدارة المشاريع البرمجية وتوزيع المهام بين أعضاء الفريق ومتابعة تقدم العمل عبر **لوحة Kanban** البصرية.

يعتمد النظام على **البنية ثلاثية الطبقات** لضمان فصل الاهتمامات وقابلية الصيانة والتوسع، ويستخدم **Git & GitHub** لإدارة التطوير الجماعي بين فريق من 5 أعضاء.

### 🎯 الأهداف

- 📊 توفير وسيلة منظمة لإدارة المشاريع البرمجية
- 👥 إدارة أعضاء فرق المشاريع وصلاحياتهم
- 📝 إنشاء وإدارة المهام مع دعم العلاقات الهرمية
- 🎨 متابعة سير العمل باستخدام **Kanban Board**
- 📈 توليد تقارير تقدم المشروع وأداء الفريق
- 🔒 ضمان أمان البيانات وتشفير كلمات المرور
- ⚡ دعم التطوير الجماعي باستخدام Git/GitHub

---

## ✨ المميزات الرئيسية

### 🔐 نظام مصادقة آمن
- تشفير كلمات المرور باستخدام **PBKDF2** مع Salt عشوائي و10,000 دورة
- إدارة الجلسات وحماية الوصول غير المصرح به
- تطبيق الصلاحيات بناءً على الأدوار (RBAC)

### 👥 إدارة المستخدمين والأدوار
- 3 أدوار ثابتة: **Administrator** / **ProjectLeader** / **TeamMember**
- إنشاء وتعديل وتعطيل المستخدمين
- تفعيل/تعطيل الحسابات دون حذف السجلات

### 📋 إدارة المشاريع
- إنشاء مشاريع مع تفاصيل كاملة (اسم، وصف، تواريخ، حالة)
- إدارة أعضاء المشروع (إضافة/إزالة)
- متابعة حالة المشروع: New / InProgress / Completed / OnHold

### 📌 إدارة المهام
- إنشاء وتعديل وحذف المهام
- دعم **المهام الفرعية (Sub-Tasks)** بهرمية غير محدودة
- تحديد الأولوية (High / Medium / Low)
- تحديد تاريخ الاستحقاق
- إسناد المهام لأعضاء المشروع فقط

### 🎨 لوحة Kanban
- عرض المهام في 3 أعمدة: **New** / **InProgress** / **Done**
- نقل المهام بضغطة زر واحدة
- منع إكمال المهمة الرئيسية قبل اكتمال مهامها الفرعية
- تحديث فوري لقاعدة البيانات

### 📜 سجل النشاطات (Activity Log)
- تسجيل تلقائي لكل عملية على المهام
- تتبع من قام بأي إجراء ومتى
- عرض قابل للفلترة حسب المهمة أو المشروع

### 📊 التقارير والإحصائيات
- نسبة إنجاز المشروع بشكل لحظي
- أداء أعضاء الفريق (عدد المهام المنجزة لكل عضو)
- ملخص بصري (إجمالي / جديدة / قيد التنفيذ / منجزة)

### 🎯 قواعد العمل المطبقة (Business Rules)

| الرمز | القاعدة |
|-------|---------|
| **BR-01** | كل مشروع له منشئ محدد |
| **BR-02** | لا يجوز إسناد مهمة لمستخدم غير عضو في المشروع |
| **BR-03** | كل مهمة تنتمي لمشروع واحد فقط |
| **BR-04** | يمكن للمهمة أن تكون رئيسية أو فرعية |
| **BR-05** | `ParentTaskID = NULL` ⇒ مهمة رئيسية |
| **BR-06** | `ParentTaskID ≠ NULL` ⇒ مهمة فرعية |
| **BR-07** | منع إنشاء دورات هرمية بين المهام |
| **BR-08** | منع إكمال المهمة الرئيسية قبل الفرعية |
| **BR-09** | تسجيل كل تغيير مهم في Activity Log |
| **BR-10** | تطبيق الصلاحيات على جميع الوظائف |

---

## 🛠️ التقنيات المستخدمة

| المجال | التقنية |
|--------|---------|
| **لغة البرمجة** | C# 12 |
| **إطار العمل** | .NET 8 (Windows Forms) |
| **قاعدة البيانات** | Microsoft SQL Server |
| **البنية** | 3-Tier Architecture |
| **تشفير كلمات المرور** | PBKDF2 + SHA256 |
| **إدارة الإصدارات** | Git & GitHub |
| **بيئة التطوير** | Visual Studio 2022 |

---

## 🏗️ البنية المعمارية

### مخطط الطبقات الثلاث

```
┌─────────────────────────────────────────────────────────────┐
│                                                             │
│           🎨 Presentation Layer (طبقة العرض)                  │
│                                                             │
│   ┌─────────────────────────────────────────────────────┐   │
│   │  LoginForm       │  DashboardForm  │  ProjectsForm │   │
│   │  UsersForm       │  TasksForm      │  KanbanForm   │   │
│   │  ReportsForm     │  MembersForm    │  ActivityForm │   │
│   └─────────────────────────────────────────────────────┘   │
│                                                             │
│   ← مسؤولة عن التفاعل مع المستخدم وعرض البيانات               │
│   ← لا تحتوي على أي SQL مباشر (NFR-02)                       │
│                                                             │
└──────────────────────────┬──────────────────────────────────┘
                           │
                           ▼ استدعاء الخدمات
┌─────────────────────────────────────────────────────────────┐
│                                                             │
│        ⚙️ Business Logic Layer (طبقة منطق العمل)             │
│                                                             │
│   ┌─────────────────────────────────────────────────────┐   │
│   │  AuthenticationService  │  UserService              │   │
│   │  ProjectService         │  TaskService              │   │
│   │  KanbanService          │  ReportService            │   │
│   │  ValidationHelper       │  DatabaseSeeder           │   │
│   └─────────────────────────────────────────────────────┘   │
│                                                             │
│   ← تطبق قواعد العمل (BR) وقواعد التحقق                    │
│   ← تستدعي طبقة الوصول إلى البيانات                         │
│                                                             │
└──────────────────────────┬──────────────────────────────────┘
                           │
                           ▼ استدعاء المستودعات
┌─────────────────────────────────────────────────────────────┐
│                                                             │
│       💾 Data Access Layer (طبقة الوصول إلى البيانات)        │
│                                                             │
│   ┌─────────────────────────────────────────────────────┐   │
│   │  DatabaseHelper         │  UserRepository           │   │
│   │  ProjectRepository      │  ProjectMemberRepository  │   │
│   │  TaskRepository         │  ActivityLogRepository    │   │
│   │  ReportRepository       │                           │   │
│   └─────────────────────────────────────────────────────┘   │
│                                                             │
│   ← تنفذ استعلامات SQL وتستخدم Transactions (NFR-05)         │
│                                                             │
└──────────────────────────┬──────────────────────────────────┘
                           │
                           ▼ SQL Queries
┌─────────────────────────────────────────────────────────────┐
│                                                             │
│              🗄️ Microsoft SQL Server Database               │
│                                                             │
│   ┌─────────────────────────────────────────────────────┐   │
│   │  Roles  │  Users  │  Projects  │  ProjectMembers    │   │
│   │  Tasks  │  TaskHistory                              │   │
│   └─────────────────────────────────────────────────────┘   │
│                                                             │
└─────────────────────────────────────────────────────────────┘
```

### مخطط قاعدة البيانات (ERD)

```
┌──────────────────┐
│      Roles       │
│──────────────────│
│ 🔑 RoleID (PK)   │
│    RoleName      │
└────────┬─────────┘
         │
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
         │                           │ 1:N
         │ 1:N                       ▼
         │                  ┌──────────────────┐
         │                  │ ProjectMembers   │
         │                  │──────────────────│
         │                  │ 🔑 PM_ID (PK)    │
         └─────────────────►│ 🔗 ProjectID (FK)│
                            │ 🔗 UserID (FK)   │
                            │    JoinedDate    │
                            │    UQ (P_ID,U_ID)│
                            └──────────────────┘
                                     │
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
                                     │             │
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

### هيكل المشروع

```
KanbanProjectManagementSystem/
│
├── 📄 README.md                       # ملف التوثيق الرئيسي
├── 📄 CONTRIBUTING.md                 # دليل المساهمة
├── 📄 ARCHITECTURE.md                 # البنية المعمارية
├── 📄 PROJECT_PLAN.md                 # خطة المشروع
├── 📄 .gitignore                      # ملفات مستبعدة من Git
│
├── 📁 .github/                        # إعدادات GitHub
│   ├── workflows/
│   │   └── build.yml                  # CI/CD
│   ├── ISSUE_TEMPLATE.md              # قالب Issues
│   ├── PULL_REQUEST_TEMPLATE.md       # قالب PRs
│   └── CODEOWNERS                     # مراجعون إلزاميون
│
├── 📁 Database/
│   └── KanbanDB.sql                   # سكربت قاعدة البيانات
│
├── 📁 Documentation/
│   ├── SRS.md                         # وثيقة المتطلبات
│   └── TestCases.md                   # حالات الاختبار
│
├── 📁 Source Code/
│   │
│   ├── 📁 PresentationLayer/          # طبقة العرض (Windows Forms)
│   │   ├── Forms/
│   │   │   ├── LoginForm.cs
│   │   │   ├── DashboardForm.cs
│   │   │   ├── UsersManagementForm.cs
│   │   │   ├── ProjectsForm.cs
│   │   │   ├── ProjectDetailsForm.cs
│   │   │   ├── ProjectMembersForm.cs
│   │   │   ├── TasksManagementForm.cs
│   │   │   ├── AddEditTaskForm.cs
│   │   │   ├── TaskDetailsForm.cs
│   │   │   ├── KanbanBoardForm.cs
│   │   │   ├── ActivityLogForm.cs
│   │   │   └── ProjectReportsForm.cs
│   │   ├── SessionManager.cs
│   │   ├── Program.cs
│   │   └── App.config
│   │
│   ├── 📁 BusinessLogicLayer/         # طبقة منطق العمل
│   │   ├── AuthenticationService.cs
│   │   ├── UserService.cs
│   │   ├── ProjectService.cs
│   │   ├── TaskService.cs
│   │   ├── KanbanService.cs
│   │   ├── ReportService.cs
│   │   ├── ValidationHelper.cs
│   │   └── DatabaseSeeder.cs
│   │
│   ├── 📁 DataAccessLayer/            # طبقة الوصول للبيانات
│   │   ├── DatabaseHelper.cs
│   │   ├── UserRepository.cs
│   │   ├── ProjectRepository.cs
│   │   ├── ProjectMemberRepository.cs
│   │   ├── TaskRepository.cs
│   │   ├── ActivityLogRepository.cs
│   │   └── ReportRepository.cs
│   │
│   └── 📁 Common/                     # الطبقة المشتركة
│       ├── Entities/
│       │   ├── User.cs
│       │   ├── Role.cs
│       │   ├── Project.cs
│       │   ├── ProjectMember.cs
│       │   ├── KanbanTask.cs
│       │   └── TaskHistory.cs
│       ├── Enums/
│       │   ├── Priority.cs
│       │   ├── TaskStatus.cs
│       │   └── ProjectStatus.cs
│       └── Helpers/
│           └── PasswordHelper.cs
│
└── 📁 Tests/                          # اختبارات الوحدة
    ├── BusinessLogicLayerTests/
    │   ├── UserServiceTests.cs
    │   ├── TaskServiceTests.cs
    │   └── KanbanServiceTests.cs
    └── DataAccessLayerTests/
        └── RepositoryTests.cs
```

---

## 👥 فريق التطوير

نظام تم تطويره بواسطة فريق من **خمسة أعضاء**، كل عضو مسؤول عن جزء محدد من النظام:

<table>
  <thead>
    <tr>
      <th>#</th>
      <th>الاسم</th>
      <th>الدور / المسؤولية</th>
      <th>الطبقة</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td align="center">1</td>
      <td align="center"><b>أحمد عبيدات</b></td>
      <td>قائد الفريق - يقبل طلبات الـ PRs ومراجعة الملفات والكود</td>
      <td align="center">Team Lead / Reviewer</td>
    </tr>
    <tr>
      <td align="center">2</td>
      <td align="center"><b>جنيد محمد</b></td>
      <td>مسؤول عن دمج الملفات وإنشاء PRs ومراجعة التكامل</td>
      <td align="center">Integration / PR Manager</td>
    </tr>
    <tr>
      <td align="center">3</td>
      <td align="center"><b>يوسف عفان</b></td>
      <td>مسؤول عن طبقة الوصول إلى البيانات</td>
      <td align="center">Data Access Layer (DAL)</td>
    </tr>
    <tr>
      <td align="center">4</td>
      <td align="center"><b>حسن صالح</b></td>
      <td>مسؤول عن طبقة منطق العمل</td>
      <td align="center">Business Logic Layer (BLL)</td>
    </tr>
    <tr>
      <td align="center">5</td>
      <td align="center"><b>محمد عثمان</b></td>
      <td>مسؤول عن طبقة الواجهات وواجهات المستخدم</td>
      <td align="center">Presentation Layer (PL)</td>
    </tr>
  </tbody>
</table>

### 🔄 سير العمل بين الأعضاء

```
   ┌──────────────────────────────────────────────────────┐
   │                                                      │
   │           🎯 سير العمل الجماعي (Git Workflow)        │
   │                                                      │
   └──────────────────────────────────────────────────────┘

        ┌────────────────┐
        │   Member 3,4,5 │  ← يطورون الفروع
        │   (Developers) │
        └────────┬───────┘
                 │
                 │  git push origin feature/FR-XX
                 ▼
        ┌────────────────┐
        │    Member 2    │  ← ينشئ PR ويدمج الملفات
        │  PR Creator    │
        └────────┬───────┘
                 │
                 │  يفتح Pull Request
                 ▼
        ┌────────────────┐
        │    Member 1    │  ← يراجع ويقبل الدمج
        │  Team Lead     │
        └────────┬───────┘
                 │
                 │  ✓ Approve & Merge
                 ▼
        ┌────────────────┐
        │  main Branch   │  ← فرع الإنتاج
        │  (Stable)      │
        └────────────────┘
```

### 📌 مسؤوليات كل عضو

| العضو | المسؤوليات الأساسية |
|-------|---------------------|
| **أحمد عبيدات** | مراجعة الكود، قبول Pull Requests، ضمان الجودة، حل النزاعات |
| **جنيد محمد** | إنشاء PRs، دمج الفروع، إدارة التعارضات (Merge Conflicts)، التكامل |
| **يوسف عفان** | كتابة Repositories، DatabaseHelper، استعلامات SQL، Transactions |
| **حسن صالح** | كتابة Services، ValidationHelper، تطبيق قواعد العمل والتحقق |
| **محمد عثمان** | تصميم Forms، ربط الأحداث، تجربة المستخدم، Kanban Board UI |

---

## 🚀 التثبيت والتشغيل

### 📋 المتطلبات الأساسية

- ✅ **Windows 10/11**
- ✅ **Visual Studio 2022** (مع حزمة تطوير .NET 8)
- ✅ **.NET 8 SDK** أو أحدث
- ✅ **SQL Server 2016** أو أحدث
- ✅ **SQL Server Management Studio (SSMS)**
- ✅ **Git** (للاستنساخ)

### 📥 الخطوة 1: استنساخ المستودع

```bash
git clone https://github.com/AhmadObeidat/KanbanProjectManagementSystem.git
cd KanbanProjectManagementSystem
```

### 🗄️ الخطوة 2: إنشاء قاعدة البيانات

**الطريقة الأولى — عبر SSMS:**

1. افتح **SQL Server Management Studio (SSMS)**
2. اتصل بسيرفر SQL Server
3. افتح ملف `Database/KanbanDB.sql`
4. اضغط **Execute (F5)** لتنفيذ السكربت

**الطريقة الثانية — عبر Command Line:**

```bash
sqlcmd -S . -i "Database/KanbanDB.sql"
```

### ⚙️ الخطوة 3: إعداد سلسلة الاتصال

افتح ملف `Source Code/PresentationLayer/App.config` وعدّل:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <connectionStrings>
    <add name="KanbanDB"
         connectionString="Server=.;Database=KanbanDB;Integrated Security=True;TrustServerCertificate=True;"
         providerName="System.Data.SqlClient" />
  </connectionStrings>
</configuration>
```

> 💡 **ملاحظات:**
> - استبدل `Server=.` باسم السيرفر لديك (مثلاً `Server=LOCALHOST` أو `Server=.\SQLEXPRESS`)
> - إذا كنت تستخدم **SQL Authentication**، استبدل:
>   ```
>   Integrated Security=True
>   ```
>   بـ:
>   ```
>   User ID=sa;Password=YOUR_PASSWORD;
>   ```

### 📦 الخطوة 4: تثبيت حزم NuGet

افتح **Package Manager Console** في Visual Studio ونفذ:

```powershell
Install-Package System.Data.SqlClient
Install-Package System.Configuration.ConfigurationManager
```

### ▶️ الخطوة 5: تشغيل التطبيق

1. افتح `KanbanProjectManagementSystem.sln` في Visual Studio
2. اضغط **F5** أو **Start** لتشغيل التطبيق
3. سيتم إنشاء الحسابات الافتراضية تلقائياً عند أول تشغيل

---

## 🔑 الحسابات الافتراضية

يتم إنشاء الحسابات التالية **تلقائياً عند أول تشغيل** للتطبيق:

| اسم المستخدم | كلمة المرور | الدور | الصلاحيات |
|--------------|-------------|-------|-----------|
| `admin` | `Admin@123` | Administrator | إدارة كاملة للمستخدمين والمشاريع |
| `leader` | `Leader@123` | ProjectLeader | إدارة المشاريع والمهام والأعضاء |
| `member` | `Member@123` | TeamMember | تنفيذ المهام المسندة فقط |

> ⚠️ **مهم جداً**: قم بتغيير كلمات المرور الافتراضية بعد أول تسجيل دخول في بيئة الإنتاج.

---

## 📘 دليل الاستخدام

### 1️⃣ تسجيل الدخول

```
┌─────────────────────────────────────┐
│    🎯 نظام إدارة المشاريع           │
├─────────────────────────────────────┤
│                                     │
│   اسم المستخدم:  [_____________]    │
│                                     │
│   كلمة المرور:   [_____________]    │
│                                     │
│         [ 🚪 دخول إلى النظام ]      │
│                                     │
└─────────────────────────────────────┘
```

- شغّل التطبيق → أدخل بيانات الحساب → اضغط **"دخول"**
- سيتم توجيهك إلى **لوحة المعلومات (Dashboard)** بحسب دورك

### 2️⃣ واجهة المدير (Administrator)

```
Dashboard → 👥 إدارة المستخدمين → ➕ إضافة مستخدم
```

1. اضغط **"➕ إضافة مستخدم"**
2. أدخل البيانات:
   - اسم المستخدم (فريد)
   - كلمة المرور
   - الاسم الكامل
   - البريد الإلكتروني
   - الدور (Administrator / ProjectLeader / TeamMember)
3. اضغط **"حفظ"**

### 3️⃣ واجهة قائد المشروع (ProjectLeader)

#### إنشاء مشروع:
```
Dashboard → 📋 إدارة المشاريع → ➕ مشروع جديد
```

#### إضافة أعضاء للمشروع:
```
المشاريع → اختر مشروعاً → 👥 الأعضاء → ➕ إضافة
```

#### إنشاء مهمة:
```
المشاريع → اختر مشروعاً → 📌 إدارة المهام → ➕ إضافة مهمة
```

#### متابعة كانبان:
```
المشاريع → اختر مشروعاً → 📊 كانبان
```

### 4️⃣ واجهة عضو الفريق (TeamMember)

```
Dashboard → 📌 تبويب "مهامي"
```

- عرض جميع المهام المسندة إليك
- تغيير حالة المهمة بضغطة زر (New → InProgress → Done)
- لا يمكنك إضافة أو حذف المهام (صلاحيات محدودة)

---

## 🔄 دورة حياة المهمة (Kanban Workflow)

```
┌─────────────────────────────────────────────────────────┐
│                                                         │
│              🎨 لوحة Kanban - ثلاث حالات               │
│                                                         │
└─────────────────────────────────────────────────────────┘

   ┌────────────┐         ┌──────────────┐         ┌──────────┐
   │            │         │              │         │          │
   │    🆕      │  بدء    │     ⚙️       │  إكمال  │    ✅    │
   │    New     │ ──────► │  InProgress  │ ──────► │   Done   │
   │  (جديدة)   │         │ (قيد التنفيذ)│         │ (منجزة)  │
   │            │         │              │         │          │
   └────────────┘         └──────────────┘         └──────────┘

   القواعد المطبقة:
   ─────────────────
   ⚠️  لا يمكن إكمال مهمة رئيسية قبل إكمال جميع المهام الفرعية
   ⚠️  فقط الأطراف المخوّلة يمكنها نقل المهام
   ⚠️  كل نقل يُسجَّل تلقائياً في Activity Log
```

---

## 🗄️ جداول قاعدة البيانات

### 1️⃣ جدول Roles (الأدوار)

| العمود | النوع | القيد | الوصف |
|--------|------|-------|-------|
| RoleID | INT | PK, IDENTITY | المعرف الفريد |
| RoleName | NVARCHAR(50) | NOT NULL, UNIQUE | اسم الدور |

**الأدوار الأساسية:**
- Administrator (مدير النظام)
- ProjectLeader (قائد مشروع)
- TeamMember (عضو فريق)

### 2️⃣ جدول Users (المستخدمون)

| العمود | النوع | القيد | الوصف |
|--------|------|-------|-------|
| UserID | INT | PK, IDENTITY | المعرف الفريد |
| Username | NVARCHAR(50) | NOT NULL, UNIQUE | اسم المستخدم |
| FullName | NVARCHAR(100) | NOT NULL | الاسم الكامل |
| Email | NVARCHAR(100) | NOT NULL | البريد الإلكتروني |
| PasswordHash | NVARCHAR(255) | NOT NULL | الهاش الآمن |
| RoleID | INT | FK → Roles | الدور |
| IsActive | BIT | NOT NULL | حالة التفعيل |
| CreatedDate | DATETIME | NOT NULL | تاريخ الإنشاء |

### 3️⃣ جدول Projects (المشاريع)

| العمود | النوع | القيد | الوصف |
|--------|------|-------|-------|
| ProjectID | INT | PK, IDENTITY | المعرف الفريد |
| ProjectName | NVARCHAR(100) | NOT NULL | اسم المشروع |
| Description | NVARCHAR(MAX) | NULL | الوصف |
| StartDate | DATE | NOT NULL | تاريخ البداية |
| ExpectedEndDate | DATE | NULL, CHECK | تاريخ النهاية |
| Status | NVARCHAR(20) | NOT NULL | الحالة |
| CreatedBy | INT | FK → Users | المنشئ |
| CreatedDate | DATETIME | NOT NULL | تاريخ الإنشاء |

### 4️⃣ جدول ProjectMembers (أعضاء المشروع)

| العمود | النوع | القيد | الوصف |
|--------|------|-------|-------|
| ProjectMemberID | INT | PK, IDENTITY | المعرف |
| ProjectID | INT | FK → Projects | المشروع |
| UserID | INT | FK → Users | المستخدم |
| JoinedDate | DATETIME | NOT NULL | تاريخ الانضمام |
| | | UNIQUE (ProjectID, UserID) | منع التكرار |

### 5️⃣ جدول Tasks (المهام)

| العمود | النوع | القيد | الوصف |
|--------|------|-------|-------|
| TaskID | INT | PK, IDENTITY | المعرف |
| Title | NVARCHAR(200) | NOT NULL | العنوان |
| Description | NVARCHAR(MAX) | NULL | الوصف |
| ProjectID | INT | FK → Projects | المشروع |
| ParentTaskID | INT | FK → Tasks | المهمة الأب |
| AssignedTo | INT | FK → Users | المسند إليه |
| Priority | INT | NOT NULL | الأولوية |
| Status | NVARCHAR(20) | NOT NULL | الحالة |
| DueDate | DATE | NULL | تاريخ الاستحقاق |
| CreatedBy | INT | FK → Users | المنشئ |
| CreatedDate | DATETIME | NOT NULL | تاريخ الإنشاء |
| LastModifiedDate | DATETIME | NULL | آخر تعديل |

### 6️⃣ جدول TaskHistory (سجل النشاطات)

| العمود | النوع | القيد | الوصف |
|--------|------|-------|-------|
| HistoryID | INT | PK, IDENTITY | المعرف |
| TaskID | INT | FK → Tasks | المهمة |
| UserID | INT | FK → Users | المنفذ |
| ActionType | NVARCHAR(50) | NOT NULL | نوع العملية |
| Description | NVARCHAR(MAX) | NOT NULL | الوصف |
| ActionDate | DATETIME | NOT NULL | التاريخ |

---

## 🧪 الاختبارات

المشروع يحتوي على اختبارات وحدة للطبقات:

```bash
# تشغيل جميع الاختبارات
dotnet test

# تشغيل اختبارات محددة
dotnet test --filter "FullyQualifiedName~BusinessLogicLayerTests"
```

### حالات الاختبار الرئيسية:

- ✅ تسجيل الدخول بحسابات صحيحة/خاطئة
- ✅ رفض إسناد مهمة لمستخدم غير عضو (BR-02)
- ✅ منع إكمال المهمة الرئيسية قبل الفرعية (BR-08)
- ✅ منع الدورات الهرمية (BR-07)
- ✅ حساب نسبة الإنجاز بدقة
- ✅ منع تكرار اسم المستخدم

---

## 🚀 الرفع إلى GitHub

### 📝 الخطوة 1: إنشاء المستودع

1. اذهب إلى [GitHub](https://github.com) وسجّل دخولك
2. اضغط على **"+"** → **"New repository"**
3. أدخل اسم المستودع: `KanbanProjectManagementSystem`
4. اختر **Public** أو **Private**
5. **لا تختر** "Initialize with README" (لأن لديك README بالفعل)
6. اضغط **"Create repository"**

### 🔧 الخطوة 2: تهيئة Git محلياً

افتح Terminal في مجلد المشروع ونفذ:

```bash
# 1. تهيئة المستودع المحلي
git init

# 2. إعداد بياناتك (إن لم تكن قد فعلتها من قبل)
git config --global user.name "اسمك"
git config --global user.email "your.email@example.com"

# 3. إضافة جميع الملفات
git add .

# 4. أول Commit
git commit -m "🎉 Initial commit: Kanban Project Management System v1.0"

# 5. تسمية الفرع الرئيسي main
git branch -M main

# 6. الربط بـ GitHub (استبدل YOUR_USERNAME)
git remote add origin https://github.com/YOUR_USERNAME/KanbanProjectManagementSystem.git

# 7. الرفع
git push -u origin main
```

### 🌿 الخطوة 3: استراتيجية الفروع

```
main (الإنتاج - مستقرة)
  │
  └── develop (التطوير الرئيسي)
       │
       ├── feature/FR-01-login           (محمد عثمان)
       ├── feature/FR-05-projects        (محمد عثمان)
       ├── feature/FR-09-tasks           (حسن صالح)
       ├── feature/FR-18-kanban          (محمد عثمان)
       └── feature/FR-24-reports         (يوسف عفان)
```

### 📝 الخطوة 4: دورة العمل اليومية لكل عضو

```bash
# 1. تحديث الفرع المحلي
git checkout develop
git pull origin develop

# 2. إنشاء فرع جديد للميزة
git checkout -b feature/FR-XX-description

# 3. العمل والتطوير
# ... تعديل الملفات ...

# 4. إضافة التعديلات
git add .
git commit -m "feat(FR-XX): وصف الميزة"

# 5. رفع الفرع
git push origin feature/FR-XX-description
```

### 🔄 الخطوة 5: إنشاء Pull Request

1. اذهب إلى صفحة المستودع على GitHub
2. اضغط **"Compare & pull request"**
3. املأ قالب PR:
   - **العنوان**: `feat(FR-XX): وصف الميزة`
   - **الوصف**: شرح ما تم تنفيذه
   - **Assignees**: جنيد محمد
   - **Reviewers**: أحمد عبيدات
4. اضغط **"Create pull request"**

### ✅ الخطوة 6: المراجعة والدمج

```
جنيد محمد (PR Creator)  →  أحمد عبيدات (Reviewer)  →  Merge إلى develop
```

---

## 📝 رسائل Commit الاحترافية

| النوع | الاستخدام | مثال |
|-------|----------|------|
| `feat` | ميزة جديدة | `feat(auth): إضافة تسجيل الدخول` |
| `fix` | إصلاح خطأ | `fix(kanban): تصحيح نقل المهام` |
| `docs` | توثيق | `docs: تحديث README` |
| `style` | تنسيق | `style: ترتيب الكود` |
| `refactor` | إعادة هيكلة | `refactor: تحسين TaskService` |
| `test` | اختبارات | `test: إضافة اختبار تسجيل الدخول` |
| `chore` | مهام عامة | `chore: تحديث الحزم` |

---

## 🤝 المساهمة

نرحب بمساهماتكم! يرجى اتباع الخطوات التالية:

1. **Fork** المستودع
2. أنشئ **Branch** جديداً: `git checkout -b feature/AmazingFeature`
3. **Commit** التغييرات: `git commit -m 'feat: إضافة ميزة رائعة'`
4. **Push** للفرع: `git push origin feature/AmazingFeature`
5. افتح **Pull Request**

راجع [CONTRIBUTING.md](CONTRIBUTING.md) للتفاصيل الكاملة.

---

## 📄 الترخيص

هذا المشروع **أكاديمي** - جميع الحقوق محفوظة لفريق التطوير © 2024

---

## 📞 التواصل

- 📧 **Email**: team@kanban-system.local
- 🐛 **Issues**: [GitHub Issues](https://github.com/ahmedob2025/Kanban-Project.git)
- 💬 **Discussions**: [GitHub Discussions](https://github.com/AhmadObeidat/KanbanProjectManagementSystem/discussions)

---

## 🏷️ Topics للمستودع

أضف هذه الكلمات المفتاحية من **Settings → Topics**:

```
csharp  winforms  dotnet  sql-server  kanban  project-management
3-tier-architecture  desktop-application  visual-studio
team-project  arabic-interface
```

---

<div align="center">

**⭐ إذا أعجبك المشروع، لا تنسَ إعطاءه نجمة على GitHub! ⭐**

صُنع بـ ❤️ باستخدام C# و .NET 8

**فريق التطوير: أحمد عبيدات • محمد جنيد • يوسف عفان • حسن صالح • محمد عثمان**

</div>
