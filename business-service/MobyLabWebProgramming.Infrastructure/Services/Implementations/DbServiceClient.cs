using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;
using System.Net.Http.Json;

namespace MobyLabWebProgramming.Infrastructure.Services.Implementations;

public class DbServiceClient : IDbServiceClient
{
    private readonly HttpClient _httpClient;

    public DbServiceClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<OrganizationDTO> GetOrganization(Guid id)
    {
        var response = await _httpClient.GetFromJsonAsync<OrganizationDTO>($"/api/organization/{id}");
        return response ?? throw new Exception("Failed to retrieve organization");
    }

    public async Task<ApplicationDTO> GetApplication(Guid id)
    {
        var response = await _httpClient.GetFromJsonAsync<ApplicationDTO>($"/api/application/{id}");
        return response ?? throw new Exception("Failed to retrieve application");
    }

    public async Task<ProjectDTO> GetProject(Guid id)
    {
        var response = await _httpClient.GetFromJsonAsync<ProjectDTO>($"/api/project/{id}");
        return response ?? throw new Exception("Failed to retrieve project");
    }

    public async Task<NotificationDTO> GetNotification(Guid id)
    {
        var response = await _httpClient.GetFromJsonAsync<NotificationDTO>($"/api/notification/{id}");
        return response ?? throw new Exception("Failed to retrieve notification");
    }
}