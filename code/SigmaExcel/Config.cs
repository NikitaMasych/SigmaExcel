using System.Collections.Generic;

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
        public static readonly Dictionary<NonSavedContentWarnings, bool> Warnings =
            new Dictionary<NonSavedContentWarnings, bool>
            {
                [NonSavedContentWarnings.DeletionOfRow] = true,
                [NonSavedContentWarnings.DeletionOfColumn] = true,
                [NonSavedContentWarnings.Reset] = true,
                [NonSavedContentWarnings.Opening] = true,
                [NonSavedContentWarnings.Exit] = true,
            };  
    }
}
