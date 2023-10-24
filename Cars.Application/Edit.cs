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
    public class Edit
    {
        public class Command : IRequest       
        {    
            public Car Car { get; set; }
            public Guid Id { get; set; }
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
                request.Car.Id=request.Id;
                _context.Cars.Update(request.Car);
                await _context.SaveChangesAsync();
                return;
            }
        }
    }
}
