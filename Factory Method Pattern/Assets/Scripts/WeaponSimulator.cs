/*
 * (Jacob Welch)
 * (WeaponSimulator)
 * (Factory Method Pattern)
 * (Description: Handles the users inputs to call two different weapon spawners and their funcitons.)
 */
using TMPro;
using UnityEngine;

public class WeaponSimulator : MonoBehaviour
{
    #region Fields
    // The creators for weapons
    WeaponCreator allyWeaponCreator;
    WeaponCreator enemyWeaponCreator;

    [Tooltip("The text displaying which spawner is being used")]
    [SerializeField] private TextMeshProUGUI spawningText;

    /// <summary>
    /// The type of spawner to use.
    /// </summary>
    private enum SpawnerType { ALLY, ENEMY }

    /// <summary>
    /// The current spawner being used.
    /// </summary>
    private SpawnerType currentSpawner = SpawnerType.ALLY;
    #endregion

    #region Functions
    /// <summary>
    /// Handles initilization of components and other fields before anything else.
    /// </summary>
    private void Awake()
    {
        allyWeaponCreator = new AllyWeaponCreator();
        enemyWeaponCreator = new EnemyWeaponCreator();
    }

    /// <summary>
    /// Calls for an event to take place once per frame.
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnWeapon("Pistol");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpawnWeapon("Rifle");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpawnWeapon("Bazooka");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeWeaponCreator();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetWeapons();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootWeapons();
        }
    }

    /// <summary>
    /// Shoots all the weapons currently spawned.
    /// </summary>
    private void ShootWeapons()
    {
        allyWeaponCreator.ShootWeapons();
        enemyWeaponCreator.ShootWeapons();
    }

    /// <summary>
    /// Changes the current weapon creator to use.
    /// </summary>
    private void ChangeWeaponCreator()
    {
        currentSpawner = (SpawnerType)((int)(++currentSpawner) % 2);

        spawningText.text = "Currently spawning " + currentSpawner.ToString() + " weapons";
    }

    /// <summary>
    /// Resets all of the weapons by destroying them.
    /// </summary>
    private void ResetWeapons()
    {
        var allyWeapons = allyWeaponCreator.Weapons();
        var enemyWeapons = enemyWeaponCreator.Weapons();

        for(int i = 0; i < allyWeapons.Count; i++)
        {
            Destroy(allyWeapons[i].gameObject);
        }

        for (int i = 0; i < enemyWeapons.Count; i++)
        {
            Destroy(enemyWeapons[i].gameObject);
        }

        allyWeapons.Clear();
        enemyWeapons.Clear();
    }

    /// <summary>
    /// Spawns a given type of weapon using the current weapon spawner.
    /// </summary>
    /// <param name="typeToSpawn">The type of weapon to spawn.</param>
    private void SpawnWeapon(string typeToSpawn)
    {
        var currentCreator = currentSpawner == 0 ? allyWeaponCreator : enemyWeaponCreator;
        var weaponToSpawn = currentCreator.CreateWeapon(typeToSpawn);
        var weapon = Instantiate(weaponToSpawn.gameObject).GetComponent<Weapon>();

        weapon.transform.position = new Vector2(weapon.transform.position.x, RandomYPos());
        allyWeaponCreator.AddWeapon(weapon);

        DestroyImmediate(weaponToSpawn, true);
    }

    /// <summary>
    /// Generates a random y position to spawn the weapon at.
    /// </summary>
    /// <returns></returns>
    private float RandomYPos()
    {
        return Random.Range(-4.0f, 4.0f);
    }
    #endregion
}
