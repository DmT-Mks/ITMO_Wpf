using System;
using System.Linq;
using System.Windows;

namespace WpfApp6
{
    public class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        public static readonly DependencyProperty WindDirectionProperty;
        public static readonly DependencyProperty WindSpeedProperty;
        public static readonly DependencyProperty PrecipitationProperty;

        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }

        public string WindDirection
        {
            get => (string)GetValue(WindDirectionProperty);
            set => SetValue(WindDirectionProperty, value);
        }

        public int WindSpeed
        {
            get => (int)GetValue(WindSpeedProperty);
            set => SetValue(WindSpeedProperty, value);
        }

        public PrecipitationType Precipitation
        {
            get => (PrecipitationType)GetValue(PrecipitationProperty);
            set => SetValue(PrecipitationProperty, value);
        }

        public WeatherControl(int temperature, string windDirection, int windSpeed, PrecipitationType precipitation)
        {
            Temperature = temperature;
            WindDirection = windDirection;
            WindSpeed = windSpeed;
            Precipitation = precipitation;
        }

        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    null),
                IsValidTemperature);

            WindDirectionProperty = DependencyProperty.Register(
                nameof(WindDirection),
                typeof(string),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    string.Empty,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    null),
                IsValidWindDirection);

            WindSpeedProperty = DependencyProperty.Register(
                nameof(WindSpeed),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    null),
                IsValidWindSpeed);

            PrecipitationProperty = DependencyProperty.Register(
                nameof(Precipitation),
                typeof(PrecipitationType),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    PrecipitationType.Sunny,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    null),
                IsValidPrecipitation);
        }

        private static bool IsValidTemperature(object value)
        {
            var v = (int)value;

            return v >= -50 && v <= +50;
        }

        private static bool IsValidWindDirection(object value)
        {
            var v = value as string;

            return !string.IsNullOrEmpty(v) && v.All(char.IsLetter);
        }

        private static bool IsValidWindSpeed(object value)
        {
            var v = (int)value;

            return v >= 0;
        }

        private static bool IsValidPrecipitation(object value)
        {
            return value is PrecipitationType enumType && Enum.IsDefined(typeof(PrecipitationType), enumType);
        }

        public enum PrecipitationType
        {
            Sunny = 0,
            Cloudy = 1,
            Rain = 2,
            Snow = 3
        }
    }
}