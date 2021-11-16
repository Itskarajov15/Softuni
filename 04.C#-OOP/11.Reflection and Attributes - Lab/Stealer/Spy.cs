using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameOfClassToInvestigate, params string[] fieldsToInvestigate)
        {
            var sb = new StringBuilder();

            Type type = Type.GetType(nameOfClassToInvestigate);

            sb.AppendLine($"Class under investigation: {type.FullName}");

            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic 
                | BindingFlags.Public
                | BindingFlags.Instance
                | BindingFlags.Static);

            var classInstance = Activator.CreateInstance(type, new object[] { });

            foreach (var field in fields.Where(f => fieldsToInvestigate.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
