using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameOfClass, params string[] fields)
        {
            StringBuilder answer = new StringBuilder();

            Type type = Type.GetType($"{nameOfClass}");
            FieldInfo[] fieldsInClass = type
            .GetFields(BindingFlags.Instance
            | BindingFlags.Static
            | BindingFlags.NonPublic
            | BindingFlags.Public);
            Object classInstance = Activator.CreateInstance(type, new object[] { });
            answer.AppendLine($"Class under investigation: {nameOfClass}");

            foreach (var field in fieldsInClass.Where(x => fields.Contains(x.Name)))
            {
                answer.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return answer.ToString().Trim();
        }

        public string AnalyzeAcessModifiers(string className)
        {
            var result = new StringBuilder();
            Type type = Type.GetType(className);

            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            MethodInfo[] publicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] nonPublicMethods = type.GetMethods(BindingFlags.Instance| BindingFlags.NonPublic);

            foreach (var field in fields)
            {
                result.AppendLine($"{field.Name} must be private!");
            }

            foreach (var nonPublicMethod in nonPublicMethods.Where(p => p.Name.StartsWith("get")))
            {
                result.AppendLine($"{nonPublicMethod.Name} have to be public!");
            }

            foreach (var publicMethod in publicMethods.Where(n => n.Name.StartsWith("set")))
            {
                result.AppendLine($"{publicMethod.Name} have to be private!");
            }

            return result.ToString().TrimEnd();
        }
    }
}