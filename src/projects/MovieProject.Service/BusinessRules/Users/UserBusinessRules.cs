using Core.CrossCuttingConcerns.Exceptions.Types;
using MovieProject.DataAccess.Repositories.Abstracts;
using MovieProject.Service.Constants.Users;

namespace MovieProject.Service.BusinessRules.Users;

public class UserBusinessRules(IUserRepository userRepository)
{
    public async Task UserNameMustBeUniqueAsync(string username)
    {
        bool isPresent = await userRepository.AnyAsync(x => x.UserName == username);
        if (!isPresent)
            throw new NotFoundException(UsersMessages.UserNameMustBeUnique);
    }

    public async Task EmailMustBeUniqueAsync(string email)
    {
        bool isPresent = await userRepository.AnyAsync(x=> x.Email == email);
        if (!isPresent)
            throw new NotFoundException(UsersMessages.EmailMustBeUnique);
    }

    public async Task UserIsPresent (int id)
    {
        bool isPresent = await userRepository.AnyAsync(x=>x.Id == id);
        if (!isPresent)
            throw new NotFoundException(UsersMessages.UserNotFound);
    }
}
