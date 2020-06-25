using Domain;
using Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateCategory
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }


        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var category = new Category
                {
                    Id = request.Id,
                    Name = request.Name
                };

                _context.Categories.Add(category);
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}
