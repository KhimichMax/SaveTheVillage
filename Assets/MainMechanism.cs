using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMechanism : MonoBehaviour
{
    public Text foodCount;
    public Text warriorCount;
    public Text peasantCount;
    public Text enemyCount;
    public Text countCycleEnd;
    public Text countWarriorEnd;
    public Text countEnemeisEnd;
    public TimerClock globalCycle;
    public TimerClock cycleAttackImgTimer;
    public GameObject gameOverScren;
    public GameObject pausGameScrence;
    public GameObject gameWinScrene;
    public GameObject menuPaus;
    [SerializeField] private Button getPeasantButton;
    [SerializeField] private Button getWarriorButton;
    [SerializeField] private Image peasantImgTimer;
    [SerializeField] private Image warriorImgTimer;

    private bool checkBoolPeasant = true;
    private bool checkBoolWarrior = true;
    private float peasantTimer = -2;
    private float warriorTimer = -2;
    private int finishCountCycle;
    private int finishCountWarrior;
    private int finishCountEnemeis;
    public bool flag;
    public float peasantCreateTimer;
    public float warriorCreateTimer;
    public int storageCountFood;
    public int storageCountPeasant;
    public int storageCountWarrior;
    public int storageCountEnemy;
    public int getCycleFood;
    public int payCycleFood;
    public int costForAllFood;
    public int winCount;
    
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
        checkBoolPeasant = false;
        getPeasantButton.interactable = checkBoolPeasant;
    }
    
    public void OnClickGetWarrior()
    {
        storageCountFood -= costForAllFood;
        warriorTimer = warriorCreateTimer;
        finishCountWarrior++;
        checkBoolWarrior = false;
        getWarriorButton.interactable = checkBoolWarrior;
    }

    public void MenuPaus()
    {
        flag = false;
        Time.timeScale = 0;
        menuPaus.SetActive(true);
    }

    public void OutMenuPaus()
    {
        flag = true;
        Time.timeScale = 1;
        menuPaus.SetActive(false);
    }
    
    public void RestartGame(GameObject obj)
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
        obj.SetActive(false);
    }

    public void StartScene()
    {
        Time.timeScale = 1;
        pausGameScrence.SetActive(false);
    }
    void Start()
    {
        UpdateText();
    }
    
    void Update()
    {
        if (flag)
        {
            Time.timeScale = 1;
            
            if (globalCycle.tick)
            {
                AddFoodOnCycle();
                SubtractFoodOnCycle();
                UpdateText();
                finishCountCycle++;
                if (winCount <= storageCountFood)
                {
                    flag = false;
                    Time.timeScale = 0;
                    countCycleEnd.text = finishCountCycle.ToString();
                    countWarriorEnd.text = finishCountWarrior.ToString();
                    countEnemeisEnd.text = finishCountEnemeis.ToString();
                    gameWinScrene.SetActive(true);
                }
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
                    finishCountEnemeis = storageCountEnemy;
                }else if (storageCountWarrior <= 0)
                {
                    flag = false;
                    Time.timeScale = 0;
                    gameOverScren.SetActive(true);
                }
            }

            if (storageCountFood <= 0)
            {
                storageCountFood = 0;
                checkBoolPeasant = false;
                getPeasantButton.interactable = checkBoolPeasant;
                checkBoolWarrior = false;
                getWarriorButton.interactable = checkBoolWarrior;
            }else if (storageCountFood >= 2)
            {
                checkBoolPeasant = true;
                getPeasantButton.interactable = checkBoolPeasant;
                checkBoolWarrior = true;
                getWarriorButton.interactable = checkBoolWarrior;
            }

            if (peasantTimer > 0)
            {
                checkBoolPeasant = false;
                getPeasantButton.interactable = checkBoolPeasant;
                peasantTimer -= Time.deltaTime;
                peasantImgTimer.fillAmount = peasantTimer / peasantCreateTimer;
            }else if (peasantTimer > -1)
            {
                checkBoolPeasant = true;
                peasantImgTimer.fillAmount = 1;
                getPeasantButton.interactable = checkBoolPeasant;
                storageCountPeasant += 1;
                peasantTimer = -2;
            }
            
            if (warriorTimer > 0)
            {
                checkBoolWarrior = false;
                getWarriorButton.interactable = checkBoolWarrior;
                warriorTimer -= Time.deltaTime;
                warriorImgTimer.fillAmount = warriorTimer / warriorCreateTimer;
            }else if (warriorTimer > -1)
            {
                checkBoolWarrior = true;
                warriorImgTimer.fillAmount = 1;
                getWarriorButton.interactable = true;
                storageCountWarrior += 1;
                warriorTimer = -2;
            }
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
