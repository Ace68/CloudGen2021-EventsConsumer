using CloudGenEventsConsumer.Shared.CustomTypes;

namespace CloudGenEventsConsumer.Shared.Converters
{
    public static class TemperatureConverter
    {
        public static Temperature FromFahrenheitToCelsius(Temperature fahrenheitTemperature)
        {
            return new Temperature((fahrenheitTemperature.Value - 32) / 1.8);
        }
    }
}