
using System.Collections.Generic;
using HuiruiSoft.Safe.Configuration;

namespace HuiruiSoft.Safe.Localization
{
     public static class LocalizationResSerializerZHN
     {
          private static string localLanguageFile = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, ApplicationDefines.ChineseSimpLanguageFile);

          public static bool SaveLocalResources()
          {
               var tmpLocalResources = new LocalizationResources();

               tmpLocalResources.Header = new LanguageHeader();
               tmpLocalResources.Header.Application = ApplicationDefines.ProductName;
               tmpLocalResources.Header.Version = ApplicationDefines.VersionNo;
               tmpLocalResources.Header.EnglishName = "Chinese.Simplified";
               tmpLocalResources.Header.NativeName = "简体中文";
               tmpLocalResources.Header.LastModified = System.DateTime.Now.ToString(ApplicationDefines.DateTimeFormat);

               tmpLocalResources.LocalizedStrings = new LocalizedStringTable();

               var tmpGeneralLocalStrings = new List<LocalizedStringItem>();
               tmpLocalResources.LocalizedStrings.General = tmpGeneralLocalStrings;

               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "KeyboardKeyAlt", Value = @"Alt" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "KeyboardKeyCtrl", Value = @"Ctrl" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "KeyboardKeyCtrlLeft", Value = @"LCtrl" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "KeyboardKeyShift", Value = @"Shift" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "KeyboardKeyShiftLeft", Value = @"LShift" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "KeyboardKeyEsc", Value = @"Esc" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "KeyboardKeyInvalid", Value = @"Invalid Key" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "KeyboardKeyModifiers", Value = @"组合键" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "KeyboardKeyReturn", Value = @"回车" });

               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "Event", Value = @"事件" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "Error", Value = @"错误" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "Errors", Value = @"错误" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "ErrorCode", Value = @"错误代码" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "Version", Value = @"版本" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "ButtonOK", Value = "确定(&O)" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "ButtonCancel", Value = "取消(&C)" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "ButtonClose", Value = "关闭(&C)" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "ButtonExitApp", Value = @"退出(&X)" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "RecycleBin", Value = @"回收站" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "DialogDescriptionFolderBrowser", Value = @"请选择文件夹" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "MessageBoxCaptionInputError", Value = @"输入错误" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "PasswordRepeatFailed", Value = @"两次输入密码不一致！" });

               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "SecretRankpublic", Value = @"公开" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "SecretRankSecret", Value = @"秘密" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "SecretRankConfidential", Value = @"机密" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "SecretRankTopsecret", Value = @"绝密" });

               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "Ready", Value = @"就绪。" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "AlgorithmUnknown", Value = @"未知算法。" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "ClipboardDataCopied", Value = @"数据已复制到剪贴板" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "ClipboardClearInSeconds", Value = @"剪贴板的数据将在 {0} 秒后清除" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "MasterPasswordMinimumLengthFailed", Value = @"账号密码太短，密码必须至少 {0} 个字符，请重新输入。" });
               tmpGeneralLocalStrings.Add(new LocalizedStringItem() { Name = "MasterPasswordMinimumQualityFailed", Value = @"账号密码的估计质量必须至少为 {0} ，请重新输入稍复杂一些的密码！" });

               var tmpMainMenuLocalStrings = new List<LocalizedStringItem>();
               tmpLocalResources.LocalizedStrings.MainMenu = tmpMainMenuLocalStrings;
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemFile", Value = @"文件(&F)" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemEdit", Value = @"编辑(&E)" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemView", Value = @"视图(&V)" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemTools", Value = @"工具(&T)" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemHelp", Value = @"帮助(&H)" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemChangePassword", Value = @"更改管理密码..." });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemFileImport", Value = @"导入(&I)..." });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemFileExport", Value = @"导出(&E)..." });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemExitWorkspace", Value = @"退出(&X)" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemSelectAll", Value = @"全选(&L)" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemEmptyRecycleBin", Value = @"清空回收站(&B)" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemRestoreRecycleBin", Value = @"还原(&E)" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemCatalogCreate", Value = @"新建目录(&A)..." });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemCatalogEdit", Value = @"编辑目录(&E)..." });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemCatalogDelete", Value = @"删除目录(&D)" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemEntryCreate", Value = @"创建账号(&A)..." });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemEntryEdit", Value = @"编辑账号(&E)..." });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemEntryDelete", Value = @"删除账号(&D)" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemEntryMoveTo", Value = @"移动到(&V)..." });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemCopyUserName", Value = @"复制用户名(&U)" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemCopyPassword", Value = @"复制密码(&P)" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemCopyMobile", Value = @"复制手机号码(&T)" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemCopyEmail", Value = @"复制电子邮箱(&E)" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemEntryTopmost", Value = @"置顶(&T)" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemEntryTopmostCancel", Value = @"取消置顶(&T)" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemReArrangePopup", Value = @"排序(&R)" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemEntryMoveToTop", Value = @"移到顶端(&T)" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemEntryMoveOneUp", Value = @"向上移动(&U)" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemEntryMoveOneDown", Value = @"向下移动(&D)" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemEntryMoveToBottom", Value = @"移到底端(&B)" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemChangeLanguage", Value = @"选择语言(&L)..." });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemViewShowToolBar", Value = @"显示工具栏" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemViewHideToolBar", Value = @"隐藏工具栏" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemViewShowStatusBar", Value = @"显示状态栏" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemViewHideStatusBar", Value = @"隐藏状态栏" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemLockWindow", Value = @"锁定窗口" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemLockScreen", Value = @"锁定屏幕(&W)" });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemToolsOptions", Value = @"选项(&O)..." });
               tmpMainMenuLocalStrings.Add(new LocalizedStringItem() { Name = "MenuItemHelpAbout", Value = @"关于(&A)..." });

               var tmpMainToolbarLocalStrings = new List<LocalizedStringItem>();
               tmpLocalResources.LocalizedStrings.MainToolbar = tmpMainToolbarLocalStrings;
               tmpMainToolbarLocalStrings.Add(new LocalizedStringItem() { Name = "ToolButtonCatalogCreate", Value = @"新建目录" });
               tmpMainToolbarLocalStrings.Add(new LocalizedStringItem() { Name = "ToolButtonCatalogCreateTips", Value = @"新建目录..." });
               tmpMainToolbarLocalStrings.Add(new LocalizedStringItem() { Name = "ToolButtonCatalogEdit", Value = @"编辑目录" });
               tmpMainToolbarLocalStrings.Add(new LocalizedStringItem() { Name = "ToolButtonCatalogEditTips", Value = @"编辑目录..." });
               tmpMainToolbarLocalStrings.Add(new LocalizedStringItem() { Name = "ToolButtonCatalogDelete", Value = @"删除目录" });
               tmpMainToolbarLocalStrings.Add(new LocalizedStringItem() { Name = "ToolButtonCatalogDeleteTips", Value = @"删除目录" });
               tmpMainToolbarLocalStrings.Add(new LocalizedStringItem() { Name = "ToolButtonEntryCreate", Value = @"创建账号" });
               tmpMainToolbarLocalStrings.Add(new LocalizedStringItem() { Name = "ToolButtonEntryCreateTips", Value = @"创建账号..." });
               tmpMainToolbarLocalStrings.Add(new LocalizedStringItem() { Name = "ToolButtonEntryEdit", Value = @"编辑账号" });
               tmpMainToolbarLocalStrings.Add(new LocalizedStringItem() { Name = "ToolButtonEntryEditTips", Value = @"编辑账号..." });
               tmpMainToolbarLocalStrings.Add(new LocalizedStringItem() { Name = "ToolButtonEntryDelete", Value = @"删除账号" });
               tmpMainToolbarLocalStrings.Add(new LocalizedStringItem() { Name = "ToolButtonEntryDeleteTips", Value = @"删除账号" });
               tmpMainToolbarLocalStrings.Add(new LocalizedStringItem() { Name = "ToolButtonDataRefresh", Value = @"刷新" });
               tmpMainToolbarLocalStrings.Add(new LocalizedStringItem() { Name = "ToolButtonDataRefreshTips", Value = @"刷新数据" });
               tmpMainToolbarLocalStrings.Add(new LocalizedStringItem() { Name = "ToolButtonLockWindow", Value = @"锁定窗口" });
               tmpMainToolbarLocalStrings.Add(new LocalizedStringItem() { Name = "ToolButtonLockWindowTips", Value = @"锁定窗口" });
               tmpMainToolbarLocalStrings.Add(new LocalizedStringItem() { Name = "ToolButtonLockScreen", Value = @"锁定屏幕" });
               tmpMainToolbarLocalStrings.Add(new LocalizedStringItem() { Name = "ToolButtonLockScreenTips", Value = @"锁定屏幕" });
               tmpMainToolbarLocalStrings.Add(new LocalizedStringItem() { Name = "ToolButtonToolsOptions", Value = @"选项" });
               tmpMainToolbarLocalStrings.Add(new LocalizedStringItem() { Name = "ToolButtonToolsOptionsTips", Value = @"选项" });

               var tmpWindowLocalStrings = new List<LocalizedStringItem>();
               tmpLocalResources.LocalizedStrings.Windows = tmpWindowLocalStrings;
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "LockedWindowCaption", Value = @"已锁定" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "LoginWindowCaption", Value = @"用户登录" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "LoginWindowOptions", Value = @"登录选项" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "LoginWindowUserName", Value = @"用户名:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "LoginWindowPassword", Value = @"密  码:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "LoginWindowPromptUserNameIsEmpty", Value = @"用户名不能为空，请重新输入用户名。" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "LoginWindowPromptPasswordIsEmpty", Value = @"登录密码不能为空，请重新输入登录密码。" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "LoginWindowPromptUserNameNonExistent", Value = @"你输入的用户名不存在，请重新输入。" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "LoginWindowPromptPasswordIncorrect", Value = @"你输入的登录密码不正确，请重新输入。" });

               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "CatalogCreatorCaption", Value = @"新建目录" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "CatalogEditorCaption", Value = @"编辑目录" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "CatalogEditorName", Value = @"目录名称:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "CatalogEditorDescription", Value = @"备注信息:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "CatalogViewerCaption", Value = @"目录信息" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "CatalogSelectorCaption", Value = @"选择目录" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "CatalogSelectorPrompt", Value = @"请选择新目录" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "CatalogEditorPromptNameIsEmpty", Value = @"“目录名称”不能为空或空字符串，请重新输入！" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "CatalogEditorPromptNameTooLong", Value = @"“目录名称”太长，输入的名称不能超过 100 个字节的长度，请重新输入！" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "CatalogEditorPromptDescriptionTooLong", Value = @"“目录的描述信息”太长，输入的描述信息不能超过 500 个字节的长度，请重新输入！" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "CatalogEditorPromptCatalogNameRepeat", Value = @"在当前目录下已经有一个与“{0}”名称相同的目录，请重新输入一个不重复的目录名称！" });

               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DeleteGroupInfo", Value = @"删除群组将会删除其所有记录及子群组。" });

               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AccountCreatorCaption", Value = @"新建账号" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AccountEditorCaption", Value = @"编辑账号" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AccountViewerCaption", Value = @"账号信息" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AccountEditorLabelName", Value = @"账号名称:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AccountEditorLabelUserName", Value = @"登录账号:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AccountEditorLabelMobile", Value = @"手机号码:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AccountEditorLabelEmail", Value = @"电子邮箱:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AccountEditorLabelPassword", Value = @"账号密码:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AccountEditorLabelPwdRepeat", Value = @"确认密码:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AccountEditorLabelPasswordQuality", Value = @"密码质量:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AccountEditorLabelURL", Value = @"网站网址:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AccountEditorLabelSecret", Value = @"密    级:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AccountEditorTabPageAttributes", Value = @"扩展属性" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AccountEditorTabPageComment", Value = @"备注信息" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AccountEditorButtonAddAttribute", Value = @"添加属性" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AccountEditorButtonDeleteAttribute", Value = @"删除属性" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AccountEditorPromptNameIsEmpty", Value = @"“账号名称”不能为空或空字符串，请重新输入！" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AccountEditorPromptNameTooLong", Value = @"“账号名称”太长，输入的字符不能超过 30 个字节的长度，请重新输入！" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AccountEditorDialogTitleCreateFailed", Value = @"创建失败" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AccountEditorDialogMessageCreateFailed", Value = @"创建账号信息时发生错误,错误原因可能是:{0}{0}{1}" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AccountEditorDialogTitleUpdateFailed", Value = @"更新失败" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AccountEditorDialogMessageUpdateFailed", Value = @"更新账号信息时发生错误,错误原因可能是:{0}{0}{1}" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DeleteAttributeMessageBoxCaption", Value = @"删除提示" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DeleteAttributeMessageBoxConfirm", Value = @"确认要删除当前选中的属性吗?" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AddAttributeWindowTitle", Value = @"添加属性" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AddAttributeWindowLabelName", Value = @"名称:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AddAttributeWindowLabelValue", Value = @"值:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AddAttributeWindowCheckBoxEncrypt", Value = @"加密" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AddAttributeWindowFieldNameEmpty", Value = @"属性名称不能为空，请重新输入。" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AddAttributeWindowFieldValueEmpty", Value = @"属性值不能为空，请重新输入。" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AddAttributeMessageBoxTitleSuccess", Value = @"添加成功" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AddAttributeMessageBoxAddedSuccess", Value = @"自定义属性名称（{0}）添加成功。" });

               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "OptionWindowCaption", Value = @"选项" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "OptionWindowTabPageGeneral", Value = @"常规" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "OptionWindowTabPageSecurity", Value = @"安全" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "OptionWindowSecretPublicColor", Value = @"公开颜色:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "OptionWindowSecretSecretColor", Value = @"秘密颜色:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "OptionWindowSecretConfidentialColor", Value = @"机密颜色:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "OptionWindowSecretTopSecretColor", Value = @"绝密颜色:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "OptionWindowLabelWorkDirectory", Value = @"工作目录:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "OptionWindowButtonChangeDirectory", Value = @"更改目录" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "OptionWindowCheckBoxLockAfterTime", Value = @"主窗口处于非活动状态锁定的时间 (秒):" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "OptionWindowCheckBoxLockGlobalTime", Value = @"操作系统处于非活动状态锁定时间 (秒):" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "OptionWindowCheckBoxAutoRunAtStartup", Value = @"开机时自动运行 SafePass (当前用户)" });

               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "PasswordGeneratorWindowCaption", Value = @"密码生成器" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "PasswordGeneratorPasswordOptions", Value = @"选项" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "PasswordGeneratorAdvancedOptions", Value = @"高级" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "PasswordGeneratorGroupPassword", Value = @"生成" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "PasswordGeneratorRadioUsingNumeral", Value = @"全部为数字" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "PasswordGeneratorRadioUsingCharacter", Value = @"使用字符集生成" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "PasswordGeneratorCheckBoxUpperCase", Value = @"大写字母(&U)" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "PasswordGeneratorCheckBoxLowerCase", Value = @"小写字母(&W)" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "PasswordGeneratorCheckBoxSpecialChars", Value = @"特殊字符(&E)" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "PasswordGeneratorCheckBoxBracketChars", Value = @"括号(&B)" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "PasswordGeneratorCheckBoxDigitChars", Value = @"数字(&D)" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "PasswordGeneratorCheckBoxMinusChar", Value = @"减号(&M)" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "PasswordGeneratorCheckBoxUnderline", Value = @"下划线(&N)" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "PasswordGeneratorCheckBoxSpaceChar", Value = @"空格(&S)" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "PasswordGeneratorLabelPasswordLength", Value = @"密码长度(&L):" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "PasswordGeneratorCheckBoxNoRepeatingChars", Value = @"每字符最多出现一次(&E)" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "PasswordGeneratorCheckBoxExcludeLookAlike", Value = @"排除相近字符" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "PasswordGeneratorCheckBoxExcludeChars", Value = @"排除这些字符(&C):" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "PasswordGeneratorButtonGenerate", Value = @"生成(&G)" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "PasswordGeneratorMessageCharSetTooFewChars", Value = @"生成密码时字符组所包含的字符太少。" });

               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ImportDialogTitle", Value = @"导入" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ExportDialogTitle", Value = @"导出" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ImportWindowCaption", Value = @"导入数据" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ImportWindowGroupBoxFileInfo", Value = @"导入文件" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ImportWindowLabelImportFile", Value = @"从文件导入:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ImportWindowGroupBoxOptions", Value = @"导入选项" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ExportWindowCaption", Value = @"导出数据" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ExportWindowGroupBoxFormat", Value = @"导出格式" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ExportWindowGroupBoxFileInfo", Value = @"导出文件" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ExportWindowLabelExportFile", Value = @"导出至:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ExportOverwriteDialogCaption", Value = @"确认另存为" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ExportOverwriteDialogPrompt", Value = @"“{0}”已存在。{1}要替换它吗？" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ExportInvalidPathDialogCaption", Value = @"无效路径" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ExportInvalidPathDialogPrompt", Value = @"“{0}”路径无效。{1}请检查文件路径是否正确，然后重试。" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ExportXML1xFilter", Value = @"SafePass XML(*.xml)|*.xml" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ExportExcelFilter", Value = @"Excel 工作簿(*.xlsx)|*.xlsx" });

               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "MoveSelectedEntryToRecycleBinTitle", Value = @"删除记录" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "MoveSelectedEntriesToRecycleBinTitle", Value = @"删除记录" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "MoveSelectedEntryToRecycleBinQuestion", Value = "确定要将所选记录移到回收站吗？" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "MoveSelectedEntriesToRecycleBinQuestion", Value = "确定要将所选记录移到回收站吗？" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DeletePermanentlySelectedEntryTitle", Value = @"删除记录" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DeletePermanentlySelectedEntriesTitle", Value = @"删除记录" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DeletePermanentlySelectedEntryQuestion", Value = "你确定要永久的删除选中记录吗？" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DeletePermanentlySelectedEntriesQuestion", Value = "你确定要永久的删除所有选中记录吗？" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DeleteSelectedEntriesMorePrompt", Value = @"{0}{1}条更多记录" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DeletePermanentlySelectedCatalogTitle", Value = @"删除目录" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DeletePermanentlySelectedCatalogQuestion", Value = @"确定要删除当前选中的目录“{0}”吗？\n\n选择“确定”即可永久删除，您将无法撤销所做的更改。" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DeleteSelectedCatalogErrorForNotEmpty", Value = @"删除目录时发生错误，错误原因是：\n\n目录“{0}”下还有子目录或记录，删除目录时该目录下不能有子目录和记录。" });

               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DataGridAttributeColumnAccountId", Value = @"账号Id" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DataGridAttributeColumnId", Value = @"属性Id" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DataGridAttributeColumnOrder", Value = @"序号" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DataGridAttributeColumnEncrypt", Value = @"加密" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DataGridAttributeColumnName", Value = @"属性名称" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DataGridAttributeColumnValue", Value = @"属性值" });

               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DataGridAccountColumnOrderNo", Value = @"序号" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DataGridAccountColumnAccountGuid", Value = @"账号Guid" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DataGridAccountColumnTopMost", Value = @"置顶" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DataGridAccountColumnName", Value = @"名称" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DataGridAccountColumnSecret", Value = @"密级" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DataGridAccountColumnLoginName", Value = @"账号" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DataGridAccountColumnPassword", Value = @"密码" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DataGridAccountColumnMobile", Value = @"手机号码" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DataGridAccountColumnEmail", Value = @"电子邮箱" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DataGridAccountColumnCreateTime", Value = @"创建时间" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DataGridAccountColumnUpdateTime", Value = @"更新时间" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "DataGridAccountColumnURL", Value = @"网址" });

               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "EmptyRecycleBinQuestion", Value = @"你确定要永久删除这些条目吗？" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "EncodingFail", Value = @"所选编码是不允许的。使用所选编码无法解析该文件。" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ExitInsteadOfLockingAlways", Value = @"总是退出，而不是锁定主窗口" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ExitInsteadOfLockingAfterTime", Value = @"在指定时间后退出程序，而不是自动锁定" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ExpiredEntries", Value = @"过期记录" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ExpiredEntriesCanMatch", Value = @"可匹配过期记录" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ExpiryTime", Value = @"过期时间" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ExpiryTimeDateOnly", Value = @"过期时间（仅日期）" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ExportFileDesc", Value = @"导出数据至外部文件。" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ExportFileTitle", Value = @"导出文件/数据" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ExportingStatusMsg", Value = @"正在导出..." });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "Feature", Value = @"属性" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "Field", Value = @"字段" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "FieldName", Value = @"字段名" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "FieldNameExistsAlready", Value = @"输入的名称已经存在，请重新输入。" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "FieldNameInvalid", Value = @"输入的名称无效，请重新输入。" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "FieldNamePrompt", Value = @"请输入字段名。" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "FieldRefInvalidChars", Value = @"用于识别源记录的字段包含非法字符（如大括号{}、换行符等...）。" });

               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AboutWindowCaption", Value = @"关于 SafePass" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "AboutWindowLabelGpl", Value = @"SafePass 的发布遵循 GNU 通用公共授权许可 V2 或新版的条款。" });
               
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "NewWizardWindowCaption", Value = @"新建向导" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "NewWizardWindowLabelLoginName", Value = @"用 户 名:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "NewWizardWindowLabelPassword", Value = @"登录密码:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "NewWizardWindowLabelPwdRepeat", Value = @"确认密码:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "NewWizardWindowLabelPwdQuality", Value = @"密码质量:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "NewWizardWindowLabelSafePassName", Value = @"保险箱名称:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "NewWizardWindowLabelWorkDirectory", Value = @"工作目录:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "NewWizardWindowButtonSelectDirectory", Value = @"选择目录" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "NewWizardWindowPromptLoginNameIsEmpty", Value = @"用户名不能为空，请重新输入用户名。" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "NewWizardWindowPromptLoginNameTooLong", Value = @"用户名太长，输入的字符不能超过30个字符，请重新输入。" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "NewWizardWindowPromptPasswordIsEmpty", Value = @"密码不能为空，请重新输入！" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "NewWizardWindowPromptRememberPassword", Value = @"请牢记您的密码，一旦丢失，将无法找回!" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "NewWizardWindowPromptSafePassNameIsEmpty", Value = @"账号保险箱名称不能为空。请重新输入！" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "NewWizardWindowPromptSafePassNameTooLong", Value = @"账号保险箱名称太长，输入的字符不能超过30个字节，请重新输入！" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "NewWizardWindowDialogTitleCreateSuccess", Value = @"创建成功" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "NewWizardWindowDialogMessageCreateSuccess", Value = @"账号保险箱创建成功，请重新登录！" });

               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ChangePasswordWindowCaption", Value = @"更改密码" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ChangePasswordWindowLabelOldPassword", Value = @"原 密 码:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ChangePasswordWindowLabelNewPassword", Value = @"新 密 码:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ChangePasswordWindowLabelRepeatPassword", Value = @"确认密码:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ChangePasswordWindowLabelPasswordQuality", Value = @"密码质量:" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ChangePasswordWindowMessageChangeFailed", Value = @"密码修改失败" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ChangePasswordWindowMessageChangeSuccess", Value = @"密码修改成功" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ChangePasswordWindowPromptPasswordIncorrect", Value = @"您输入的登录密码不正确。请重新输入！" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ChangePasswordWindowPromptPasswordIsEmpty", Value = @"密码不能为空。请重新输入密码。" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ChangePasswordWindowPromptSameAsOldPassword", Value = @"输入的新密码不能与原密码相同。" });

               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ChangeLanguageWindowCaption", Value = @"选择语言" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ChangeLanguageWindowColumnLanguageName", Value = @"语言" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ChangeLanguageWindowColumnLanguageVersion", Value = @"版本" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ChangeLanguageWindowColumnLanguageFile", Value = @"文件" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ChangeLanguageWindowLanguageBuiltIn", Value = @"内置" });
               tmpWindowLocalStrings.Add(new LocalizedStringItem() { Name = "ChangeLanguageWindowMessage", Value = @"是否切换为选中的语言，需要重启 SafePass 以重新加载。\n\n现在要重新启动 SafePass 吗？" });

               return LocalizationResourceWriter.SaveLocalResource(localLanguageFile, tmpLocalResources);
          }
     }
}