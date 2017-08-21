﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClasses
{
    public abstract class Weapon : MonoBehaviour
    {
        public GameObject muzzleFlash;
        public GameObject bulletPrefab;
        public int damage = 10;
        public int ammo = 0;
        public int maxAmmo = 30;
        public float recoil = 5;
        public float fireInterval = 0.2f;


        public abstract void Fire();

        public virtual void Reload()
        {
            ammo = maxAmmo;
        }

        public Bullet SpawnBullet(Vector3 position, Quaternion rotation)
        {
            //Instantiate the bullet at position and rotation
            GameObject clone = Instantiate(bulletPrefab, position, rotation);
            Bullet b = clone.GetComponent<Bullet>();
            //Set bullet's direction
            //Instantiate MuzzleFlash
            //Instantiate(muzzleFlash, position, rotation);
            //Play Sound
            //Reduce current ammo by 1
            ammo--;
            //Return bullet
            return b;
        }
    }
}
