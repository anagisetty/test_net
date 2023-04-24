using System;
using System.Collections.Generic;
using System.Data;
using Test_Net.DTO.Testing;

namespace Test_Net
{
    public class WebServicesUserStoryRepository
    {
        private readonly IDbConnection _connection;

        public WebServicesUserStoryRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public WebServicesUserStory GetById(int id)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM WebServicesUserStory WHERE Id = @id";
                command.AddParameter("id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new WebServicesUserStory
                        {
                            Id = (int)reader["Id"]
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public void Create(WebServicesUserStory story)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO WebServicesUserStory (Id) VALUES (@id)";
                command.AddParameter("id", story.Id);
                command.ExecuteNonQuery();
            }
        }

        public void Update(WebServicesUserStory story)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "UPDATE WebServicesUserStory SET Id = @id WHERE Id = @id";
                command.AddParameter("id", story.Id);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM WebServicesUserStory WHERE Id = @id";
                command.AddParameter("id", id);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<WebServicesUserStory> GetAll()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM WebServicesUserStory";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new WebServicesUserStory
                        {
                            Id = (int)reader["Id"]
                        };
                    }
                }
            }
        }
    }
}