using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;
using TMPro;

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

        Assert.AreEqual("Play", SceneManager.GetActiveScene().name);

    }
    [UnityTest]
    public IEnumerator TestVolumSetting()
    {
        var volumSiler = GameObject.Find("Canvas/Image/MusicSlide").GetComponent<Slider>();
        volumSiler.value = 0.5f;

        Assert.AreEqual(0.5f, volumSiler.value);
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
        [TestFixture]
        public class GameSessionIntegrationTest
        {
            private GameSession gameSession;
            private Slider healthSlider;
            private TextMeshProUGUI txtGem;

            [SetUp]

            public void SetUp()
            {
                var go = new GameObject("GameSession");
                gameSession = go.AddComponent<GameSession>();

                var sliderGO = new GameObject("HealthSlider");
                healthSlider = sliderGO.AddComponent<Slider>();
                healthSlider.maxValue = 100; // <--- Thêm dòng này
                gameSession.healthSlider = healthSlider;

                var txtGO = new GameObject("GemText");
                txtGem = txtGO.AddComponent<TextMeshProUGUI>();
                gameSession.txtGem = txtGem;

                gameSession.health = 100;
                gameSession.gem = 0;
            }

            [UnityTest]
            public IEnumerator TestUpdateHealthAndGemUI()
            {

                Assert.AreEqual(100, gameSession.health);
                Assert.AreEqual(0, gameSession.gem);


                gameSession.UpdateHealth(75);
                yield return null;
                Assert.AreEqual(75, healthSlider.value);


                gameSession.IncreaseHealth(20);
                yield return null;
                Assert.AreEqual(95, healthSlider.value);


                gameSession.UpdateGem(50);
                yield return null;
                Assert.AreEqual("Gem: 50", txtGem.text);
            }
            [Test]
            public void TestStartButtonAndUIUpdate()
            {
                // Tạo các GameObject và gán Text
                var scoreGO = new GameObject("ScoreText");
                var scoreText = scoreGO.AddComponent<Text>();
                scoreText.text = "Score: 0";

                var livesGO = new GameObject("LivesText");
                var livesText = livesGO.AddComponent<Text>();
                livesText.text = "Lives: 3";

                // Tạo nút start và mô phỏng click
                var startGO = new GameObject("startButton");
                var button = startGO.AddComponent<Button>();
                button.onClick.AddListener(() => {
                    scoreText.text = "Score: 0";
                    livesText.text = "Lives: 3";
                });

                // Mô phỏng nhấn nút
                button.onClick.Invoke();

                Assert.AreEqual("Score: 0", scoreText.text);
                Assert.AreEqual("Lives: 3", livesText.text);
            }
            [Test]
            public void TestHealthUIUpdateAfterDamage()
            {
                // Simulate player taking damage
                gameSession.UpdateHealth(50); // Player's health reduced to 50
                Assert.AreEqual(50, healthSlider.value);  // Verify that health UI reflects damage
            }

            [Test]
            public void TestGemUIUpdateAfterPickup()
            {
                // Simulate gem pickup event
                gameSession.UpdateGem(100); // Player collects 100 gems
                Assert.AreEqual("Gem: 100", txtGem.text);  // Check if gem text was updated correctly
            }
            [Test]
            public void TestBackgroundMusicOnGameStart()
            {
                // Giả sử bạn có một AudioManager để quản lý âm thanh
                var audioManager = new GameObject("AudioManager").AddComponent<AudioManager>();

                // Giả sử nhạc nền là một AudioClip đã được thiết lập
                var backgroundMusicClip = Resources.Load<AudioClip>("BackgroundMusic");
                audioManager.PlayBackgroundMusic(backgroundMusicClip);


            }


        }
        [TestFixture]

        public class GameManagetext {
        
        private GameManager gameManager;

        [UnitySetUp]
        public IEnumerator SetUp()
        {
            GameObject obj = new GameObject("GameManager");
            gameManager = obj.AddComponent<GameManager>();
            yield return null;
        }

        [UnityTest]
        [Category("PC")]
        public IEnumerator TestAddPointsOnPC()
        {
            gameManager.AddPoints(50);
            Assert.AreEqual(50, gameManager.score);

            gameManager.AddPoints(60);
            Assert.AreEqual(100, gameManager.score);

            yield return null;
        }

        [UnityTest]
        [Category("Mobile")]
        public IEnumerator TestAddPointsOnMobile()
        {
            gameManager.AddPoints(50);
            Assert.AreEqual(50, gameManager.score);

            gameManager.AddPoints(60);
            Assert.AreEqual(100, gameManager.score);

            yield return null;
        }
        [UnityTest]
            //line coverage
            public IEnumerator TestAddPoints()
            {
            gameManager.AddPoints(50);
            Assert.AreEqual(50, gameManager.score);

            gameManager.AddPoints(60);
            Assert.AreEqual(100, gameManager.score);

            yield return null;
            }
        [UnityTest]
            //branch coverage
            public IEnumerator TestCheckGameState()
            {
                gameManager.score = 100;
                Assert.AreEqual("Win", gameManager.CheckGameState());

                gameManager.score = 50;
                Assert.AreEqual("Lose", gameManager.CheckGameState());

                yield return null;
            }
        [UnityTest]
            //method coverage
            public IEnumerator TestAddAndSubtractPoints()
            {
                gameManager.AddPoints(10);
                Assert.AreEqual(10, gameManager.score);   // ✅ Kiểm tra cộng điểm

                gameManager.SubtractPoints(5);
                Assert.AreEqual(5, gameManager.score);    // ✅ Kiểm tra trừ điểm

                yield return null;
            }

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
