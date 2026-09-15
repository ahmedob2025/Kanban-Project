# 🤝 دليل المساهمة في المشروع

## 📖 مقدمة

شكراً لمساهمتك في **نظام إدارة المشاريع بطريقة Kanban**!
هذا الدليل يوضح كيفية المساهمة بشكل احترافي ومنظم.

---

## 🎯 قواعد المساهمة الأساسية

### ✅ افعل:
1. اقرأ الوثائق قبل البدء
2. اتبع بنية 3-Tier
3. اختبر الكود محلياً قبل الرفع
4. اكتب تعليقات عربية واضحة
5. حدّث `develop` يومياً
6. استخدم رسائل commit احترافية

### ❌ لا تفعل:
1. لا ترفع على `main` مباشرة
2. لا تخلط ميزات متعددة في فرع واحد
3. لا ترفع `App.config` الحقيقي
4. لا ترفع `bin/` أو `obj/`
5. لا تعمل force push على الفروع الرئيسية
6. لا توافق على PRك الخاص

---

## 🔄 سير العمل (Workflow)

### 1️⃣ تحديث الفرع المحلي

```bash
git checkout develop
git pull origin develop
```

### 2️⃣ إنشاء فرع جديد

```bash
# للتطوير
git checkout -b feature/FR-XX-description

# لإصلاح خطأ
git checkout -b bugfix/issue-description

# للتوثيق
git checkout -b docs/description
```

### 3️⃣ العمل على الميزة

- اكتب الكود
- اختبر محلياً
- تأكد من Build ناجح
- أضف التعليقات

### 4️⃣ إضافة الملفات وعمل Commit

```bash
git add "المسار/للملف.cs"
git commit -m "feat(الطبقة): وصف الميزة

- تفصيل 1
- تفصيل 2

Author: اسمك"
```

### 5️⃣ رفع الفرع

```bash
git push origin feature/FR-XX-description
```

### 6️⃣ إنشاء Pull Request

- اذهب إلى GitHub
- اضغط "Compare & pull request"
- املأ القالب
- Assignees: جنيد محمد
- Reviewers: أحمد عبيدات

### 7️⃣ المراجعة والدمج

- أحمد يراجع
- عند الموافقة: جنيد يدمج
- حذف الفرع بعد الدمج

---

## 📝 معايير رسائل Commit

استخدم **Conventional Commits**:

```
نوع(النطاق): وصف قصير

وصف تفصيلي (اختياري)

Author: اسمك
```

### الأنواع:

| النوع | الاستخدام |
|-------|----------|
| `feat` | ميزة جديدة |
| `fix` | إصلاح خطأ |
| `docs` | توثيق |
| `style` | تنسيق |
| `refactor` | إعادة هيكلة |
| `test` | اختبارات |
| `chore` | مهام عامة |

### أمثلة:

```bash
# ميزة جديدة
git commit -m "feat(auth): إضافة تسجيل الدخول مع PBKDF2

- تشفير كلمات المرور
- تطبيق FR-01
- اختبار الحالات الحدية

Author: Hasan Saleh"

# إصلاح خطأ
git commit -m "fix(kanban): تصحيح نقل المهام بين الأعمدة

- منع إكمال المهمة الرئيسية قبل الفرعية
- تطبيق BR-08

Author: Mohammad Othman"
```

---

## 🎨 معايير الكود

### 1. تسمية الملفات

| النوع | النمط | مثال |
|-------|-------|------|
| Forms | PascalCase | `LoginForm.cs` |
| Services | PascalCase | `UserService.cs` |
| Repositories | PascalCase | `UserRepository.cs` |
| Entities | PascalCase | `User.cs` |

### 2. تسمية المتغيرات

```csharp
// جيد
private readonly UserRepository _userRepository;
public int UserID { get; set; }

// سيء
private UserRepository repo;
public int userid { get; set; }
```

### 3. التعليقات

```csharp
/// <summary>
/// خدمة إدارة المستخدمين.
/// تتوافق مع FR-02, FR-03, FR-04.
/// </summary>
public class UserService
{
    /// <summary>
    /// إنشاء مستخدم جديد.
    /// </summary>
    /// <param name="user">بيانات المستخدم</param>
    /// <returns>معرف المستخدم الجديد</returns>
    public int CreateUser(User user, string password) { ... }
}
```

### 4. معالجة الأخطاء

```csharp
// استخدم try-catch
try
{
    _service.DoSomething();
}
catch (Exception ex)
{
    MessageBox.Show($"خطأ: {ex.Message}");
}
```

---

## 🚫 ما لا يجب رفعه

| الملف | السبب |
|-------|-------|
| `App.config` الحقيقي | يحتوي سلسلة الاتصال |
| `bin/` و `obj/` | ملفات بناء مؤقتة |
| `.vs/` | إعدادات Visual Studio |
| `*.user` | إعدادات شخصية |
| `*.mdf`, `*.ldf` | ملفات قاعدة البيانات |
| `packages/` | حزم NuGet |
| `*.log` | ملفات السجلات |

### تأكد من `.gitignore`

```gitignore
bin/
obj/
.vs/
*.user
packages/
Source Code/PresentationLayer/App.config
*.log
*.mdf
*.ldf
```

---

## 🔍 مراجعة الكود (Code Review)

### المراجع (Reviewer) يتحقق من:

- ✅ الكود يعمل بدون أخطاء
- ✅ يتبع بنية 3-Tier
- ✅ لا SQL في الواجهات
- ✅ التعليقات العربية موجودة
- ✅ معالجة الأخطاء
- ✅ لا ملفات حساسة

### المراجع يكتب:

- ✅ **Approve** - الموافقة
- 💬 **Comment** - ملاحظات
- ❌ **Request Changes** - طلب تعديلات

---

## 🎯 نموذج Pull Request

عند فتح PR، استخدم القالب الموجود في `.github/PULL_REQUEST_TEMPLATE.md`.

**يجب أن يحتوي PR على:**
- وصف واضح للتغييرات
- المتطلبات المرتبطة (FR/NFR/BR)
- طريقة الاختبار
- قائمة التحقق

---

## 🐛 الإبلاغ عن الأخطاء

عند فتح Issue، استخدم القالب واذكر:
- الوصف
- خطوات إعادة الإنتاج
- السلوك المتوقع
- السلوك الفعلي
- لقطات شاشة

---

## 📞 التواصل

- **Issues**: للمناقشات الفنية
- **Discussions**: للأسئلة العامة
- **Slack**: للتواصل السريع

---

## 🎓 نصائح للنجاح

1. **الصبر** - البرمجة الجماعية تحتاج تنسيق
2. **التواصل** - اسأل عند عدم الفهم
3. **الجودة** - الأفضل من السريع
4. **الاختبار** - لا ترفع بدون اختبار
5. **التوثيق** - اكتب لأجل من يأتي بعدك

---

**بالتوفيق! 🚀**

**آخر تحديث:** 2026
**الكاتب:** أحمد عبيدات