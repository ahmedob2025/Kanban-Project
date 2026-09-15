# 🏗️ البنية المعمارية للنظام

## 📖 مقدمة

يعتمد نظام إدارة المشاريع بطريقة Kanban على **البنية ثلاثية الطبقات (3-Tier Architecture)** لضمان:
- ✅ **فصل الاهتمامات** (Separation of Concerns)
- ✅ **قابلية الصيانة والتوسع**
- ✅ **إعادة استخدام الكود**
- ✅ **سهولة الاختبار**

---

## 🎯 مبادئ التصميم

### 1. الفصل الصارم بين الطبقات
كل طبقة لها مسؤولية محددة ولا تتداخل مع غيرها.

### 2. لا SQL في الواجهات (NFR-02)
جميع استعلامات قاعدة البيانات تمر عبر DAL.

### 3. منطق العمل في BLL
جميع قواعد العمل والتحقق في BLL، وليس في الواجهات.

### 4. تمرير البيانات عبر كائنات
استخدام كائنات الكيانات (Entities) بدلاً من DataTable.

### 5. أمان المعاملات (NFR-05)
استخدام Transactions للعمليات متعددة الخطوات.

---

## 📐 الطبقات بالتفصيل

### 🎨 الطبقة 1: Presentation Layer (PL)

**الموقع:** `Source Code/PresentationLayer/`

**المسؤوليات:**
- عرض البيانات للمستخدم
- استقبال المدخلات
- استدعاء خدمات BLL
- عرض النتائج والرسائل

**لا تحتوي على:**
- ❌ استعلامات SQL
- ❌ منطق عمل
- ❌ تحقق من قواعد BR

**المكونات:**
```
PresentationLayer/
├── Forms/                    # 12 نموذج
├── UserControls/             # عناصر مخصصة
├── SessionManager.cs         # إدارة الجلسة
├── Program.cs                # نقطة الدخول
└── App.config               # الإعدادات
```

**مثال:**
```csharp
private void btnLogin_Click(object sender, EventArgs e)
{
    // PL: استدعاء الخدمة فقط
    var user = _authService.Login(txtUsername.Text, txtPassword.Text);
    if (user != null) { /* عرض النجاح */ }
}
```

---

### ⚙️ الطبقة 2: Business Logic Layer (BLL)

**الموقع:** `Source Code/BusinessLogicLayer/`

**المسؤوليات:**
- تطبيق قواعد العمل (BR)
- التحقق من صحة البيانات
- تنسيق العمليات بين المستودعات
- تسجيل النشاطات

**تحتوي على:**
- ✅ 7 خدمات
- ✅ ValidationHelper
- ✅ DatabaseSeeder

**المكونات:**
```
BusinessLogicLayer/
├── AuthenticationService.cs    # FR-01
├── UserService.cs              # FR-02, FR-03, FR-04
├── ProjectService.cs           # FR-05, FR-06, FR-07, FR-08
├── TaskService.cs              # FR-09 → FR-17, FR-21
├── KanbanService.cs            # FR-18, FR-19, FR-20
├── ReportService.cs            # FR-24, FR-25, FR-26
├── ValidationHelper.cs         # BR-07, BR-08
└── DatabaseSeeder.cs           # الحسابات الافتراضية
```

**مثال:**
```csharp
public int CreateTask(KanbanTask task)
{
    // BLL: تطبيق قواعد BR
    var errors = ValidationHelper.ValidateTask(task, _projectRepo, _taskRepo);
    if (errors.Any()) throw new Exception(string.Join("\n", errors));
    
    // استدعاء DAL
    int newId = _taskRepository.Insert(task);
    
    // تسجيل النشاط (BR-09)
    _activityLog.Insert(new TaskHistory { ... });
    
    return newId;
}
```

---

### 💾 الطبقة 3: Data Access Layer (DAL)

**الموقع:** `Source Code/DataAccessLayer/`

**المسؤوليات:**
- الاتصال بقاعدة البيانات
- تنفيذ استعلامات SQL
- تحويل الصفوف إلى كائنات
- إدارة Transactions

**تحتوي على:**
- ✅ 7 مستودعات
- ✅ DatabaseHelper

**المكونات:**
```
DataAccessLayer/
├── DatabaseHelper.cs
├── UserRepository.cs
├── ProjectRepository.cs
├── ProjectMemberRepository.cs
├── TaskRepository.cs
├── ActivityLogRepository.cs
└── ReportRepository.cs
```

**مثال:**
```csharp
public int Insert(KanbanTask task)
{
    string query = @"INSERT INTO Tasks (...) VALUES (...);
                     SELECT SCOPE_IDENTITY();";
    return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
}
```

---

## 🔄 تدفق البيانات

```
المستخدم
   │
   │ 1. يضغط زر "حفظ"
   ▼
┌──────────────────┐
│  Presentation    │  ← استقبال المدخلات
│      Layer       │
└────────┬─────────┘
         │ 2. استدعاء الخدمة
         ▼
┌──────────────────┐
│  Business Logic  │  ← التحقق من القواعد
│      Layer       │
└────────┬─────────┘
         │ 3. استدعاء المستودع
         ▼
┌──────────────────┐
│   Data Access    │  ← تنفيذ SQL
│      Layer       │
└────────┬─────────┘
         │ 4. استعلام
         ▼
┌──────────────────┐
│   SQL Server     │  ← تخزين/استرجاع
│    Database      │
└──────────────────┘
```

---

## 🔗 العلاقات بين الطبقات

```
┌──────────────────────┐
│  Presentation Layer  │
└──────────┬───────────┘
           │ references
           ▼
┌──────────────────────┐
│  Business Logic      │
└──────────┬───────────┘
           │ references
           ▼
┌──────────────────────┐
│  Data Access Layer   │
└──────────┬───────────┘
           │ references
           ▼
┌──────────────────────┐
│  Common (Entities)   │
└──────────────────────┘
```

**قواعد المراجع:**
- PL يعتمد على BLL + Common
- BLL يعتمد على DAL + Common
- DAL يعتمد على Common
- Common مستقل

---

## 📊 المتطلبات غير الوظيفية المطبقة

| الرمز | المتطلب | التنفيذ |
|-------|---------|---------|
| **NFR-01** | 3-Tier | فصل كامل |
| **NFR-02** | لا SQL في UI | SQL في DAL فقط |
| **NFR-03** | Security | PBKDF2 |
| **NFR-04** | Data Integrity | FKs + Constraints |
| **NFR-05** | Transactions | DatabaseHelper |
| **NFR-06** | Performance | الفهارس |
| **NFR-07** | Usability | تصميم عربي |
| **NFR-08** | Reliability | Try-Catch شامل |
| **NFR-09** | Scalability | بنية قابلة للتوسع |
| **NFR-10** | Collaboration | Git/GitHub |

---

## 🎯 الخلاصة

البنية ثلاثية الطبقات في هذا المشروع:
- ✅ **واضحة** - كل طبقة لها دور محدد
- ✅ **مرنة** - يمكن استبدال أي طبقة دون التأثير على الأخرى
- ✅ **قابلة للاختبار** - كل طبقة قابلة للاختبار بشكل مستقل
- ✅ **احترافية** - تتبع أفضل الممارسات

---

**آخر تحديث:** 2026
**الكاتب:** أحمد عبيدات (قائد الفريق)