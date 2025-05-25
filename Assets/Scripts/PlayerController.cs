using UnityEngine;
using UnityEngine.InputSystem; // Add this for the new Input System

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject blockPrefab; // Assign a block prefab in the Inspector

    void Update()
    {
        // Basic 2D movement (WASD or Arrow Keys) using the new Input System
        float moveX = 0f;
        float moveY = 0f;
        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) moveX -= 1f;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) moveX += 1f;
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) moveY += 1f;
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) moveY -= 1f;
        }
        Vector3 move = new Vector3(moveX, moveY, 0).normalized * moveSpeed * Time.deltaTime;
        transform.position += move;

        // Place block on left mouse click using the new Input System
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 mouseScreenPos = Mouse.current.position.ReadValue();
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, -Camera.main.transform.position.z));
            Vector3 placePos = new Vector3(Mathf.Round(mouseWorldPos.x), Mathf.Round(mouseWorldPos.y), 0);
            Instantiate(blockPrefab, placePos, Quaternion.identity);
        }
    }
}
