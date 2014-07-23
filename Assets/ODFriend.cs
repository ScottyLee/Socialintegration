using UnityEngine;
using System.Collections;

public class ODFriend : ISocialFriend
{
	private string _UserID = "";
	private string _UserName = "";
	private string _UserLastName = "";
	private string _SmallUserPhotoURL = "";
	private string _MiddleUserPhotoURL = "";
	private string _BigUserPhotoURL = "";

	public string UserID 					{ get { return _UserID; 			} }
	public string UserName 					{ get { return _UserName; 			} }
	public string UserLastName 				{ get { return _UserLastName;		} }
	public string SmallUserPhotoURL 		{ get { return _SmallUserPhotoURL;  } }
	public string MiddleUserPhotoURL 		{ get { return _MiddleUserPhotoURL;	} }
	public string BigUserPhotoURL 			{ get { return _BigUserPhotoURL; 	} }

	public ODFriend(string uid, string name, string lname, string sup, string mup, string bup)
	{
		_UserID = uid;
		_UserName = name;
		_UserLastName = lname;
		_SmallUserPhotoURL = sup;
		_MiddleUserPhotoURL = mup;
		_BigUserPhotoURL = bup;
	}
}
