using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float sensitivity;
    [SerializeField] private float smoothing;
    private Vector2 mousePos;
    private Vector2 smoothV;
    private Transform mainCamera;
    

    private void Start()
    {
        mainCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * walkSpeed * Time.deltaTime;
        float straffe = Input.GetAxis("Horizontal") * walkSpeed * Time.deltaTime;

        transform.Translate(straffe,0,translation);

        Vector2 temp = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        temp = Vector2.Scale(temp,new Vector2(sensitivity*smoothing,sensitivity*smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x,temp.x,1f/smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, temp.y, 1f / smoothing);
        mousePos += smoothV;
        mousePos.y = Mathf.Clamp(mousePos.y, -90f, 90f);

        mainCamera.localRotation = Quaternion.AngleAxis(-mousePos.y,Vector3.right);
        transform.localRotation = Quaternion.AngleAxis(mousePos.x, transform.up);
    }
}
