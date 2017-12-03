// by @torahhorse

using UnityEngine;
using System.Collections;

public class LockMouse : MonoBehaviour    
{
    bool cursorLocked = true;
    void Start()
	{
		LockCursor(cursorLocked);
	}

    void Update()
    {
    	// lock when mouse is clicked
    	if( Input.GetMouseButtonDown(0) && Time.timeScale > 0.0f )
    	{
    		LockCursor(true);
    	}
    
    	// unlock when escape is hit
        if  ( Input.GetKeyDown(KeyCode.Escape) )
        {
        	LockCursor(!cursorLocked);
        }
    }
    
    public void LockCursor(bool isLocked)
    {
        if (isLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}