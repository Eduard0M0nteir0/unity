using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public float speed = 5f;
    public float speedIncreaseRate = 0.5f; // How much the speed increases every second
    public float maxSpeed = 20f;
    public Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 2f;

    public float minX = -3.9199f;
    public float maxX = 3.83f;
    public float minY = -0.1499f;
    public float maxY = 0f;
    // public float minZ = -10f;
    // public float maxZ = 10f;

    private void FixedUpdate() {
        speed = Mathf.Min(maxSpeed, speed + speedIncreaseRate * Time.fixedDeltaTime);
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * 5 * Time.fixedDeltaTime * horizontalMultiplier;  

        Vector3 newPosition = rb.position + forwardMove + horizontalMove;

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        // newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

         rb.MovePosition(newPosition);
        // rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    void Update() {
        horizontalInput = Input.GetAxis("Horizontal");       
    }
}