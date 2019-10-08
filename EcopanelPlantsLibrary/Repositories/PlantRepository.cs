using System.Collections.Generic;
using System.Threading.Tasks;
using EcopanelPlantsLibrary.Entities.Plant;
using EcopanelPlantsLibrary.Repositories.Interfaces;

namespace EcopanelPlantsLibrary.Repositories
{
    public class PlantRepository : IPlantsRepository
    {
        
        public PlantRepository()
        {

        }
        public Task<IEnumerable<Plant>> GetPlants()
        {
            throw new System.NotImplementedException();
        }
    }
}
