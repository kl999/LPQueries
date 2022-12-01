<Query Kind="Program">
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
    var str = "910221350048";
    
    try
    {
        checkBIN(str, 1);
        
        true.Dump("checkBIN");
    }
    catch(Exception ex)
    {
        ex.Dump("checkBIN Exception");
    }
    
    var dbg = "";
    var isRez = false;
    checkIIN(str, out dbg, out isRez).Dump("checkIIN");
    dbg.Dump("Debug");
    isRez.Dump("is resident");
}

        public static void checkBIN(string bin, int rowNum)
        {
            if (Regex.IsMatch(bin, @"\s")) throw new Exception("строка " + (rowNum + 1) + " В БИНе есть непечатаемые символы");

            if (!Regex.IsMatch(bin, @"^\d{12}$")) throw new Exception("строка " + (rowNum + 1) + " БИН должен состаять из 12 цифр.");

            /*Первая часть – состоит из 4 цифр и включает в себя год (две последние цифры) и месяц государственной (учетной) регистрации или перерегистрации юридического лица, филиалов и представительств или индивидуального предпринимателя, осуществляющего деятельность в виде совместного предпринимательства (далее - ИП(С);

            Вторая часть – состоит из 1 цифры и означает тип юридического лица или ИП(С).
            Конкретные значения типа юридического лица или ИП(С):
                  4 – для юридических лиц-резидентов;
                  5 – для юридических лиц-нерезидентов;
                  6 – для ИП(С);

            Третья часть – состоит из 1 цифры и является дополнительным признаком и определяется следующим образом:
                  0 – головного подразделения юридического лица или ИП(С);
                  1 – филиала юридического лица или ИП(С);
                  2 – представительства юридического лица или ИП(С);
                  3 – крестьянское (фермерское) хозяйство, осуществляющее деятельность на основе совместного предпринимательства;

            Четвертая часть – состоит из 5 цифр и включает в себя порядковый номер регистрации в системе юридического лица (филиалов и представительств) или ИП (С);

            Пятая часть – состоит из 1 цифры, определяемой автоматически и являющейся контрольной цифрой.*/
            
            if (Int32.Parse(bin.Substring(2,2)) > 12) throw new Exception("строка " + (rowNum + 1) + " Значение месяца больше 12!");
            var urType = new List<string>(new[] { "4", "5", "6" });
            if (!urType.Contains(bin.Substring(4, 1))) throw new Exception("строка " + (rowNum + 1) + " Значение типа юр. лица не правильное!");
            var addAtr = new List<string>(new[] { "0", "1", "2", "3" });
            if (!addAtr.Contains(bin.Substring(5, 1))) throw new Exception("строка " + (rowNum + 1) + " Значение дополнительного признака не правильное!");

            byte[] digit = new byte[12];

            for (int i = 0; i < digit.Length; i++)
            {
                digit[i] = byte.Parse(bin[i].ToString());
            }

            byte control = digit[11];

            var weight = new byte[2][];
            weight[0] = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            weight[1] = new byte[] { 3, 4, 5, 6, 7, 8, 9, 10, 11, 1, 2 };

            int[] cv = new int[2];
            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < 11; i++)
                    cv[k] += digit[i] * weight[k][i];
                cv[k] %= 11;
            }

            if (cv[0] == 10 && cv[1] == 10) throw new Exception("строка " + (rowNum + 1) + "Контрольный разряд неиспользуемого ИИН");

            if (cv[0] != 10 && cv[0] != control || cv[0] == 10 && cv[1] != control) if (cv[0] == 10 && cv[1] == 10) throw new Exception("строка " + (rowNum + 1) + "Контрольный разряд не верен");
        }

        public static bool checkIIN(string IIN, out string debug, out bool isResident)
        {
            string valid = "Корректный ИИН";
            string error = "Ошибка проверки ИИН: ";
            isResident = true;

            if (IIN.Length != 12 ||
                false == Regex.Match(IIN, @"\d{12}").Success)
            {
                debug = error + "Должен состоять из 12 цифр";
                return false;
            }

            byte[] digit = new byte[12];
            for (int i = 0; i < 12; i++)
                digit[i] = Convert.ToByte(IIN.Substring(i, 1));

            int year = digit[0]*10 + digit[1];
            int month = digit[2]*10 + digit[3];
            int day = digit[4]*10 + digit[5];
            byte century = digit[6];
            byte control = digit[11];

            if (month < 1 || 12 < month)
            {
                debug = error + "Месяц должен быть в диапазоне от 1 до 12 (" + month + ")";
                return false;
            }

            if (century > 6)
            {
                debug = error + "Век должен быть в диапазоне от 0 до 6 (" + century + ")";
                return false;
            }

            switch (century)
            {
                case 1:
                case 2:
                    year += 1800;
                    break;
                case 3:
                case 4:
                    year += 1900;
                    break;
                case 5:
                case 6:
                    year += 2000;
                    break;
            }

            if (century == 0)
            {
                isResident = false;
                year += 2000; //Все нерезиденты будут 2000-го
            }

            try
            {
                new DateTime(year, month, day);
            }
            catch
            {
                debug = error + "Дата рождения отсутствует в календаре";
                return false;
            }

            // Расчет контрольного разряда
            var weight = new byte[2][];
            weight[0] = new byte[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
            weight[1] = new byte[] {3, 4, 5, 6, 7, 8, 9, 10, 11, 1, 2};

            int[] cv = new int[2];
            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < 11; i++)
                    cv[k] += digit[i]*weight[k][i];
                cv[k] %= 11;
            }

            if (cv[0] == 10 && cv[1] == 10)
            {
                debug = error + "Контрольный разряд неиспользуемого ИИН";
                return false;
            }

            if (cv[0] != 10 && cv[0] != control ||
                cv[0] == 10 && cv[1] != control)
            {
                debug = error + "Контрольный разряд не верен";
                return false;
            }

            debug = valid;
            return true;
        }