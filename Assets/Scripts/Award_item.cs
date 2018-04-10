using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AwardType
{
    Gun,
    DualSword
}
public class Award_item : MonoBehaviour {
    private Rigidbody m_rigidbody;
    private Transform player;
    private bool startMove;
    public AwardType type;
    public AudioClip awardSound;
    public float speed = 10;
    
	void Start () {
        m_rigidbody=this.GetComponent<Rigidbody>();
        m_rigidbody.velocity = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
        startMove = false;
    }

    private void Update()
    {
        if (startMove)
        {
            transform.position= Vector3.Lerp(this.transform.position,player.position+Vector3.up,speed*Time.deltaTime);
            if (Vector3.Distance(this.transform.position, player.position+ Vector3.up) < 0.5f)
            {
                player.GetComponent<PlayerAward>().GetAward(type);
                AudioSource.PlayClipAtPoint(awardSound, transform.position, 1f);
                Destroy(this.gameObject);
            }
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == Tags.Ground)
        {
            m_rigidbody.useGravity=false;
            m_rigidbody.isKinematic = true;
            SphereCollider collider = this.GetComponent<SphereCollider>();
            collider.isTrigger = true;
            collider.radius = 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.Player)
        {
            startMove = true;
            player = other.transform;
        }
    }
}
