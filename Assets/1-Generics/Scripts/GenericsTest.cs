using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generics
{
    public class GenericsTest : MonoBehaviour
    {
        public CustomList<GameObject> gameObjects;

        // Use this for initialization
        void Start()
        {
            gameObjects = new CustomList<GameObject>();
            gameObjects.Add(new GameObject());

            GameObject firstObject = gameObjects[0];
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
