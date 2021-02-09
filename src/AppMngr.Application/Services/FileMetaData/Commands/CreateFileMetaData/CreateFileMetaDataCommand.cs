using MediatR;

namespace AppMngr.Application
{
    public class CreateFileMetaDataCommand : IRequest<FileMetaDataDto>
    {
        public int AppTypeId { get; set; }
    }
}