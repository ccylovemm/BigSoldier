using UnityEngine;
using System.Collections.Generic;

public class DragToShoot : MonoBehaviour
{
    public float Power = 1.0f;

    public float AngleOffset;

    public float AngleRandomness;

    public SpriteRenderer Indicator;

    public Transform shootPos;

    private bool down;

    void OnEnable()
    {
        EventSystem.AddEvent(EType.MoveBack, this, "OnMoveBack");
        EventSystem.AddEvent(EType.MoveForward, this, "OnMoveForward");
    }

    void OnDisable()
    {
        EventSystem.RemoveEvent(EType.MoveBack, this, "OnMoveBack");
        EventSystem.RemoveEvent(EType.MoveForward, this, "OnMoveForward");
    }

    public void OnMoveBack(bool state)
    {
        shootPos.transform.localPosition = new Vector3(-1.32f , 1.64f , 0.0f);
    }

    public void OnMoveForward(bool state)
    {
        shootPos.transform.localPosition = new Vector3(1.32f, 1.64f, 0.0f);
    }

    void Update()
    {
		if (!DataCenter.CanFire || UICamera.isOverUI)
			return;
        // Begin dragging?
        if (Input.GetMouseButton(0) == true && down == false)
        {
            down = true;
        }

        // End dragging?
        if (Input.GetMouseButton(0) == false && down == true)
        {
            down = false;

            // Fire?
            if (Camera.main != null)
            {
                var endMousePosition = Input.mousePosition;
                var startPos = shootPos.position;
                var endPos = Camera.main.ScreenToWorldPoint(endMousePosition);
                var vec = endPos - startPos;
                var angle = D2D_Helper.Atan2(vec) * -Mathf.Rad2Deg + AngleOffset + Random.Range(-0.5f, 0.5f) * AngleRandomness;
                var clone = D2D_Helper.CloneGameObject(Resources.Load<GameObject>("Prefabs/Bomb/Bomb" + (DataCenter.currSelectBomb + 1)), null, startPos, Quaternion.Euler(0.0f, 0.0f, angle));
                var cloneRb2D = clone.GetComponent<Rigidbody2D>();

                if (cloneRb2D != null)
                {
                    cloneRb2D.velocity = (endPos - startPos).normalized * Mathf.Min(20.0f , Vector3.Distance(endPos, startPos));
                }

                EventSystem.DispatchEvent(EType.Fire);
            }
        }

        // Show dragging?
        if (Indicator != null)
        {
            Indicator.enabled = down;

            if (Camera.main != null && down == true)
            {
                var currentMousePosition = Input.mousePosition;
                var startPos = shootPos.position;
                var currentPos = Camera.main.ScreenToWorldPoint(currentMousePosition);
                var scale = Vector3.Distance(currentPos, startPos);
                var angle = D2D_Helper.Atan2(currentPos - startPos) * Mathf.Rad2Deg;

                scale = Mathf.Min(20.0f , scale);

                Indicator.transform.position = shootPos.position;
                Indicator.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -angle);
                Indicator.transform.localScale = new Vector3(scale, scale, scale);
            }
        }
    }
}