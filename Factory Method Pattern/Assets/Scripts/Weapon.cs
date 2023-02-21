/*
 * (Jacob Welch)
 * (Weapon)
 * (Factory Method Pattern)
 * (Description: Provides the base funcitonality for all weapons.)
 */
using System.Collections;
using TMPro;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    #region Fields
    // Fields to be set in inherited classes
    protected string shootingWords = "";
    protected float timeBeforeRemovingText = 0.5f;

    // Text fields
    private TextMeshProUGUI shootingText;
    private Coroutine shootingRoutine;
    #endregion

    #region Functions
    /// <summary>
    /// Gets components and initializes them.
    /// </summary>
    protected virtual void Awake()
    {
        shootingText = GetComponentInChildren<TextMeshProUGUI>();
        shootingText.text = "";
    }

    /// <summary>
    /// Shoots the weapon and calls for it's text to be reset.
    /// </summary>
    public void Shoot()
    {
        shootingText.text = shootingWords;

        if (shootingRoutine != null) StopCoroutine(shootingRoutine);

        shootingRoutine = StartCoroutine(RemoveShootingText());
    }

    /// <summary>
    /// Removes the shooting text after a short delay.
    /// </summary>
    /// <returns></returns>
    private IEnumerator RemoveShootingText()
    {
        yield return new WaitForSeconds(timeBeforeRemovingText);
        shootingText.text = "";
        shootingRoutine = null;
    }
    #endregion
}
