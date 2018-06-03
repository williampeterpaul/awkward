using System.Text;

namespace awkward.api.Extensions
{
    public static class ClassExtension
    {
        public static string PropertyList(this object obj)
        {
            var properties = obj.GetType().GetProperties();

            var builder = new StringBuilder();

            foreach (var property in properties)
            {
                builder.AppendLine(property.Name + ": " + property.GetValue(obj, null));
            }
            return builder.ToString();
        }
    }
}
