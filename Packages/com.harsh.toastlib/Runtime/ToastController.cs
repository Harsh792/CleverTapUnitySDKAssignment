using UnityEngine;

namespace Harsh.ToastSDK
{
    public class ToastController : MonoBehaviour
    {
        private IToastService toastService;

        private void Awake()
        {
            toastService = ToastFactory.Create();
        }

        public void ShowToast(string message)
        {
            toastService.Show(message);
        }
    }
}
