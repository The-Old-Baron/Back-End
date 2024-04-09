using OldBarom.Core.Domain.Entities.Portifolio;
using OldBarom.Core.Domain.Repository.Portifolio;
using OldBarom.Infra.Data.Context;

namespace OldBarom.Infra.Data.Repository.Portifolio
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly ApplicationDbContext _context;

        public Task Add(Projects entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Projects entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Projects>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Projects> GetByID(string guid)
        {
            throw new NotImplementedException();
        }

        public Task Update(Projects entity)
        {
            throw new NotImplementedException();
        }
    }
}
