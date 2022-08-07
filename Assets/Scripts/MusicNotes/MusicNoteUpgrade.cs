using System;
using UnityEngine;

public class MusicNoteUpgrade : MonoBehaviour
{
    #region Variables

    #endregion

    #region Unity Methods

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mix") || other.gameObject.CompareTag("Master"))
        {
            UpgradeNote();
        }
    }

    #endregion

    private void UpgradeNote()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.green;
    }
}
