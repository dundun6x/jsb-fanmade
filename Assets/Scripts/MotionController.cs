using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionController : MonoBehaviour
{
    private Queue<Motion> motions;
    private Motion curMotion;
    private bool curMotionActive = false;
    private MotionDataBlock dataBlock;

    private Timer timer;
    private float timePoint = 0;

    private void Start()
    {
        dataBlock.AttachTo(transform);
    }

    public void Initiate()
    {
        if (motions.Count == 0) return;
        timer.Start();
        StartCoroutine(MotionCoroutine());
    }

    private void Update()
    {
        if (!curMotionActive) return;
        curMotion.Act();
    }

    private IEnumerator MotionCoroutine()
    {
        if (motions.Count == 0) yield break;

        curMotion = motions.Dequeue();
        curMotion.SetDataBlock(dataBlock);
        timePoint += curMotion.frontWaitTime;
        yield return new WaitForSeconds(timePoint - timer.Time());

        curMotionActive = true;
        curMotion.Start();
        timePoint += curMotion.duration;
        yield return new WaitForSeconds(timePoint - timer.Time());

        curMotionActive = false;
        curMotion.End();
        timePoint += curMotion.endWaitTime;
        yield return new WaitForSeconds(timePoint - timer.Time());

        StartCoroutine(MotionCoroutine());
    }
}
