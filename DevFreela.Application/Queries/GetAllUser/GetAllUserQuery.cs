using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.GetAllUser
{
    public class GetAllUserQuery : IRequest<List<UserViewModel>>
    {
    }
}
