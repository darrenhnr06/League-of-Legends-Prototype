using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyProjectileMovement : MonoBehaviour
{
    public float speed;

    private void OnEnable()
    {
        //transform.rotation = Quaternion.Euler(0, 0, 0);
        //transform.SetParent(null);
        //StartCoroutine(DestroyBullet());
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
        if (co.gameObject.CompareTag("Bullet") || (co.gameObject.CompareTag("EnemyBullet")) || (co.gameObject.CompareTag("EnemyHitEffect") || (co.gameObject.CompareTag("PlayerHitEffect"))))
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
}
