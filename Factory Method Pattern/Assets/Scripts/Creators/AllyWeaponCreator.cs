/*
 * (Jacob Welch)
 * (AllyWeaponCreator)
 * (Factory Method Pattern)
 * (Description: Handles the creation of ally weapons.)
 */
using UnityEngine;

public class AllyWeaponCreator : WeaponCreator
{
    #region Fields
    /// <summary>
    /// The color of ally weapons.
    /// </summary>
    private Color gunColor = Color.green;
    #endregion

    #region Functions
    /// <summary>
    /// Creates a weapon of a given type with ally default settings.
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
                weapon = weaponObj.AddComponent<AllyPistol>();
                break;
            case "Rifle":
                weapon = weaponObj.AddComponent<AllyRifle>();
                break;
            case "Bazooka":
                weapon = weaponObj.AddComponent<AllyBazooka>();
                break;
            default:
                Debug.Log("No weapon of given type: " + type.ToUpper());
                break;
        }

        // Sets x position and color
        weaponObj.transform.position = new Vector2(-5, 0);
        weaponObj.GetComponent<SpriteRenderer>().color = gunColor;

        // Sets correct scalings
        var weaponScale = new Vector3(Mathf.Sign(weaponObj.transform.localScale.x) * weaponObj.transform.localScale.x, weaponObj.transform.localScale.y, weaponObj.transform.localScale.z);
        weaponObj.transform.localScale = weaponScale;

        foreach (Transform transform in weaponObj.transform)
        {
            var scale = new Vector3(Mathf.Sign(transform.localScale.x) * transform.localScale.x, transform.localScale.y, transform.localScale.z);
            transform.localScale = scale;
        }

        return weapon;
    }
    #endregion
}
