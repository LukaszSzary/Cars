using Cars.Domain;
using Cars.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application
{
    public class Create
    {
        public class Command : IRequest
        {
            public Car Car { get; set; }

        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Cars.Add(request.Car);
                await _context.SaveChangesAsync();
                return;
            }
        }
    }
}

