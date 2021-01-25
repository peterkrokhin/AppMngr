using MediatR;

namespace AppMngr.Application
{
    public class GetAppByIdQuery :IRequest<AppDto>
    {
        public int Id { get; set; }

        public GetAppByIdQuery(int id)
        {
            Id = id;
        }
    }
}