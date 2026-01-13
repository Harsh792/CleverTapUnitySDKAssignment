using NUnit.Framework;
using Harsh.ToastSDK;
using UnityEngine;

public class ToastFactoryTests
{
    [Test]
    public void ToastFactory_Returns_Service()
    {
        IToastService service = ToastFactory.Create();
        Assert.IsNotNull(service);
    }

    [Test]
    public void ToastController_CanBeAddedToGameObject()
    {
        GameObject go = new GameObject("ToastControllerTest");
        ToastController controller = go.AddComponent<ToastController>();

        Assert.IsNotNull(controller);

        Object.DestroyImmediate(go);
    }
}
