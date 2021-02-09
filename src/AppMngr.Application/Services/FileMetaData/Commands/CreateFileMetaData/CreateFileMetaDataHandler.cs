using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using AppMngr.Core;

namespace AppMngr.Application
{
    public class CreateFileMetaDataHandler : IRequestHandler<CreateFileMetaDataCommand, FileMetaDataDto>
    {
        private IAppTypeRepo _appTypes;
        private IFileMetaDataRepo _fileMetaData;
        private IUOW _uow;
        private IMapper _mapper;
        
        public CreateFileMetaDataHandler(IAppTypeRepo appTypes, IFileMetaDataRepo fileMetaData, IUOW uow, IMapper mapper)
        {
            _appTypes = appTypes;
            _fileMetaData = fileMetaData;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<FileMetaDataDto> Handle(CreateFileMetaDataCommand command, CancellationToken cancellationToken)
        {
            var appType = await _appTypes.GetByIdAsync(command.AppTypeId);
            if (appType == null)
            {
                throw new AppTypeNotFoundException($"Тип заявки с Id={command.AppTypeId} не найден.");
            }

            var fileMetaData = new FileMetaData()
            {
                AppTypeId = command.AppTypeId
            };

            await _fileMetaData.AddAsync(fileMetaData);
            await _uow.SaveChangesAsync();

            var fileMetaDataDto = _mapper.Map<FileMetaDataDto>(fileMetaData);
            return fileMetaDataDto;
        }
    }
}