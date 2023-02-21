/*
 * (Jacob Welch)
 * (AllyBazooka)
 * (Factory Method Pattern)
 * (Description: Initializes values for an ally bazooka.)
 */

public class AllyBazooka : Weapon
{
    #region Functions
    protected override void Awake()
    {
        base.Awake();

        shootingWords = "Boom";
        timeBeforeRemovingText = 1.5f;
    }
    #endregion
}
