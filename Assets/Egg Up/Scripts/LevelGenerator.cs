using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
	
	//visible in inspector
	public GameObject platform;
	public Transform parent;
	public Transform pole;
	public GameObject finishLine;
	
	public float yOffset;
	public int rotationMin;
	public int rotationMax;
	public float startHeight;
	public int startRotation;
	
	public int diamondChance;
	
	//not in inspector
	int size;
    
	void Start(){
		//get the total level size from the game manager
		size = FindObjectOfType<GameManager>().totalHeight;
		
		//build level
		MakeLevel();
	}
	
	void MakeLevel(){
		float height = startHeight;
		float rot = startRotation;
		
		bool lastHadDiamond = false;
		
		//loop over the size of the level
		for(int i = 0; i < size; i++){
			
			GameObject newPlatform = Instantiate(platform);
			newPlatform.transform.position = Vector3.up * height;
			newPlatform.transform.Rotate(Vector3.up * rot);
			
			
			newPlatform.transform.SetParent(parent, false);
			
			
			bool diamond = i > 0 && !lastHadDiamond && Random.Range(0, diamondChance) == 0;
			newPlatform.GetComponent<Platform>().SetDiamond(diamond, i < size - 3 && i > 0);
			
			lastHadDiamond = diamond;
			
			float randomRotation = Random.Range(rotationMin, rotationMax);
			
			if(i == 0)
				randomRotation = Random.Range((rotationMin + rotationMax)/2, rotationMax);
			
			bool rotateLeft = Random.Range(0, 2) == 0;
			
			
			rot += rotateLeft ? -randomRotation : randomRotation;
						
			height += yOffset;
		}
		
		//position the finish line at the top and scale the center pole
		finishLine.transform.position = Vector3.up * height;
		finishLine.transform.SetParent(parent, false);

		finishLine.transform.SetParent(null);

		Vector3 poleScale = pole.localScale;

		pole.localScale = new Vector3(poleScale.x, height, poleScale.z);
	}
}
