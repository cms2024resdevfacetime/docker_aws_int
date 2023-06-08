using Microsoft.AspNetCore.Mvc;
//using DesignPatter_MainSubSystem;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using Accord.Math;
using Accord.MachineLearning;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Net.WebSockets;
using docker_aws_int.ControllerApi;
using docker_aws_int.Models;   
using docker_aws_int.ControllerApi;

namespace docker_aws_int.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NodalController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


        [HttpPost("/ExampleObject_Request")]
        public IActionResult CreateExampleObject_Request(CreateExampleObject_Request request)
        {
            var exampleObjectConcreteClient = new ExampleObject_Concrete_Client(
                request.stringvalue,
                request.numericalvalue,
                request.statistic,
                request.DataSet1,
                request.DataSet2,
                request.DataSet3
                 );
                 var response = new CreateExampleObject_Response(
                    request.stringvalue,
                    request.numericalvalue,
                    request.statistic,
                    request.DataSet1,
                    request.DataSet2,
                    request.DataSet3

                 );
            return Ok(vlaue:response);
        }

        // Pramiry Application Entry 
        public class ExampleObject_Program
        {
            public static void ExampleObject_Main()
            {
                //1- Here we are creating an instance object or reference yours
                ExampleObject_Concrete _compoenent_ = new ExampleObject_Concrete();

                //2- This section is preliminary and PRE-processes the object
                PreApplication_ pae = new PreApplication_(_compoenent_);


                //3- In this section we include a porcess that passes the object 
                Application_ ae = new Application_(_compoenent_);
            }
        }

        //Example Object Class

        public class ExampleObject_
        {
            //Here is the instanciatio of the nested object as
            //part of the object constructor
            public ExampleObject_()
            {
                //And an instaciation of the nested within the consructor
                this.ExampleNestedObjectInstance = new ExampleNestedObject() { PolicyId = -1 };
            }
            //REQUIRED: Example ExampleObject_ Base operation
            //No need to define here
            public virtual void Operation()
            {

            }
            //An empty object with fields and nested values
            public string stringvalue = "SomeCustomDLL";
            //An empty object with fields and nested values
            public int numericalvalue = 1;
            //A regular field that can be null
            public int statistic { get; set; }

            //Instanciating a empty local instance of the object nested
            ExampleNestedObject ExampleNestedObjectInstance { get; set; }
            //Here is the structure of the nested object
            public class ExampleNestedObject
            {
                //And a couple of fields withing the nested object
                public int PolicyId { get; set; }
                public string? PolicyName { get; set; }
            }
            //Here is the instanciatio of the nested object as
            //part of the object constructor

        }
        /// Here is an example object with nested values
        //Ensure you add exteding Component to your object
        //REQUIRED: The object must be public abstract class
        public class ExampleObject_Concrete : ExampleObject_
        {
            public ExampleObject_Concrete()
            {
            }

            //The Concrete Objects Constrctor
            public ExampleObject_Concrete(string stringvalue, int numericalvalue, int statistic)
            {
            }
            public override void Operation()
            {
                this.statistic = 4;
                Console.WriteLine("Incoming ExampleObject_Concrete statistic Example Object Concrete Operation after:" + this.statistic);


            }
            public static implicit operator EndOfStreamException(ExampleObject_Concrete v)
            {
                throw new NotImplementedException();
            }
        }
        /// ExampleObject_ 'Decorator' abstract class
        public abstract class ExampleObject_Decorator : ExampleObject_
        {
            protected ExampleObject_? _compoenent_;
            public void SetComponent(ExampleObject_ _compoenent_)
            {
                this._compoenent_ = _compoenent_;
            }
            public override void Operation()
            {
                if (_compoenent_ != null)
                {
                    _compoenent_.Operation();
                }
            }
        }
        /// ExampleObject Decorator Concrete Decorator A
        public class ExampleObject_Decorator_ConcreteDecoratorA : ExampleObject_Decorator
        {
            public override void Operation()
            {
                base.Operation();

                //Augment
                this._compoenent_.statistic = 5;
                Console.WriteLine("Incoming ExampleObject_Decorator_ConcreteDecoratorA statistic ConcreteDecorator A Operation after:" + this._compoenent_.statistic);

                SubProcessing_Type1 _subprocessing_type1_instance = new SubProcessing_Type1(_compoenent_, _compoenent_.stringvalue, this._compoenent_.statistic);


            }
        }
        /// ExampleObject Decorator Concrete Decorator B
        public class ExampleObject_Decorator_ConcreteDecoratorB : ExampleObject_Decorator
        {
            public override void Operation()
            {
                base.Operation();

                //Augement
                this._compoenent_.statistic = 8;
                Console.WriteLine("Incoming ExampleObject_Decorator_ConcreteDecoratorB statistic ConcreteDecorator B Operation 1 after:" + this._compoenent_.statistic);

                AddedBehavior();


                this._compoenent_.statistic = 10;
                Console.WriteLine("Incoming ExampleObject_Decorator_ConcreteDecoratorB statistic ConcreteDecorator B Operation 2 after:" + this._compoenent_.statistic);

            }
            void AddedBehavior()
            {
                this._compoenent_.statistic = 9;
                Console.WriteLine("Incoming ExampleObject_Decorator_ConcreteDecoratorB statistic Concrete Decorator B AddedBehavior after:" + this._compoenent_.statistic);

            }
        }
        //public class ConcreteExampleObject : ExampleObject{}
        /// Inital object augmentation including conditional factors 
        public class PreApplication_
        {

            //Here we are creating an empty local insstance of the object 
            //we are processing
            public ExampleObject_ _compoenent_ { get; set; }
            // And the PreApplication_ Constrctor
            //We accept the object that is being proccessed as param
            //In the constructor we will pass the promary object 
            public PreApplication_(ExampleObject_ _compoenent_)
            {
                // First Process
                SetComponent(_compoenent_);
                // Second Process
                Phase1(_compoenent_);
                // Third Process
                Phase2(_compoenent_);

            }
            //PreApplication_ constructor Method 1
            public object SetComponent(ExampleObject_ _compoenent_)
            {
                //Lets create a local instance
                this._compoenent_ = _compoenent_;

                //AUGMENTATION HERE!!
                //Change the field value
                _compoenent_.statistic = 1;
                //Write new field value
                Console.WriteLine("Incoming PreApplication_ SetCompoenent statistic after:" + _compoenent_.statistic);
                //And return object
                return _compoenent_;
            }
            //PreApplication_ Constrctor Method 2
            private object Phase1(ExampleObject_ _compoenent_)
            {
                //In this example we will get the nested value name

                // We will take the objects and define locally
                Type objType = typeof(ExampleObject_);

                // We will do a catch try to evaluate
                try
                {
                    // Getting the types nested by
                    // using GetNestedTypes() Method
                    Type[] type = objType.GetNestedTypes();

                    // Display the Result
                    for (int i = 0; i < type.Length; i++)
                        Console.WriteLine("Incoming PreApplication_ SetCompoenent NestedType: " + "{0} ", type[i]);

                }

                // catch ArgumentNullException here
                catch (ArgumentNullException e)
                {
                    Console.Write("name is null.");
                    Console.Write("Exception Thrown: ");
                    Console.Write("{0}", e.GetType(), e.Message);
                }


                //AUGMENTATION HERE!!
                //Write new field value
                _compoenent_.statistic = 2;
                Console.WriteLine("Incoming PreApplication_ Phase1 statistic after:" + _compoenent_.statistic);
                //And return object
                return _compoenent_;
            }
            //PreApplication_ Constrctor Method 3
            private object Phase2(ExampleObject_ _compoenent_)
            {


                //AUGMENTATION HERE!!++
                _compoenent_.statistic = 3;
                Console.WriteLine("Incoming PreApplication_ Phase2 statistic after:" + _compoenent_.statistic);
                //And return object

                return _compoenent_;
            }

        }
        /// Pass the primary object to generated sub-routines
        public class Application_
        {


            //Application Entry Constructor
            public Application_(ExampleObject_ _compoenent_)
            {

                //TESTING 
                Console.WriteLine("Incoming Application____ Starting...");
                //In the application constructor we will accept the current 
                //object and implement Method 1
                Phase1(_compoenent_);

                Phase2(_compoenent_);

            }


            //Parse Initial operations
            internal static object Phase1(ExampleObject_ _compoenent_)
            {
                //TESTING 
                Console.WriteLine("Incoming Application____ Phase1 Starting...");



                // Create ConcreteComponent and two Decorators
                ExampleObject_Concrete _concrete_compoenent_ = new ExampleObject_Concrete();

                ExampleObject_Decorator_ConcreteDecoratorA _concrete_compoenent_concretedecoratorA_ = new ExampleObject_Decorator_ConcreteDecoratorA();
                ExampleObject_Decorator_ConcreteDecoratorB _concrete_compoenent_concretedecoratorB_ = new ExampleObject_Decorator_ConcreteDecoratorB();

                // Link decorators
                //EXAMPLE:Lets have decorator A take _concrete_component_ 


                //Lets have decorator A take _concrete_component_ 
                _concrete_compoenent_concretedecoratorA_.SetComponent(_compoenent_);


                // Link decorators
                //Then we will have decorator take A that also has _concrete_component
                _concrete_compoenent_concretedecoratorB_.SetComponent(_concrete_compoenent_concretedecoratorA_);


                //When you put _concrete_component in A then put A in B
                //B has custom functionlity we can apply
                _concrete_compoenent_concretedecoratorB_.Operation();



                _compoenent_.statistic = 11;
                Console.WriteLine("Incoming Application____ Phase1 statistic after:" + _compoenent_.statistic);
                return _compoenent_;

            }
            //Parse Initial operations
            internal static object Phase2(ExampleObject_ _compoenent_)
            {

                //TESTING 
                Console.WriteLine("Incoming Application____ Phase2 Starting...");

                _compoenent_.statistic = 12;
                Console.WriteLine("Incoming Application____ Phase2 statistic after:" + _compoenent_.statistic);

                return _compoenent_;
            }


        }

        /// The Deleneated object procesing
        class SubProcessing_Type1
        {
            private int? statistic;

            public ExampleObject_ Compoenent_ { get; }
            public ExampleObject_ Stringvalue_ { get; }
            public string Stringvalue { get; }
            public int Statistic_ { get; }

            public int ConditionalFlag_ { get; }
            public string? AssemballyName_ { get; private set; }

            public SubProcessing_Type1(ExampleObject_ compoenent_, string stringvalue, int statistic)
            {
                Compoenent_ = compoenent_;
                Stringvalue = stringvalue;
                Statistic_ = statistic;
                ConditionalFlag_ = ConditionalFlag_;
                this.AssemballyName_ = AssemballyName_;


                Method1(Compoenent_, Stringvalue, Statistic_, ConditionalFlag_, AssemballyName_);
                Method2(Compoenent_);
                //CciCleanup();
            }

            //Object Conjstructor

            private string Method1(ExampleObject_ compoenent_, string stringvalue_, int Statistic_, int ConditionalFlag_, string AssemballyName_)
            {


                lock (this)
                {

                    //Console.WriteLine("SubProcessing_Type1 Method1 called in sync ConditionalFlag_:" + ConditionalFlag_);

                    //Lets get the name of the generated library and assign 
                    //Create a library called stringvalue_ and some property data
                    //Then lets assign the result
                    //this.AssemballyName_ = DesignPatter_MainSubSystem.Program.DesignPatter_MainSubSystem_entry_Phase1(Compoenent_, stringvalue_, Statistic_, ConditionalFlag_);

                    //Then lets verify the updated values have been implemented to the instance object
                    Console.WriteLine("Incoming Application____ Phase1 after complete Method 1..." + this.AssemballyName_);
                    Thread.Sleep(1000);
                    return AssemballyName_;


                }
            }

            private void Method2(ExampleObject_ compoenent_)
            {
                lock (this)

                {


                    compoenent_.statistic = 7;
                    Console.WriteLine("Incoming Application____ Phase2 statistic after:" + compoenent_.statistic);


                    //var assembly = Assembly.Load("./"+ this.AssemballyName_);
                    //var entryPoint = assembly.EntryPoint;
                    // if (entryPoint != null)
                    // {
                    //      entryPoint.Invoke(null, new object[] { new string[] { } });
                    //  }

                    Thread.Sleep(1000);
                }
            }

            private void CciCleanup()
            {
                Console.WriteLine("Started CCI Cleanup");
                string ilmergePath = @"./bin/Debug/net6.0/generated/utilities/ILMerge.exe";
                string primaryAssembly = @"MyStringValue1.dll";
                string[] otherAssemblies = new[] { @"MyStringValue2.dll" };
                string outputAssembly = @"MyStringValue.exe";

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = ilmergePath;
                startInfo.Arguments = $"/target:winexe /out:{outputAssembly} {primaryAssembly} {string.Join(" ", otherAssemblies)}";
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                startInfo.CreateNoWindow = true;

                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();


            }
        }



    }




















}