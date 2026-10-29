using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, bool>
    {
        private readonly DevFreelaDbContext _db;

        public UpdateProjectCommandHandler(DevFreelaDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _db.Projects.SingleOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (project == null) return false;

            project.Update(request.Title, request.Description, request.TotalCost);
            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
