using UnityEngine;
using System.Collections;

public class DragToShoot : MonoBehaviour
{
    public GameObject Bullet;

    public float Power = 1.0f;

    public float AngleOffset;

    public float AngleRandomness;

    public SpriteRenderer Indicator;

    public Transform shootPos;

    private bool down;

    protected virtual void Update()
    {
		if (DataCenter.isBattleOver)
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
            if (Camera.main != null && Bullet != null)
            {
                var endMousePosition = Input.mousePosition;
                var startPos = shootPos.position;
                var endPos = Camera.main.ScreenToWorldPoint(endMousePosition);
                var vec = endPos - startPos;
                var angle = D2D_Helper.Atan2(vec) * -Mathf.Rad2Deg + AngleOffset + Random.Range(-0.5f, 0.5f) * AngleRandomness;
                var clone = D2D_Helper.CloneGameObject(Bullet, null, startPos, Quaternion.Euler(0.0f, 0.0f, angle));
                var cloneRb2D = clone.GetComponent<Rigidbody2D>();

                if (cloneRb2D != null)
                {
                    cloneRb2D.velocity = (endPos - startPos).normalized * Mathf.Min(20.0f , Vector3.Distance(endPos, startPos));
                }
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