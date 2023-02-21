/*
 * (Jacob Welch)
 * (WeaponCreator)
 * (Factory Method Pattern)
 * (Description: Handles the base abstract template for creating weapons.)
 */
using System.Collections.Generic;

public abstract class WeaponCreator
{
    #region Fields
    /// <summary>
    /// The list of weapons currently spawned.
    /// </summary>
    private List<Weapon> weaponsSpawned = new List<Weapon>();
    #endregion

    #region Functions
    /// <summary>
    /// Creates a desired weapon of a given type.
    /// </summary>
    /// <param name="type">The type of weapon to be spawned.</param>
    /// <returns></returns>
    public abstract Weapon CreateWeapon(string type);

    /// <summary>
    /// Adds a weapon to the list of currently spawned weapons.
    /// </summary>
    /// <param name="weapon">The weapon that has been spawned.</param>
    public void AddWeapon(Weapon weapon)
    {
        weaponsSpawned.Add(weapon);
    }

    /// <summary>
    /// Returns the current list of weapons that are spawned.
    /// </summary>
    /// <returns></returns>
    public List<Weapon> Weapons()
    {
        return weaponsSpawned;
    }

    /// <summary>
    /// Shoots all of the weapons that are spawned.
    /// </summary>
    public void ShootWeapons()
    {
        foreach(Weapon weapon in weaponsSpawned)
        {
            weapon.Shoot();
        }
    }
    #endregion
}
