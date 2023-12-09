using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
    public int gold; //public for starting gold purposes
    public TMP_Text goldText;
    public TMP_Text waveNumber;
    public TMP_Text waveCountdown;

    // Start is called before the first frame update
    void Start()
    {
        goldText.text = gold.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gainMoney(int money)
    {
        gold += money;
        goldText.text = gold.ToString();
    }

    public bool spendMoney(int price)
    {
        if (gold >= price)
        {
            gold -= price;
            goldText.text = gold.ToString();
            return true;
        }
        return false;
    }

    public void setWaveNumber(int number)
    {
        waveNumber.text = number.ToString();
    }

    public void setWaveCountdown(int number)
    {
        waveCountdown.text = number.ToString();
    }
}
