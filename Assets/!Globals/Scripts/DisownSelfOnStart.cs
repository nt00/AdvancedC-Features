using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GolfWithManny
{
    public class DisownSelfOnStart : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            // bye parents
            transform.SetParent(null);
        }
    }
}
