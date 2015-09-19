using UnityEngine;
using System.Collections;

public class DragAndDrop : MonoBehaviour
{
    public Collider2D[] DropZones;
    public float LiftHeight = 4f;
    public float LiftForce = 10f;
    public float Gravity = 20f;
    public Transform SpriteObject;
    public GameObject Parent;

    private float m_targetHeight = 0f;

    public float Height
    {
        get { return SpriteObject.localPosition.y; }
        set { m_targetHeight = value; }
    }

    private Vector3 m_origin;
    public Vector3 Origin
    {
        get { return m_origin; }
        set { m_origin = value; }
    }

    // Use this for initialization
    void Start()
    {
        if (Parent == null) {
            if (transform.parent != null)
                Parent = transform.parent.gameObject;
            else
                Parent = this.gameObject;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        updateHeight();
    }

    private void updateHeight()
    {
        //Debug.Log(Height + " target " + m_targetHeight);
        if (Height < m_targetHeight)
        {
            SpriteObject.Translate(0, Mathf.Min(Mathf.Max(m_targetHeight - Height, 0f), LiftForce * Time.deltaTime), 0f, Space.Self);
        }
        else if (Height > m_targetHeight)
        {
            SpriteObject.Translate(0, Mathf.Min(Mathf.Abs(m_targetHeight - Height), Gravity * Time.deltaTime) * -1f, 0f, Space.Self);
        }


    }
    void OnMouseDown()
    {
        Debug.Log(gameObject.name + " Selected ");
        Height = LiftHeight;
        Origin = transform.position;
        Cursor.visible = false;
    }

    void OnMouseDrag()
    {

        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(gameObject.name + "Dragging..." + mouse);
        Debug.DrawLine(Vector3.zero, mouse);
        Parent.transform.position = new Vector3(mouse.x, mouse.y, 0f);

    }

    void OnMouseUp()
    {
        Height = 0f;

        Collider2D col = getDropZone(Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        if (col == null || !IsDropZone(col))
        {
            transform.position = Origin;
        }
        else
        {
            Debug.Log("DropZone: " + col.name);
            DropZone zone = col.gameObject.GetComponent<DropZone>();
            if (zone != null) zone.Interact(gameObject);
        }

        Cursor.visible = true;
        Debug.Log(gameObject.name + "released " );
    }

    private Collider2D getDropZone(Collider2D[] colliders)
    {
        foreach (Collider2D c in colliders)
        {
            foreach (Collider2D z in DropZones)
            {
                if (c.Equals(z))
                {
                    return c;
                }
            }
        }
        return null;
    }

    public bool IsDropZone(Collider2D collider)
    {
        foreach (Collider2D c in DropZones)
        {
            if (c.Equals(collider))
            {
                return true;
            }
        }

        return false;
    }
}
