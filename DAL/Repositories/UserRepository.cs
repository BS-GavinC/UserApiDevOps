using DAL.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _Connection;

        public UserRepository(IDbConnection connection)
        {
            _Connection = connection;
        }

        private UserModel Convert(IDataRecord record)
        {
            return new UserModel(
                (int)record["User_Id"],
                (string)record["Firstname"],
                (string)record["Lastname"],
                (string)record["Email"],
                (string)record["Password_Hash"],
                (DateTime)record["Birthdate"]
            );
        }

        private void AddParameter(IDbCommand command, string name, object data)
        {
            IDbDataParameter cmdEmail = command.CreateParameter();
            cmdEmail.ParameterName = name;
            cmdEmail.Value = data ?? DBNull.Value;
            command.Parameters.Add(cmdEmail);
        }

        public IEnumerable<UserModel> GetAll()
        {
            IDbCommand command = _Connection.CreateCommand();
            command.CommandText = "SELECT * FROM [UserApp];";
            command.CommandType = CommandType.Text;

            _Connection.Open();

            using (IDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return Convert(reader);
                }
            }

            _Connection.Close();
        }

        public UserModel? GetByEmail(string email)
        {
            IDbCommand command = _Connection.CreateCommand();
            command.CommandText = "SELECT * FROM [UserApp] WHERE [Email] = @Email;";
            command.CommandType = CommandType.Text;

            //IDbDataParameter cmdEmail = command.CreateParameter();
            //cmdEmail.ParameterName = "Email";
            //cmdEmail.Value = email;
            //command.Parameters.Add(cmdEmail);

            AddParameter(command, "Email", email);

            UserModel? user = null;

            _Connection.Open();
            using (IDataReader reader = command.ExecuteReader())
            {
                if(reader.Read())
                {
                    user = Convert(reader);
                }
            }
            _Connection.Close();

            return user;
        }

        public UserModel? GetById(int id)
        {
            IDbCommand command = _Connection.CreateCommand();
            command.CommandText = "SELECT * FROM [UserApp] WHERE [User_Id] = @ArnaudOrAlex;";
            command.CommandType = CommandType.Text;

            AddParameter(command, "ArnaudOrAlex", id);

            UserModel? user = null;

            _Connection.Open();
            using (IDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    user = Convert(reader);
                }
            }
            _Connection.Close();

            return user;
        }

        public UserModel? Create(UserModel user)
        {
            string query = "INSERT INTO [UserApp] (Firstname, Lastname, Birthdate, Email, Password_Hash)"
                + " OUTPUT [inserted].*"
                + " VALUES(@Firstname, @Lastname, @Birthdate, @Email, @Password)";

            IDbCommand command = _Connection.CreateCommand();
            command.CommandText = query;
            command.CommandType= CommandType.Text;

            AddParameter(command, "Firstname", user.Firstname);
            AddParameter(command, "Lastname", user.Lastname);
            AddParameter(command, "Birthdate", user.Birthdate);
            AddParameter(command, "Email", user.Email);
            AddParameter(command, "Password", user.Password);

            UserModel? userCreated = null;

            try
            {
                _Connection.Open();
                using(IDataReader reader = command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        userCreated = Convert(reader);
                    }
                }
            }
            finally
            {
                _Connection.Close();
            }

            return userCreated;
        }

        public bool ChangePassword(int id, string password)
        {
            string query = "UPDATE [UserApp]" +
                " SET [Password_Hash] = @Password" +
                " WHERE [User_Id] = @UserId";

            IDbCommand command = _Connection.CreateCommand();
            command.CommandText = query;
            command.CommandType= CommandType.Text;

            AddParameter(command, "UserId", id);
            AddParameter(command, "Password", password);

            _Connection.Open();
            int nbRow = command.ExecuteNonQuery();
            _Connection.Close();

            return nbRow == 1;
        }

        public bool Delete(int id)
        {
            IDbCommand command = _Connection.CreateCommand();
            command.CommandText = "DELETE FROM [UserApp] WHERE [User_Id] = @Id";
            command.CommandType = CommandType.Text;

            AddParameter(command, "Id", id);

            _Connection.Open();
            int nbRow = command.ExecuteNonQuery();
            _Connection.Close();

            return nbRow == 1;
        }
    }
}
