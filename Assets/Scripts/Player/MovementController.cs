using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float m_walkSpeed = 3f;
    [SerializeField] private float m_runSpeed = 6f;
    [SerializeField] private float m_sensitivity = 1f;
    [SerializeField] private float m_smoothing = 1f;
    [SerializeField] private float m_staminaExpense = .5f;
    [SerializeField] private float m_maxStamina = 100f;
    private Vector2 m_mousePos;
    private Vector2 m_smoothV;
    private Transform m_mainCamera;
    private Rigidbody m_rigidBody;
    private float m_stamina;


    private void Start()
    {
        m_mainCamera = Camera.main.transform;
        m_rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation;
        float straffe;

        if (!GameStateManager.Instance.IsPaused())
        {
            if(Input.GetKey(KeyCode.LeftShift) && m_stamina >= m_staminaExpense)
            {
                translation = Input.GetAxis("Vertical") * m_runSpeed * Time.deltaTime;
                straffe = Input.GetAxis("Horizontal") * m_runSpeed * Time.deltaTime;
                DepleteStamina(m_staminaExpense);
                Debug.Log(m_stamina);
            }
            else
            {
                translation = Input.GetAxis("Vertical") * m_walkSpeed * Time.deltaTime;
                straffe = Input.GetAxis("Horizontal") * m_walkSpeed * Time.deltaTime;
            }

            transform.Translate(straffe, 0, translation);

            Vector2 temp = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            temp = Vector2.Scale(temp, new Vector2(m_sensitivity * m_smoothing, m_sensitivity * m_smoothing));
            m_smoothV.x = Mathf.Lerp(m_smoothV.x, temp.x, 1f / m_smoothing);
            m_smoothV.y = Mathf.Lerp(m_smoothV.y, temp.y, 1f / m_smoothing);
            m_mousePos += m_smoothV;
            m_mousePos.y = Mathf.Clamp(m_mousePos.y, -90f, 90f);

            m_mainCamera.localRotation = Quaternion.AngleAxis(-m_mousePos.y, Vector3.right);
            transform.localRotation = Quaternion.AngleAxis(m_mousePos.x, transform.up);

            if (!Input.GetKey(KeyCode.LeftShift) && m_stamina < m_maxStamina)
            {
                RecoverStamina(m_staminaExpense);
            }
        }
    }

    public void RecoverStamina(float amount)
    {
        m_stamina += amount;
    }

    public void DepleteStamina(float amount)
    {
        m_stamina -= amount;
    }

    public void SetStamina(float amount)
    {
        m_stamina = amount;
    }
}
