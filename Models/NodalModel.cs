using ServiceStack;

namespace docker_aws_int.Models;

//Example Object Class

public class ExampleObject_Concrete_Client : ExampleObject_Client
        {
    public ExampleObject_Concrete_Client(string stringvalue, int numericalvalue, int statistic, int DataSet1, int DataSet2, int DataSet3) : base(stringvalue, numericalvalue, statistic, DataSet1, DataSet2, DataSet3)
    {

    }
    //The Concrete Objects Constrctor

    public override void Operation()
            {
               
            }
          
 }


public class ExampleObject_Client
        {
             //An empty object with fields and nested values
            public string stringvalue  {get;} 
            //An empty object with fields and nested values
            public int numericalvalue {get;}
            //A regular field that can be null
            public int statistic { get;}
             //A regular field that can be null
            public int DataSet1 { get;}
             //A regular field that can be null
            public int DataSet2 { get;}
             //A regular field that can be null
            public int DataSet3 { get;}

            //Here is the instanciatio of the nested object as
            //part of the object constructor
            public ExampleObject_Client(

                string stringvalue,
                int numericalvalue,
                int statistic,
                int DataSet1,
                int DataSet2,
                int DataSet3
            )
            {
                //And an instaciation of the nested within the consructor
                this.ExampleNestedObjectInstance = new ExampleNestedObject() { PolicyId = -1 };
            }
            //REQUIRED: Example ExampleObject_ Base operation
            //No need to define here
            public virtual void Operation()
            {

            }
           
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