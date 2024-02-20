using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Applications.Commands
{
    public class CreateRecipeCommand : IRequest<string>
    {
    }

    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, string>
    {
        public CreateRecipeCommandHandler() { }

        public async Task<string> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
