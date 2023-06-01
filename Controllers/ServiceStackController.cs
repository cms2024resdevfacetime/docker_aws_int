using ServiceStack;

namespace docker_aws_int.Controllers
{
    public class ServiceStackController : Service
    {
        public HelloResponse HelloResponse { get; set; }    
    }
}
