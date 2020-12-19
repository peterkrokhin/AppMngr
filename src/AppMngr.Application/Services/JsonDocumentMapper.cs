using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using AppMngr.Core;
using System.Text.Json;

namespace AppMngr.Application
{
    public class JsonDocumentMapper
    {
        public static double? GetNullableDouble(JsonDocument doc, string nameProperty)
        {
            JsonElement root = doc.RootElement;

            // Поле не найдено
            if (!root.TryGetProperty(nameProperty, out JsonElement current))
                return null;

            // Поле найдено, но значение null
            if (current.GetRawText() == "null")
                return null;

            // Поле найдено, значение не null, но нельзя преобразовать в double
            if (!current.TryGetDouble(out double tmpDouble))
                throw new Exception($"Свойство {nameProperty} найдено, значение не равно null, но значение нельзя привести к типу double");

            // Поле найдено, значение не null, можно преобразовать в double
            return tmpDouble;
               
        }

        public static T Map<T>(JsonElement jsonElement, JsonValueKind jsonValueKind, Func<T> getValueFunc)
        {
            T fieldT = default(T);

            try
            {
                // Json-cвойство найдено, но значение null
                if (jsonElement.ValueKind == JsonValueKind.Null)
                    fieldT = default(T);

                // Json-cвойство найдено, и значение не null
                if (jsonElement.ValueKind == jsonValueKind)
                    fieldT = getValueFunc();
            }
            catch
            {
                // Json-cвойство не найдено: исключение от root.GetProperty("name")
                // Значение нельзя привести к string: исключение от current.GetString()
                // Ничего не делаем.
            }

            return fieldT;
        }

    }
}