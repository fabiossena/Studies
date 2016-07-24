using FDS.StandardsDev.Tools.Model;
using System.Collections.Generic;

namespace FDS.StandardsDev.Tools.AngularMVC5.Models
{
    public class ConfigurationModel : IConfigurationRepository
    {
        IConfigurationRepository configurationRepository = new ConfigurationRepository();
        public Configuration Add(Configuration configuration)
        {
            return configurationRepository.Add(configuration);
        }

        public bool Delete(int id)
        {
            return configurationRepository.Delete(id);
        }

        public Configuration Get(int id)
        {
            return configurationRepository.Get(id);
        }

        public IEnumerable<Configuration> GetAll()
        {
            return configurationRepository.GetAll();
        }

        public Configuration Update(Configuration configuration)
        {
            return configurationRepository.Update(configuration);
        }
    }
}