using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDroneVFX : MonoBehaviour {

	[SerializeField] List<ParticleSystem> m_Particles;

	public static DestroyDroneVFX Instance;
	
	public void SpawnExplosionFire(int index)
	{
		m_Particles[index].Play();
	}
	
}
