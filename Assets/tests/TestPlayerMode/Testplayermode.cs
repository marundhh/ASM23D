using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class Testplayermode
{

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        SceneManager.LoadScene("StartScene");
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestGameStart()
    {

        GameObject playerButton = GameObject.Find("Canvas/Image/Play");
       Button stratgame = playerButton.GetComponent<Button>();

        stratgame.onClick.Invoke();
        yield return new WaitForSeconds(1f);

        Assert.AreEqual("Play",SceneManager.GetActiveScene().name);

    }
    [UnityTest]
    public IEnumerator TestVolumSetting()
    {
        var volumSiler = GameObject.Find("Canvas/Image/MusicSlide").GetComponent<Slider>();
        volumSiler.value = 0.5f;

        Assert.AreEqual(0.5f,volumSiler.value);
        yield return null;
    }
    [TestFixture]
    public class PlayerControllerTest
    {
        private class MockPlayerController : PlayerController1
        {
            public KeyCode simulatedKey;

            public override bool GetKey(KeyCode key)
            {
                return key == simulatedKey;
            }
        }

        [UnityTest]
        public IEnumerator TestMoveForward_WhenPressW()
        {
            var playerGO = new GameObject();
            var mockController = playerGO.AddComponent<MockPlayerController>();
            mockController.simulatedKey = KeyCode.W;

            Vector3 startPosition = playerGO.transform.position;

            yield return new WaitForSeconds(0.1f); // Chờ 1 frame Update

            Vector3 newPosition = playerGO.transform.position;

            Assert.Greater(newPosition.z, startPosition.z, "Không di chuyển tới trước khi nhấn W");
        }

        [UnityTest]
        public IEnumerator TestMoveLeft_WhenPressA()
        {
            var playerGO = new GameObject();
            var mockController = playerGO.AddComponent<MockPlayerController>();
            mockController.simulatedKey = KeyCode.A;

            Vector3 startPosition = playerGO.transform.position;

            yield return new WaitForSeconds(0.1f);

            Vector3 newPosition = playerGO.transform.position;

            Assert.Less(newPosition.x, startPosition.x, "Không di chuyển trái khi nhấn A");
        }

        [UnityTest]
        public IEnumerator TestMoveBack_WhenPressS()
        {
            var playerGO = new GameObject();
            var mockController = playerGO.AddComponent<MockPlayerController>();
            mockController.simulatedKey = KeyCode.S;

            Vector3 startPosition = playerGO.transform.position;

            yield return new WaitForSeconds(0.1f); // chờ 1 frame

            Vector3 newPosition = playerGO.transform.position;

            Assert.Less(newPosition.z, startPosition.z, "Không di chuyển lùi khi nhấn S");
        }

        [UnityTest]
        public IEnumerator TestMoveRight_WhenPressD()
        {
            var playerGO = new GameObject();
            var mockController = playerGO.AddComponent<MockPlayerController>();
            mockController.simulatedKey = KeyCode.D;

            Vector3 startPosition = playerGO.transform.position;

            yield return new WaitForSeconds(0.1f); // chờ 1 frame

            Vector3 newPosition = playerGO.transform.position;

            Assert.Greater(newPosition.x, startPosition.x, "Không di chuyển phải khi nhấn D");
        }
    }

    // A Test behaves as an ordinary method
    [Test]
    public void TestplayermodeSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestplayermodeWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
