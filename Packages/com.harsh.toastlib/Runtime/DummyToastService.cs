using UnityEngine;

namespace Harsh.ToastSDK
{
    public class DummyToastService : IToastService
    {
        public void Show(string message)
        {
            Debug.Log("Toast Message: " + message);
        }
    }
}
