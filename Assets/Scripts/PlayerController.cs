using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float dashSpeed;
    public float dashDuration;
    public float dashInterval;
    public float rotateRate;
    public float dashRotateRate;
    public float scaleRate;
    public float moveStateScaleFactor;
    public float dashStateScaleFactor;

    public Transform interTransform;
    public GameObject dashGlow;

    private Vector2 arrow;
    private float lastDashTime = float.NegativeInfinity;

    private Vector2 moveStateScale;
    private Vector2 dashStateScale;

    private void Start()
    {
        moveStateScale = new Vector2(1 / moveStateScaleFactor, moveStateScaleFactor);
        dashStateScale = new Vector2(1 / dashStateScaleFactor, dashStateScaleFactor);
    }

    private void Update()
    {
        arrow = Vector2.zero;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))  arrow.x -= 1;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) arrow.x += 1;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))  arrow.y -= 1;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))    arrow.y += 1;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastDashTime < dashDuration + dashInterval) goto jump_1;
            lastDashTime = Time.time;
        } jump_1:
        
        Vector2 motionInFrame = Vector2.zero;
        float curRotateRate = rotateRate;
        Vector2 targetScale = Vector2.one;
        if (!arrow.Equals(Vector2.zero))
        {
            float curSpeed = moveSpeed;
            targetScale = moveStateScale;
            if (Time.time - lastDashTime < dashDuration)
            {
                curSpeed = dashSpeed;
                targetScale = dashStateScale;
                curRotateRate = dashRotateRate;
            }
            motionInFrame = arrow * curSpeed * Time.deltaTime / arrow.magnitude;
        }

        transform.Translate(motionInFrame.x, motionInFrame.y, 0);
        Vector2 newScale = Vector2.Lerp(interTransform.localScale, targetScale, Time.deltaTime * scaleRate);
        interTransform.localScale = (Vector3)newScale;

        float arrowAngle = Vector2.SignedAngle(Vector2.left, arrow);
        interTransform.transform.localRotation = Quaternion.Lerp(interTransform.transform.localRotation, Quaternion.Euler(0, 0, arrowAngle), Time.deltaTime * curRotateRate);
    }
}
