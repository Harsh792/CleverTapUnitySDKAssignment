using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace WeatherApp
{
    public class WeatherApiService : MonoBehaviour
    {
        public IEnumerator GetWeather(float lat, float lon, System.Action<float> onResult)
        {
            string url =
                $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&timezone=IST&daily=temperature_2m_max";

            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError(request.error);
                    yield break;
                }

                WeatherResponse response =
                    JsonUtility.FromJson<WeatherResponse>(request.downloadHandler.text);

                float todayTemp = response.daily.temperature_2m_max[0];
                onResult?.Invoke(todayTemp);
            }
        }
    }
}
