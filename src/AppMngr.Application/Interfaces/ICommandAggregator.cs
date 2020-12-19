using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;

namespace AppMngr.Application
{
    public interface ICommandAggregator : IDisposable
    {
        Task AddAppTypeAsync(JsonDocument doc);

        Task AddStringFieldInAppTypeAsync(int appTypeId, JsonDocument doc);
        Task AddNumFieldInAppTypeAsync(int appTypeId, JsonDocument doc);
        Task AddDateFieldInAppTypeAsync(int appTypeId, JsonDocument doc);
        Task AddTimeFieldInAppTypeAsync(int appTypeId, JsonDocument doc);
        Task AddFileFieldInAppTypeAsync(int appTypeId, JsonDocument doc);
        Task AddStatusInAppTypeAsync(int appTypeId, JsonDocument doc);

        Task ChangeAppTypeAsync(int appTypeId, JsonDocument doc);

        Task ChangeStringFieldInAppTypeAsync(int appTypeId, int idStringField, JsonDocument doc);
        Task ChangeNumFieldInAppTypeAsync(int appTypeId, int idNumField, JsonDocument doc);
        Task ChangeDateFieldInAppTypeAsync(int appTypeId, int idDateField, JsonDocument doc);
        Task ChangeTimeFieldInAppTypeAsync(int appTypeId, int idTimeField, JsonDocument doc);
        Task ChangeFileFieldInAppTypeAsync(int appTypeId, int idFileField, JsonDocument doc);
        Task ChangeStatusInAppTypeAsync(int appTypeId, int idStatusField, JsonDocument doc);

        Task ChangeStatusInAppAsync(int appId, JsonDocument doc);
        Task AddAppAsync(JsonDocument doc);

        Task AddUserAsync(JsonDocument doc);
    }
}