-- صف التحديث v1.2.7 لجدول updates على Supabase
-- يُنفَّذ بعد اكتمال GitHub Release (الأصول لازم تكون متاحة قبل النشر)
INSERT INTO updates
(version, previous_version, channel, title, title_ar, description, whats_new,
 is_mandatory, min_version_to_update, manifest_url, full_install_url,
 delta_size_bytes, full_size_bytes, is_active, is_rolled_back, release_date)
VALUES (
  '1.2.7',
  '1.2.6',
  'public',
  'تحديث سيستمك الأمني والحسابي v1.2.7',
  'تحديث سيستمك الأمني والحسابي v1.2.7',
  'حماية كلمات المرور بتجزئة PBKDF2 في كل مسارات المزامنة، تفعيل ضريبة الأصناف في نقطة البيع، إصلاح حساب رصيد الخزينة مع الرصيد الافتتاحي، وأيقونات جديدة موحدة للقائمة الجانبية',
  '["حماية كلمات المرور: تجزئة PBKDF2 إلزامية محلياً وعند المزامنة مع Supabase — لا نص صريح في قاعدة البيانات أو السحابة","تفعيل ضريبة الأصناف في شاشة البيع: تُحسب تلقائياً لكل صنف بحسب نسبته وتظهر في الإجمالي","إصلاح محاسبي: رصيد الخزينة = الافتتاحي + مجموع الحركات في كل المسارات دون استثناء","أيقونات القائمة الجانبية الجديدة من Flaticon بستايل موحد أنيق","تحسينات تشغيلية: نسخة البرنامج تُقرأ من الملف تلقائياً وسجل المزامنة لا يكرر التحذيرات"]'::jsonb,
  false,
  '0.0.0',
  'https://github.com/ammar92006/Sestamk.VB/releases/download/v1.2.7/manifest.json',
  'https://github.com/ammar92006/Sestamk.VB/releases/download/v1.2.7/Sestamk_Setup_v2026.exe',
  84879288,
  123091905,
  true,
  false,
  CURRENT_DATE
);
