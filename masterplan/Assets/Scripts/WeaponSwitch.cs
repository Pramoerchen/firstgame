using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public int selectedWeapon = 0;
    List<Transform> active_weapons = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        selectWeapon();
    }

    // Update is called once per frame
    void Update()
    {



        int previousSelectedWeapon = selectedWeapon;
        if (Input.GetAxis("Mouse ScrollWheel")>0f)
        {
            if (selectedWeapon >= active_weapons.Count)
                selectedWeapon = 0;
            else
            selectedWeapon++;
        }
        if(Input.GetAxis("Mouse ScrollWheel") <0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = active_weapons.Count;
            else
                selectedWeapon--;
        }
        if(previousSelectedWeapon != selectedWeapon)
        {
            selectWeapon();
        }
    }
    void selectWeapon()
    {
        
        foreach(Transform weapon in transform)
        {
            if (weapon.GetComponent<Gun>().isBuyed && !active_weapons.Contains(weapon))
                active_weapons.Add(weapon);

            if (!weapon.GetComponent<Gun>().isBuyed && active_weapons.Contains(weapon))
                active_weapons.Remove(weapon);

            weapon.gameObject.SetActive(false);
            Debug.Log(active_weapons.Count);

        }
        
        int i = 0;
        foreach(Transform weapon in active_weapons)
        {
            if (i == selectedWeapon && weapon.GetComponent<Gun>().isBuyed)
                weapon.gameObject.SetActive(true);

            i++;
            
        }
    }
}
