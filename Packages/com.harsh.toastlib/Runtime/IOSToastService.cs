#if UNITY_IOS
using System.Runtime.InteropServices;

namespace Harsh.ToastSDK
{
    public class IOSToastService : IToastService
    {
        [DllImport("__Internal")]
        private static extern void ShowNativeToast(string message);

        public void Show(string message)
        {
            ShowNativeToast(message);
        }
    }
}
#endif
