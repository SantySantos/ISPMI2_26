using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BulletPoolTest
{
    int bulletNum = 100;

    // A Test behaves as an ordinary method
    [Test]
    public void NumTest()
    {
        int testnum = 100;
        Assert.AreEqual(testnum, bulletNum);    
    }

   
    [UnityTest]
    public IEnumerator BulletPoolSizeTest()
    {
        // Arrange
        GameObject obj = new GameObject();
        BulletPool. pool = obj.AddComponent<BulletPool>();

        int expectedNum = bulletNum;

        // Assign
        pool.SetPoolSize(expectedNum);
        yield return null;

        // Let Unity run one frame (important for MonoBehaviour lifecycle)


        // Assert
        Assert.AreEqual(expectedNum, pool.PoolSize);

        
    }

    [UnityTest]
    public IEnumerator AudioVolume()
    {
        float expectedVolume = 0.3f;
        float actualVolume;

        actualVolume = AudioManager.AudioInstance.SFXVolume;
        yield return null;

        Assert.AreNotEqual((float)expectedVolume, actualVolume);
    }
}
