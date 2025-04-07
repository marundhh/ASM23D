using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;
using UnityEngine.UI;
using static GameItem;
using static GameUI;
using static GameEffects;

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
        [Test]
        public void UpdateGem_DoesNotGoNegative()
        {
            gameSession.UpdateGem(10);
            gameSession.UpdateGem(-20);

            Assert.AreEqual(0, gameSession.gem, "Gem không được giảm dưới 0.");
            Assert.AreEqual("Gem: 0", gameSession.txtGem.text);
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
        [Test]
        public void UpdateHealth_HealsCorrectly()
        {
            gameSession.UpdateHealth(50);
            gameSession.UpdateHealth(70);

            Assert.AreEqual(70, gameSession.health);
            Assert.AreEqual(70, gameSession.healthSlider.value);
        }
        [Test]
        public void UpdateHealth_DoesNotExceedMax()
        {
            gameSession.UpdateHealth(100);
            gameSession.UpdateHealth(150); // Quá giới hạn 100

            Assert.AreEqual(100, gameSession.health, "Máu không được vượt quá max.");
            Assert.AreEqual(100, gameSession.healthSlider.value);
        }
        
    }
    [Test]
    public void TestMyTestClass()
    {
        MyTestClass a = new MyTestClass();
        a.suadiem(50);
        int x = a.xemdiem();
        Assert.AreEqual(50, x);
    }
    [TestFixture]
    public class InventoryTests
    {
        [Test]
        public void Test_AddItem_ContainsItem()
        {
            var inventory = new Inventory();
            var item = new GameIte("HealthPotion");

            inventory.AddItem(item);

            Assert.IsTrue(inventory.Contains(item));
        }

        [Test]
        public void Test_RemoveItem_NotContainsItem()
        {
            var inventory = new Inventory();
            var item = new GameIte("HealthPotion");

            inventory.AddItem(item);
            inventory.RemoveItem(item);

            Assert.IsFalse(inventory.Contains(item));
        }

        [Test]
        public void Test_InventoryItemCount()
        {
            var inventory = new Inventory();
            var item1 = new GameIte("HealthPotion");
            var item2 = new GameIte("ManaPotion");

            inventory.AddItem(item1);
            inventory.AddItem(item2);

            Assert.AreEqual(2, inventory.ItemCount());
        }
        [Test]
        public void Test_ItemNotAdded_FailsCheck()
        {
            var inventory = new Inventory();
            var item = new GameIte("HealthPotion");

            

            Assert.IsTrue(inventory.Contains(item));
        }
    }
    [TestFixture]
    public class GameUITests
    {
        [Test]
        public void Test_HUD_ToggleVisibility()
        {
            var hud = new GameHUD();

            hud.ToggleHUD();
            Assert.IsFalse(hud.IsVisible, "HUD should be hidden after toggle.");

            hud.ToggleHUD();
            Assert.IsTrue(hud.IsVisible, "HUD should be visible after second toggle.");
        }

        [Test]
        public void Test_Inventory_OpenClose()
        {
            var inventory = new InventoryUI();

            inventory.OpenInventory();
            Assert.IsTrue(inventory.IsOpen, "Inventory should be open.");

            inventory.CloseInventory();
            Assert.IsFalse(inventory.IsOpen, "Inventory should be closed.");
        }

        [Test]
        public void Test_Settings_SetVolume()
        {
            var settings = new GameSettings();

            settings.SetVolume(80);
            Assert.AreEqual(80, settings.Volume, "Volume should be set to 80.");

            settings.SetVolume(-10);
            Assert.AreNotEqual(-10, settings.Volume, "Volume should not be negative.");

            settings.SetVolume(150);
            Assert.AreNotEqual(150, settings.Volume, "Volume should not exceed 100.");
        }
        [Test]
        public void Test_HUD_ToggleVisibility_Fail()
        {
            var hud = new GameHUD();

            // Giả sử HUD đang hiển thị
            Assert.IsTrue(hud.IsVisible, "HUD should start as visible.");

            // Gọi ToggleHUD để ẩn nó
            hud.ToggleHUD();

            // Kiểm tra HUD có bị ẩn hay không, nhưng cố tình kiểm tra sai
            Assert.IsTrue(hud.IsVisible, "HUD should be hidden after toggle."); // Test này sẽ FAIL!
        }
        [TestFixture]
        public class GameEffectsTests
        {
            // Test Sound System
            [Test]
            public void Test_Sound_SetVolume()
            {
                var sound = new SoundSystem();
                sound.SetVolume(80);
                Assert.AreEqual(80, sound.Volume, "Volume should be set to 80.");

                sound.SetVolume(-10);
                Assert.AreNotEqual(-10, sound.Volume, "Volume should not be negative.");

                sound.SetVolume(150);
                Assert.AreNotEqual(150, sound.Volume, "Volume should not exceed 100.");
            }

            [Test]
            public void Test_Sound_MuteUnmute()
            {
                var sound = new SoundSystem();
                sound.Mute();
                Assert.IsTrue(sound.IsMuted, "Sound should be muted.");

                sound.Unmute();
                Assert.IsFalse(sound.IsMuted, "Sound should be unmuted.");
            }

            // Test Animation System
            [Test]
            public void Test_Animation_Play()
            {
                var animation = new AnimationSystem();
                animation.PlayAnimation("Run");
                Assert.AreEqual("Run", animation.CurrentAnimation, "Animation should be 'Run'.");

                animation.PlayAnimation("Jump");
                Assert.AreEqual("Jump", animation.CurrentAnimation, "Animation should be 'Jump'.");
            }

            // Test Effects System
            [Test]
            public void Test_Effect_PlayStop()
            {
                var effects = new EffectsSystem();
                effects.PlayEffect();
                Assert.IsTrue(effects.IsEffectPlaying, "Effect should be playing.");

                effects.StopEffect();
                Assert.IsFalse(effects.IsEffectPlaying, "Effect should be stopped.");
            }
            [Test]
            public void Test_Animation_Fail()
            {
                var animation = new AnimationSystem();

                animation.PlayAnimation("Run");

                // Kiểm tra sai mong đợi, đáng lẽ là "Run" nhưng cố tình kiểm tra "Idle"
                Assert.AreEqual("Idle", animation.CurrentAnimation, "Animation should be 'Idle'."); // Test này sẽ FAIL!
            }
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