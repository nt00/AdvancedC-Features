using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegates
{
    public class EnemySpawner : MonoBehaviour
    {
        public Transform target;
        public GameObject orcPrefab;
        public GameObject trollPrefab;
        public float minAmount = 0, maxAmount = 20;
        public float spawnRate = 1f;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// goal is to call those two functions
        /// randomly using delegates
        /// </summary>
        void SpawnTroll()
        {
            //Spawn Troll Prefab
            //SetTarget on troll to target
        }

        void SpawnOrc()
        {
            //Spawn Orc Prefab
            //SetTarget on Orc to target
        }
    }
}
