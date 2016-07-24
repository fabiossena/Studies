using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace FDS.StandardsDev.Tools.Model
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionStringLocal"].ConnectionString;

        public Configuration Add(Configuration configuration)
        {
            Configuration configurationAdded = null;
            if (configuration != null)
            {
                string query =
                @"INSERT INTO [Configuration]([Description], [Setting], [Value]) 
                OUTPUT INSERTED.*
                VALUES (@Description, @Setting, @Value)";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var configurations = connection.Query<Configuration>(query, configuration);
                    configurationAdded = configurations.FirstOrDefault();
                    connection.Close();
                }
            }
            return configurationAdded;
        }

        public bool Delete(int id)
        {
            bool deleted = false;
            if (id > 0)
            {
                string query =
                    @"DELETE FROM [Configuration]
                  OUTPUT DELETED.*
                  WHERE ConfigurationId=@ConfigurationId";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var configurations = connection.Execute(query, new { ConfigurationId = id });
                    deleted = true;
                    connection.Close();
                }
            }
            return deleted;
        }

        public Configuration Get(int id)
        {
            Configuration configuration = null;
            if (id > 0)
            {
                string query =
                @"SELECT * FROM [Configuration] WHERE ConfigurationId=@ConfigurationId";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var configurations = connection.Query<Configuration>(query, new { ConfigurationId = id });
                    configuration = configurations.FirstOrDefault();
                    connection.Close();
                }
            }
            return configuration;
        }

        public IEnumerable<Configuration> GetAll()
        {
            IEnumerable<Configuration> configurationsList = null;
            string query =
                @"SELECT * FROM [Configuration]";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                configurationsList = connection.Query<Configuration>(query);
                connection.Close();
            }
            return configurationsList;
        }

        public Configuration Update(Configuration configuration)
        {
            Configuration configurationUpdated = null;
            if (configuration != null)
            {
                string query =
                @"UPDATE [Configuration] SET
	                [Description]=@Description,
	                [Setting]=@Setting,
	                [Value]=@Value
                WHERE ConfigurationId=@ConfigurationId;
                SELECT * FROM [Configuration] WHERE ConfigurationId=@ConfigurationId";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var configurations = connection.Query<Configuration>(query, configuration);
                    configurationUpdated = configurations.FirstOrDefault();
                    connection.Close();
                }
            }
            return configurationUpdated;
        }
    }
}