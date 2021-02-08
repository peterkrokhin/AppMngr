using MediatR;

namespace AppMngr.Application
{
    public class GetTimeFieldByIdQuery :IRequest<TimeFieldDto>
    {
        public int Id { get; set; }

        public GetTimeFieldByIdQuery(int id)
        {
            Id = id;
        }
    }
}