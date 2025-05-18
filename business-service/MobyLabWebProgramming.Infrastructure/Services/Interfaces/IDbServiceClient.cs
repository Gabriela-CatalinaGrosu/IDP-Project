using MobyLabWebProgramming.Core.DataTransferObjects;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces;

public interface IDbServiceClient
{
    Task<OrganizationDTO> GetOrganization(Guid id);
    Task<ApplicationDTO> GetApplication(Guid id);
    Task<ProjectDTO> GetProject(Guid id);
    Task<NotificationDTO> GetNotification(Guid id);
}