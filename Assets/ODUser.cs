using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;
using System;

public class ODUser : OdnoklassnikiWebplayerAPI, ISocialUser 
{
	// Constants:
	private const string _Prefix = "od";
	private const string _Currency = "ok";
	private const string _PaymentVerification = "true";

	private const string _FirstNameField 	= "first_name";
	private const string _LastNameField 	= "last_name";
	private const string _UIDField 			= "uid";
	private const string _SmallUserPicURL 	= "pic_1";
	private const string _MiddleUserPicURL 	= "pic_2";
	private const string _BigUserPicURL 	= "pic_4";
	private const string _BirthdayField 	= "birthday";
	private const string _GenderField 		= "gender";
	private const string _LocationField 	= "location"; 	

	// Fields:
	private string _UserID = "";   	
   	private string _UserName = "";
   	private string _UserLastName = "";
	private string _UserGender = "";
	private string _UserLocation = "";
	private string _UserBirthDay = "";
   	private string _SmallUserPhotoURL = "";
   	private string _MiddleUserPhotoURL = "";
   	private string _BigUserPhotoURL = "";
	private List<ISocialFriend> _Friends = null;
	private List<ISocialFriend> _AppFriends = null;

   	//Propertys:
	public string UserID 					{ get { return _UserID; 			} }
	public string UserName 					{ get { return _UserName; 			} }
	public string UserLastName 				{ get { return _UserLastName; 		} }
	public string UserGender 				{ get { return _UserGender; 		} }
	public string UserLocation 				{ get { return _UserLocation; 		} }
	public string UserBirthDay 				{ get { return _UserBirthDay; 		} }	
	public string SmallUserPhotoURL 		{ get { return _SmallUserPhotoURL; 	} }
	public string MiddleUserPhotoURL 		{ get { return _MiddleUserPhotoURL; } }
	public string BigUserPhotoURL 			{ get { return _BigUserPhotoURL; 	} }
	public string InternalUserID 			{ get { return _Prefix + _UserID; 	} }
	public List<ISocialFriend> Friends 		{ get { return _Friends; 			} }
	public List<ISocialFriend> AppFriends 	{ get { return _AppFriends; 		} }


	void Start () {
		#if UNITY_WEBPLAYER
			base.GetUserInfo();
			base.GetUserFriends();
		#endif
	}
	

	protected override void APIMethodCallback(string param)
	{
		#if UNITY_WEBPLAYER
			Dictionary<string, object> dict = Json.Deserialize(param) as Dictionary<string,object>;
			_UserName = dict[_FirstNameField] as string;
			_UserLastName = dict[_LastNameField] as string;
			_UserID = dict[_UIDField] as string;
   			_SmallUserPhotoURL = dict[_SmallUserPicURL] as string;
   			_MiddleUserPhotoURL = dict[_MiddleUserPicURL] as string;
   			_BigUserPhotoURL = dict[_BigUserPicURL] as string;
   			_UserBirthDay = dict[_BirthdayField] as string;
   			_UserLocation = dict[_LocationField] as string;
   			_UserGender = dict[_GenderField] as string;
		#endif
	}

	//NOTE: max length of ImgURL - 64 symbols
	public void PublishToStream(string Title, string Message, string ImgURL)
	{
		Dictionary<string, string> attachment = new Dictionary<string, string>()
		{
			{"src", ImgURL}, {"type", "image"}
		};

		Dictionary<string, object> media = new Dictionary<string, object>()
		{
			{"media", new List<object>(){ attachment } }
		};
		this.Publish(Title, Message, Json.Serialize(media), null);
	}

	public void MakePurchase(string name, string description, string code, int price)
	{
		base.JSshowPayment(name, description, code, price, null, null, _Currency, _PaymentVerification);
	}

	protected override void OnGetAppUserFriends(string param)
	{
		_AppFriends = new List<ISocialFriend>();
		List< string > Friends = Json.Deserialize(param) as List< string >;
		for(int i = 0; i < _Friends.Count; i++)
		{
			ISocialFriend Friend = _Friends[i] as ISocialFriend;
			if(Friends.Contains(Friend.UserID))
			{
				_AppFriends.Add(Friend);
			}
		}
	}

	protected override void OnGetUserFriendsData(string param){
		_Friends = new List<ISocialFriend>();
		List< object > Friends = Json.Deserialize(param) as List< object >;
		for(int i = 0; i < Friends.Count; i++)
		{
			Dictionary<string, object> Friend = Friends[i] as Dictionary<string, object>;
			ODFriend LocODFriend = new ODFriend(Friend[_UIDField] as string,
											Friend[_FirstNameField] as string,
											Friend[_LastNameField]  as string,
											Friend[_SmallUserPicURL]  as string,
											Friend[_MiddleUserPicURL]  as string,
											Friend[_BigUserPicURL] as string);
           _Friends.Add(LocODFriend);
		}
		//only after _Friends is full
		base.GetAppFriends();
	}

	protected override void GetFriendsCallBack(string param){
		base.GetFriendData(param);
	}

	protected void trace(string msg)
	{
		#if UNITY_WEBPLAYER
			base.LogToConsole ("[unity trace] : " + msg);
		#endif
		Debug.Log("[trace] " + msg.ToString() , this);
	}

}
