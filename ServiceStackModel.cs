using ServiceStack;

namespace docker_aws_int
{

    [Route ("/helo/{Name}")]
    public class ServiceStackModel : IReturn<HelloResponse>
    {
        public string Name {get; set;}
    }
    public class ServiceStackModelResponse 
    {
    public string Result { get; set; }
    }
}
