using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction
{
    public interface ICalendarRepository
    {
        public Task<Calendar> GetAsync(int userId);
        public Task CreateAsync(Calendar calendar);
    }
}
