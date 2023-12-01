using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                Debug.Log("CLICKED " + hit.collider.name);
                hit.collider.gameObject.SendMessage("OnClick");
                GameObject[] Towers = GameObject.FindGameObjectsWithTag("Tower");
                foreach (GameObject p in Towers)
                {
                    if (p != hit.collider.gameObject)
                    {
                        p.SendMessage("Deselect");
                    }
                }
            }
            else
            {
                GameObject[] Towers = GameObject.FindGameObjectsWithTag("Tower");
                foreach (GameObject p in Towers)
                {
                    p.SendMessage("Deselect");
                }
            }
        }
    }
}
