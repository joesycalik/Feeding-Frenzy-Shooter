using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float speedRamp;

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speedRamp = 2f;
            transform.Translate(x * (speed * speedRamp) * Time.deltaTime, y * (speed * speedRamp) * Time.deltaTime, 0, Space.World);
        } else if (Input.GetKey(KeyCode.LeftShift))
        {
            if (speedRamp <= 5f)
            {
                speedRamp += 0.1f;
            } else
            {
                speedRamp = 5f;
            }
            
            transform.Translate(x * (speed * speedRamp) * Time.deltaTime, y * (speed * speedRamp) * Time.deltaTime, 0, Space.World);
        } else
        {
            
            transform.Translate(x * speed * Time.deltaTime, y * speed * Time.deltaTime, 0, Space.World);
        }

        // convert mouse position into world coordinates
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // get direction you want to point at
        Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;

        // set vector of transform directly
        transform.up = direction;
    }

    private void LateUpdate()
    {
        speed = LevelManager.instance.camSize;
    }
}
