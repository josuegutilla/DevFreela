using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.GetByIdProject
{
    public class GetByIdProjectQuery : IRequest<ProjectDetailsViewModel?>
    {
        public int Id { get; set; }
    }
}
