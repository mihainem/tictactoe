using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class WinLogic
    {
        /*
        [OneTimeSetUp]
        public void Setup()
        {
            EditorSceneManager.OpenScene("Assets/Scenes/SampleScene.unity", OpenSceneMode.Single);
        }*/

        // A Test behaves as an ordinary method
        [Test]
        public void Win()
        {

            // Use the Assert class to test conditions
            List<int[]> winningSolutions = new List<int[]> { new int[] {0,0,0,
                                                                        0,1,1,
                                                                        1,0,1},
                                                             new int[] {0,1,0,
                                                                        0,1,0,
                                                                        1,0,0},
                                                             new int[] {1,1,0,
                                                                        1,0,1,
                                                                        0,0,0},
                                                             new int[] {0,0,1,
                                                                        0,1,0,
                                                                        0,1,1},
                                                             new int[] {0,1,0,
                                                                        0,0,1,
                                                                        1,1,0},
                                                             new int[] {1,1,0,
                                                                        1,0,1,
                                                                        0,0,1},
                                                             new int[] {1,0,1,
                                                                        1,0,0,
                                                                        1,0,1},
                                                             new int[] {0,0,1,
                                                                        0,1,0,
                                                                        0,1,1},

            };

            GridChecker gridChecker = new GridChecker();
            for (int i = 0; i < winningSolutions.Count; i++)
            {
                Assert.AreEqual(GameResult.Win, gridChecker.GetResult(0, winningSolutions[i]));
            }
        }
    }
}
