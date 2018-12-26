using System.Collections.Generic;
using System.Data;
using Core;
using Dapper;

namespace Persistance
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(IDbConnection dbConnection) : base(dbConnection)
        {

        }

        public void Add(User userToAdd)
        {
            const string query = @"
                                   INSERT INTO [dbo].[Users]
                                   ([FirstName]
                                   ,[MiddleName]
                                   ,[LastName]
                                   ,[Email]
                                   ,[Address]
                                   ,[Phone]
                                   ,[Password]
                                   ,[UserName])
                             VALUES
                                   (@FirstName
                                   ,@MiddleName
                                   ,@LastName
                                   ,@Email
                                   ,@Address
                                   ,@Phone
                                   ,@Password
                                   ,@UserName) 
                                    ";
            EnsureDbConnectionIsOpen();
            Connection.Query(query, userToAdd);
        }

        public void Update(User userToUpdate)
        {
            const string query = @"
                                    UPDATE [dbo].[Users]
                                       SET [FirstName] = @FirstName
                                          ,[MiddleName] = @MiddleName
                                          ,[LastName] = @LastName
                                          ,[Email] = @Email
                                          ,[Address] = @Address
                                          ,[Phone] = @Phone
                                          ,[Password] = @Password
                                          ,[UserName] = @UserName
                                     WHERE Id = @Id
                                  ";
            EnsureDbConnectionIsOpen();
            Connection.Query(query, userToUpdate);
        }

        public void Delete(int userId)
        {
            const string query = @"
                                    DELETE FROM [dbo].[Users]
                                    WHERE Id = @userId
                                  ";
            EnsureDbConnectionIsOpen();
            Connection.Query(query, new {userId});
        }

        public IEnumerable<User> GetAllUser()
        {
            const string query = @"
                                   SELECT [Id]
                                      ,[FirstName]
                                      ,[MiddleName]
                                      ,[LastName]
                                      ,[Email]
                                      ,[Address]
                                      ,[Phone]
                                      ,[Password]
                                      ,[UserName]
                                  FROM [UserRegistrationApp].[dbo].[Users]
                                  ";
            EnsureDbConnectionIsOpen();
            return Connection.Query<User>(query);
        }

        public User Get(int userId)
        {
            const string query = @"
                                   SELECT [Id]
                                      ,[FirstName]
                                      ,[MiddleName]
                                      ,[LastName]
                                      ,[Email]
                                      ,[Address]
                                      ,[Phone]
                                      ,[Password]
                                      ,[UserName]
                                  FROM [UserRegistrationApp].[dbo].[Users]
                                  WHERE Id = @userId
                                  ";
            EnsureDbConnectionIsOpen();
            return Connection.QuerySingleOrDefault<User>(query, new { userId });
        }

        public string GetPasswordFor(int userId)
        {
            const string query = @"
                                    SELECT 
                                       [Password]
                                  FROM [UserRegistrationApp].[dbo].[Users]
                                  WHERE Id = @userId
                                  ";
            EnsureDbConnectionIsOpen();
            return Connection.QuerySingleOrDefault<string>(query);
        }

        public User GetUserBy(string userNameOrEmail)
        {
            const string query = @"
                                   SELECT [Id]
                                  ,[FirstName]
                                  ,[MiddleName]
                                  ,[LastName]
                                  ,[Email]
                                  ,[Address]
                                  ,[Phone]
                                  ,[Password]
                                  ,[UserName]
                              FROM [UserRegistrationApp].[dbo].[Users]
                              WHERE UserName = @userNameOrEmail 
                              OR    Email = @userNameOrEmail
                                  ";
            EnsureDbConnectionIsOpen();
            return Connection.QuerySingleOrDefault<User>(query);
        }
    }
}
