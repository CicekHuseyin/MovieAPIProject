﻿using AutoMapper;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using MovieProject.DataAccess.Repositories.Abstracts;
using MovieProject.DataAccess.Repositories.Concretes;
using MovieProject.Model.Dtos.Users;
using MovieProject.Service.Abstracts;
using MovieProject.Service.BusinessRules.Users;
using System.Linq.Expressions;
using System.Threading;

namespace MovieProject.Service.Concretes;

public sealed class UserService(
    UserRepository userRepository,
    UserBusinessRules businessRules,
    IMapper mapper
    ) : IUserService
{
    public async Task<UserResponseDto?> AddAsync(User user, CancellationToken cancellationToken = default)
    {
        await businessRules.EmailMustBeUniqueAsync(user.Email);
        await businessRules.UserNameMustBeUniqueAsync(user.UserName);

        User created = await userRepository.AddAsync(user, cancellationToken);

        UserResponseDto response = mapper.Map<UserResponseDto>(created);

        return response;
    }

    public async Task<UserResponseDto?> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await businessRules.UserIsPresent(id);

        User user = await userRepository.GetAsync(filter: x => x.Id == id, include: false, cancellationToken: cancellationToken);

        User deleted = await userRepository.DeleteAsync(user, cancellationToken);

        UserResponseDto userResponseDto = mapper.Map<UserResponseDto>(deleted);

        return userResponseDto;
    }

    public async Task<List<UserResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var users = await userRepository.GetAllAsync(enableTracking: false, cancellationToken: cancellationToken);
        var response = mapper.Map<List<UserResponseDto>>(users);
        return response;
    }

    public async Task<User> GetAsync(Expression<Func<User, bool>> filter, bool include = true, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        var user = await userRepository.GetAsync(filter, include, enableTracking, cancellationToken);

        return user;
    }

    public async Task<UserResponseDto?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        var user = await userRepository.GetAsync(filter: x => x.Email == email, include: false, enableTracking: false, cancellationToken: cancellationToken);

        var response = mapper.Map<UserResponseDto>(user);

        return response;
    }

    public async Task<UserResponseDto?> GetByIdAsync(int id)
    {
        await businessRules.UserIsPresent(id);

        var user = await userRepository.GetAsync(filter: x => x.Id == id, include: true, enableTracking: false);

        var response = mapper.Map<UserResponseDto>(user);

        return response;
    }

    public async Task<UserResponseDto?> GetByUserNameAsync(string username, CancellationToken cancellationToken = default)
    {
        await businessRules.UserNameMustBeUniqueAsync(username);

        var user = await userRepository.GetAsync(filter: x => x.UserName == username, include: true, enableTracking: false, cancellationToken: cancellationToken);

        var response = mapper.Map<UserResponseDto>(user);

        return response;
    }

    public async Task<UserResponseDto?> SetStatusAsync(int id, bool status)
    {
        await businessRules.UserIsPresent(id);

        User user = await userRepository.GetAsync(filter: x => x.Id == id, include: false);

        user.Status = status;

        User updatedUser = await userRepository.UpdateAsync(user);

        var response = mapper.Map<UserResponseDto>(updatedUser);

        return response;
    }
}
