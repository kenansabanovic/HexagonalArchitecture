using Domain;
using Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class DetailsCategory
    {
        public class Query : IRequest<Category>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Category>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Category> Handle(Query request, CancellationToken cancellationToken)
            {
                var category = await _context.Categories.FindAsync(request.Id);

                return category;
            }
        }
    }
}
