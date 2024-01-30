using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TieLogic
    {
        // A Test behaves as an ordinary method
        [Test]
        public void Tie()
        {
            // Use the Assert class to test conditions
            List<int[]> tieSolutions = new List<int[]> {    new int[] {1,0,0,
                                                                        0,1,1,
                                                                        1,0,0},
                                                             new int[] {1,0,1,
                                                                        0,1,0,
                                                                        0,1,0},
                                                             new int[] {1,0,1,
                                                                        1,0,0,
                                                                        0,1,1},
                                                             new int[] {0,1,0,
                                                                        0,1,1,
                                                                        1,0,1},
                                                             new int[] {1,1,0,
                                                                        0,0,1,
                                                                        1,1,0},
                                                             new int[] {1,0,1,
                                                                        1,0,0,
                                                                        0,1,0},
                                                             new int[] {0,0,1,
                                                                        1,1,0,
                                                                        0,1,1},
                                                             new int[] {1,0,1,
                                                                        1,0,0,
                                                                        0,1,1},
                                                              };
            GridChecker gridChecker = new GridChecker();
            for (int i = 0; i < tieSolutions.Count; i++)
            {
                Assert.AreEqual(GameResult.Tie, gridChecker.GetResult(0, tieSolutions[i]));
            }
        }
    }
}
