<Query Kind="Statements">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var s1 = 
@"423464, Аллоды Онлайн, Ввести Игровой аккаунт
762386, ArcheAge, Ввести Логин (Ваш е-mail)
920228, Войны престолов, Ввести Ник персонажа
953927, Perfect World, Ввести Игровой аккаунт
505270, Ground War: Tanks, Ввести ID персонажа
671478, Warface, Ввести Введите логин (Ваш е-mail)
362507, Strife ,Ввести Введите логин (Ваш е-mail)
519826, Легенда : Наследие драконов. Сервер: Фэо-прайм, Ввести Ник персонажа
907401, Легенда : Наследие драконов. Сервер: Фэо-минор, Ввести Ник персонажа
868526, Cross Fire, Ввести Ваш логин
942462, Dragon Nest, Ввести Введите логин (Ваш е-mail)
906551, Троецарствие@mail.ru, Ввести Ник персонажа
239790, ПараПа: Город танцев, Ввести Ваш ЛОГИН
790670, Джаггернаут, Ввести Ник персонажа
198213, Бумз, Ввести Платежный ID
936155, Jade Dynasty, Ввести Игровой аккаунт
651780, RIOT, Ввести Ник персонажа
761490, Властелин колец онлайн, Ввести Логин
688131, TimeZero, Ввести Ник персонажа
369387, Территория, Ввести Ник персонажа
765063, Bloody World, Ввести Ник персонажа
935080, Мини-игры@Mail.Ru, Ввести e-mail
760315, Кодекс пиратов, Ввести Ник персонажа
374204, Спарта, Ввести Ник персонажа";

var q = s1
	.Split('\n')
	.Select(i => i.Split(',').Select(o => o.Trim()).ToArray());
	
string.Join("\n",
	q
	.Select((i, ind) =>
		"gamesInfo.Add(" + (ind + 1) + ", new GameInfo(" + i[0]
		+ ", \"" + i[1] + "\", \"" + i[2] + "\"));")
).Dump();

string.Join(";",
	q.Select((i, ind) => (ind + 1) + "=" + i[1])
).Dump("Dictionary");

var s2 = @"423464, Аллоды Онлайн, Ввести Игровой аккаунт
762386, ArcheAge, Ввести Логин (Ваш е-mail)
920228, Войны престолов, Ввести Ник персонажа
953927, Perfect World, Ввести Игровой аккаунт
505270, Ground War: Tanks, Ввести ID персонажа
671478, Warface, Ввести Введите логин (Ваш е-mail)
362507, Strife ,Ввести Введите логин (Ваш е-mail)
519826, Легенда : Наследие драконов. Сервер: Фэо-прайм, Ввести Ник персонажа
907401, Легенда : Наследие драконов. Сервер: Фэо-минор, Ввести Ник персонажа
868526, Cross Fire, Ввести Ваш логин
942462, Dragon Nest, Ввести Введите логин (Ваш е-mail)
906551, Троецарствие@mail.ru, Ввести Ник персонажа
239790, ПараПа: Город танцев, Ввести Ваш ЛОГИН
790670, Джаггернаут, Ввести Ник персонажа
198213, Бумз, Ввести Платежный ID
936155, Jade Dynasty, Ввести Игровой аккаунт
651780, RIOT, Ввести Ник персонажа
761490, Властелин колец онлайн, Ввести Логин
688131, TimeZero, Ввести Ник персонажа
369387, Территория, Ввести Ник персонажа
765063, Bloody World, Ввести Ник персонажа
935080, Мини-игры@Mail.Ru, Ввести e-mail
760315, Кодекс пиратов, Ввести Ник персонажа
374204, Спарта, Ввести Ник персонажа";

(s1 == s2).Dump();