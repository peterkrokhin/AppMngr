using MediatR;

namespace AppMngr.Application
{
    public class GetNumFieldByIdQuery :IRequest<NumFieldDto>
    {
        public int Id { get; set; }

        public GetNumFieldByIdQuery(int id)
        {
            Id = id;
        }
    }
}