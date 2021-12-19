using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[System.Serializable]
public class TweenData
{
	public enum TweenType { Move, Rotate, Scale }

	public TweenType tweenType;
	public Transform objectToTween;
	public Vector3 positionOffset;
	public float duration = 1f;
	public Vector3 targetRotation;
	public float targetScale = 1f;
	public bool join = false;


	public Tween GetTween(){
		Tween tween = null;

		switch(tweenType){
			case TweenType.Move:
				Vector3 targetPosition = objectToTween.transform.position + positionOffset;
				tween = objectToTween.DOMove(targetPosition, duration);
				break;
			case TweenType.Rotate:
				tween = objectToTween.DORotate(targetRotation, duration);
				break;
			case TweenType.Scale:
				tween = objectToTween.DOScale(targetScale, duration);
				break;
			default:
				break;		
		}

		return tween;
	}
}
