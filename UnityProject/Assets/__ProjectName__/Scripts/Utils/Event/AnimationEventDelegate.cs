﻿using UnityEngine;
using System.Collections;

/*
 * 	アニメーションカーブのフレームにイベントを設定する
 */
namespace GarageKit
{
	public class AnimationEventDelegate : MonoBehaviour
	{	
		private AnimationEvent animEvent;
		
		// デリゲート設定
		public delegate void OnAnimationEventDelegate(GameObject senderObject);
		public event OnAnimationEventDelegate OnAnimationEvent;
		private void InvokeOnAnimationEvent()
		{
			if(OnAnimationEvent != null)
				OnAnimationEvent(this.gameObject);
		}
		
		
		void Awake()
		{
		
		}

		void Start()
		{
			// アニメーションイベントを設定
			animEvent = new AnimationEvent();
			animEvent.time = this.gameObject.GetComponent<Animation>().clip.length;
			animEvent.functionName = "AnimationEventFunction";
			this.gameObject.GetComponent<Animation>().clip.AddEvent(animEvent);
		}

		void Update()
		{
		
		}
		
		/// <summary>
		/// アニメーションイベントで呼ばれる
		/// </summary>
		private void AnimationEventFunction()
		{
			InvokeOnAnimationEvent();
		}
	}
}
