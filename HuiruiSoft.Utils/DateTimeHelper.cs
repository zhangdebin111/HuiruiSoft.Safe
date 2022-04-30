
namespace HuiruiSoft.Utils
{
	using System.Globalization;

	public sealed class DateTimeHelper
	{
		public const string GeneralDateTimePattern = "yyyy-MM-dd";
		public const string SimpleTimeStampPattern = "HH:mm:ss";
		public const string DefaultDateTimePattern = "yyyy-MM-dd HH:mm:ss";
		public const string MillisecondTimePattern = "yyyy-MM-dd HH:mm:ss.fff";

		public const string SimpleDateFormatPattern = "yyyyMMdd";
		public const string SimpleTimeFormatPattern = "yyyyMMddHHmmss";
		public const string MillisecondFormatPattern = "yyyyMMddHHmmssfff";

		private static CultureInfo CurrentCulture = CultureInfo.CurrentCulture;
		private static DateTimeStyles CurrentTimeStyle = DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces;

		private readonly static string[] DateTimeFormats =
		{
			GeneralDateTimePattern,
			DefaultDateTimePattern,
			"yyyy-M-d HH:mm:ss",
			"yyyy-M-d HH:mm",
			"yyyy-M-d",
			"yyyy-MM-dd HH:mm",
			"yy-MM-dd HH:mm",
			"yy-MM-dd HH:mm:ss",
			MillisecondTimePattern,
			SimpleTimeFormatPattern
		};

		public static System.DateTime TryParseExact(string @string, System.DateTime @default)
		{
			try
			{
				System.DateTime tmpParseResult;
				return System.DateTime.TryParseExact(@string, DateTimeFormats, CurrentCulture, CurrentTimeStyle, out tmpParseResult) ? tmpParseResult : @default;
			}
			catch (System.ArgumentException)
			{
				return @default;
			}
		}
	}
}