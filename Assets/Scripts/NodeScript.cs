using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Scripts
{
    public class NodeScript : MonoBehaviour
    {
        public GameObject destination;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.GetComponent<EnemyScript>().setDestination(destination);
        }
    }
}


