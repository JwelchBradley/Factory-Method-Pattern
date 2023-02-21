/*
 * (Jacob Welch)
 * (EnemyRifle)
 * (Factory Method Pattern)
 * (Description: Initializes values for an enemy rifle.)
 */

public class EnemyRifle : Weapon
{
    #region Functions
    protected override void Awake()
    {
        base.Awake();

        shootingWords = "Big Bang";
        timeBeforeRemovingText = 1.2f;
    }
    #endregion
}
