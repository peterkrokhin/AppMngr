using MediatR;

namespace AppMngr.Application
{
    public class GetStringFieldByIdQuery :IRequest<StringFieldDto>
    {
        public int Id { get; set; }

        public GetStringFieldByIdQuery(int id)
        {
            Id = id;
        }
    }
}