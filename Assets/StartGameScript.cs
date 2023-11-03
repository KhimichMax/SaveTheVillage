using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScript : MonoBehaviour
{
    public GameObject mainSceneGame;
    public GameObject rulesSceneGame;
    public GameObject menuSceneGame;
    public MainMechanism switchFlag;

    public void StartGameButton()
    {
        switchFlag.flag = true;
        mainSceneGame.SetActive(true);
    }

    public void RulesGameButton()
    {
        rulesSceneGame.SetActive(true);
        menuSceneGame.SetActive(false);
    }
}
