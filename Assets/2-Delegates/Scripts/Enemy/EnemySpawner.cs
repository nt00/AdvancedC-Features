using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegates
{
    public class EnemySpawner : MonoBehaviour
    {
        public Transform target;
        public GameObject orcPrefab, trollPrefab;
        public float minAmount = 0, maxAmount = 20;
        public float spawnRate = 1f;

        public enum Spawn
        {
            SpawnTroll = 0,
            SpawnOrc = 1
        }
        //Defining a delegate
        delegate void SpawnFunc();

        public Spawn spawnIndex = Spawn.SpawnTroll;

        //Creating a list for the delegates
        private List<SpawnFunc> spawnFuncs = new List<SpawnFunc>();

        void Awake()
        {
            //Setup Spawn
            spawnFuncs.Add(SpawnTroll);
            spawnFuncs.Add(SpawnOrc);
        }

        protected virtual void Update()
        {
            // Call current spawn function randomly
            int randomIndex = Random.Range(0, spawnFuncs.Count);
            spawnFuncs[randomIndex]();
        }
        /// <summary>
        /// goal is to call those two functions
        /// randomly using delegates    
        /// </summary>
        void SpawnTroll()
        {
            //Spawn Troll Prefab
            GameObject clone = Instantiate(trollPrefab, transform.position, transform.rotation);
            //SetTarget on troll to target
            Enemy enemy = clone.GetComponent<Enemy>();
            enemy.target = target;
        }

        void SpawnOrc()
        {
            //Spawn Orc Prefab
            GameObject clone = Instantiate(orcPrefab, transform.position, transform.rotation);
            //SetTarget on Orc to target
            Enemy enemy = clone.GetComponent<Enemy>();
            enemy.target = target;
        }
    }
}
