using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UI_Object : MonoBehaviour
{
    public bool IS_DRAGGABLE;

    public Texture2D cursorOverIcon;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public virtual void OnMouseClick() { }
    public virtual void OnMouseOver() { }
    public virtual void WhenMouseDown() { }
    public virtual void OnMouseUp() { }
    
}
