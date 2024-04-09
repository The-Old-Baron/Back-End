using OldBarom.Core.Domain.Entities.TeamController;
using OldBarom.Core.Domain.Repository.TeamController;
using OldBarom.Infra.Data.Context;

namespace OldBarom.Infra.Data.Repository.TeamController
{
    public class TeamRespository : ITeamRepository
    {
        private readonly ApplicationDbContext _context;
        public TeamRespository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Add(Team entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Team entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Team>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Team> GetByID(string guid)
        {
            throw new NotImplementedException();
        }

        public Task Update(Team entity)
        {
            throw new NotImplementedException();
        }
    }
}
