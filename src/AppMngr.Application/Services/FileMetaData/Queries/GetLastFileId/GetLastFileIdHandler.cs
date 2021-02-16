using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using MediatR;
using AppMngr.Core;

namespace AppMngr.Application
{
    public class GetLastFileIdHandler : IRequestHandler<GetLastFileIdQuery, int>
    {
        private readonly IFileMetaDataRepo _fileMetaData;

        public GetLastFileIdHandler(IFileMetaDataRepo fileMetaData)
        {
            _fileMetaData = fileMetaData;
        }

        public async Task<int> Handle(GetLastFileIdQuery query, CancellationToken cancellationToken)
        {
            var fileMetaData = await _fileMetaData.GetAllAsync();

            var lastFileMetaData = fileMetaData
                .OrderBy(f => f.Id)
                .Last();

            return lastFileMetaData.Id;
        }
    }
}