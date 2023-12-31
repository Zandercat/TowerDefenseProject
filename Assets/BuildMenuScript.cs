using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenuScript : MonoBehaviour
{
    public GameObject upgrade;
    public int upgradePrice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        bool canAffordUpgrade = GameObject.Find("Canvas").GetComponent<UIScript>().spendMoney(upgradePrice);
        if (!canAffordUpgrade) return;

        //spawn the upgraded self and destroy the current self
        GameObject parent = transform.parent.parent.gameObject;
        Instantiate(upgrade, parent.transform.position, Quaternion.identity);
        Debug.Log("Built a " + upgrade.name + " tower.");
        Destroy(parent);
    }
}
