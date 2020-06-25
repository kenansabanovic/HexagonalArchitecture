using Domain;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class ListCategory
    {
        public class Query : IRequest<List<Category>> { }

        public class Handler : IRequestHandler<Query, List<Category>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Category>> Handle(Query request, CancellationToken cancellationToken)
            {
                var categories = await _context.Categories.ToListAsync();

                return categories;
            }
        }
    }
}
