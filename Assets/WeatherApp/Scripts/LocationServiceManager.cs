#if UNITY_ANDROID
using UnityEngine.Android;
#endif
using System.Collections;
using UnityEngine;

namespace WeatherApp
{
    public class LocationServiceManager : MonoBehaviour
    {
        public bool IsReady { get; private set; }
        public float Latitude { get; private set; }
        public float Longitude { get; private set; }

        private void Start()
        {
#if UNITY_ANDROID
            StartCoroutine(RequestPermissionAndStartLocation());
#else
    StartCoroutine(StartLocationService());
#endif
        }

        private IEnumerator RequestPermissionAndStartLocation()
        {
#if UNITY_ANDROID
            if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
            {
                Permission.RequestUserPermission(Permission.FineLocation);

                // Wait until user responds to permission dialog
                while (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
                {
                    yield return null;
                }
            }
#endif
            yield return StartCoroutine(StartLocationService());
        }

        private IEnumerator StartLocationService()
        {
            if (!Input.location.isEnabledByUser)
            {
                Debug.LogError("Location service not enabled by user");
                yield break;
            }

            Input.location.Start();

            int maxWait = 20;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                yield return new WaitForSeconds(1);
                maxWait--;
            }

            if (Input.location.status == LocationServiceStatus.Failed)
            {
                Debug.LogError("Location service failed");
                yield break;
            }

            if (Input.location.status != LocationServiceStatus.Running)
            {
                Debug.LogError("Location service not running");
                yield break;
            }

            Latitude = Input.location.lastData.latitude;
            Longitude = Input.location.lastData.longitude;

            Debug.Log($"Location ready: {Latitude}, {Longitude}");

            IsReady = true;
        }
    }
}
