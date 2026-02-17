using UnityEngine;

public class Raycast : MonoBehaviour
{
    public LayerMask mask;
    private Camera cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        DrawRay();
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("clicked mouse");
            OnMouseClick();
        }
    }

    private void OnMouseClick()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit,100,mask))
        {
            Debug.Log(hit.transform.name);
        }
    }
    
    private void DrawRay()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position,mousePos-transform.position, Color.cyan);
    }
}
