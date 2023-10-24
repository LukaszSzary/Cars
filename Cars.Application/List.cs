using Cars.Persistence;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Cars.Domain;

namespace Cars.Application
{
    public class List
    {
        public class Query : IRequest<List<Car>> { }
        public class Handler : IRequestHandler<Query, List<Car>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context; 
            }

            public async Task<List<Car>>Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Cars.ToListAsync();
            }
        }
    }
}