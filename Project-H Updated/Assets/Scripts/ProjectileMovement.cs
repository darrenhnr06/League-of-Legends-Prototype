using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
	public float speed;
	public float timer;
	public float accuracy;
	private Vector3 offset;
	public bool collided;
	public List<GameObject> trails;
	private GameObject playerHitVFX;
	private GameObject enemyHitVFX;


	private void OnEnable()
	{
		transform.SetParent(null);
		//if (accuracy != 100)
		//{
		//    accuracy = 1 - (accuracy / 100);

		//    for (int i = 0; i < 2; i++)
		//    {
		//        var val = 1 * Random.Range(-accuracy, accuracy);
		//        var index = Random.Range(0, 2);
		//        if (i == 0)
		//        {
		//            if (index == 0)
		//                offset = new Vector3(0, -val, 0);
		//            else
		//                offset = new Vector3(0, val, 0);
		//        }
		//        else
		//        {
		//            if (index == 0)
		//                offset = new Vector3(0, offset.y, -val);
		//            else
		//                offset = new Vector3(0, offset.y, val);
		//        }
		//    }
		//}
		StartCoroutine(DestroyBullet());
	}

	IEnumerator DestroyBullet()
	{
		yield return new WaitForSeconds(5f);
		this.gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		transform.position += (transform.forward) * (speed * Time.deltaTime);
	}

	private void OnCollisionEnter(Collision co)
	{
		//Debug.Log("NAHI");
		if (co.gameObject.CompareTag("Player"))
		{
			return;
		}
        else
        {
			gameObject.SetActive(false);
		}
		
    
	}

	public IEnumerator DestroyParticle(float waitTime)
	{
		if (transform.childCount > 0 && waitTime != 0)
		{
			List<Transform> tList = new List<Transform>();

			foreach (Transform t in transform.GetChild(0).transform)
			{
				tList.Add(t);
			}

			while (transform.GetChild(0).localScale.x > 0)
			{
				yield return new WaitForSeconds(0.01f);
				transform.GetChild(0).localScale -= new Vector3(0.1f, 0.1f, 0.1f);
				for (int i = 0; i < tList.Count; i++)
				{
					tList[i].localScale -= new Vector3(0.1f, 0.1f, 0.1f);
				}
			}
		}

		yield return new WaitForSeconds(waitTime);
		//Destroy(this.gameObject);
	}

	IEnumerator deactivatePlayerHitEffect()
    {
		yield return new WaitForSeconds(1f);
		Debug.Log("After");
		playerHitVFX.SetActive(false);
    }
	IEnumerator deactivateEnemyHitEffect()
	{
		yield return new WaitForSeconds(1f);
		Debug.Log("After");
		enemyHitVFX.SetActive(false);
	}
}
