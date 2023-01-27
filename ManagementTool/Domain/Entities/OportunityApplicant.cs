using Domain.Entities.OportunityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OportunityApplicant
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public Oportunity Oportunity { get; set; }
        public int OportunityId { get; set; }
        public Position Position { get; set; }
        public int PositionId { get; set; }

        public OportunityApplicant(int userId,int oportunityId,int positionId)
        {
            UserId = userId;
            OportunityId = oportunityId;
            PositionId = positionId;
        }

    }
}
