using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerNoteCollector : MonoBehaviour
{
    #region Variables

    public List<GameObject> collectedNotes;
    public float noteOffset = 10f;

    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    private void Start()
    {
        collectedNotes.Add(gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        foreach (var note in collectedNotes)
        {
            // note.transform.position
        }
    }

    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MusicNote"))
        {
            collectedNotes.Add(collision.gameObject);
            var playerTransform = collectedNotes.Last().transform;
            var position = playerTransform.position;
            gameObject.transform.position = new Vector3(position.x, position.y, position.z + playerTransform.localScale.z + noteOffset);
        }
    }
}
