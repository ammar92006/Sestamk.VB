-- صف التحديث v1.3.0 لجدول updates على Supabase
-- نُفِّذ بعد اكتمال GitHub Release v1.3.0 (الأصول مرفوعة والهاش مطابق)
-- ملاحظة: عمود whats_new نوعه text[] — استخدم ARRAY[...] وليس jsonb
INSERT INTO updates
(version, previous_version, channel, title, title_ar, description, whats_new,
 is_mandatory, min_version_to_update, manifest_url, full_install_url,
 delta_size_bytes, full_size_bytes, is_active, is_rolled_back, release_date)
VALUES (
  '1.3.0',
  '1.2.7',
  'public',
  'تحديث سيستمك الحسابي المتكامل v1.3.0',
  'تحديث سيستمك الحسابي المتكامل v1.3.0',
  'حماية محاسبية تمنع حذف العملاء المدينين والفئات الممتلئة، توثيق رسوم الصالة والضريبة في أعمدة منفصلة لكل فاتورة، مصدر حقيقة واحد لإجماليات الوردية، وإصلاح ذاتي لأرصدة الخزائن عند الإقلاع',
  ARRAY[
    'حماية الحذف: لا يمكن حذف عميل عليه مديونية أو دائن — يجب تصفير الحساب أولاً مثل قاعدة الموردين',
    'حماية الفئات: لا يمكن حذف فئة فيها أصناف — مع إظهار عدد الأصناف التابعة',
    'توثيق الفاتورة: أعمدة جديدة تحفظ رسوم الصالة والضريبة لكل فاتورة لأغراض التدقيق',
    'دقة الورديات: إجماليات الوردية تُحدَّث في قاعدة البيانات فقط — نهاية انحراف الإجماليات بين أكثر من كاشير',
    'إصلاح ذاتي: عند الإقلاع يطابق البرنامج رصيد كل خزينة مع حركاتها ويصحح أي انحراف تلقائياً',
    'صلاحيات محكمة: كل شاشة جديدة تصبح ممنوعة افتراضياً لغير المدير حتى يمنحها — مع حفظ صلاحيات الجميع الحالية'
  ],
  false,
  '1.2.7',
  'https://github.com/ammar92006/Sestamk.VB/releases/download/v1.3.0/manifest.json',
  'https://github.com/ammar92006/Sestamk.VB/releases/download/v1.3.0/Sestamk_Setup_v2026.exe',
  84881177,
  123076737,
  true,
  false,
  CURRENT_DATE
);

-- تحقق بعد التنفيذ (يجب أن يعيد الصف الجديد بعدد ملاحظات = 6):
-- SELECT version, release_date, is_active, array_length(whats_new, 1) AS notes_count
-- FROM updates WHERE version = '1.3.0';
