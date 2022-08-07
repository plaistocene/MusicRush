using System;
using UnityEngine;

public class AddNotePlayerStack : MonoBehaviour
{
    #region Variables

    public PlayerNoteCollector player;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerNoteCollector>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("MusicNote"))
        {
            player.AddCollectedNotes(gameObject);
        }
    }

    #endregion
}