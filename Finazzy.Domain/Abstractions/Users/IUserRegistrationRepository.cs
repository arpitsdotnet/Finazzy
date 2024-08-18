using Finazzy.Domain.Entities.Users;

namespace Finazzy.Domain.Abstractions.Users;

public interface IUserRegistrationRepository
{
    List<UserRegistration> GetAll(int pageNo = 0);
    UserRegistration GetById(Guid userId);
    UserRegistration GetByUsername(string username);
    void Insert(UserRegistration user);
    void Update(UserRegistration user);
}
