using System.Collections.Generic;

namespace RealExcel
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
        public readonly Dictionary<NonSavedContentWarnings, bool> Warnings =
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
