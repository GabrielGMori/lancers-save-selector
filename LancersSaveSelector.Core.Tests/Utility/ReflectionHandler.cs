using LancersSaveSelector.Core.FileManager;
using System.Reflection;

namespace LancersSaveSelector.Core.Tests.Utility
{
	internal class ReflectionHandler
	{
		public static PropertyInfo GetProperty(object obj, string propertyName)
		{
			PropertyInfo? property = obj.GetType().GetProperty(propertyName) ?? throw new InvalidOperationException();
			return property;
		}

		public static object? GetPropertyValue(object obj, string propertyName)
		{
			PropertyInfo property = GetProperty(obj, propertyName);
			return property.GetValue(obj);
		}

		public static void SetPropertyValue(object obj, string propertyName, object? value)
		{
			PropertyInfo property = GetProperty(obj, propertyName);
			property.SetValue(obj, value);
		}
	}
}
