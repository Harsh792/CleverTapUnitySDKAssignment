using UnityEngine;
using Harsh.ToastSDK;

namespace WeatherApp
{
    public class WeatherUIController : MonoBehaviour
    {
        public LocationServiceManager locationService;
        public WeatherApiService weatherApi;
        public ToastController toastController;

        public void OnGetWeatherClicked()
        {
            if (!locationService.IsReady)
            {
                toastController.ShowToast("Fetching location...");
                return;
            }

            StartCoroutine(weatherApi.GetWeather(
                locationService.Latitude,
                locationService.Longitude,
                temp =>
                {
                    toastController.ShowToast($"Today's Max Temp: {temp}°C");
                }));
        }
    }
}
