using MediatR;

namespace AppMngr.Application
{
    public class GetStatusByIdQuery :IRequest<StatusDto>
    {
        public int Id { get; set; }

        public GetStatusByIdQuery(int id)
        {
            Id = id;
        }
    }
}