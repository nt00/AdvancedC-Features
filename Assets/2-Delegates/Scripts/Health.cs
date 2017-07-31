using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegates
{
    public class Health : MonoBehaviour
    {
        [SerializeField] protected int health = 100;

        // Update is called once per frame
        void Update()
        {
            //If health <= 0
            if(health <= 0)
            {
                //Destory the gameObject
                Destroy(gameObject);
            }
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }
    }
}
