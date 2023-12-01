using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTowers : MonoBehaviour
{
    private GameObject upgradeMenu;
    // Start is called before the first frame update
    void Start()
    {
        upgradeMenu = transform.Find("UpgradeMenu").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        upgradeMenu.SetActive(true);
    }

    public void Deselect()
    {
        upgradeMenu.SetActive(false);
    }
}
