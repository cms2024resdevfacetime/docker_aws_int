using Microsoft.Cci.MutableCodeModel;
using Microsoft.Cci;
using System;
using System.Collections.Generic;
using System.IO;

namespace DesignPatter_MainSubSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {       
        }
        public static string DesignPatter_MainSubSystem_entry_Phase1()
        {

            //Executed as part of the original library and not the generated 
            Console.WriteLine("Greetings From My Method");

            {
                var nameTable = new NameTable();

                //Start
                using (var host = new PeReader.DefaultHost(nameTable))
                {
                    var coreAssembly = host.LoadAssembly(host.CoreAssemblySymbolicIdentity);

                    var assembly = new Assembly()
                    {
                        Name = nameTable.GetNameFor("hello"),
                        ModuleName = nameTable.GetNameFor("ProceduralLogic_1.dll"),
                        PlatformType = host.PlatformType,
                        Kind = ModuleKind.ConsoleApplication,
                        RequiresStartupStub = host.PointerSize == 4,
                        TargetRuntimeVersion = coreAssembly.TargetRuntimeVersion,
                    };
                    assembly.AssemblyReferences.Add(coreAssembly);

                    var rootUnitNamespace = new RootUnitNamespace();
                    assembly.UnitNamespaceRoot = rootUnitNamespace;
                    rootUnitNamespace.Unit = assembly;


                    //Namespace definition
                    var moduleClass = new NamespaceTypeDefinition()
                    {
                        ContainingUnitNamespace = rootUnitNamespace,
                        InternFactory = host.InternFactory,
                        IsClass = true,
                        Name = nameTable.GetNameFor("<Module>"),
                    };
                    assembly.AllTypes.Add(moduleClass);





                    // 1- Class Instance
                    var testClass = new NamespaceTypeDefinition()
                    {

                        //What the namespace will be
                        ContainingUnitNamespace = rootUnitNamespace,
                        InternFactory = host.InternFactory,

                        //Access Modifiers
                        IsClass = true,
                        IsPublic = true,

                        //Method instance in a list defined below
                        Methods = new List<IMethodDefinition>(1),



                        Name = nameTable.GetNameFor("Test"),
                    };

                    //2-Add the class to the root namespace
                    rootUnitNamespace.Members.Add(testClass);



                    //3- Add Class
                    assembly.AllTypes.Add(testClass);
                    testClass.BaseClasses = new List<ITypeReference>() { host.PlatformType.SystemObject };





                    //2- Method instance
                    var mainMethod = new MethodDefinition()
                    {
                        ContainingTypeDefinition = testClass,
                        InternFactory = host.InternFactory,
                        IsCil = true,
                        IsStatic = true,
                        Name = nameTable.GetNameFor("Main"),
                        Type = host.PlatformType.SystemVoid,
                        Visibility = TypeMemberVisibility.Public,

                    };



                    //Application of method
                    assembly.EntryPoint = mainMethod;

                    //Adding method to the class
                    testClass.Methods.Add(mainMethod);


                    //Generate the method
                    var ilGenerator = new ILGenerator(host, mainMethod);


                    //3- Implementations for the primary library and executed within the primary method not the generated 
                    var systemConsole = UnitHelper.FindType(nameTable, coreAssembly, "System.Console");
                    var writeLine = TypeHelper.GetMethod(systemConsole, nameTable.GetNameFor("WriteLine"), host.PlatformType.SystemString);
                    ilGenerator.Emit(OperationCode.Ldstr, "hello");
                    ilGenerator.Emit(OperationCode.Call, writeLine);
                    ilGenerator.Emit(OperationCode.Ret);


                    //4- Load the entire body 
                    var body = new ILGeneratorMethodBody(ilGenerator, true, 1, mainMethod, Enumerable<ILocalDefinition>.Empty, Enumerable<ITypeDefinition>.Empty);
                    mainMethod.Body = body;


                    //5- In the case of the generated library  we will create a loop that writes this data to stream then to file 
                    using (var peStream = File.Create("ProceduralLogic_1.dll"))
                    {
                        PeWriter.WritePeToStream(assembly, host, peStream);
                    }
                }
                //End


                //Executed as part of the original library and not the generated 
                Console.WriteLine("Hello, World!");

                string mystring = "Complete";
                return mystring;


            }
        }
    }

}

