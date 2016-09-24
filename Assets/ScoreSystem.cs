using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {

	//スコアを表示するテキスト
	private GameObject GamePointCount;

	//スコア計算用変数
	private int score = 0;

	void Start () {
		//シーン中のScoreTextオブジェクトを取得
		this.GamePointCount = GameObject.Find("GamePointCount");
	}
	// Update is called once per frame
	void Update () {
		//Scoreを画面に表示する
		this.GamePointCount.GetComponent<Text>().text = "Score:" + score;
	}
	void OnCollisionEnter(Collision col)
	{
		//接触した相手のtagに応じてスコアを加算する
		if (col.gameObject.CompareTag("SmallStarTag"))
		{
			score += 10;
		}else if (col.gameObject.CompareTag("LargeStarTag"))
		{
			score += 20;
		}else if(col.gameObject.CompareTag("SmallCloudTag"))
		{
			score += 40;
		}else if (col.gameObject.CompareTag("LargeCloudTag"))
		{
			score += 100;
		}
	}


}
//下記の条件を満たしてください
//
//Lesson5で作成したPinBallをもとに作成してください
//UIのTextを使って得点を表示してください
//ターゲット（大小の星と雲）にボールが衝突した時に得点を加算してください
//ターゲットの種類によって取得できる点数を変えてください（例：小さい星は10点、大きい星は20点など）
//得点は画面の右上に見やすく表示しましょう
//発展課題：スマートフォンでも動かせるようにマルチタッチに対応しましょう
//
//余力がある方、さらに理解を深めたい方は発展課題もチャレンジしましょう！
//上記の課題が完了してから、PinBallプロジェクト内で作業をしてください。
//
//下記の条件を満たしてください
//
//Lesson5で作成したPinBallをもとに作成してください
//画面の真ん中より左側でタップした時は左フリッパーを動かしてください
//画面の真ん中より右側でタップした時は右フリッパーを動かしてください
//左右で同時にタップした時も左右のフリッパーが正しく動くようにしましょう
//タップが終わった時にフリッパーを元の位置に戻してください
//ヒント
//
//タップの情報を取得するにはInput.touchesで得られるTouchクラスを使いましょう
//タップの状態を取得するにはTouchクラスのphase変数を使いましょう
//フリッパーを動かすには、左右の矢印キーを押した場合を参考にしましょう



//GameObject.Find("hoge")
//です。hogeの部分にはHierarchyにある操作したいオブジェクトの名前が入ります。
//位置を定める関数としてtransformが用意されていますから、コレで数値を決めてしまえばオブジェクトはその位置に存在するようになります。
//transformにはまた6つの関数系統が用意されていますが、今回使うのは
//transform.positionです。
//
//・ワールド座標：transform.position
//
//・ワールド角度：transform.eulerAngles
//
//・ワールドサイズ：transform.lossyScale
//
//・ローカル位置：transform.localPosition
//
//・ローカル角度：transform.localEulerAngles
//
//・ローカルサイズ：transform.localScale
//
//ワールドというのは画面全体に対する位置や角度、サイズであり、ローカルというのはHierarchyで確認することの出来るオブジェクト同士の親子関係に起因する位置や角度、サイズになります。
//
//これらは全て
//
//this.transform.position.x
//
//this.transform.position.y
//
//this.transform.position.z