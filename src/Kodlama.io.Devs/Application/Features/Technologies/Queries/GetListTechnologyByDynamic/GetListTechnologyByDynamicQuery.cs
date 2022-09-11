using Application.Features.Technologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Queries.GetListTechnologyByDynamic
{
    public class GetListTechnologyByDynamicQuery : IRequest<TechnologyListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest;
        public class GetListTechnologyByDynamicQueryHandler : IRequestHandler<GetListTechnologyByDynamicQuery, TechnologyListModel>
        {
            private readonly IMapper _mapper;
            private readonly ITechnologyRepository _technologyRepository;

            public GetListTechnologyByDynamicQueryHandler(IMapper mapper, ITechnologyRepository modelRepository)
            {
                _mapper = mapper;
                _technologyRepository = modelRepository;
            }

            public async Task<TechnologyListModel> Handle(GetListTechnologyByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Technology> models = await _technologyRepository.GetListByDynamicAsync(request.Dynamic, include: m => m.Include(c => c.ProgrammingLanguage), index: request.PageRequest.Page, size: request.PageRequest.PageSize);//Car Models
                TechnologyListModel mappedModels = _mapper.Map<TechnologyListModel>(models);//dataModel
                return mappedModels;
            }

        }
    }
}
