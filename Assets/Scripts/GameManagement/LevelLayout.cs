using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class LevelLayout : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnCollisionStay2D(Collision2D col)
	{
		//Debug.Log("Contact Points:" + col.contacts.Length.ToString());

//		if(col.collider.GetComponent<Player>()){
//
//			PlatformerCharacter2D pc2d = col.collider.GetComponent<PlatformerCharacter2D>();
//			if(col.contacts.Length > 0)
//			{
//
//				Vector2 puntoContacto = col.contacts[0].point;
//				Vector2 normal = col.contacts[0].normal;
//
//				//Linea Roja
//				Debug.DrawRay (puntoContacto, normal * -1.0f * 5.0f, Color.red);
//
//				//Normal del punto de contacto con respecto al piso
//				//Rotaciòn del personaje
//				//Debug.Log("Hero Rotation: " + col.collider.transform.rotation.eulerAngles);
//				//Normal con respecto al piso
//				//Debug.Log("Normal: " + normal);
//				//Vector3 productoCruz = Vector3.Cross(puntoContacto,normal * -1);
//				//Debug.Log("Producto Cruz: " + productoCruz );
////				col.collider.transform.rotation = Quaternion.Slerp(col.collider.transform.rotation,  Quaternion.FromToRotation(Vector3.down, normal)
////					, Time.deltaTime * 30);
//
//
//				Quaternion QAmountToRotate = Quaternion.FromToRotation(Vector3.down, normal);
//				Vector3 v3AmountToRotate = QAmountToRotate.eulerAngles;
//
//				float zRotation = v3AmountToRotate.z;
//
//
//					if(zRotation < 355.0f && zRotation > 0.0f)
//						v3AmountToRotate = new Vector3(v3AmountToRotate.x, v3AmountToRotate.y, Mathf.Clamp( v3AmountToRotate.z, 0, 330));
//					else
//						v3AmountToRotate = new Vector3(v3AmountToRotate.x, v3AmountToRotate.y, Mathf.Clamp( v3AmountToRotate.z, 0, 0));
//				
//
//
//				QAmountToRotate = Quaternion.Euler(v3AmountToRotate);
//
//				//Debug.Log(zRotation);
//
////				Quaternion rotToPlayer = Quaternion.LookRotation( normal );
////				float amountToRotate = Quaternion.Angle( col.collider.transform.rotation, rotToPlayer );
//
//				col.collider.transform.rotation = Quaternion.Slerp(col.collider.transform.rotation,  QAmountToRotate, Time.deltaTime * 30);
//
//
//			}
//		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		//Debug.Log("Contact Points:" + col.contacts.Length.ToString());

//		if(col.collider.GetComponent<Player>()){
//
//			if(col.contacts.Length > 0)
//			{
//
//				Vector2 puntoContacto = col.contacts[0].point;
//				Vector2 normal = col.contacts[0].normal;
//
//				//Linea Roja
////				Debug.DrawRay (puntoContacto, normal * -1.0f * 5.0f, Color.red);
////
////				//Normal del punto de contacto con respecto al piso
////
////
////				//Rotaciòn del personaje
////				Debug.Log("Hero Rotation: " + col.collider.transform.rotation.eulerAngles);
////
////				//Normal con respecto al piso
////				Debug.Log("Normal: " + normal);
//
////				col.collider.transform.rotation = Quaternion.Slerp(col.collider.transform.rotation,  
////					Quaternion.FromToRotation(Vector3.down, normal), Time.deltaTime * 40.0f);
//
//			}
//		}
	}


}
