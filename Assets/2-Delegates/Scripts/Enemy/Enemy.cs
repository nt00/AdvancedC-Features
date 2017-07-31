using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Delegates
{
    public class Enemy : MonoBehaviour
    {
        public enum Behaviour
        {
            IDLE = 0,
            SEEK = 1
        }

        // Defining a delegate
        delegate void BehaviourFunc();

        public Transform target;
        public Behaviour behaviourIndex = Behaviour.SEEK;

        // Creating a list for the delegates
        private List<BehaviourFunc> behaviourFuncs = new List<BehaviourFunc>();
        private NavMeshAgent agent;

        // Use this for initialization
        void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            //Setup our behaviour
            behaviourFuncs.Add(Idle);
            behaviourFuncs.Add(Seek);
        }

        void Idle()
        {
            //Stop the NavAgent
            agent.Stop();
        }

        void Seek()
        {
            //Resume the NavAgent;
            agent.Resume();
            // If target is not null
            if(target != null)
            {
                // Move agent to target
                agent.SetDestination(target.position);
            }

        }

        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        public bool IsCloseToTarget(float distance)
        {
            //Check if target exists
            if(target != null)
            {
                float distToTarget = Vector3.Distance(transform.position, target.position);
                if(distToTarget <= distance)
                {
                    return true;
                }
            }
            return false;
        }
        // Update is called once per frame
        protected virtual void Update()
        {
            // Call current behaviour function
            behaviourFuncs[(int)behaviourIndex]();
        }
    }
}
