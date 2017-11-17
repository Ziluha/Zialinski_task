using System;

namespace Zialinski_task.Pathes
{
    public static class ProjectPathes
    {
        public static string GetBinPath()
        {
            return System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        }

        public static string GetActualPath(string binPath)
        {
            return binPath.Substring(0, binPath.LastIndexOf("bin", StringComparison.Ordinal));
        }

        public static string GetLocalUri(string actualPath)
        {
            return new Uri(actualPath).LocalPath;
        }
    }
}
