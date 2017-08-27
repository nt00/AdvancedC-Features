using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClasses
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Explosive : Bullet
    {
        public int explosionDamage = 10;
        public float explosionRadius = 5f;
        public GameObject explosionParticles;

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

        void Explode()
        {
            //Create explosion animation at positon
            Instantiate(explosionParticles, transform.position, Quaternion.identity);
            //Destroys the bullet
            Destroy(gameObject);
        }

        void OnCollisionEnter(Collision other)
        {
            //Upon colliding, calls the explode function
            Explode();
        }
    }
}
