using System;

namespace OAuthSig.Extensions
{
	public static class CustomExtensions
	{
		public static string FormatWith(this string pSource, params object[] args) {
			return String.Format(pSource, args);
		}

		public static bool Contains(this string pSource, string pCompareTo, StringComparison stringComparison) {
			return pSource.IndexOf(pCompareTo, stringComparison) > 0;
		}
	}
}