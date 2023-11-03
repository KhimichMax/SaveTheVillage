using UnityEngine;

namespace DefaultNamespace
{
    public class Rules : MonoBehaviour
    {
        public GameObject menuSceneGame;
        public GameObject rulesSceneGame;

        public void ReversToMenu()
        {
            menuSceneGame.SetActive(true);
            rulesSceneGame.SetActive(false);
        }
    }
}