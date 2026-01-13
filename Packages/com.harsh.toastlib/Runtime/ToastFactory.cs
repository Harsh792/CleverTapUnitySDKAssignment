namespace Harsh.ToastSDK
{
    public static class ToastFactory
    {
        public static IToastService Create()
        {
#if UNITY_ANDROID
            return new AndroidToastService();
#elif UNITY_IOS
            return new IOSToastService();
#else
            return new DummyToastService();
#endif
        }
    }
}
