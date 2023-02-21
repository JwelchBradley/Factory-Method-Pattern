/*
 * (Jacob Welch)
 * (AllyRifle)
 * (Factory Method Pattern)
 * (Description: Initializes values for an ally rifle)
 */

public class AllyRifle : Weapon
{
    #region Functions
    protected override void Awake()
    {
        base.Awake();

        shootingWords = "Bang";
        timeBeforeRemovingText = 1.0f;
    }
    #endregion
}
