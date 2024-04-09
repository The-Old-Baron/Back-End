using OldBarom.Core.Domain.Entities.TeamController;
using OldBarom.Core.Domain.Repository.TeamController;
using OldBarom.Infra.Data.Context;

namespace OldBarom.Infra.Data.Repository.TeamController
{
    public class TeamCategoriesRepository : ITeamCategoriesRepository
    {
        private readonly ApplicationDbContext _context;
        public TeamCategoriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Add(TeamCategories entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(TeamCategories entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TeamCategories>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TeamCategories> GetByID(string guid)
        {
            throw new NotImplementedException();
        }

        public Task Update(TeamCategories entity)
        {
            throw new NotImplementedException();
        }
    }
}
