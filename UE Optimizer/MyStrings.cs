using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UE_Optimizer
{
    static class MyStrings
    {
        public static string FbDescEng => "Select a config folder for Unreal Engine based game.\n" +
                                          "(You can select MyGames folder to search for all Steam games).";
        public static string FbDescRus => "Выберите папку с настройками игры на Unreal Engine.\n" +
                                          "(можно указать папку MyGames для поиска всех игр Steam).";

        public static string MbNotFoundTxtEng => "No config files found!";
        public static string MbNotFoundTxtRus => "Конфигурационные файлы не найдены!";

        public static string MbNotFoundCapEng => "Attention!";
        public static string MbNotFoundCapRus => "Внимание!";

        public static string MbAccErrCapEng => "File access error!";
        public static string MbAccErrCapRus => "Ошибка доступа к файлу!";

        public static string MbReadErrCapEng => "File read error!";
        public static string MbReadErrCapRus => "Ошибка чтения из файла!";

        public static string MbWriteErrCapEng => "File write error!";
        public static string MbWriteErrCapRus => "Ошибка записи в файл!";

        public static string BrowseEng => "Browse";
        public static string BrowseRus => "Обзор";

        public static string VramEng => "VRAM";
        public static string VramRus => "Объём VRAM";

        public static string StartEng => "Apply";
        public static string StartRus => "Применить";

        public static string StatusEng => "Done!";
        public static string StatusRus => "Готово!";

        public static string HTEnabledEng => "HT enabled";
        public static string HTEnabledRus => "HT включён";
    }
}