using UnityEngine;
using System.Collections;

public class Immunity : MonoBehaviour {

	public ParticleSystem particles;
	public bool canBleed;
	public bool canKnockBack;

	public void Bleed (int amount) {
		particles.Emit (amount);
	}
}