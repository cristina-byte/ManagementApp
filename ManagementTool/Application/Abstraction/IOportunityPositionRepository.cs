using Domain.Entities.OportunityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction
{
    public interface IOportunityPositionRepository
    {
        public Task CreateAsync(Position position);

        public Task Delete(int id);

    }
}
