using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BelzonaMobile.Core.Models
{
	public interface IEntityModel
	{
	}

	public static class EntityHelpers
	{
		public static string ToJson(this IEntityModel entity, JsonSerializerSettings settings = null, [CallerMemberName] string callername = "", [CallerFilePath] string filename = "")
		{
#if DEBUG
			var str = JsonConvert.SerializeObject(entity, Formatting.Indented, settings);

			if (!string.IsNullOrEmpty(callername))
			{
				Debug.WriteLine("{1} in {3}:{0}{2}", Environment.NewLine, callername, str, filename);
			}
			else
				Debug.WriteLine(str);

#else
      var str = JsonConvert.SerializeObject (entity, settings);
#endif

			return str;
		}

		public static string ToJson<T>(this IEnumerable<T> entity, JsonSerializerSettings settings = null, [CallerMemberName] string callername = "", [CallerFilePath] string filename = "") where T : IEntityModel
		{
#if DEBUG
			var str = JsonConvert.SerializeObject(entity, Formatting.Indented, settings);

			if (!string.IsNullOrEmpty(callername))
			{
				Debug.WriteLine("{1} in {3}:{0}{2}", Environment.NewLine, callername, str, filename);
			}
			else
				Debug.WriteLine(str);

#else
      var str = JsonConvert.SerializeObject (entity, settings);
#endif

			return str;
		}

		[Conditional("DEBUG")]
		public static void DebugThis(this string str, [CallerMemberName] string callername = "", [CallerFilePath] string filename = "")
		{
			if (!string.IsNullOrEmpty(callername))
			{
				Debug.WriteLine("{1} in {3}:{0}{2}", Environment.NewLine, callername, str, filename);
			}
			else
				Debug.WriteLine(str);
		}
	}
}
