using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    up,
    down,
    left,
    right
}
public class InputManager : MonoBehaviour
{
    public bool replayMode;
    public static InputManager instance;
    
    [SerializeField]public bool[] m_Directions;
    public void SetDirections(bool[] dir) { dir.CopyTo(m_Directions, 0); ; }

    public bool GetDirection(Direction dir) { return m_Directions[(int)dir]; }


    private void Awake()
    {
        CreateInstance();
        m_Directions = new bool[4];      
    }

    void CreateInstance()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }
    void Update()
    {
        if (!replayMode)
        {
            m_Directions[(int)Direction.up] = Input.GetKey(KeyCode.W);
            m_Directions[(int)Direction.down] = Input.GetKey(KeyCode.S);
            m_Directions[(int)Direction.left] = Input.GetKey(KeyCode.A);
            m_Directions[(int)Direction.right] = Input.GetKey(KeyCode.D);       
            DataCollectionSaver.instance.AddInput(m_Directions);
        }
    }
}
