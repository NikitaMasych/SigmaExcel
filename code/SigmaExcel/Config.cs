using System.Collections.Generic;
using System.IO;
using System;

namespace SigmaExcel
{
    enum NonSavedContentWarnings
    {
        DeletionOfRow,
        DeletionOfColumn,
        Reset,
        Opening,
        Exit
    }
    class Config
    {
        private const string warningsConfigurationFile = "warnings.env";
        private const string SigmaExcelFilesFolder = "SigmaExcel";
        public static readonly Dictionary<NonSavedContentWarnings, bool> Warnings =
            new Dictionary<NonSavedContentWarnings, bool>
            {
                [NonSavedContentWarnings.DeletionOfRow] = true,
                [NonSavedContentWarnings.DeletionOfColumn] = true,
                [NonSavedContentWarnings.Reset] = true,
                [NonSavedContentWarnings.Opening] = true,
                [NonSavedContentWarnings.Exit] = true,
            };  
        
        public static void SetWarningsToEnvironmental()
        {
            Warnings[NonSavedContentWarnings.DeletionOfColumn] =
                bool.Parse(Environment.GetEnvironmentVariable("DELETION_OF_COLUMN"));
            Warnings[NonSavedContentWarnings.DeletionOfRow] =
               bool.Parse(Environment.GetEnvironmentVariable("DELETION_OF_ROW"));
            Warnings[NonSavedContentWarnings.Reset] =
               bool.Parse(Environment.GetEnvironmentVariable("RESET"));
            Warnings[NonSavedContentWarnings.Opening] =
               bool.Parse(Environment.GetEnvironmentVariable("OPENING"));
            Warnings[NonSavedContentWarnings.Exit] =
               bool.Parse(Environment.GetEnvironmentVariable("EXIT"));
        }
        public static void LoadWarningsEnvironmental()
        {
            var saveDirectory = GetSigmaExcelFilesDirectory();
            var saveFile = warningsConfigurationFile;
            var warningsEnvPath = saveDirectory + @"\" + saveFile;
            if (!File.Exists(warningsEnvPath))
            {
                throw new Exception("warnings.env does not exist");
            }
            using (var reader = new StreamReader(warningsEnvPath))
            {
                while (!reader.EndOfStream)
                {
                    var warning = reader.ReadLine().Split('=');
                    Environment.SetEnvironmentVariable(warning[0], warning[1]);
                }
            }
        }
        public static void SaveCurrentWarningsConfiguration()
        {
            var saveDirectory = GetSigmaExcelFilesDirectory();
            Directory.CreateDirectory(saveDirectory);
            var saveFile = warningsConfigurationFile;
            
            if (File.Exists(saveFile))
            {
                File.Delete(saveFile);
            }
            File.WriteAllText(saveDirectory + @"\" + saveFile, ComposeWarningsEnvContent());
        }
        private static string GetSigmaExcelFilesDirectory()
        {
            var serverProgramFilesDirectory =
               Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var sigmaExcelFilesDirectory =
                serverProgramFilesDirectory + @"\" + SigmaExcelFilesFolder;
            return sigmaExcelFilesDirectory;
        }
        private static string ComposeWarningsEnvContent()
        {
            return 
                $"DELETION_OF_ROW={Warnings[NonSavedContentWarnings.DeletionOfRow]}\n" +
                $"DELETION_OF_COLUMN={Warnings[NonSavedContentWarnings.DeletionOfColumn]}\n" +
                $"RESET={Warnings[NonSavedContentWarnings.Reset]}\n" +
                $"OPENING={Warnings[NonSavedContentWarnings.Opening]}\n" +
                $"EXIT={Warnings[NonSavedContentWarnings.Exit]}\n";
        }

        public const int DefaultRowsAmount = 37;
        public const int DefaultColumnsAmount = 19;
        public const char DefaultDelimiter = '$';
        public const string DocumentationURL = "https://github.com/NikitaMasych/SigmaExcel/blob/main/README.md";
        public const string EmergencySaveFilePath = "SigmaExcelTableEmergencySave.csv";
    }
}
