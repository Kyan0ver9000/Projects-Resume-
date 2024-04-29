using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathbarrrrr : MonoBehaviour
{
    /// <summary>
    /// The minimum Y position the player is allowed to have before being moved back to start.
    /// </summary>
    [SerializeField]
    private float deathBarrier = -10.0f;

    /// <summary>
    /// The position to apply to the player if player gets below the death barrier.
    /// </summary>
    [SerializeField]
    private Vector3 startPosition = new Vector3(0.0f, 0.5f, 0.0f);

    /// <summary>
    /// Checks if player is below death barrier and repositions the player back to start if so.
    /// </summary>
    private void Update()
    {
        if (this.transform.position.y < this.deathBarrier)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
