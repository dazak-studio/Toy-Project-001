using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    public float Force;
    public float Duration;
    
    private Transform _transform;
    private Rigidbody _rigidbody;

    #region Unity-Callbacks
    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Duration > Mathf.Epsilon)
            Duration -= Time.fixedDeltaTime;
        else
            Destroy(this);
    }

    #endregion

    public void SetTrigger(Vector3 shootPointNorm, float rotateDegree)
    {
        _transform.rotation = Quaternion.Euler(0f, 0f, rotateDegree);
        _rigidbody.AddForce(shootPointNorm * Force, ForceMode.VelocityChange);
    }
}