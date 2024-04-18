using FlightManager.ViewModels.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Services.Contracts
{
    public interface IFlightService
    {
        public Task<IndexFlightsViewModel> GetProjectsAsync(IndexFlightsViewModel model);
        public Task<int> GetFlightCountAsync();
        public Task<string> CreateFlightAsync(CreateFlightViewModel model);
        //public Task<ProjectDetailsViewModel> GetProjectDetails(string id);
        //public Task<string> AddTeamToProject(AddTeamToProject model);
        //public Task<AddTeamToProject> GetTeamToAddAsync(string id);
        //public Task<string> RemoveTeamFromProject(RemoveTeamViewModel model);
        //public Task<RemoveTeamViewModel> GetTeamToRemoveAsync(string id);
        //public Task<EditProjectViewModel?> GetProjectToEditAsync(string id);
        //public Task<string> UpdateProjectAsync(EditProjectViewModel project);
        //public Task<int> DeleteProjectAsync(string id);
    }
}
