using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JSB.HazardSystem;

namespace JSB
{
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 5;
        public float dashSpeed = 30;
        public float rotateRate = 20;
        public float dashRotateRate = 50;
        public float scaleRate = 20;

        public float moveScaleFactor = 0.75f;
        public float dashScaleFactor = 0.5f;

        public float dashDuration = 0.15f;
        public float dashInterval = 0.5f;

        public float protectionDuration = 2;

        public Transform internalTransform;
        public GameObject dashGlow;

        private Timer timer;

        private Vector2 arrow;
        private float lastDashTime = float.NegativeInfinity;
        private float lastDamagedTime = float.NegativeInfinity;

        private Vector2 moveScale;
        private Vector2 dashScale;

        private int hp = 6;
        public int HP { get => hp; }

        private void Start()
        {
            moveScale = new Vector2(1 / moveScaleFactor, moveScaleFactor);
            dashScale = new Vector2(1 / dashScaleFactor, dashScaleFactor);
            timer.Start();
        }

        private void Update()
        {
            if (hp == 0) { Debug.Log("Player loses"); hp = -1; }

            arrow = Vector2.zero;
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) arrow.x -= 1;
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) arrow.x += 1;
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) arrow.y -= 1;
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) arrow.y += 1;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (timer.Time() - lastDashTime < dashDuration + dashInterval) goto jump_1;
                lastDashTime = timer.Time();
            }
        jump_1:

            Vector2 motionInFrame = Vector2.zero;
            float curRotateRate = rotateRate;
            Vector2 targetScale = Vector2.one;
            if (!arrow.Equals(Vector2.zero))
            {
                float curSpeed = moveSpeed;
                targetScale = moveScale;
                if (Time.time - lastDashTime < dashDuration)
                {
                    curSpeed = dashSpeed;
                    targetScale = dashScale;
                    curRotateRate = dashRotateRate;
                }
                motionInFrame = arrow * curSpeed * Time.deltaTime / arrow.magnitude;
            }

            transform.Translate(motionInFrame.x, motionInFrame.y, 0);
            Vector2 newScale = Vector2.Lerp(internalTransform.localScale, targetScale, Time.deltaTime * scaleRate);
            internalTransform.localScale = (Vector3)newScale;

            float arrowAngle = Vector2.SignedAngle(Vector2.left, arrow);
            internalTransform.transform.localRotation = Quaternion.Euler(0, 0, Mathf.LerpAngle(internalTransform.transform.localRotation.eulerAngles.z, arrowAngle, Time.deltaTime * curRotateRate));
        }

        private void OnTriggerEnter2D(Collider2D coll)
        {
            HazardComponent component;
            if (coll.TryGetComponent(out component))
            {
                if (component.IsHarmful())
                {
                    if (timer.Time() > lastDamagedTime + protectionDuration)
                    {
                        --hp;
                        Debug.Log("Player damaged");
                        lastDamagedTime = timer.Time();
                    }
                }
            }
        }
    }
}
