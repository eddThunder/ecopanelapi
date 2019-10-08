using EcopanelPlantsLibrary.Entities.Plant;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcopanelPlantsLibrary.Repositories.Interfaces
{
    interface IPlantsRepository
    {
        Task<IEnumerable<Plant>> GetPlants();
    }
}
