using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] SpriteRenderer imageSprite;

    private Vector3 screenBounds;
    private Vector2 objectSize;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));  // calculates screen bounds in World space coordinates
        objectSize = new Vector2(imageSprite.bounds.extents.x, imageSprite.bounds.extents.y); // calculates size of GameObject's bounding box through its sprite renderer
    }

    void Update()
    {
        MakeMove();
    }

    /** Makes GameObject moveable within the World space. */
    void MakeMove()
    {
        float moveUp = Input.GetAxis("Vertical");
        float moveRight = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveRight, moveUp);
        Vector3 newPosition = transform.position + (Vector3)(movement * moveSpeed * Time.deltaTime);

        transform.position = GetClampedPosition(newPosition); // limit position to the screen boundaries

        // applies smoothing (similar to an ease-in animation) to the GameObject's movement, but not desirable for a retro game's esthetics
        // transform.Translate(movement * speed * Time.deltaTime);
    }

    /** Clamps a Vector3 position between the screen boundaries and returns the clamped Vector3 position. */
    Vector3 GetClampedPosition(Vector3 position)
    {
        int clampDirection =  -1; // corresponds to orthographic camera 

        Vector3 clampedPosition = position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, screenBounds.x * clampDirection + objectSize.x, screenBounds.x - objectSize.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, screenBounds.y * clampDirection + objectSize.y, screenBounds.y - objectSize.y);

        return clampedPosition;
    }
}
