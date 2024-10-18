
# Exam Application
In initial task(can be found [here](https://i.imgur.com/0l1iDW9.png)) there was not any user or identity functionality.
I adjusted initial logic by creating 3 user roles:

- Admin: Can create and edit users, exams and lessons.
- Teacher: Can see lessons related to him and exams for this lessons. Can change scores of lessons.
- Student: Can see lessons of his grade and exams related to him.

Default Admin account is created automatically on app's first run with following credentials(can be found in Exam.MVC assembly in appsettings.json file):
- "Username": "Admin"
- "Password": "Admin123%"

You can check how application by logining in with this account and then creating students, teachers, exams etc.

Don't forget to change MS SQL connection string and migrdate database before running!(connection string is at appsettings.json file)

## It is the first my MVC app created with Repository Pattern. 

# İmtahan proqramı
İlkin tapşırıqda ([burada tapa bilərsiniz](https://i.imgur.com/0l1iDW9.png)) heç bir User və ya Identitty yox idi
3 istifadəçi rolu yaradaraq ilkin məntiqi biraz dəyişdim:

- Admin: İstifadəçilər, imtahanlar və dərslər yarada və redaktə edə bilər.
- Müəllim: Onunla bağlı dərsləri və bu dərslər üçün imtahanları görə bilər. Dərslərin ballarını dəyişə bilir.
- Tələbə: Sinifinə aid dərsləri və ona aid imtahanları görə bilir.

Defolt Admin hesabı aşağıdakı etimadnamələrlə tətbiqin ilk işə salınmasında avtomatik olaraq yaradılır (appsettings.json faylında Exam.MVC assembly-də ​​tapıla bilər):
- "Username": "Admin"
- "Password": "Admin123%"

Bu hesabı ilə daxil olaraq tətbiqin necə işlənməsini yoxliya bilərsiz.

Tətbiqi run eləməzdən əvvəl MS SQL connection string'i dəyişdirməyi və database migrations unutmayın!(connection string appsettings.json faylındadır)

## Bu, Repository Pattern ilə yaradılmış ilk MVC tətbiqimdir.
