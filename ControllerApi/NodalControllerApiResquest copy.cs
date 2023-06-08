namespace docker_aws_int.ControllerApi;

//Example Object Class
public record CreateExampleObject_Request(
    string stringvalue,
    int numericalvalue,
    string Description,
    int statistic,
    int DataSet1,
    int DataSet2,
    int DataSet3
   );
