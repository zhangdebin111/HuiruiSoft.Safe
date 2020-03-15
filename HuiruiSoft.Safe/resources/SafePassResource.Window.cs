namespace HuiruiSoft.Safe.Resources
{
     public static partial class SafePassResource
     {
          public static string LockedWindowCaption { get; private set; } = @"Locked";

          public static string LoginWindowCaption { get; private set; } = @"Login";

          public static string LoginWindowOptions { get; private set; } = @"Login options";

          public static string LoginWindowUserName { get; private set; } = @"Login name:";

          public static string LoginWindowPassword { get; private set; } = @"Password:";

          public static string LoginWindowPromptUserNameIsEmpty { get; private set; } = @"The user name cannot be empty. Please re-enter the user name.";

          public static string LoginWindowPromptPasswordIsEmpty { get; private set; } = @"The password cannot be empty. Please re-enter the password.";

          public static string LoginWindowPromptUserNameNonExistent { get; private set; } = @"The user name you entered does not exist, please try again.";

          public static string LoginWindowPromptPasswordIncorrect { get; private set; } = @"The login password you entered is incorrect. Please re-enter it.";


          public static string CatalogCreatorCaption { get; private set; } = @"New Catalog";

          public static string CatalogEditorCaption { get; private set; } = @"Edit Catalog";

          public static string CatalogEditorName { get; private set; } = @"Name:";

          public static string CatalogEditorDescription { get; private set; } = @"Description:";

          public static string CatalogViewerCaption { get; private set; } = @"Catalog Info";

          public static string CatalogSelectorCaption { get; private set; } = @"Select catalog";

          public static string CatalogSelectorPrompt { get; private set; } = @"Please select a new catalog";

          public static string CatalogEditorPromptNameIsEmpty { get; private set; } = @"Name cannot be null or empty string, please re-enter catalog name!";

          public static string CatalogEditorPromptNameTooLong { get; private set; } = @"Name is too long, the input text cannot exceed 100 bytes, please re-enter!";

          public static string CatalogEditorPromptDescriptionTooLong { get; private set; } = @"Description is too long, the input text cannot exceed 500 bytes, please re-enter!";

          public static string CatalogEditorPromptCatalogNameRepeat { get; private set; } = @"There is already a catalog with the same name as ""{0}"" in the current catalog. Please re-enter a different name";

          public static string DeleteGroupInfo { get; private set; } = @"Deleting a group will also delete all entries and subgroups in that group.";




          public static string AccountCreatorCaption { get; private set; } = @"New Account";

          public static string AccountEditorCaption { get; private set; } = @"Edit Account";

          public static string AccountViewerCaption { get; private set; } = @"Account Info";

          public static string AccountEditorLabelName { get; private set; } = @"&Account:";

          public static string AccountEditorLabelUserName { get; private set; } = @"&User name:";

          public static string AccountEditorLabelMobile { get; private set; } = @"&Mobile:";

          public static string AccountEditorLabelEmail { get; private set; } = @"&Email:";

          public static string AccountEditorLabelPassword { get; private set; } = @"&Password:";

          public static string AccountEditorLabelPwdRepeat { get; private set; } = @"&Repeat:";

          public static string AccountEditorLabelPasswordQuality { get; private set; } = @"&Quality:";

          public static string AccountEditorLabelURL { get; private set; } = @"UR&L:";

          public static string AccountEditorLabelSecret { get; private set; } = @"Secret:";

          public static string AccountEditorTabPageAttributes { get; private set; } = @"Attributes";

          public static string AccountEditorTabPageComment { get; private set; } = @"Comment";

          public static string AccountEditorButtonAddAttribute { get; private set; } = @"Add attribute";

          public static string AccountEditorButtonDeleteAttribute { get; private set; } = @"Delete attribute";

          public static string AccountEditorPromptNameIsEmpty { get; private set; } = @"""Account Name"" cannot be null or empty string, please re-enter account name!";

          public static string AccountEditorPromptNameTooLong { get; private set; } = @"""Account Name"" is too long, the char entered cannot exceed 30 bytes, please re-enter!";

          public static string AccountEditorDialogTitleCreateFailed { get; private set; } = @"Create failed";

          public static string AccountEditorDialogMessageCreateFailed { get; private set; } = @"An error occurred while creating account.The cause of the error may be:{0}{0}{1}";

          public static string AccountEditorDialogTitleUpdateFailed { get; private set; } = @"Update failed";

          public static string AccountEditorDialogMessageUpdateFailed { get; private set; } = @"An error occurred while updating account.The cause of the error may be:{0}{0}{1}";

          public static string DeleteAttributeMessageBoxCaption { get; private set; } = @"Delete confirm";

          public static string DeleteAttributeMessageBoxConfirm { get; private set; } = @"Are you sure you want to delete the current selected attribute?";

          public static string AddAttributeWindowTitle { get; private set; } = @"New attribute";

          public static string AddAttributeWindowLabelName { get; private set; } = @"Name:";

          public static string AddAttributeWindowLabelValue { get; private set; } = @"Value:";

          public static string AddAttributeWindowCheckBoxEncrypt { get; private set; } = @"Encrypt attribute value";

          public static string AddAttributeWindowFieldNameEmpty { get; private set; } = @"The Field Name cannot contain empty values, please re-enter.";

          public static string AddAttributeWindowFieldValueEmpty { get; private set; } = @"The Field Value cannot contain empty values, please re-enter.";

          public static string AddAttributeMessageBoxTitleSuccess { get; private set; } = @"Added success";

          public static string AddAttributeMessageBoxAddedSuccess { get; private set; } = @"The custom attribute name ({0}) was added successfully.";


          public static string OptionWindowCaption { get; private set; } = @"Options";

          public static string OptionWindowTabPageGeneral { get; private set; } = @"General";

          public static string OptionWindowTabPageSecurity { get; private set; } = @"Security";

          public static string OptionWindowSecretPublicColor { get; private set; } = @"public color:";

          public static string OptionWindowSecretSecretColor { get; private set; } = @"secret color:";

          public static string OptionWindowSecretConfidentialColor { get; private set; } = @"confidential color:";

          public static string OptionWindowSecretTopSecretColor { get; private set; } = @"Top secret color:";

          public static string OptionWindowLabelWorkDirectory { get; private set; } = @"Work directory:";

          public static string OptionWindowButtonChangeDirectory { get; private set; } = @"Change directory";

          public static string OptionWindowCheckBoxLockAfterTime { get; private set; } = @"Time the main window was locked inactive (seconds):";

          public static string OptionWindowCheckBoxLockGlobalTime { get; private set; } = @"Operating system inactivity lock time (seconds):";

          public static string OptionWindowCheckBoxAutoRunAtStartup { get; private set; } = @"Run SafePass at Windows startup (current user)";


          public static string PasswordGeneratorWindowCaption { get; private set; } = @"Password Generator";

          public static string PasswordGeneratorPasswordOptions { get; private set; } = @"Password options";

          public static string PasswordGeneratorAdvancedOptions { get; private set; } = @"Advanced options";

          public static string PasswordGeneratorGroupPassword { get; private set; } = @"Generated password";

          public static string PasswordGeneratorRadioUsingNumeral { get; private set; } = @"Using Numeral";

          public static string PasswordGeneratorRadioUsingCharacter { get; private set; } = @"&Generate using character set:";

          public static string PasswordGeneratorCheckBoxUpperCase { get; private set; } = @"&Upper-case";

          public static string PasswordGeneratorCheckBoxLowerCase { get; private set; } = @"Lo&wer-case";

          public static string PasswordGeneratorCheckBoxSpecialChars { get; private set; } = @"Sp&ecial";

          public static string PasswordGeneratorCheckBoxBracketChars { get; private set; } = @"&Brackets";

          public static string PasswordGeneratorCheckBoxDigitChars { get; private set; } = @"&Digits";

          public static string PasswordGeneratorCheckBoxMinusChar { get; private set; } = @"&Minus";

          public static string PasswordGeneratorCheckBoxUnderline { get; private set; } = @"U&nderline";

          public static string PasswordGeneratorCheckBoxSpaceChar { get; private set; } = @"&Space";

          public static string PasswordGeneratorLabelPasswordLength { get; private set; } = @"&Length of generated password:";

          public static string PasswordGeneratorCheckBoxNoRepeatingChars { get; private set; } = @"&Each character must occur at most once";

          public static string PasswordGeneratorCheckBoxExcludeLookAlike { get; private set; } = @"E&xclude look-alike characters";

          public static string PasswordGeneratorCheckBoxExcludeChars { get; private set; } = @"Ex&clude these characters:";

          public static string PasswordGeneratorButtonGenerate { get; private set; } = @"&Generate";

          public static string PasswordGeneratorMessageCharSetTooFewChars { get; private set; } = @"There are too few characters in the character set.";



          public static string ImportDialogTitle { get; private set; } = @"Import";

          public static string ExportDialogTitle { get; private set; } = @"Export";

          public static string ImportWindowCaption { get; private set; } = @"Import data";

          public static string ImportWindowGroupBoxFileInfo { get; private set; } = @"Import file";

          public static string ImportWindowLabelImportFile { get; private set; } = @"Import from file:";

          public static string ImportWindowGroupBoxOptions { get; private set; } = @"Import options";

          public static string ExportWindowCaption { get; private set; } = @"Export data";

          public static string ExportWindowGroupBoxFormat { get; private set; } = @"Export Format";

          public static string ExportWindowGroupBoxFileInfo { get; private set; } = @"Export file";

          public static string ExportWindowLabelExportFile { get; private set; } = @"Export to file:";

          public static string ExportOverwriteDialogCaption { get; private set; } = @"Confirm save as";

          public static string ExportOverwriteDialogPrompt { get; private set; } = @"""{0}"" already exists. {1} Do you want to replace it?";

          public static string ExportInvalidPathDialogCaption { get; private set; } = @"Invalid path";

          public static string ExportInvalidPathDialogPrompt { get; private set; } = @"""{0}"" invalid path. {1} Check that the file path is correct and try again.";

          public static string ExportXML1xFilter { get; private set; } = @"SafePass XML(*.xml)|*.xml";

          public static string ExportExcelFilter { get; private set; } = @"Excel workbook(*.xlsx)|*.xlsx";


          public static string AboutWindowCaption { get; private set; } = @"About SafePass";

          public static string AboutWindowLabelGpl { get; private set; } = @"The program is distributed under the terms of the GNU General Public License v2 or later.";


          public static string NewWizardWindowCaption { get; private set; } = @"New Wizard";

          public static string NewWizardWindowLabelLoginName { get; private set; } = @"Login name:";

          public static string NewWizardWindowLabelPassword { get; private set; } = @"&Password:";

          public static string NewWizardWindowLabelPwdRepeat { get; private set; } = @"&Confirm password:";

          public static string NewWizardWindowLabelPwdQuality { get; private set; } = @"Password &quality:";

          public static string NewWizardWindowLabelSafePassName { get; private set; } = @"SafePass Name:";

          public static string NewWizardWindowLabelWorkDirectory { get; private set; } = @"Work directory:";

          public static string NewWizardWindowButtonSelectDirectory { get; private set; } = @"Select directory";

          public static string NewWizardWindowPromptLoginNameIsEmpty { get; private set; } = @"The Login name cannot be empty. Please re-enter the user name!";

          public static string NewWizardWindowPromptLoginNameTooLong { get; private set; } = @"The Login name is too long, the char entered cannot exceed 30 bytes, please re-enter!";

          public static string NewWizardWindowPromptPasswordIsEmpty { get; private set; } = @"The password cannot be empty. Please re-enter the password.";

          public static string NewWizardWindowPromptRememberPassword { get; private set; } = @"Please remember your password. Once lost, it will not be retrieved.";

          public static string NewWizardWindowPromptSafePassNameIsEmpty { get; private set; } = @"The SafePass name cannot be empty. Please re-enter!";

          public static string NewWizardWindowPromptSafePassNameTooLong { get; private set; } = @"The SafePass name is too long, the char entered cannot exceed 30 bytes, please re-enter!";

          public static string NewWizardWindowDialogTitleCreateSuccess { get; private set; } = @"Create success";

          public static string NewWizardWindowDialogMessageCreateSuccess { get; private set; } = @"Master account create success, please login again.";

          public static string ChangePasswordWindowCaption { get; private set; } = @"Change password";

          public static string ChangePasswordWindowLabelOldPassword { get; private set; } = @"Old password:";

          public static string ChangePasswordWindowLabelNewPassword { get; private set; } = @"New password:";

          public static string ChangePasswordWindowLabelRepeatPassword { get; private set; } = @"Confirm new password:";

          public static string ChangePasswordWindowLabelPasswordQuality { get; private set; } = @"Password &quality:";

          public static string ChangePasswordWindowMessageChangeFailed { get; private set; } = @"Change password failed";

          public static string ChangePasswordWindowMessageChangeSuccess { get; private set; } = @"Change password success";

          public static string ChangePasswordWindowPromptPasswordIncorrect { get; private set; } = @"The login password you entered is incorrect. Please re-enter it.";

          public static string ChangePasswordWindowPromptPasswordIsEmpty { get; private set; } = @"The password cannot be empty. Please re-enter the password.";

          public static string ChangePasswordWindowPromptSameAsOldPassword { get; private set; } = @"The new password cannot be the same as the old password.";

          public static string ChangeLanguageWindowCaption { get; private set; } = @"Select Language";

          public static string ChangeLanguageWindowColumnLanguageName { get; private set; } = @"Language";

          public static string ChangeLanguageWindowColumnLanguageVersion { get; private set; } = @"Version";

          public static string ChangeLanguageWindowColumnLanguageFile { get; private set; } = @"File";

          public static string ChangeLanguageWindowLanguageBuiltIn { get; private set; } = @"Built in";

          public static string ChangeLanguageWindowMessage { get; private set; } = @"To change to the selected language, you need to restart safepass to reload. \n\n do you want to restart safepass now?";

     }
}