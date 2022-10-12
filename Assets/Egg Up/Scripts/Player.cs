using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
	//visible in inspector
	public Rigidbody rb;
	public float jumpForce;
	public float bouncePadJumpForce;
	public Transform mesh;
	public float meshEffect;
	public float meshEffectSpeed;
	public float meshEffectLimit;
	public float eggHeight;
	public Material eggMat;
	
	//not in inspector
	GameManager manager;
	
	void Start(){
		//get game manager
		manager = FindObjectOfType<GameManager>();
	}
	
	void LateUpdate(){
		//
		float effect = rb.velocity.y * meshEffect;
		effect = Mathf.Clamp(effect, -meshEffectLimit, meshEffectLimit);
		mesh.transform.localScale = Vector3.MoveTowards(mesh.transform.localScale, Vector3.one + new Vector3(-effect, effect, -effect), Time.deltaTime * meshEffectSpeed);
	}
	
	void OnTriggerEnter(Collider other){
		//
		if(!other.gameObject.CompareTag("Platform") || transform.position.y < other.gameObject.transform.position.y)
			return;
		
		//show platform bounce effect
		Platform platform = other.gameObject.transform.parent.GetComponent<Platform>();
		platform.Bounce(transform.position - (Vector3.up * eggHeight), eggMat);
		
		//jump up
		rb.velocity = Vector3.up * (platform.hasBouncePad ? bouncePadJumpForce : jumpForce);
		
		manager.Jumped(transform.position);
		
		//
		if(transform.position.y > 1f)
			manager.HideTitle();
	}
}
