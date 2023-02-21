/*
 * (Jacob Welch)
 * (AllyPistol)
 * (Factory Method Pattern)
 * (Description: Initializes values for an ally pistol.)
 */

public class AllyPistol : Weapon
{
    #region Functions
    protected override void Awake()
    {
        base.Awake();

        shootingWords = "Bop";
        timeBeforeRemovingText = 0.5f;
    }
    #endregion
}
