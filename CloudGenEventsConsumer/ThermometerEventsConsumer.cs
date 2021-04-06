using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudGenEventsConsumer.Shared.Converters;
using CloudGenEventsConsumer.Shared.CustomTypes;
using CloudGenEventsConsumer.Shared.Events;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CloudGenEventsConsumer
{
    public static class SchumagEventsConsumer
    {
        [FunctionName("ThermomterEventsConsumer")]
        [return: ServiceBus("thermometervaluesupdated", Connection = "ServicesBusConnection")]
        public static async Task<string> Run([EventHubTrigger("globalazurethermometer", Connection = "EventHubConnection")]
            EventData[] events, ILogger log)
        {
            log.LogInformation("Start listen to schumag eventhub");

            var exceptions = new List<Exception>();

            foreach (EventData eventData in events)
            {
                if (eventData.Body == null || eventData.Body.Array == null)
                    continue;
                
                try
                {
                    var messageBody = Encoding.UTF8.GetString(eventData.Body.Array, eventData.Body.Offset,
                        eventData.Body.Count);

                    log.LogInformation("Deserialize eventData Body");
                    var thermometerValuesUpdated = JsonConvert.DeserializeObject<ThermometerValuesUpdated>(messageBody);

                    var celsiusTemperature =
                        TemperatureConverter.FromFahrenheitToCelsius(thermometerValuesUpdated.Temperature);

                    thermometerValuesUpdated = new ThermometerValuesUpdated(thermometerValuesUpdated.DeviceId,
                        thermometerValuesUpdated.EventId,
                        thermometerValuesUpdated.DeviceName,
                        celsiusTemperature,
                        new UnitOfMeasurement("C"),
                        thermometerValuesUpdated.CommunicationDate,
                        thermometerValuesUpdated.Who, thermometerValuesUpdated.When);
                    
                    return JsonConvert.SerializeObject(thermometerValuesUpdated);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                    log.LogError(ex.Message);
                }
            }
            
            if (exceptions.Count > 1)
                throw new AggregateException(exceptions);

            if (exceptions.Count == 1)
                throw exceptions.Single();

            return string.Empty;
        }
    }
}