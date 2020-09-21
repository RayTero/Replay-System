using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private const float m_deadZone = 0.25f;
    [SerializeField] private float m_movementSpeed = 2.5f;
    private const float m_collisionRayLength = 0.5f;
    private float m_turnY = 0;
    [SerializeField] private float m_rotationSpeed = 30;

    private Vector3 m_movement = Vector3.zero;
    private Vector3 m_lookRotation = Vector3.zero;

    private Rigidbody m_RB = null;
    public Vector3 PlayerPos { get => transform.position; }
    public Quaternion PlayerRotation { get => transform.rotation; }

    private void Start()
    {
        m_RB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (InputManager.instance.GetDirection(Direction.up))
        {
            m_movement.z = 1f;
        }
        else if (InputManager.instance.GetDirection(Direction.down))
        {
            m_movement.z = -1f;
        }
        else
        {
            m_movement.z = 0f;
        }

        if (InputManager.instance.GetDirection(Direction.left))
        {
            m_movement.x = -1f;
        }
        else if (InputManager.instance.GetDirection(Direction.right))
        {
            m_movement.x = 1f;
        }
        else
        {
            m_movement.x = 0f;
        }

        m_RB.transform.position += transform.forward * m_movement.z * m_movementSpeed;
        m_RB.transform.position += transform.right * m_movement.x * m_movementSpeed;
        m_RB.transform.position = new Vector3(transform.position.x, 2.38f, transform.position.z);
    }

 
}