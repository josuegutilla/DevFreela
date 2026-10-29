using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.GetByIdUser
{
    public class GetByIdUserQuery : IRequest<UserDetailsViewModel?>
    {
        public int Id { get; set; }
    }
}
