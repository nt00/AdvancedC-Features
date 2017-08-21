using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClasses
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        public float speed = 10f;
        public float aliveDistance = 5f;

        private Rigidbody2D rigid;
        private Vector3 shotPos; // Position it fired from

        void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            shotPos = transform.position;
        }

        void Update()
        {
            float distance = Vector3.Distance(shotPos, transform.position);
            if (distance > aliveDistance)
            {
                Destroy(gameObject);
            }
        }

        public virtual void Fire(Vector3 direction, float? speed = null)
        {
            //Set currentSpeed to the member speed
            float currentSpeed = this.speed;
            //If the optional argument has been set
            if (speed != null)
            {
                //Replace currentSpeed with the argument
                currentSpeed = speed.Value;
            }
            //Add force in direction and currentSpeed
            rigid.AddForce(direction * currentSpeed, ForceMode2D.Impulse);
        }
    }
}
