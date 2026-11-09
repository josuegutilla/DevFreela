using DevFreela.Domain.Enums;
using MediatR;
using System.Text.Json.Serialization;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommand : IRequest<ProjectCommandResult>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalCost { get; set; }

        [JsonIgnore]
        public int IdUser { get; set; }
    }
}
