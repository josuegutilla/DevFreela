using DevFreela.Domain.Entities;
using DevFreela.Domain.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, bool>
    {
        private readonly IProjectRepository _projectRepository;

        public CreateCommentCommandHandler(IProjectRepository repository)
        {
            _projectRepository = repository;
        }

        public async Task<bool> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var projectExists = await _projectRepository.ExistsAsync(request.IdProject, cancellationToken);

            if (!projectExists) return false;

            var comment = new ProjectComment(
                request.Content,
                request.IdProject,
                request.IdUser
            );

            await _projectRepository.AddCommentAsync(comment, cancellationToken);

            return true;
        }
    }
}
