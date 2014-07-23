using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using MiniJSON;

public class OdnoklassnikiWebplayerAPI : MonoBehaviour {
	
	#if UNITY_WEBPLAYER
	protected void CallApiMethodObj(Dictionary<string,object> parameters){
		Application.ExternalCall( "OKAPIWrapper.unity_api_call",  Json.Serialize(parameters));
	}

	protected void CallApiMethodStr(Dictionary<string,string> parameters){
		Application.ExternalCall( "OKAPIWrapper.unity_api_call",  Json.Serialize(parameters));
	}

	protected virtual void APIMethodCallback(string param){
		this.LogToConsole ("API METHOD CALLBACK FROM UNITY: " + param);		
	}

	protected void JSgetPageInfo(){
		Application.ExternalCall ("FAPI.UI.getPageInfo");
	}

	protected void JSscrollToTop(){
		Application.ExternalCall ("FAPI.UI.scrollToTop");
	}

	protected void JSsetWindowSize(int width, int height){
		Application.ExternalCall ("FAPI.UI.setWindowSize", width, height);
	}

	protected void JSshowInvite(string text,string parameters, string selected_uids){
		Application.ExternalCall ("FAPI.UI.showInvite", text, parameters, selected_uids);
	}

	protected void JSshowNotification(string text,string parameters, string selected_uids){
		Application.ExternalCall ("FAPI.UI.showNotification", text, parameters, selected_uids);
	}

	// TODO uiConf (now not supported)
	protected void JSshowPayment(string name, string description, string code, int price, string options, string attributes, string currency, string callback){
		Application.ExternalCall ("FAPI.UI.showPayment", name, description, code, price, options, attributes, currency, callback);
	}

	protected void JSshowPermissions(List<string> permissions){
		StringBuilder builder = new StringBuilder ();
		builder.Append("[");
		foreach (string permission in permissions) {
			builder.Append("\"").Append(permission).Append("\",");
		}
		builder.Replace (",", "]", builder.Length - 1, 1);
		Application.ExternalCall ("FAPI.UI.showPermissions", builder.ToString());
	}

	protected virtual void JSMethodCallback(string param){
		this.LogToConsole ("JS METHOD CALLBACK FROM UNITY: " + param);	
	}

	protected void GetUrlVars(){
		Application.ExternalCall ("getUrlVars");
	}

	protected virtual void GetUrlVarsCallback(string param){
		this.LogToConsole ("GETVARS CALLBACK FROM UNITY: " + param);	
	}

	protected void Publish(string description, string message, string JSONAttachment, string JSONActionLinks){
		Application.ExternalCall ("publish", description, message, JSONAttachment, JSONActionLinks);
	}

	protected virtual void PublishCallback(string param){
		this.LogToConsole ("PUBLISH CALLBACK FROM UNITY: " + param);	
	}

	public virtual void PurchaseCallBack(string param)
	{
		this.LogToConsole ("PAYMENT CALLBACK FROM UNITY: " + param);
	}

	protected void LogToConsole(string param){
		Application.ExternalCall("console.log", param);
	}

	protected void GetUserFriends(){
		Dictionary<string,string> p = new Dictionary<string,string>()
		{
			{"method", "friends.get"}
		};
		CallApiMethodStr(p);
	}	

	protected virtual void GetFriendsCallBack(string param){
		this.LogToConsole ("[unity]: ovveride me! GetFriendsCallBack : " + param);
	}
	

	protected virtual void GetFriendData(string uids){
		
		Dictionary<string,object> p = new Dictionary<string,object>()
		{
			{"method", "users.getInfo"},
			{"fields", "first_name, last_name, pic_1, pic_2, pic_4"},
			{"uids", Json.Deserialize(uids)}
		};

		CallApiMethodObj(p);
	}

	protected virtual void OnGetUserFriendsData(string param)
	{
		this.LogToConsole ("[unity]: ovveride me! OnGetUserFriendsData : " + param);
	}

	protected virtual void GetUserInfo()
	{
		Dictionary<string, string> p = new Dictionary<string, string>()
		{
			{"method", "users.getCurrentUser"},
			{"fields", "last_name, first_name, gender, location, birthday, pic_4, pic_1, pic_2"}
		};
		CallApiMethodStr(p);
	}

	#endif
}