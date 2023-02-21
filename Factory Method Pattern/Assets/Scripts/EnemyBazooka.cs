/*
 * (Jacob Welch)
 * (EnemyBazooka)
 * (Factory Method Pattern)
 * (Description: Initializes values for an enemy bazooka.)
 */

public class EnemyBazooka : Weapon
{
    #region Functions
    protected override void Awake()
    {
        base.Awake();

        shootingWords = "Big Boom";
        timeBeforeRemovingText = 2.0f;
    }
    #endregion
}
