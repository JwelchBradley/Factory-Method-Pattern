/*
 * (Jacob Welch)
 * (EnemyWeaponCreator)
 * (Factory Method Pattern)
 * (Description: Handles the creation of enemy weapons.)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponCreator : WeaponCreator
{
    #region Fields
    /// <summary>
    /// The color of enemy weapons.
    /// </summary>
    private Color gunColor = Color.red;
    #endregion

    #region Functions
    /// <summary>
    /// Creates a weapon of a given type with enemy default settings.
    /// </summary>
    /// <param name="type">The type of weapon to spawn.</param>
    /// <returns></returns>
    public override Weapon CreateWeapon(string type)
    {
        // Spawns weapon and adds components
        Weapon weapon = null;
        GameObject weaponObj = Resources.Load<GameObject>(type);
        switch (type)
        {
            case "Pistol":
                weapon = weaponObj.AddComponent<EnemyPistol>();
                break;
            case "Rifle":
                weapon = weaponObj.AddComponent<EnemyRifle>();
                break;
            case "Bazooka":
                weapon = weaponObj.AddComponent<EnemyBazooka>();
                break;
            default:
                Debug.Log("No weapon of given type: " + type.ToUpper());
                break;
        }

        // Sets x position and color
        weaponObj.transform.position = new Vector2(5, 0);
        weaponObj.GetComponent<SpriteRenderer>().color = gunColor;

        // Sets correct scalings
        if (weaponObj.transform.localScale.x > 0)
        {
            var scale = new Vector3(weaponObj.transform.localScale.x * -1, weaponObj.transform.localScale.y, weaponObj.transform.localScale.z);
            weaponObj.transform.localScale = scale;

            var childTransform = weaponObj.transform.GetChild(0);
            var childScale = new Vector3(childTransform.localScale.x * -1, childTransform.localScale.y, childTransform.localScale.z);
            childTransform.localScale = childScale;
        }

        return weapon;
    }
    #endregion
}
