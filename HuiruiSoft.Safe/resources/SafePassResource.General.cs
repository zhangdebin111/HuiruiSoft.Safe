namespace HuiruiSoft.Safe.Resources
{
     public static partial class SafePassResource
     {
          public static string KeyboardKeyAlt { get; private set; } = "Alt";

          public static string KeyboardKeyCtrl { get; private set; } = "Ctrl";

          public static string KeyboardKeyCtrlLeft { get; private set; } = "LCtrl";

          public static string KeyboardKeyShift { get; private set; } = "Shift";

          public static string KeyboardKeyShiftLeft { get; private set; } = "LShift";

          public static string KeyboardKeyEsc { get; private set; } = "Esc";

          public static string KeyboardKeyInvalid { get; private set; } = "Invalid Key";

          public static string KeyboardKeyModifiers { get; private set; } = "Key Modifiers";

          public static string KeyboardKeyReturn { get; private set; } = "Return";

          public static string Event { get; private set; } = @"Event";

          public static string Info { get; private set; } = @"Info";

          public static string Error { get; private set; } = @"Error";

          public static string Errors { get; private set; } = @"Errors";

          public static string ErrorCode { get; private set; } = @"Error Code";

          public static string Success { get; private set; } = @"Success";

          public static string Version { get; } = @"Version";

          public static string ButtonOK { get; private set; } = @"&OK";

          public static string ButtonCancel { get; private set; } = @"&Cancel";

          public static string ButtonClose { get; private set; } = @"&Close";

          public static string ButtonExitApp { get; private set; } = @"E&xit";

          public static string RecycleBin { get; private set; } = @"Recycle Bin";

          public static string MessageBoxCaptionInputError { get; private set; } = @"Input error";

          public static string PasswordRepeatFailed { get; private set; } = @"Password and repeated password aren't identical!";

          public static string SecretRankpublic { get; private set; } = @"public";

          public static string SecretRankSecret { get; private set; } = @"secret";

          public static string SecretRankConfidential { get; private set; } = @"confidential";

          public static string SecretRankTopsecret { get; private set; } = @"Top secret";

          public static string Ready { get; private set; } = "Readied";

          public static string AlgorithmUnknown { get; private set; } = "The algorithm is unknown.";

          public static string ClipboardDataCopied { get; private set; } = @"Data copied to clipboard."; // 数据已复制到剪贴板

          public static string ClipboardClearInSeconds { get; private set; } = @"Clipboard will be cleared in {0} seconds";  // 剪贴板的数据将在 {0} 秒后清除
     }
}