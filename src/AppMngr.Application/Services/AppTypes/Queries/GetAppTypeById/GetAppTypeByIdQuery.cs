using MediatR;

namespace AppMngr.Application
{
    public class GetAppTypeByIdQuery : IRequest<AppTypeDto>
    {
        public int Id { get; set; }

        public GetAppTypeByIdQuery(int id)
        {
            Id = id;
        }
    }
}