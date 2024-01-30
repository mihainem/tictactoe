using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class LoseLogic
    {
        // A Test behaves as an ordinary method
        [Test]
        public void Lose()
        {
            // Use the Assert class to test conditions
            List<int[]> loseSolutions = new List<int[]> {    new int[] {1,0,1,
                                                                        0,1,0,
                                                                        1,0,0},
                                                             new int[] {0,0,1,
                                                                        1,0,1,
                                                                        0,1,1},
                                                             new int[] {1,1,1,
                                                                        1,0,0,
                                                                        0,0,1},
                                                             new int[] {1,1,0,
                                                                        1,0,0,
                                                                        1,0,1},
                                                             new int[] {1,0,0,
                                                                        0,0,1,
                                                                        1,1,1},
                                                             new int[] {1,0,0,
                                                                        1,1,1,
                                                                        0,1,0},
                                                             new int[] {1,0,1,
                                                                        0,1,0,
                                                                        0,1,1},
                                                             new int[] {1,1,0,
                                                                        0,1,0,
                                                                        0,1,1},
                                                              };
            GridChecker gridChecker = new GridChecker();
            for (int i = 0; i < loseSolutions.Count; i++)
            {
                Assert.AreEqual(GameResult.Lose, gridChecker.GetResult(0, loseSolutions[i]));
            }
        }
    }
}
