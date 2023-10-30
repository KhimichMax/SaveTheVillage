using UnityEngine;
using UnityEngine.UI;

public class TimerClock : MonoBehaviour
{
    public float maxTime;
    public bool tick;
    
    private Image img;
    private float currentTime;
    
    void Start()
    {
        img = GetComponent<Image>();
        currentTime = maxTime;
    }
    
    void Update()
    {
        tick = false;
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            currentTime = maxTime;
            tick = true;
        }
        img.fillAmount = currentTime / maxTime;
    }
}
