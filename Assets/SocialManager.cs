using UnityEngine;
using System.Collections;

public class SocialManager : MonoBehaviour 
{
	private ISocialUser _CurrentUser = null;
	public enum _Mode {OD, VK, FB};
	public _Mode SocialNetwork;

	void Start () 
	{
		switch (SocialNetwork)
        {
            case _Mode.OD:
				gameObject.AddComponent ("ODUser");
				_CurrentUser = gameObject.GetComponent<ODUser>() as ISocialUser;
				_CurrentUser.MakePurchase("Лимонад", "Класс", "777", 1);
            break;

            default:

            break;
        }		
	}
	
	ISocialUser GetSocialUser()
	{
		return _CurrentUser;
	}

}
