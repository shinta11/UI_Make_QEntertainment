using UnityEngine;
using System.Collections;


/// <summary>
/// ゴールド値管理クラス.
/// </summary>
public class GoldManager : MonoBehaviour {


	private const int ANIM_TIME=30;

	private const int DISP_MAX_NUM=9999999;


	private int curGold;

	private int addGold;

	private int tgtGold;

	private int length;

	//public NumberSprite[] numberSprite;
	


	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake() {

		Init ();

		//length=numberSprite.Length;
	}

	//************************
	/// <summary>
	/// 全ての数値を０に設定する.
	/// </summary>
	//************************
	public void Init() {

		curGold=0;
		addGold=0;
		tgtGold=0;
		
		//描画を０に設定する処理.
	}


	public void AddGold(int value) {

		bool finishAnim=(curGold==tgtGold);

		tgtGold+=value;

		addGold=(tgtGold-curGold)/ANIM_TIME;

		if(finishAnim) {

			StartCoroutine (updateGold());
		}
	}


	private IEnumerator updateGold() {

		while(true) {

			curGold+=addGold;

			if(curGold < tgtGold){

				drawNumber();
			}
			else{

				curGold=tgtGold;

				drawNumber();

				break;
			}
			yield return 0;
		}
	}


	private void drawNumber() {

		int num=curGold;

		if(curGold > DISP_MAX_NUM) {

			num=DISP_MAX_NUM;
		}
	}
}
