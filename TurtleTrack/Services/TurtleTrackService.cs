/*using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace TurtleTrack.Services
{
    public class TurtleTrackService
    {
        private readonly string _connectionString;

        public TurtleTrackService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<YourEntity> GetEntities()
        {
            var entities = new List<YourEntity>();

            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (var command = new OracleCommand("SELECT * FROM YourTable", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            entities.Add(new YourEntity
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                                // Map other properties
                            });
                        }
                    }
                }
            }

            return entities;
        }
    }
}
*/