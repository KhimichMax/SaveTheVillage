using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MainMechanism : MonoBehaviour
{
    public Text foodCount;
    public Text warriorCount;
    public Text peasantCount;
    public Text enemyCount;
    public Text countCycleText;
    public TimerClock globalCycle;
    public TimerClock cycleAttackImgTimer;
    public GameObject gameOverScren;
    [SerializeField] private Button getPeasantButton;
    [SerializeField] private Button getWarriorButton;
    [SerializeField] private Image peasantImgTimer;
    [SerializeField] private Image warriorImgTimer;
    
    private float peasantTimer = -2;
    private float warriorTimer = -2;
    public float peasantCreateTimer;
    public float warriorCreateTimer;
    //public float cycleAttackCreateTimer;
    public int storageCountFood;
    public int storageCountPeasant;
    public int storageCountWarrior;
    public int storageCountEnemy;
    public int getCycleFood;
    public int payCycleFood;
    public int costForAllFood;
    
    public void UpdateText()
    {
        warriorCount.text = storageCountWarrior.ToString();
        foodCount.text = storageCountFood.ToString();
        peasantCount.text = storageCountPeasant.ToString();
        enemyCount.text = storageCountEnemy.ToString();
    }

    public void AddFoodOnCycle()
    {
        storageCountFood += storageCountPeasant * getCycleFood;
    }

    public void SubtractFoodOnCycle()
    {
        storageCountFood -= storageCountWarrior * payCycleFood;
    }

    public void OnClickGetPeasant()
    {
        storageCountFood -= costForAllFood;
        peasantTimer = peasantCreateTimer;
        getPeasantButton.interactable = false;
    }
    
    public void OnClickGetWarrior()
    {
        storageCountFood -= costForAllFood;
        warriorTimer = warriorCreateTimer;
        getWarriorButton.interactable = false;
    }
    
    
    void Start()
    {
        UpdateText();
    }
    
    void Update()
    {
        if (globalCycle.tick)
        {
            AddFoodOnCycle();
            SubtractFoodOnCycle();
            UpdateText();
        }
        else
        {
            UpdateText();
        }

        if (cycleAttackImgTimer.tick)
        {
            if (storageCountWarrior >= 2)
            {
                storageCountWarrior -= storageCountEnemy;
                storageCountEnemy += 2;
            }else if (storageCountWarrior <= 0)
            {
                Time.timeScale = 0;
                gameOverScren.SetActive(true);
            }
        }

        if (peasantTimer > 0)
        {
            peasantTimer -= Time.deltaTime;
            peasantImgTimer.fillAmount = peasantTimer / peasantCreateTimer;
        }else if (peasantTimer > -1)
        {
            peasantImgTimer.fillAmount = 1;
            getPeasantButton.interactable = true;
            storageCountPeasant += 1;
            peasantTimer = -2;
        }
        
        if (warriorTimer > 0)
        {
            warriorTimer -= Time.deltaTime;
            warriorImgTimer.fillAmount = warriorTimer / warriorCreateTimer;
        }else if (warriorTimer > -1)
        {
            warriorImgTimer.fillAmount = 1;
            getWarriorButton.interactable = true;
            storageCountWarrior += 1;
            warriorTimer = -2;
        }
    }
}
