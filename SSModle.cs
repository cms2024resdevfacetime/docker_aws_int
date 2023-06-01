using ServiceStack;

namespace docker_aws_int
{

    [Route ("/helo/{Name}")]
    public class Hello : IReturn<HelloResponse>
    {
        public string Name {get; set;}
    }
    public class HelloResponse 
    {
    public string Result { get; set; }
    }
}
