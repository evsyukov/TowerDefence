using UnityEngine;

public class MovementAgent : MonoBehaviour {

    [SerializeField]
    private float m_Speed;
    [SerializeField]
    private Vector3 m_Target;
    private const float TOLERANCE = 0.1f;

    void Start() {
        m_Speed = 5;
        m_Target = new Vector3(10f, 0f, 10f);
    }

    void Update() {
        float distance = (m_Target - transform.position).magnitude;
        if(distance > TOLERANCE) {
            Vector3 dir = (m_Target - transform.position).normalized;
            Vector3 delta = dir * m_Speed * Time.deltaTime;
            transform.Translate(delta);
        }
    }
}
