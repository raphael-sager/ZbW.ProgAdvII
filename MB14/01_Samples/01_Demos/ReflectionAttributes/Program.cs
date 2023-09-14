using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ReflectionAttributes.Attributes;
using ReflectionAttributes.Attributes.ReflectionDemos;

namespace ReflectionAttributes {
    public class Program {
        public static void Main(string[] args) {


            var assembl = Assembly.LoadFile("C:\\Users\\rapha\\OneDrive - ZBW Zentrum für Berufliche Weiterbildung\\_ZbW\\PGA_II\\_CodeRepo\\MB14\\01_Samples\\01_Demos\\ReflectionTest\\obj\\Debug\\ReflectionTest.dll");

            var typesTest = assembl.GetTypes();
            var type = assembl.GetType("ReflectionTest.Person");

            var p1 = Activator.CreateInstance(type, "Raphael");

            var fieldInfo = type.GetField("name", BindingFlags.NonPublic | BindingFlags.Instance);

            var name = fieldInfo.GetValue(p1);



            var p2 = Activator.CreateInstance(type, "Noe");

            dynamic dynamicTest = p2;

            dynamicTest.SayHello(); // late binding


            var sayHelloMethod = type.GetMethod("SayHello");

            sayHelloMethod.Invoke(p1, null);
            sayHelloMethod.Invoke(p2, null);


            //Type sampleType = typeof(SampleClass);

            //var assembly = Assembly.LoadFile(@"C:\Users\tkehl\source\repos\ClassLibrary1\ClassLibrary1\bin\Debug\ClassLibrary1.dll");
            //var types = assembly.ExportedTypes.ToList();

            ////Type sampleType = Type.GetType("ReflectionAttributes.SampleClass");
            //Type sampleType = types[0];

            ////var o1 = new SampleClass();
            //var o1 = Activator.CreateInstance(sampleType);

            //var mi = sampleType.GetMethod("CacheItem", BindingFlags.Instance | BindingFlags.NonPublic);
            //mi.Invoke(o1, new object[] { "abc", "xyz" });




            //var pi = sampleType.GetProperty("CachedItems", BindingFlags.Instance | BindingFlags.NonPublic);

            


            new ReflectionAttributes.Reflection.Types.Patient().TestType();

            ReflectionAttributes.Reflection.AssemblyDemo.Examples.TestAssembly();

            Reflection.Metadata.Examples.TestAssemblyMembers();
            Reflection.Metadata.Examples.TestTypeMembersAll();
            Reflection.Metadata.Examples.TestTypeMembersDynamicSearch();
            Reflection.Metadata.Examples.TestFieldInfo();
            Reflection.Metadata.Examples.TestPropertyInfo();
            Reflection.Metadata.Examples.TestMethodInfo();
            Reflection.Metadata.Examples.TestMethodInfoAdvanced();
            Reflection.Metadata.Examples.TestConstructorInfo();

            CustomAttribute_Author.TestClassAttributes();
            CustomAttribute_Author.TestPropertyAttributes();

            CustomAttribute_Csv.Test();

            ReflectionAttributes.Emit.EmitDemo.Test();
            Emit.EmitDemo.TestZbwEmitDemoAssembly();

            AttributeConditional.Test(new []{"a"});

            AttributeObsolete.Test();
        }
    }


}
