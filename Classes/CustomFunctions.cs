using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;

namespace Template.Classes
{
    public interface ICustomFunctions
    {
        string GetRandomString(int length);
        SelectList CreateSelectList<T>(IEnumerable<T> items, string idPropertyName, string namePropertyName) where T : class;
    }

    public class CustomFunctions : ICustomFunctions
    {
        public string GetRandomString(int length)
        {
            var random = new System.Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public SelectList CreateSelectList<T>(IEnumerable<T> items, string idPropertyName, string namePropertyName) where T : class
        {
            PropertyInfo idProperty = typeof(T).GetProperty(idPropertyName);
            PropertyInfo nameProperty = typeof(T).GetProperty(namePropertyName);

            if (idProperty == null || nameProperty == null)
            {
                throw new Exception($"Model must have properties named '{idPropertyName}' and '{namePropertyName}'");
            }

            var selectItems = items.Select(item => new SelectListItem
            {
                Value = idProperty.GetValue(item).ToString(),
                Text = nameProperty.GetValue(item).ToString()
            });

            return new SelectList(selectItems, "Value", "Text");
        }
    }
}