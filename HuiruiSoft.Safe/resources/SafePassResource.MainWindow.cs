namespace HuiruiSoft.Safe.Resources
{
     public static partial class SafePassResource
     {
          public static string MoveSelectedEntryToRecycleBinTitle { get; private set; } = @"Delete Entry";

          public static string MoveSelectedEntriesToRecycleBinTitle { get; private set; } = @"Delete Entries";

          public static string MoveSelectedEntryToRecycleBinQuestion { get; private set; } = @"Are you sure you want to move the selected entry to the recycle bin?";

          public static string MoveSelectedEntriesToRecycleBinQuestion { get; private set; } = @"Are you sure you want to move the selected entries to the recycle bin?";

          public static string DeletePermanentlySelectedEntryTitle { get; private set; } = @"Delete Entry";

          public static string DeletePermanentlySelectedEntriesTitle { get; private set; } = @"Delete Entries";

          public static string DeletePermanentlySelectedEntryQuestion { get; private set; } = @"Are you sure you want to permanently delete the selected entry?";

          public static string DeletePermanentlySelectedEntriesQuestion { get; private set; } = @"Are you sure you want to permanently delete the selected entries?";

          public static string DeleteSelectedEntriesMorePrompt { get; private set; } = @"{0}{1} More entries";

          public static string DeletePermanentlySelectedCatalogTitle { get; private set; } = @"Delete Catalog";

          public static string DeletePermanentlySelectedCatalogQuestion { get; private set; } = @"Are you sure you want to permanently delete the selected catalog? \r\n\r\n Select ""OK"" to delete permanently and you will not be able to undo your changes.";

          public static string DeleteSelectedCatalogErrorForNotEmpty { get; private set; } = @"An error occurred while deleting the catalog, The reason for the error is: \r\n\r\n there are sub catalogs under the catalog '{0}'. When deleting a catalog, there cannot be sub catalogs or entries under the catalog.";
     }
}