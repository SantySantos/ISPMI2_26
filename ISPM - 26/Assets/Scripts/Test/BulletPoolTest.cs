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
        /*
        // Arrange
        var obj = new BulletPool();

        int expectedNum = bulletNum;

        // Act
        obj.SetPoolSize(expectedNum);
        

        // Let Unity run one frame (important for MonoBehaviour lifecycle)


        // Assert
        Assert.AreEqual(expectedNum, pool.PoolSize);

        */
        yield return null;
    }

    [UnityTest]
    public IEnumerator AudioVolume()
    {
        float expectedVolume = 0.3f;
        float actualVolume;

        //actualVolume = AudioManager.AudioInstance.SFXVolume;
        yield return null;

       //Assert.AreNotEqual((float)expectedVolume, actualVolume);
    }
}
