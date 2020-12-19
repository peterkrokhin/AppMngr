using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using AppMngr.Core;
using System.Text.Json;

namespace AppMngr.Application
{
    public class CommandAggregator : ICommandAggregator
    {

        private IUOW UOW { get; set; }
        public CommandAggregator(IUOW uOW)
        {
            UOW = uOW;
        }

        public async Task AddAppTypeAsync(JsonDocument doc)
        {
            JsonElement root = doc.RootElement;
            string name = root.GetProperty("name").GetString();

            if (name == null) 
                throw new Exception("Значение свойства name не может быть null");

            AppType appType = new AppType(){Name = name};

            await UOW.AppTypes.AddAsync(appType);
            await UOW.SaveChangesAsync();
        }

        public async Task AddStringFieldInAppTypeAsync(int appTypeId, JsonDocument doc)
        {
            if (await UOW.AppTypes.GetByIdAsync(appTypeId) == null)
                throw new Exception($"Тип заявки с id={appTypeId} не найден");

            JsonElement root = doc.RootElement;

            string value = root.GetProperty("value").GetString();
            if (value == null) 
                throw new Exception("Значение свойства value не может быть null");

            StringField stringField = new StringField(){Value = value, AppTypeId = appTypeId};

            await UOW.StringFields.AddAsync(stringField);
            await UOW.SaveChangesAsync();
        }

        public async Task AddNumFieldInAppTypeAsync(int appTypeId, JsonDocument doc)
        {
            if (await UOW.AppTypes.GetByIdAsync(appTypeId) == null)
                throw new Exception($"Тип заявки с id={appTypeId} не найден");

            JsonElement root = doc.RootElement;

            double value = root.GetProperty("value").GetDouble();
            // if (value == null) 
            //    throw new Exception("Значение свойства value не может быть null");

            NumField numField = new NumField(){Value = value, AppTypeId = appTypeId};

            await UOW.NumFields.AddAsync(numField);
            await UOW.SaveChangesAsync();
        }

        public async Task AddDateFieldInAppTypeAsync(int appTypeId, JsonDocument doc)
        {
            if (await UOW.AppTypes.GetByIdAsync(appTypeId) == null)
                throw new Exception($"Тип заявки с id={appTypeId} не найден");

            JsonElement root = doc.RootElement;

            DateTime value = root.GetProperty("value").GetDateTime();
            // if (value == null) 
            //    throw new Exception("Значение свойства value не может быть null");

            DateField dateField = new DateField(){Value = value, AppTypeId = appTypeId};

            await UOW.DateFields.AddAsync(dateField);
            await UOW.SaveChangesAsync();
        }

        public async Task AddTimeFieldInAppTypeAsync(int appTypeId, JsonDocument doc)
        {
            if (await UOW.AppTypes.GetByIdAsync(appTypeId) == null)
                throw new Exception($"Тип заявки с id={appTypeId} не найден");

            JsonElement root = doc.RootElement;

            DateTime value = root.GetProperty("value").GetDateTime();
            // if (value == null) 
            //    throw new Exception("Значение свойства value не может быть null");

            TimeField timeField = new TimeField(){Value = value, AppTypeId = appTypeId};

            await UOW.TimeFields.AddAsync(timeField);
            await UOW.SaveChangesAsync();
        }

        public async Task AddFileFieldInAppTypeAsync(int appTypeId, JsonDocument doc)
        {
            if (await UOW.AppTypes.GetByIdAsync(appTypeId) == null)
                throw new Exception($"Тип заявки с id={appTypeId} не найден");

            JsonElement root = doc.RootElement;

            byte[] value = root.GetProperty("value").GetBytesFromBase64();
            if (value == null) 
                throw new Exception("Значение свойства value не может быть null");

            FileField fileField = new FileField(){Value = value, AppTypeId = appTypeId};

            await UOW.FileFields.AddAsync(fileField);
            await UOW.SaveChangesAsync();
        }

        public async Task AddStatusInAppTypeAsync(int appTypeId, JsonDocument doc)
        {
            if (await UOW.AppTypes.GetByIdAsync(appTypeId) == null)
                throw new Exception($"Тип заявки с id={appTypeId} не найден");

            JsonElement root = doc.RootElement;

            string value = root.GetProperty("value").GetString();
            if (value == null) 
                throw new Exception("Значение свойства value не может быть null");

            Status status = new Status(){Value = value, AppTypeId = appTypeId};

            await UOW.Statuses.AddAsync(status);
            await UOW.SaveChangesAsync();
        }

        public async Task ChangeAppTypeAsync(int appTypeId, JsonDocument doc)
        {
            JsonElement root = doc.RootElement;

            String name = root.GetProperty("name").GetString();
            if (name == null) 
                throw new Exception("Значение свойства name не может быть null");

            AppType appType = await UOW.AppTypes.GetByIdAsync(appTypeId);
            if (appType == null)
                throw new Exception($"Тип заявки с id={appTypeId} не найден");

            appType.Name = name;

            UOW.AppTypes.Update(appType);
            await UOW.SaveChangesAsync();
        }

        public async Task ChangeStringFieldInAppTypeAsync(int appTypeId, int stringFieldId, JsonDocument doc)
        {
            JsonElement root = doc.RootElement;

            string value = root.GetProperty("value").GetString();
            if (value == null) 
                throw new Exception("Значение свойства value не может быть null");

            if (await UOW.AppTypes.GetByIdAsync(appTypeId) == null)
                throw new Exception($"Тип заявки с id={appTypeId} не найден");

            StringField stringField = await UOW.StringFields.GetByIdAsync(stringFieldId);
            if (stringField == null)
                throw new Exception($"Поле с id={stringFieldId} не найдено");

            stringField.Value = value;

            UOW.StringFields.Update(stringField);
            await UOW.SaveChangesAsync();
        }

        public async Task ChangeNumFieldInAppTypeAsync(int appTypeId, int numFieldId, JsonDocument doc)
        {
            JsonElement root = doc.RootElement;

            double value = root.GetProperty("value").GetDouble();
            // if (value == null) 
            //    throw new Exception("Значение свойства value не может быть null");

            if (await UOW.AppTypes.GetByIdAsync(appTypeId) == null)
                throw new Exception($"Тип заявки с id={appTypeId} не найден");

            NumField numField = await UOW.NumFields.GetByIdAsync(numFieldId);
            if (numField == null)
                throw new Exception($"Поле с id={numFieldId} не найдено");

            numField.Value = value;

            UOW.NumFields.Update(numField);
            await UOW.SaveChangesAsync();
        }

        public async Task ChangeDateFieldInAppTypeAsync(int appTypeId, int dateFieldId, JsonDocument doc)
        {
            JsonElement root = doc.RootElement;

            DateTime value = root.GetProperty("value").GetDateTime();
            // if (value == null) 
            //    throw new Exception("Значение свойства value не может быть null");

            if (await UOW.AppTypes.GetByIdAsync(appTypeId) == null)
                throw new Exception($"Тип заявки с id={appTypeId} не найден");

            DateField dateField = await UOW.DateFields.GetByIdAsync(dateFieldId);
            if (dateField == null)
                throw new Exception($"Поле с id={dateFieldId} не найдено");

            dateField.Value = value;

            UOW.DateFields.Update(dateField);
            await UOW.SaveChangesAsync();
        }

        public async Task ChangeTimeFieldInAppTypeAsync(int appTypeId, int timeFieldId, JsonDocument doc)
        {
            JsonElement root = doc.RootElement;

            DateTime value = root.GetProperty("value").GetDateTime();
            // if (value == null) 
            //    throw new Exception("Значение свойства value не может быть null");

            if (await UOW.AppTypes.GetByIdAsync(appTypeId) == null)
                throw new Exception($"Тип заявки с id={appTypeId} не найден");

            TimeField timeField = await UOW.TimeFields.GetByIdAsync(timeFieldId);
            if (timeField == null)
                throw new Exception($"Поле с id={timeFieldId} не найдено");

            timeField.Value = value;

            UOW.TimeFields.Update(timeField);
            await UOW.SaveChangesAsync();
        }

        public async Task ChangeFileFieldInAppTypeAsync(int appTypeId, int fileFieldId, JsonDocument doc)
        {
            JsonElement root = doc.RootElement;

            byte[] value = root.GetProperty("value").GetBytesFromBase64();
            if (value == null) 
               throw new Exception("Значение свойства value не может быть null");

            if (await UOW.AppTypes.GetByIdAsync(appTypeId) == null)
                throw new Exception($"Тип заявки с id={appTypeId} не найден");

            FileField fileField = await UOW.FileFields.GetByIdAsync(fileFieldId);
            if (fileField == null)
                throw new Exception($"Поле с id={fileFieldId} не найдено");

            fileField.Value = value;

            UOW.FileFields.Update(fileField);
            await UOW.SaveChangesAsync();
        }

        public async Task ChangeStatusInAppTypeAsync(int appTypeId, int statusId, JsonDocument doc)
        {
            JsonElement root = doc.RootElement;

            string value = root.GetProperty("value").GetString();
            if (value == null) 
                throw new Exception("Значение свойства value не может быть null");

            if (await UOW.AppTypes.GetByIdAsync(appTypeId) == null)
                throw new Exception($"Тип заявки с id={appTypeId} не найден");

            Status status = await UOW.Statuses.GetByIdAsync(statusId);
            if (status == null)
                throw new Exception($"Поле с id={statusId} не найдено");

            status.Value = value;

            UOW.Statuses.Update(status);
            await UOW.SaveChangesAsync();
        }

        public async Task ChangeStatusInAppAsync(int appId, JsonDocument doc)
        {
            JsonElement root = doc.RootElement;

            int newStatusId = root.GetProperty("statusId").GetInt32();
            
            App app = await UOW.Apps.GetByIdAsync(appId);
            if (app == null)
                throw new Exception($"Заявка с id={appId} не найдена");

            IEnumerable<Status> statuses = await UOW.Statuses.GetAllByAppTypeIdAsync(app.AppTypeId);
            if (!statuses.Select(s => s.Id).Contains(newStatusId))
                throw new Exception($"Заявка id={appId} имеет тип id={app.AppTypeId}. Но данный тип не содержит статус id={newStatusId}.");

            app.StatusId = newStatusId;
            UOW.Apps.Update(app);
            await UOW.SaveChangesAsync();

        }

        public async Task AddAppAsync(JsonDocument doc)
        {
            JsonElement root = doc.RootElement;

            string name = root.GetProperty("name").GetString();
            if (name == null)
                throw new Exception("Значение свойства name не может быть null");

            int appTypeId = root.GetProperty("appTypeId").GetInt32();

            int statusId = root.GetProperty("statusId").GetInt32();

            AppType appType = await UOW.AppTypes.GetByIdAsync(appTypeId);
            if (appType == null)
                throw new Exception($"Тип заявок с id={appTypeId} не найден");

            IEnumerable<Status> statuses = await UOW.Statuses.GetAllByAppTypeIdAsync(appTypeId);
            if (!statuses.Select(s => s.Id).Contains(statusId))
                throw new Exception($"В типе id={appTypeId} не содержится статуса id={statusId}.");

            App app = new App(){Name = name, AppTypeId = appTypeId, StatusId = statusId};

            await UOW.Apps.AddAsync(app);
            await UOW.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if(disposed)
                return;

            if(disposing)
            {
                UOW?.Dispose();
                // Console.WriteLine($"object {this.ToString()} Dispose"); // Проверка работы Dispose()
            }
            
            disposed = true;
        }
 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
