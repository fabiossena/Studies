using ServiceStack;

namespace FDS.StandardsDev.Tools.ServiceStackJobHangFire.Operations
{
    [Route("/servicestacktest")]
    [Route("/servicestacktest/{id}")]
    public class ServiceStackTestRequest
    {
        public int Id { get; set; }
    }

    public class ServiceStackTestResponse
    {
        public string Description { get; set; }
    }

}