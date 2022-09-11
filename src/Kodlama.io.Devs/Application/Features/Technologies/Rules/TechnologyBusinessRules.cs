using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly ITechnologyRepository _technology;

        public TechnologyBusinessRules(ITechnologyRepository technology)
        {
            _technology = technology;
        }

        public async Task CanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Technology> result = await _technology.GetListAsync(p => p.Name == name);
            if (result.Items.Any()) throw new BusinessException("Name already exists.");
        }

        public void TechnologyShouldExistWhenRequested(Technology technology)
        {

            if (technology == null) throw new BusinessException("Requested does not exist.");
        }



    }
}
