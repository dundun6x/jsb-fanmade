using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionController : MonoBehaviour
{
    private LinkedList<MotionSequence> sequences;

    public void AddSequence(MotionSequence sequence)
    {
        sequences.AddLast(sequence);
    }

    private void Update()
    {
        foreach (var seq in sequences)
        {
            if (seq.GetState() == MotionSequenceState.Stopped)
            {
                sequences.Remove(seq);
                return;
            }
            seq.Act();
        }
    }
}
