using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundToScreen : MonoBehaviour
{
    private Vector2 screenBounds;
    private Vector2 currentPosition;
    private float widthOffset = 0;
    private float heightOffset = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        // Calculate screen boundaries
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        // Calculate offset
        widthOffset = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        heightOffset = GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Get the current position from the game object
        currentPosition = transform.position;

        // Clamp the x and y values based on the screen size
        currentPosition.x = Mathf.Clamp(currentPosition.x, screenBounds.x * -1 + widthOffset, screenBounds.x - widthOffset);
        currentPosition.y = Mathf.Clamp(currentPosition.y, screenBounds.y * -1 + heightOffset, screenBounds.y - heightOffset);

        // Updates the game object position
        transform.position = currentPosition;
    }
}
