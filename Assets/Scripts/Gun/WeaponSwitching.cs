using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 1;

    [SerializeField] GameObject Weapon1, Weapon2;

    private void Start()
    {
        Weapon1.SetActive(true);
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            if(selectedWeapon != 1)
            {
                SwapWeapon(1);
                selectedWeapon = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (selectedWeapon != 2)
            {
                SwapWeapon(2);
                selectedWeapon = 2;
            }
        }
        
    }

    private void SwapWeapon(int weaponType)
    {
        if(weaponType == 1)
        {
            Weapon1.SetActive(true);
            Weapon2.SetActive(false);
        }

        if (weaponType == 2)
        {
            Weapon1.SetActive(false);
            Weapon2.SetActive(true);
        }
    }
}
