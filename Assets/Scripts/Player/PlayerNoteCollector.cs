using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class PlayerNoteCollector : MonoBehaviour
{
    #region Variables

    public List<GameObject> collectedNotes;
    public float noteOffset = 10f;

    [Range(0f, 1f)] public float moveDuration;

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
        if (collectedNotes.Count > 1)
        {
            foreach (var note in collectedNotes)
            {
                var previousIndex = collectedNotes.IndexOf(note) - 1;
                if (previousIndex >= 0)
                {
                    var previousTransform = collectedNotes[previousIndex].transform;
                    var previousPosition = previousTransform.position;

                    // TODO: make note position calculations based of each other
                    if (note.gameObject.CompareTag("MusicNote"))
                    {
                        var previousForwardPosition = previousPosition.z + previousTransform.localScale.z * .5f;
                        var noteZPosition = previousForwardPosition + note.transform.localScale.z * .5f + noteOffset;

                        var endValue = new Vector3(previousPosition.x, previousPosition.y, noteZPosition);

                        note.transform.DOMove(endValue, moveDuration).SetEase(Ease.InOutSine);
                    }
                }
            }
        }
    }

    #endregion

    public void AddCollectedNotes(GameObject other)
    {
        var isExisting = collectedNotes.IndexOf(other);
        if (isExisting == -1)
        {
            collectedNotes.Add(other.gameObject);
        }
    }
}