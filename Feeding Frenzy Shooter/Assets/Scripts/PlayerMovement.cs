using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float speedRamp;
    public bool atBound;

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speedRamp = 1.1f;
            transform.Translate(x * (speed * speedRamp) * Time.deltaTime, y * (speed * speedRamp) * Time.deltaTime, 0, Space.World);
        } else if (Input.GetKey(KeyCode.LeftShift))
        {
            if (speedRamp <= 2.5f)
            {
                speedRamp += 0.1f;
            } else
            {
                speedRamp = 2.5f;
            }
            transform.Translate(x * (speed * speedRamp) * Time.deltaTime, y * (speed * speedRamp) * Time.deltaTime, 0, Space.World);
        } else
        {
            transform.Translate(x * speed * Time.deltaTime, y * speed * Time.deltaTime, 0, Space.World);
        }
        checkWrapMovement();

        // convert mouse position into world coordinates
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // get direction you want to point at
        Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;

        // set vector of transform directly
        transform.up = direction;
    }

    void checkWrapMovement()
    {
        if (transform.position.y > LevelManager.instance.camSize)
        {
            transform.position = new Vector2(transform.position.x, -LevelManager.instance.camSize);
        }
        else if (transform.position.y < -LevelManager.instance.camSize)
        {
            transform.position = new Vector2(transform.position.x, LevelManager.instance.camSize);
        }

        float horBound = LevelManager.instance.camSize + (LevelManager.instance.camSize / 3);

        if (transform.position.x > horBound)
        {
            transform.position = new Vector2(-horBound, -transform.position.y);
        }
        else if (transform.position.x < -horBound)
        {
            transform.position = new Vector2(horBound, transform.position.y);
        }
    }
}
