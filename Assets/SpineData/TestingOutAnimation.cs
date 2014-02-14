using UnityEngine;
using System.Collections;

public class TestingOutAnimation : MonoBehaviour {
	bool toggleAnimation = true;

	void Update ( ) {
		if( Input.anyKeyDown && toggleAnimation ){
			toggleAnimation = false;
			StartCoroutine( startNormalAnimation( ) );
		}
	}

	IEnumerator startNormalAnimation( ){
		this.GetComponent< SkeletonAnimation >( ).animationName = "jump";
		yield return new WaitForSeconds( 1.4f );
		this.GetComponent< SkeletonAnimation >( ).animationName = "walk";
		toggleAnimation = true;
	}
}
