using System.IO;
using Gallio.Common.Reflection.Impl;
using Zialinski_task.Pathes;

namespace Zialinski_task.TapReporting
{
    public static class CreateTapReport
    {
        static readonly string BinPath = ProjectPathes.GetBinPath();
        static readonly string ActualPath = ProjectPathes.GetActualPath(BinPath);
        static readonly string ProjectPath = ProjectPathes.GetLocalUri(ActualPath);
        private static string _reportPath;

        public static void SetTAPReportName(string reportName)
        {
            _reportPath = ProjectPath + $"TAPReporting\\{reportName}.tap";
            StartTapReport();
        }

        public static void StartTapReport()
        {
            TextWriter tsw = new StreamWriter(_reportPath);
            tsw.WriteLine("1..1");
            tsw.Close();
        }

        public static void WriteTapLineResults()
        {
            TextWriter tsw = new StreamWriter(_reportPath, true);
            tsw.WriteLine();
            tsw.Close();
        }

        public static void WriteTapResults(string tapRes)
        {
            TextWriter tsw = new StreamWriter(_reportPath, true);
            tsw.Write(tapRes);
            tsw.Close();
        }
    }
}
