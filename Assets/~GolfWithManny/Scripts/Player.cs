using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GolfWithManny
{
    public class Player : MonoBehaviour
    {
        public float speed = 20f;
        private Rigidbody rigid;

        void Awake()
        {
            rigid = GetComponent<Rigidbody>();
        }
        public void Move(Vector3 direction)
        {
            rigid.AddForce(direction * speed, ForceMode.Impulse);
        }
    }
}
