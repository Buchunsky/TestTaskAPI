using MediatR;
using TestTask.Domain;

namespace TestTask.Application.MediatR.Commands.UpdatePackage;

public class UpdatePackageCommand : IRequest
{
    public int Id { get; set; }
    public string PackageIdentifier { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public string Status { get; set; }
    public int RecipientId { get; set; }
}