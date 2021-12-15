using System;
using System.IO;
using VBIDE = Microsoft.Vbe.Interop;
using Word = Microsoft.Office.Interop.Word;
using Worde = Microsoft.Office.Interop.Word.Application;
using System.Threading;

namespace WpfApp2
{
    public class FileOperations
    {
        //private Microsoft.Office.Interop.Word.ApplicationClass MSdoc;
        public static bool CompressFile(string path)
        {
            //@"C:\Users\praktikant\Desktop\CompressedConvert.pdf"
            FileInfo sr = new FileInfo(path);
            if (sr.Length > 500000)
            {
                return true;
            }

            return false;
        }

        private static void CreateMacros(string inputPath)
        {
            var wordApp = new Word.Application();
            wordApp.Documents.Add(inputPath);
            var doc = wordApp.Documents[1];
            VBIDE.VBComponent oModule = doc.VBProject.VBComponents.Add(VBIDE.vbext_ComponentType.vbext_ct_StdModule);
            string sCode = string.Format(
               $"Sub МакросConvert() " +
               $"ActiveDocument.ExportAsFixedFormat OutputFileName:= _" +
                $"\"C: \\Users\\{Environment.UserName}\\Desktop\\ConvertedFile.pdf\", ExportFormat:= _" +
                $" wdExportFormatPDF, OpenAfterExport:= True, OptimizeFor:= _" +
                $"wdExportOptimizeForPrint, Range:= wdExportAllDocument, From:= 1, To:= 1, _" +
                $"Item:= wdExportDocumentContent, IncludeDocProps:= True, KeepIRM:= True, _" +
                $"CreateBookmarks:= wdExportCreateNoBookmarks, DocStructureTags:= True, _" +
                $" BitmapMissingFonts:= True, UseISO19005_1:= False" +
                $"ChangeFileOpenDirectory \"C: \\Users\\{Environment.UserName}\\Desktop\\\"" +
                $"End Sub");
            // Add the VBA macro to the new code module.
            oModule.CodeModule.AddFromString(sCode);
            Thread.Sleep(5000);
            RunMacro(wordApp, new Object[] { "МакросConvert" });
            wordApp.Visible = true;
        }

        private static void macros(string inputPath)
        {
            string file1 = inputPath;

            var word = new Worde { Visible = true };
            var doc = word.Documents.Open(file1);
            var project = doc.VBProject;
            var module = project.VBComponents.Add(VBIDE.vbext_ComponentType.vbext_ct_StdModule);
            var script = $"Sub МакросConvert() Attribute МакросConvert.VB_ProcData.VB_Invoke_Func" +
                $" = \"Normal.NewMacros.МакросConvert\" МакросConvert Макрос ActiveDocument." +
                $"ExportAsFixedFormat OutputFileName:= _ \"C:\\Users\\{Environment.UserName}\\Desktop\\ConvertedFile.pdf\"" +
                $", ExportFormat:= _ wdExportFormatPDF, OpenA" +
                $"fterExport:= True, OptimizeFor:= _ wdExportOptimizeForPrint, Range:= wd" +
                $"ExportAllDocument, From:= 1, To:= 1, _ Item:= wdExportDocumentContent, Inc" +
                $"ludeDocProps:= True, KeepIRM:= True, _ CreateBookmarks:= wdExportCreateNoBook" +
                $"marks, DocStructureTags:= True, _ BitmapMissingFonts:= True, UseISO19005_1:= Fal" +
                $"se ChangeFileOpenDirectory \"C:\\Users\\{Environment.UserName}\\Desktop\\\" End Sub";
            module.CodeModule.AddFromString(script);
            Thread.Sleep(6000);
            word.Run("МакросConvert");
        }

        public static async void ConvertDocxToPdf(string inputPath, string outputPath)
        {
            //CreateMacros(inputPath);
            // macros(inputPath);
            Message mess = MainWindow.Mesage;
            try
            {
                var WordApp = new Word.Application();
                WordApp.Documents.Add(inputPath);
                await System.Threading.Tasks.Task.Run(() => RunMacro(WordApp, new Object[] { "Макрос66" })); // аргументы, если есть
                WordApp.Visible = true;
                WordApp.Quit();
            }
            catch (Exception ex)
            {
                mess($"Ошибка конвертации\n{ex.Message}");
            }
        }

        public static void RunMacro(object oApp, object[] oRunArgs)
        {
            try
            {
                oApp.GetType().InvokeMember("Run",
                System.Reflection.BindingFlags.Default |
                System.Reflection.BindingFlags.InvokeMethod,
                null, oApp, oRunArgs);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка макроса\n{ex.Message}");
            }
        }

        public static string ConvertingToBase64(string path)
        {
            return Convert.ToBase64String(File.ReadAllBytes(path));
        }

        public static void ConvertingFromBase64(string base64Item, string path)
        {
            var fromBase64 = Convert.FromBase64String(base64Item);
            File.WriteAllBytes(path, fromBase64);
        }
    }
}