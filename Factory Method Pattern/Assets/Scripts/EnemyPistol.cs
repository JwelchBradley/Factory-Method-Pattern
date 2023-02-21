/*
 * (Jacob Welch)
 * (EnemyPistol)
 * (Factory Method Pattern)
 * (Description: Initializes values for an enemy pistol.)
 */

public class EnemyPistol : Weapon
{
    #region Functions
    protected override void Awake()
    {
        base.Awake();

        shootingWords = "Big Bop";
        timeBeforeRemovingText = 0.8f;
    }
    #endregion
}
