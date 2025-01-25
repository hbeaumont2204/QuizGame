using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public Text healthPanel;
    public Text ammoPanel;
    public Text timePanel;
    public float ammo = 90;
    float maxAmmo = 90;
    public int health = 100;
    int maxHealth = 100;
    public float stopwatch = 0;
    float hours;
    float minutes;
    float seconds;
    //bool frozen = false;
    [SerializeField] private Slider ammoSlider;
    [SerializeField] private Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        inflictDamage(0);
        decreaseAmmo(0);
    }

    // Update is called once per frame
    void Update()
    {
        increaseTime();
        updateBars();
        //decreaseTime();
    }

    public void inflictDamage(int damage)
    {
        // Updates the health variable and the UI when the player takes damage.
        if (healthPanel != null && health > 0)
        {
            health = health - damage;
            healthPanel.text = "Health: " + health.ToString();
        }
    }

    public void decreaseAmmo(int decrease)
    {
        if (ammoPanel != null && ammo > 0)
        {
            ammo = ammo - decrease;
            ammoPanel.text = "Ammo:" + ammo.ToString();
        }
    }

    public void increaseTime()
    {
        stopwatch = stopwatch + Time.deltaTime;
        hours = Mathf.Floor(stopwatch / 3600);
        minutes = Mathf.Floor(stopwatch / 60);
        seconds = stopwatch%60;

        string hoursStr = hours.ToString();
        string minsStr = minutes.ToString();
        string secondsStr = Mathf.RoundToInt(seconds).ToString();
        if (seconds < 9)
        {
            secondsStr = "0" + secondsStr;
        }
        if (minutes < 10)
        {
            minsStr = "0" + minsStr;
        }
        if (hours == 0 && minutes == 0)
        {
            timePanel.text = secondsStr;
        }
        else if (hours == 0)
        {
            timePanel.text = minsStr + ":" + secondsStr;
        }
        else
        {
            timePanel.text = hoursStr + ":" + minsStr + ":" + secondsStr;
        }
        
    }

    public void updateBars()
    {
        ammoSlider.value = ammo / maxAmmo;
        healthSlider.value = health / maxHealth;
    }

    /* public void decreaseTime()
    {
        // Time will only decrease if it isn't frozen (can be frozen with the item in the 4th level)
        if (battery > 0 && frozen == false)
        {
            // Displays time on the UI. It is constantly updated to display an accurate time.
            battery = battery - Time.deltaTime;
            batteryPanel.text = "Battery: " + battery.ToString();
        }
        // If the time limit falls below 0, it will be set to zero so negative time isn't displayed on the screen.
        else if (battery < 0)
        {
            battery = 0;
            batteryPanel.text = "Battery: " + battery.ToString();
        }
    } */
}
