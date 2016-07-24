using FDS.StandardsDev.Tools.ServiceStackJobHangFire.Operations;
using ServiceStack;

namespace FDS.StandardsDev.Tools.ServiceStackJobHangFire
{
    public class ServiceStackTestService : Service
    {
        public ServiceStackTestResponse Any(ServiceStackTestRequest request)
        {
            var description = string.Format("Your number is '{0}'", request.Id);

            var response = new ServiceStackTestResponse
            {
                Description = description
            };

            return response;
        }
    }

}
