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

        public string RevealPrivateMethods(string className)
        {
            var sb = new StringBuilder();

            Type type = Type.GetType(className);

            MethodInfo[] privateMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");

            foreach (var method in privateMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string className)
        {
            var sb = new StringBuilder();

            Type type = Type.GetType(className);

            MethodInfo[] methods = type.GetMethods(BindingFlags.Public
                | BindingFlags.NonPublic
                | BindingFlags.Instance
                | BindingFlags.Static);

            foreach (var method in methods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType.FullName}");
            }

            foreach (var method in methods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}