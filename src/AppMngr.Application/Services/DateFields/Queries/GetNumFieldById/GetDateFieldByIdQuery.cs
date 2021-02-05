using MediatR;

namespace AppMngr.Application
{
    public class GetDateFieldByIdQuery :IRequest<DateFieldDto>
    {
        public int Id { get; set; }

        public GetDateFieldByIdQuery(int id)
        {
            Id = id;
        }
    }
}