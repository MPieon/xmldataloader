enum Type 
	{
		Cube   = 0, 
		Cylinder  = 1, 
		Capsule  = 2,
		Sphere = 3
	}

var LoadXmlDataScript;
var ObjectType : Type;
var IsTriggered : boolean = false;
var IsSelected : boolean = false;

function Start () 
{
    LoadXmlDataScript = GameObject.FindWithTag("Director").GetComponent("LoadXmlData");
}

function Update () 
{
	switch (ObjectType) 
			{
			case Type.Cube:
					if (IsTriggered==true)
					{
						gameObject.renderer.enabled = true;
     					gameObject.GetComponent(TextMesh).text = LoadXmlDataScript.Cube_Character;
     					DestroyObject(this.collider);
     					if (Input.GetKey (KeyCode.Z))
						{
						LoadXmlDataScript.Value+=1;			
						}
     				}     					
			break;
			case Type.Cylinder:
					if (IsTriggered==true)
					{
						gameObject.renderer.enabled = true;
     					gameObject.GetComponent(TextMesh).text = LoadXmlDataScript.Cylinder_Character;
     					DestroyObject(this.collider);
     					if (Input.GetKey (KeyCode.X))
						{
						LoadXmlDataScript.Value+=2;		
						}     					
     				}     					
			break;
			case Type.Capsule:
					if (IsTriggered==true)
					{
						gameObject.renderer.enabled = true;
     					gameObject.GetComponent(TextMesh).text = LoadXmlDataScript.Capsule_Character;
     					DestroyObject(this.collider);
     					if (Input.GetKey (KeyCode.C))
						{
						LoadXmlDataScript.Value+=3;			
						}
     				}     					
			break;
			case Type.Sphere:
					if (IsTriggered==true)
					{
						gameObject.renderer.enabled = true;
     					gameObject.GetComponent(TextMesh).text = LoadXmlDataScript.Sphere_Character;
     					DestroyObject(this.collider);
     					if (Input.GetKey (KeyCode.V))
						{
						LoadXmlDataScript.Value+=4;			
						}
     				}     					
			break;
			}
}
		
function OnTriggerEnter (other : Collider) 
{
	IsTriggered = true;
	LoadXmlDataScript.WaipointCounter+=1;	
}
