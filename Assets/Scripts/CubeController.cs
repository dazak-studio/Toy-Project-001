using UnityEngine;

public abstract class CubeController : MonoBehaviour
{
	/* properties */
	public bool IsShootable { get { return ShootCooldownLeft <= Mathf.Epsilon; } }		
	
	/* public fields */
	public float ShootCooldown;
	
	/* protected fields */
	[SerializeField] protected GameObject BulletPrefab;
	protected float ShootCooldownLeft;

	/* unity callbacks */
	#region Unity-Callbacks
	protected void FixedUpdate()
	{
		if (!IsShootable)
			ShootCooldownLeft -= Time.fixedDeltaTime;
	}
	#endregion

	/* public methods */
	public abstract void Shoot();
}
