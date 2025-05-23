﻿using DAL.EF.Users;
using Domain.User;

namespace BL.Users;

public class UserManager : IUserManager
{
    
    private readonly IUserRepository _userRepository;

    public UserManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public List<User> GetAllUsers()
    {
        return _userRepository.ReadAllUsers();
    }

    public User GetUserById(string id)
    {
        return _userRepository.ReadUserById(id);
    }

    public void AddUser(User user)
    {
         _userRepository.CreateUser(user);
    }

    public User EditUser(User user)
    {
        throw new NotImplementedException();
    }

    public void RemoveUser(Guid id)
    {
        throw new NotImplementedException();
    }
}