using System;

namespace gtkfetch
{
    class MemInfoGetter
    {
        public struct MemInfo 
        {
        public decimal total;
        public decimal available;
        public decimal used;
        }
        public static MemInfo Mem;
        static string totalexpr = @"MemTotal:\s*(\d*)";
        static string availableexpr = @"MemAvailable:\s*(\d*)";
        /// <summary> Reads memory info from /proc/meminfo and populates MemInfo instance </summary>
        public static void GetMemInfo()
        {   
            Mem.total = Decimal.Parse(FileReader.ReadFileAndFindGroup("/proc/meminfo", totalexpr, 1));
            Mem.available = Decimal.Parse(FileReader.ReadFileAndFindGroup("/proc/meminfo", availableexpr, 1));
            Mem.used = Mem.total - Mem.available;
        }
        /// <summary> Updates memory information </summary>
        public static void RefreshMemInfo()
        {
            Mem.available = Decimal.Parse(FileReader.ReadFileAndFindGroup("/proc/meminfo", availableexpr, 1));
            Mem.used = Mem.total - Mem.available;
        }
    }   
}