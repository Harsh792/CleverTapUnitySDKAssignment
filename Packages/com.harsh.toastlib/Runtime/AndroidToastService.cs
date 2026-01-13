#if UNITY_ANDROID
using UnityEngine;

namespace Harsh.ToastSDK
{
    public class AndroidToastService : IToastService
    {
        public void Show(string message)
        {
            AndroidJavaClass unityPlayer =
                new AndroidJavaClass("com.unity3d.player.UnityPlayer");

            AndroidJavaObject activity =
                unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            AndroidJavaClass toastClass =
                new AndroidJavaClass("android.widget.Toast");

            activity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toast = toastClass.CallStatic<AndroidJavaObject>(
                    "makeText",
                    activity,
                    message,
                    toastClass.GetStatic<int>("LENGTH_SHORT"));

                toast.Call("show");
            }));
        }
    }
}
#endif
