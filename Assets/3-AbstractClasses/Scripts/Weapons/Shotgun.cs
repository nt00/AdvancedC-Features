using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Preprocessor Directives
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AbstractClasses
{
    public class Shotgun : Weapon
    {
        public int shells = 10;
        public float shootAngle = 45f;
        public float shootRadius = 5f;

        private Vector2 leftDir;
        private Vector2 rightDir;

        public Vector2 GetDir(float angleD)
        {
            float angleR = angleD * Mathf.Deg2Rad;
            Vector2 dir = new Vector2(Mathf.Cos(angleR), Mathf.Sin(angleR));
            return transform.rotation * dir;
        }

        public override void Fire()
        {
            // Loop through and spawn bullets
            for (int i = 0; i < shells; i++)
            {
                //Spawn a new bullet called 'b'
                Bullet b = SpawnBullet(transform.position, transform.rotation);
                //Calculate rnadom angle using shootAngle(Random.Range)
                float randomAngle = Random.Range(-shootAngle, shootAngle);
                //GetDir using the randomAngle
                Vector3 direction = GetDir(randomAngle);
                //Set b's aliveDistance to shootRadis
                b.aliveDistance = shootRadius;
                //Call b.Fire() and pass direction
                b.Fire(direction);
            }

                //Fire each bullet in the range amd direction of player
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
#if UNITY_EDITOR
    [CanEditMultipleObjects]
    [CustomEditor(typeof(Shotgun))]
    public class ShotgunEditor : Editor
    {
        void OnSceneGUI()
        {
            Shotgun shotgun = (Shotgun)target;

            Transform transform = shotgun.transform;
            Vector2 pos = transform.position;

            float angle = shotgun.shootAngle;
            float radius = shotgun.shootRadius;

            Vector2 leftDir = shotgun.GetDir(angle);
            Vector2 rightDir = shotgun.GetDir(-angle);


            Handles.color = Color.magenta;
            Handles.DrawLine(pos, pos + leftDir * shotgun.shootRadius);
            Handles.DrawLine(pos, pos + rightDir * shotgun.shootRadius);

            Handles.color = Color.blue;
            Handles.DrawWireArc(pos, Vector3.forward, rightDir, angle * 2, radius);
        }

    }

#endif
}
