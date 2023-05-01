using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {   //publicler büyük harfle başlar
        public static string CarAdded = "Araba eklendi";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarListed = "Arabalar listelendi";
        public static string CarIdNull = "Araba seçmediniz";
        public static string CarUpdated = "Araba verileri güncellendi";
        public static string CarDeleted = "Araba silindi";

        internal static string BrandNameInvalid="Marka ismi geçersiz";
        internal static string BrandAdded="Marka eklendi";
        internal static string BrandIdNull="Marka seçmediniz";
        internal static string BrandUpdated="Marka verileri güncellendi";
        internal static string BrandDeleted="Marka silindi";

        internal static string ColorNameInvalid="Renk adı geçersiz";
        internal static string ColorAdded="Renk eklendi";
        internal static string ColorUpdated="Renk verileri güncellendi";
        internal static string ColorIdNull="Renk seçmediniz";
        internal static string ColorDeleted="Renk silindi";
    }
}
