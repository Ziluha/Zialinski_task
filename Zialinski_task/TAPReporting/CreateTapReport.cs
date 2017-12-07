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
        static readonly string ReportPath = ProjectPath + "TAPReporting\\tapresults.tap";
        
        public static void StartTapReport()
        {
            TextWriter tsw = new StreamWriter(ReportPath);
            tsw.WriteLine("1..6");
            tsw.Close();
        }

        public static void WriteTapLineResults()
        {
            TextWriter tsw = new StreamWriter(ReportPath, true);
            tsw.WriteLine();
            tsw.Close();
        }

        public static void WriteTapResults(string tapRes)
        {
            TextWriter tsw = new StreamWriter(ReportPath, true);
            tsw.Write(tapRes);
            tsw.Close();
        }
    }
}
