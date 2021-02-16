using MediatR;

namespace AppMngr.Application
{
    public class GetFileMetaDataByIdQuery : IRequest<FileMetaDataDto>
    {
        public int Id { get; set; }

        public GetFileMetaDataByIdQuery(int id)
        {
            Id = id;
        }
    }
}