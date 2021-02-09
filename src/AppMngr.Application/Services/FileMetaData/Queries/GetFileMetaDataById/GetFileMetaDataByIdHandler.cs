using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace AppMngr.Application
{
    public class GetFileMetaDataByIdHandler : IRequestHandler<GetFileMetaDataByIdQuery, FileMetaDataDto>
    {
        private readonly IFileMetaDataRepo _fileMetaData;
        private readonly IMapper _mapper;

        public GetFileMetaDataByIdHandler(IFileMetaDataRepo fileMetaData, IMapper mapper)
        {
            _fileMetaData = fileMetaData;
            _mapper = mapper;
        }

        public async Task<FileMetaDataDto> Handle(GetFileMetaDataByIdQuery query, CancellationToken cancellationToken)
        {
            var fileMetaData = await _fileMetaData.GetByIdAsync(query.Id);

            if (fileMetaData == null)
            {
                throw new FileMetaDataNotFoundException($"Данные для файла с Id={query.Id} не найдены.");
            }
            
            var fileMetaDataDto = _mapper.Map<FileMetaDataDto>(fileMetaData);
            return fileMetaDataDto;
        }
    }
}