using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClasses
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Shooting : MonoBehaviour
    {
        public int weaponIndex = 0;

        private Weapon[] attachedWeapons;
        private Rigidbody2D rigid;

        //Happens during instantiation as well
        void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        // Use this for initialization
        void Start()
        {
            //Get all attachedWeapons in chidren
            attachedWeapons = GetComponentsInChildren<Weapon>();
            //Set the first weapon
            SwitchWeapon(weaponIndex);
        }

        // Update is called once per frame
        void Update()
        {
            CheckFire();
            WeaponSwitching();
        }
        
        //Checks if the user pressed a button to fire the current weapon
        void CheckFire()
        {
            //Set currentWeapon to attachedWeapons[weaponIndex]
            Weapon currentWeapon = attachedWeapons[weaponIndex];
            //If user pressed down space
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //Fire currentWeapon
                currentWeapon.Fire();
                //Add recoil to player from weapon's recoil
                rigid.AddForce(-transform.right * currentWeapon.recoil,ForceMode2D.Impulse);
            }


        }

        //Handles weapon switching when pressing keys
        void WeaponSwitching()
        {
            if(Input.GetKey(KeyCode.Q))
            {
                CycleWeapon(1);
            }
            if(Input.GetKey(KeyCode.E))
            {
                CycleWeapon(-1);
            }

        }

        //Cylces through weapons using amount as an index
        void CycleWeapon(int amount)
        {
            //SET desiredIndex to weaponIndex + amount
            int desiredIndex = weaponIndex + amount;
            //IF desiredIndex >= length of weapons
            if(desiredIndex >= attachedWeapons.Length)
            {
                //SET desiredIndex to zero
                desiredIndex = 0;
            }
            //ELSE IF desiredIndex < zero
            else if (desiredIndex < 0)
            {
                //SET desiredIndex to length of weapons -1
                desiredIndex = attachedWeapons.Length - 1;
            }
            //SET weaponIndex to desiredIndex
            weaponIndex = desiredIndex;
            //SwitchWeapon() to weaponIndex
            SwitchWeapon(weaponIndex);

        }
        //Disables all other weapons in the list and return the selected one
        Weapon SwitchWeapon (int weaponIndex)
        {
            //Check if index is outside of bounds
            if(weaponIndex < 0 || weaponIndex > attachedWeapons.Length)
            {
                // Return null weapon as error
                return null;
            }
            //Looping through all the weapon
            for (int i = 0; i < attachedWeapons.Length; i++)
            {
                //Get the weapon at index
                Weapon w = attachedWeapons[i];
                //If index == weaponIndex
                if(i == weaponIndex)
                {
                    //Activate the weapon
                    w.gameObject.SetActive(true);
                }
                //ELSE
                else
                {
                    //Deactivate the weapon
                    w.gameObject.SetActive(false);
                }
            }
            //Return selected weapon
            return attachedWeapons[weaponIndex];
        }
    }
}
