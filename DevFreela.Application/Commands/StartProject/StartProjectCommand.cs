using DevFreela.Domain.Enums;
using MediatR;
using System.Text.Json.Serialization;

namespace DevFreela.Application.Commands.StartProject
{
    public class StartProjectCommand : IRequest<ProjectCommandResult>
    {
        public int Id { get; set; }

        [JsonIgnore]
        public int IdUser { get; set; }
    }
}
