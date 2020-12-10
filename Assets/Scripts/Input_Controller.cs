using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Controller : MonoBehaviour
{
    public UI_Object UI_Null;
    private UI_Object UI_MouseOver;
    private UI_Object UI_Active;

    // Start is called before the first frame update
    void Start()
    {
        UI_MouseOver = UI_Null;
        UI_Active = UI_Null;
        UI_Active.OnMouseOver();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        RaycastHit2D hit;

        if (hit = Physics2D.Raycast(worldPosition, Vector3.forward, 0.01f))
        {
            if (hit.collider)
            {
                GameObject gameObject = hit.collider.gameObject;
                if (gameObject.GetComponent<UI_Object>())
                {
                    UI_MouseOver = gameObject.GetComponent<UI_Object>();
                }
            }
        }
        else
        {
            UI_MouseOver = UI_Null;
        }


        if (UI_Active.IS_DRAGGABLE && Input.GetMouseButton(0))
        {
            UI_Active.WhenMouseDown();
        }
        else if(UI_Active != UI_MouseOver)  
        {
            UI_Active = UI_MouseOver;
            UI_Active.OnMouseOver();
        }

        if(Input.GetMouseButtonDown(0))
        {
            UI_Active.OnMouseClick();
        }

        if(Input.GetMouseButtonUp(0))
        {
            UI_Active.OnMouseUp();
        }
    }
}
