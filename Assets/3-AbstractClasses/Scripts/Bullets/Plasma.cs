using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClasses
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Plasma : Bullet
    {

        void Update()
        {
            float distance = Vector3.Distance(shotPos, transform.position);
            if (distance > aliveDistance)
            {
                Destroy(gameObject);
            }
        }

        public override void Fire(Vector3 direction, float? speed = null)
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
