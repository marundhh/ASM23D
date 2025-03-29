using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;
using UnityEngine.UI;

public class Scripstest
{
    [TestFixture]
    public class GameSessionTests
    {
        private GameSession gameSession;
        private GameObject gameObject;

        [SetUp]
        public void SetUp()
        {
            // Tạo một GameObject mới để chứa GameSession
            gameObject = new GameObject();
            gameSession = gameObject.AddComponent<GameSession>();

            // Tạo một TextMeshPro giả lập để tránh lỗi NullReferenceException
            var textObject = new GameObject();
            var textComponent = textObject.AddComponent<TextMeshProUGUI>();

            // Gán TextMeshPro vào gameSession
            gameSession.txtGem = textComponent;

            // Đảm bảo giá trị ban đầu của gem là 0
            gameSession.gem = 0;
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(gameObject);
        }
        [Test]
        public void UpdateGem_AddsCorrectAmount()
        {
            gameSession.UpdateGem(10);

            // Cố tình kiểm tra sai giá trị
            Assert.AreEqual(15, gameSession.gem);
        }

        [Test]
        public void UpdateGem_AddsMultipleTimes()
        {
            // Act: Cập nhật gem nhiều lần
            gameSession.UpdateGem(5);
            gameSession.UpdateGem(15);

            // Assert: Tổng số gem có đúng không
            Assert.AreEqual(20, gameSession.gem);
            Assert.AreEqual("Gem: 20", gameSession.txtGem.text);
        }
    }


    [TestFixture]
    public class GameSessionHealthTests
    {
        private GameSession gameSession;
        private GameObject gameObject;

        [SetUp]
        public void SetUp()
        {
            // Tạo một GameObject mới để chứa GameSession
            gameObject = new GameObject();
            gameSession = gameObject.AddComponent<GameSession>();

            // Tạo Slider giả lập để tránh lỗi NullReferenceException
            var sliderObject = new GameObject();
            var sliderComponent = sliderObject.AddComponent<Slider>();

            // Gán Slider vào gameSession
            gameSession.healthSlider = sliderComponent;

            // Thiết lập giá trị ban đầu
            gameSession.health = 100;
            gameSession.healthSlider.maxValue = 100;
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(gameObject);
        }

        [Test]
        public void DecreaseHealth_DecreasesCorrectly()
        {
            // Act: Mất 1 máu
            gameSession.UpdateHealth(gameSession.health - 1);

            // Assert: Kiểm tra xem máu có còn 99 không
            Assert.AreEqual(99, gameSession.health, "Health không bị giảm chính xác.");
        }
    }
    

public void ScripstestSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // yield return null; to skip a frame.
    [UnityTest]
    public IEnumerator ScripstestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}