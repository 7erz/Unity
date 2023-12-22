using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CURSOR
{
    HOLD,
    ATTACK
}

public class Mouse : MonoBehaviour
{
    [SerializeField] Texture2D[] mouseCursor;



    void Start()
    {
        SetCursor(CURSOR.HOLD);
    }

    // Update is called once per frame
    void Update()
    {
        Launch();
    }

    public void Launch()
    {
        if (Input.GetButton("Fire1"))
        {
            SetCursor(CURSOR.ATTACK);
        }
        else
        {
            SetCursor(CURSOR.HOLD);
        }
    }

    public void SetCursor(CURSOR cursorImg)
    {
        Cursor.SetCursor(mouseCursor[(int)cursorImg], Vector2.zero, CursorMode.ForceSoftware);
    }
}
