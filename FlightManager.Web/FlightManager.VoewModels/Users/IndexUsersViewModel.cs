using FlightManager.ViewModels.Shared;
using System.Collections.Generic;

namespace FlightManager.ViewModels.Users
{
    public class IndexUsersViewModel : PagingViewModel
    {
        public IndexUsersViewModel(int elementsCount, int itemsPerPage = 5, string action = "Index") : base(elementsCount, itemsPerPage, action)
        {
        }

        public IndexUsersViewModel() : base(0)
        {
        }
        public ICollection<IndexUserViewModel> Users { get; set; } = new List<IndexUserViewModel>();
    }
}
