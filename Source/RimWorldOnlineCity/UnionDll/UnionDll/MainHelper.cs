﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Verse;

namespace OCUnion
{
    public static class MainHelper
    {
        public static bool DebugMode = false;

        public static string VersionInfo = "Версия 0.02.15a от 2018.08.26";

        private static CultureInfo CultureValue = null;
        public static CultureInfo Culture
        {
            get
            {
                if (CultureValue == null)
                {
                    try
                    {
                        if ((Prefs.LangFolderName ?? "").StartsWith("Russian"))
                            CultureValue = CultureInfo.GetCultureInfo("ru-RU");
                        else
                            CultureValue = CultureInfo.InvariantCulture;
                    }
                    catch
                    {
                        CultureValue = CultureInfo.InvariantCulture;
                    }
                }
                return CultureValue;
            }
        }

        public static string ToGoodString(this DateTime that)
        {
            return that.ToString(Culture);
        }
        public static string ToGoodUtcString(this DateTime that)
        {
            var nowUtc = DateTime.Now - DateTime.UtcNow;
            return (that + nowUtc).ToString(Culture);
        }
    }
}
