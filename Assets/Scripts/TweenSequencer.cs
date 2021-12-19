using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenSequencer : MonoBehaviour
{
	public TweenData[] tweenDataArray;

	Sequence mySequence;

	private bool sequenceTriggered;

	void Awake(){
		mySequence = DOTween.Sequence();
		BuildSequence();
	}

	void BuildSequence(){
		//Take control for you
		mySequence.Pause();
		mySequence.SetAutoKill(false);

		for(int i = 0; i < tweenDataArray.Length; i++){
			if(tweenDataArray[i].join){
				mySequence.Join(tweenDataArray[i].GetTween()); //meaining we're gonna play concurrently
			}else{
				mySequence.Append(tweenDataArray[i].GetTween()); //just builds a sequential sequence of tweens
				//so those movements are gonna happen one after the other then
			}
		}
	}


	[ContextMenu("Start Sequence")]
	public void StartSequence(){
		Debug.Log("Start sequence on " + gameObject.name);

		if(!sequenceTriggered){
			mySequence.PlayForward();
		}else{
			mySequence.PlayBackwards();
		}

		sequenceTriggered = !sequenceTriggered;
	}
}
