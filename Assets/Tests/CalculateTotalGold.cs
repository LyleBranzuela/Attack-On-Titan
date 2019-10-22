using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class NewTestScript
    {
       
        // A Test behaves as an ordinary method
        [Test]
        public void NewTestScriptSimplePasses()
        {
            var killedEnemies = 1;
            var goldPoint = 100;
            var expectedGold = 100 * 1 + 250;
            var gold = goldCalculator(killedEnemies, goldPoint);

            Assert.That(gold, Is.EqualTo(expectedGold));
            // Use the Assert class to test conditions
        }

        public int goldCalculator(int enemies, int goldPoint)
        {
            return enemies * goldPoint+250;
        }
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
