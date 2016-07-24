using System.Collections.Generic;

namespace FDS.StandardsDev.Tools.Model
{
    public interface IConfigurationRepository
    {
        IEnumerable<Model.Configuration> GetAll();
        Model.Configuration Get(int id);
        Model.Configuration Add(Model.Configuration configuration);
        Model.Configuration Update(Model.Configuration configuration);
        bool Delete(int id);
    }
}