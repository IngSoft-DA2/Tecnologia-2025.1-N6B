using shop.Domain;
using shop.IBusinessLogic;
using shop.IDataAccess;
using System;
using System.Collections.Generic;

namespace shop.BusinessLogic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRepository;

        public UserLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentException("User cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(user.Name))
            {
                throw new ArgumentException("User name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(user.Email))
            {
                throw new ArgumentException("User email cannot be empty.");
            }

            if (!user.Email.Contains("@"))
            {
                throw new ArgumentException("User email is not valid.");
            }

            if (string.IsNullOrWhiteSpace(user.Password))
            {
                throw new ArgumentException("User password cannot be empty.");
            }

            if (user.Password.Length < 6)
            {
                throw new ArgumentException("User password must be at least 6 characters long.");
            }

            _userRepository.AddUser(user);
        }

        public User GetUser(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("User ID must be greater than zero.");
            }

            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }

            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public void UpdateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentException("User cannot be null.");
            }

            if (user.Id <= 0)
            {
                throw new ArgumentException("User ID must be greater than zero.");
            }

            var existingUser = _userRepository.GetUserById(user.Id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {user.Id} not found.");
            }

            if (string.IsNullOrWhiteSpace(user.Name))
            {
                throw new ArgumentException("User name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(user.Email))
            {
                throw new ArgumentException("User email cannot be empty.");
            }

            if (!user.Email.Contains("@"))
            {
                throw new ArgumentException("User email is not valid.");
            }

            _userRepository.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("User ID must be greater than zero.");
            }

            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }

            _userRepository.DeleteUser(id);
        }
    }
}